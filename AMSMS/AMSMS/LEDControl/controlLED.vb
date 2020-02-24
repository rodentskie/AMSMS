Imports System.IO.Ports

Public Class controlLED
    Private q As New queries
    Private f As New functions

    '#
    Dim comPort As String = ""
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Public Property isConnected As Boolean = False  'check if connected to arduino
    Public Property notConnected As Boolean = False
    Public Property connectCounter As Integer = 0       'allow manual type after 5 attempts

    Public Property activateOnce = False        'activated event

    Private Sub controlLED_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'get comport
        getComPort()

        initPort()
    End Sub

    Private Sub controlLED_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub controlLED_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mainform.Enabled = True

        If sp.IsOpen = True Then
            sp.Close()
        End If
    End Sub

    Private Sub controlLED_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If activateOnce = False Then
            connectArd()
        End If
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

    'insert to db base on device
    Sub insertLogs()
        Dim s As String = txtId.Text.Trim

        If s = "a" Then
            'on vault
            q.insertLightLogs("Vault Room", "ON")
        End If

        If s = "b" Then
            'off vault
            q.insertLightLogs("Vault Room", "OFF")
        End If

        If s = "c" Then
            'on teller
            q.insertLightLogs("Teller", "ON")
        End If

        If s = "d" Then
            'off teller
            q.insertLightLogs("Teller", "OFF")
        End If


        If s = "e" Then
            'on wait area
            q.insertLightLogs("Wait Area", "ON")
        End If


        If s = "f" Then
            'off wait area
            q.insertLightLogs("Wait Area", "OFF")
        End If

        If s = "g" Then
            'on manager
            q.insertLightLogs("Manager", "ON")
        End If

        If s = "h" Then
            'off manager
            q.insertLightLogs("Manager", "OFF")
        End If

        If s = "i" Then
            'on employee
            q.insertLightLogs("Employee's Room", "ON")
        End If

        If s = "j" Then
            'off employee
            q.insertLightLogs("Employee's Room", "OFF")
        End If

        If s = "k" Then
            'on all room
            q.insertLightLogs("All Room", "ON")
        End If

        If s = "l" Then
            'off all room
            q.insertLightLogs("All Room", "OFF")
        End If
    End Sub

    Private Sub sp_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles sp.DataReceived
        If notConnected = False Then
            'establish connection
            conn(sp.ReadLine())

            establishConnection()

        Else
            ReceivedText(sp.ReadLine())

            insertLogs()
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
            sp.Write("l")
        End If
    End Sub

    'send serial to exit function
    Public Sub sendSerialExit()
        If comPort <> "" Then
            sp.Write("z")
        End If
    End Sub

    Private Sub controlLED_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sendSerialExit()
    End Sub

    Private Sub btnOnVault_Click(sender As Object, e As EventArgs) Handles btnOnVault.Click
        If comPort <> "" Then
            sp.Write("a")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnOffVault_Click(sender As Object, e As EventArgs) Handles btnOffVault.Click
        If comPort <> "" Then
            sp.Write("b")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnOnTeller_Click(sender As Object, e As EventArgs) Handles btnOnTeller.Click
        If comPort <> "" Then
            sp.Write("c")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnOffTeller_Click(sender As Object, e As EventArgs) Handles btnOffTeller.Click
        If comPort <> "" Then
            sp.Write("d")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnOnWaitArea_Click(sender As Object, e As EventArgs) Handles btnOnWaitArea.Click
        If comPort <> "" Then
            sp.Write("e")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnOffWaitArea_Click(sender As Object, e As EventArgs) Handles btnOffWaitArea.Click
        If comPort <> "" Then
            sp.Write("f")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnOnManager_Click(sender As Object, e As EventArgs) Handles btnOnManager.Click
        If comPort <> "" Then
            sp.Write("g")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnOffManager_Click(sender As Object, e As EventArgs) Handles btnOffManager.Click
        If comPort <> "" Then
            sp.Write("h")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnOnEmployees_Click(sender As Object, e As EventArgs) Handles btnOnEmployees.Click
        If comPort <> "" Then
            sp.Write("i")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnOffEmployees_Click(sender As Object, e As EventArgs) Handles btnOffEmployees.Click
        If comPort <> "" Then
            sp.Write("j")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnAllOn_Click(sender As Object, e As EventArgs) Handles btnAllOn.Click
        If comPort <> "" Then
            sp.Write("k")
            f.Delay(1)
        End If
    End Sub

    Private Sub btnAllOff_Click(sender As Object, e As EventArgs) Handles btnAllOff.Click
        If comPort <> "" Then
            sp.Write("l")
            f.Delay(1)
        End If
    End Sub
End Class