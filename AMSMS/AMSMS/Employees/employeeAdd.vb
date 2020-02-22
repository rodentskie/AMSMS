Imports System.IO.Ports
Imports AxZKFPEngXControl

Public Class employeeAdd
    Private q As New queries
    Dim bool As Boolean = False         'check if has add or not

    Public Property template As String = ""            'store finger print template
    Public Property positionId As String = ""   'store position id from cbx

    'finger print module
    Dim WithEvents ZkFprint As New AxZKFPEngX
    Private f As New functions

    '#for comport
    Dim comPort As String = ""
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Public Property isConnected As Boolean = False  'check if connected to arduino
    Public Property notConnected As Boolean = False
    Public Property connectCounter As Integer = 0       'allow manual type after 5 attempts

    Public Property activateOnce = False        'activated event

    Private Sub employeeAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mainform.Enabled = True
        employees.Enabled = True
        employees.Select()
        employees.Focus()
        employees.Focus()
        If bool = True Then
            'if user has added account; reload view
            employees.loads()
        End If

        If sp.IsOpen = True Then
            sp.Close()
        End If
    End Sub

    Private Sub employeeAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxGender.SelectedIndex = 0
        lblGuide.Text = ""
        'load cbx positions
        q.positionLoadCbx(cbxPositions)

        'adjust drop down height
        cbxPositions.DropDownHeight = cbxPositions.ItemHeight * 8


        InitialAxZkfp()
        beginEnroll()

        'get comport
        getComPort()

        initPort()

    End Sub

    Sub getComPort()
        Dim portArray As New ArrayList
        portArray = q.getSerialPorts()

        'absolutely one com port on this device only
        'if multiple com port; it may not work properly

        For Each p As String In portArray
            comPort = p
        Next
    End Sub

    'init com port
    Sub initPort()
        If comPort <> "" Then
            sp.PortName = comPort
            sp.BaudRate = 9600

            sp.Parity = IO.Ports.Parity.None
            sp.StopBits = IO.Ports.StopBits.One
            sp.DataBits = 8
            sp.Open()
        End If
    End Sub

    'initialize scanner
    Private Sub InitialAxZkfp()
        Try
            Controls.Add(ZkFprint)
            If (ZkFprint.InitEngine = 0) Then
                ZkFprint.FPEngineVersion = "9"
                ZkFprint.EnrollCount = 3
            End If
        Catch ex As Exception
            MessageBox.Show("Finger print scanner not detected.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'begin enroll
    Sub beginEnroll()
        ZkFprint.CancelEnroll()
        ZkFprint.EnrollCount = 3
        ZkFprint.BeginEnroll()
    End Sub

    'sub check if connected to arduino
    Sub connectArd()
        Me.Enabled = False
        f.Delay(0.5)
        comLoading.Show()
    End Sub

    Private Sub employeeAdd_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        addEmployee()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        fpicture.Image = Nothing
        template = ""

        beginEnroll()
    End Sub

    Sub addEmployee()
        If String.IsNullOrWhiteSpace(txtId.Text) Then
            MessageBox.Show("Please employee's ID.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtId.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtFn.Text) Then
            MessageBox.Show("Please employee's first name.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFn.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtMn.Text) Then
            MessageBox.Show("Please employee's middle name.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtMn.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtLn.Text) Then
            MessageBox.Show("Please employee's last name.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLn.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(txtAddress.Text) Then
            MessageBox.Show("Please employee's address.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAddress.Focus()
            Exit Sub
        End If

        If fpicture.Image IsNot Nothing Then
            If template = "" Then
                MessageBox.Show("Please complete all 3 scans.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        End If

        'insert to db
        q.employeesAdd()
        bool = True
    End Sub

    Private Sub cbxPositions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPositions.SelectedIndexChanged
        positionId = q.positionGetId(cbxPositions.Text)
    End Sub

    Private Sub ZkFprint_OnImageReceived(sender As Object, e As IZKFPEngXEvents_OnImageReceivedEvent) Handles ZkFprint.OnImageReceived
        Dim g As Graphics = fpicture.CreateGraphics
        Dim bmp As Bitmap = New Bitmap(fpicture.Width, fpicture.Height)
        g = Graphics.FromImage(bmp)
        Dim dc As Integer = g.GetHdc.ToInt32
        ZkFprint.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height)
        g.Dispose()
        fpicture.Image = bmp
    End Sub

    Private Sub ZkFprint_OnEnroll(sender As Object, e As IZKFPEngXEvents_OnEnrollEvent) Handles ZkFprint.OnEnroll
        If e.actionResult Then
            Dim scan As String = ZkFprint.EncodeTemplate1(e.aTemplate)
            template = scan
        Else
            MessageBox.Show("Something went wrong, please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
    End Sub

    Private Sub ZkFprint_OnFeatureInfo(sender As Object, e As IZKFPEngXEvents_OnFeatureInfoEvent) Handles ZkFprint.OnFeatureInfo
        Dim strTemp As String = String.Empty
        If (ZkFprint.EnrollIndex <> 1) Then
            If ZkFprint.IsRegister Then
                If ((ZkFprint.EnrollIndex - 1) _
                            > 0) Then
                    Dim eindex As Integer = (ZkFprint.EnrollIndex - 1)
                    strTemp = ("Please scan again .. " + eindex.ToString())
                End If

            End If

        End If

        ShowHintInfo(strTemp)
    End Sub

    Private Sub ShowHintInfo(ByVal s As String)
        lblGuide.Text = s
    End Sub

    Private Sub sp_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles sp.DataReceived
        If notConnected = False Then
            'establish connection
            conn(sp.ReadLine())

            establishConnection()

        Else
            ReceivedText(sp.ReadLine())
        End If
    End Sub

    Private Sub ReceivedText(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.txtId.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.txtId.Text &= [text]
        End If
    End Sub

    Private Sub conn(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.txtCon.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf conn)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.txtCon.Text = ""
            f.Delay(0.1)
            Me.txtCon.Text &= [text]
        End If
    End Sub

    Private Sub lblClear_Click(sender As Object, e As EventArgs) Handles lblClear.Click
        txtId.Text = ""
    End Sub

    'connecting to arduino
    Public Sub establishConnection()
        Dim s As String = txtCon.Text.Trim
        If s = "r" Then
            activateOnce = True
            f.Delay(0.5)
            isConnected = True
            notConnected = True
        End If
    End Sub

    'send data to connect to ard
    Public Sub sendSerialData()
        If comPort <> "" Then
            sp.Write("a")
        End If
    End Sub

    Private Sub employeeAdd_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If activateOnce = False Then
            connectArd()
        End If
    End Sub

    Private Sub txtContact_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContact.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8)
    End Sub

    Private Sub employeeAdd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sendSerialExit()
    End Sub

    'send serial to exit function
    Public Sub sendSerialExit()
        If comPort <> "" Then
            sp.Write("e")
        End If
    End Sub

End Class