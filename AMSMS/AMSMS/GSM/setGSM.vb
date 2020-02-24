Imports System.IO.Ports

Public Class setGSM
    Private q As New queries
    Private f As New functions

    '#
    Dim comPort As String = ""
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Public Property isConnected As Boolean = False  'check if connected to arduino
    Public Property notConnected As Boolean = False
    Public Property connectCounter As Integer = 0       'allow manual type after 5 attempts

    Public Property activateOnce = False        'activated event

    '# check if receive by arduino
    Public Property bfp = False
    Public Property manager = False
    Dim counter = 0

    Private Sub setGSM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtManager.Text = q.returnManager()

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

    'sub check if connected to arduino
    Sub connectArd()
        Me.Enabled = False
        f.Delay(0.5)
        comLoading.Show()
    End Sub


    Private Sub ReceivedText(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.txtId.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.txtId.Text = ""
            f.Delay(0.1)
            Me.txtId.Text &= [text]
        End If
    End Sub

    Private Sub conn(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.txtconn.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf conn)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.txtconn.Text = ""
            f.Delay(0.1)
            Me.txtconn.Text &= [text]
        End If
    End Sub

    Private Sub btnSet_Click(sender As Object, e As EventArgs) Handles btnSet.Click
        sendNumber()
    End Sub

    Private Sub setGSM_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub setGSM_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mainform.Enabled = True

        If sp.IsOpen = True Then
            sp.Close()
        End If
    End Sub

    Private Sub sp_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles sp.DataReceived
        If notConnected = False Then
            'establish connection
            conn(sp.ReadLine())

            establishConnection()

        Else
            ReceivedText(sp.ReadLine())

            checkIfReceived()
        End If
    End Sub

    'check if received by arduino
    Sub checkIfReceived()
        Dim s As String = txtId.Text.Trim
        counter += 1

        If s = "q" Then
            manager = True
        End If

        If s = "w" Then
            bfp = True
        End If

        If counter = 2 Then
            If bfp = True And manager = True Then
                MessageBox.Show("Set GSM number successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                MessageBox.Show("Something went wrong, please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
    End Sub

    'connecting to arduino
    Public Sub establishConnection()
        Dim s As String = txtconn.Text.Trim
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
            sp.Write("g")
        End If
    End Sub

    'send serial to exit function
    Public Sub sendSerialExit()
        If comPort <> "" Then
            sp.Write("e")
        End If
    End Sub

    Private Sub setGSM_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If activateOnce = False Then
            connectArd()
        End If
    End Sub

    Private Sub setGSM_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sendSerialExit()
    End Sub

    'send to serial gsm
    Sub sendNumber()
        Me.Cursor = Cursors.WaitCursor

        If txtManager.Text = "" Then
            MessageBox.Show("Please enter the number of manager.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If txtBFP.Text = "" Then
            MessageBox.Show("Please enter the number of BFP.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        sp.Write("a")
        f.Delay(1)
        sp.Write(txtManager.Text.ToString())
        f.Delay(2)
        sp.Write("b")
        f.Delay(1)
        sp.Write(txtBFP.Text.ToString())
        f.Delay(2)

        Me.Cursor = Cursors.Default
    End Sub

End Class