Imports System.IO.Ports

Public Class attendance
    Private q As New queries
    Private p As New dgvPaging
    Private dtSource As DataTable
    Private f As New functions

    Private WithEvents timers As New Timer
    Dim comPort As String = ""
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    '##
    Public Property isConnected As Boolean = False  'check if connected to arduino
    Public Property notConnected As Boolean = False
    Public Property connectCounter As Integer = 0       'allow manual type after 5 attempts

    Public Property activateOnce = False        'activated event
    '##
    Private Sub attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtId.Select()
        txtId.Focus()
        txtId.Focus()

        'fetch cut off time
        q.attendanceDisplayCutOff()

        getComPort()

        lblTime.Text = ""
        timers.Interval = 1500   'tick every second
        timers.Start()

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

    'receive text from serial port
    Private Sub ReceivedText(ByVal [text] As String)
        If Me.txtId.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            'clear first
            Me.txtId.Text = ""
            f.Delay(0.1)
            Me.txtId.Text &= [text]
        End If
    End Sub

    'load morning
    Sub loadMorning()
        q.attendanceDGVMorning(dgvData)

        dgvData.ClearSelection()
        'for adjusting data to display
        dtSource = q.SQL.DBDT
        p.fillDgv("10", dtSource)
        p.LoadPage(dtSource, dgvData, "10")
    End Sub

    'load afternoon
    Sub loadAfternoon()
        q.attendanceDGVAfternoon(dgvData)

        dgvData.ClearSelection()
        'for adjusting data to display
        dtSource = q.SQL.DBDT
        p.fillDgv("10", dtSource)
        p.LoadPage(dtSource, dgvData, "10")
        '--
    End Sub

    Private Sub attendance_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub dgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvData.CellFormatting
        Me.dgvData.RowsDefaultCellStyle.BackColor = Color.White
        Me.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
    End Sub

    Private Sub dgvData_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvData.DataBindingComplete
        dgvData.ClearSelection()
    End Sub

    Private Sub timers_Tick(sender As Object, e As EventArgs) Handles timers.Tick
        lblTime.Text = Format$(Now, "hh:mm:ss tt")

        Dim timenow As DateTime = Convert.ToDateTime(lblTime.Text)

        Dim inAM As DateTime = Convert.ToDateTime(lblin.Text)
        Dim lunch As DateTime = Convert.ToDateTime(lblbreak.Text)
        Dim inPM As DateTime = Convert.ToDateTime(lblinPM.Text)
        Dim out As DateTime = Convert.ToDateTime(lblOut.Text)

        loadAfternoon()

        Dim id = txtId.Text.Trim
        If id <> "" Then
            'when earlier than time in in morning; allow scan; credit time is time in cut off
            If timenow < inAM Then
                q.attendanceInEarly(id, timenow, inAM)
                txtId.Text = ""
            End If

            'time in actual time
            If timenow > inAM And timenow < lunch Then
                q.attendanceTimeInActual(id, timenow)
                txtId.Text = ""
            End If

            'lunch break; actual lunch break; lunch out or half day falls here
            If timenow > lunch And timenow < inPM Then
                q.attendanceLunchScan(id, timenow)
                txtId.Text = ""
            End If

            'lunch out greater than time in afternoon; half day too; early out too
            If timenow > inPM And timenow < out Then
                q.attendanceExceedAndHalf(id, timenow, lunch)
                txtId.Text = ""
            End If

            If timenow > out Then
                q.attendanceScanOut(id, timenow)
                txtId.Text = ""
            End If
        End If

    End Sub

    Private Sub attendance_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sendSerialExit()
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

    '##
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
            sp.Write("b")
        End If
    End Sub

    'send serial to exit function
    Public Sub sendSerialExit()
        If comPort <> "" Then
            sp.Write("e")
        End If
    End Sub

    Private Sub conn(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.txtId.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf conn)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.txtCon.Text = ""
            f.Delay(0.1)
            Me.txtCon.Text &= [text]
        End If
    End Sub

    'sub check if connected to arduino
    Sub connectArd()
        Me.Enabled = False
        f.Delay(0.5)
        comLoading.Show()
    End Sub
    '##

    Private Sub attendance_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If activateOnce = False Then
            connectArd()
        End If
    End Sub

    Private Sub attendance_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        timers.Stop()

        If sp.IsOpen = True Then
            sp.Close()
        End If
    End Sub


End Class