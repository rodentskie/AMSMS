Imports System.IO.Ports
Imports System.Threading
Imports AxZKFPEngXControl

Public Class vaultMonitoring64
    Const WM_CAP As Short = &H400S
    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30
    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1
    Dim iDevice As Integer = 0
    Dim hHwnd As Integer
    'for 32 bit
    'Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Object) As Integer
    'for 64 bit
    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As IntPtr, ByRef RECT As IntPtr) As IntPtr
    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean
    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWndParent As Integer, ByVal nID As Integer) As Integer
    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean

    Private f As New functions
    Private q As New queries

    '914, 597

    Dim ip = f.GetIPv4Address()

    Dim filepath As String = "\\" & ip & "\vault\"

    '#for comport
    Dim comPort As String = ""
    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data

    Public Property isConnected As Boolean = False  'check if connected to arduino
    Public Property notConnected As Boolean = False
    Public Property connectCounter As Integer = 0       'allow manual type after 5 attempts

    Public Property activateOnce = False        'activated event
    '#end for com port

    '# for finger scan
    Dim WithEvents ZkFprint As New AxZKFPEngX
    Dim template As String = "" 'store template from db

    '#for com port and finger scanner
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

    'sub check if connected to arduino
    Sub connectArd()
        Me.Enabled = False
        f.Delay(0.5)
        comLoading.Show()
    End Sub

    'send serial to exit function
    Public Sub sendSerialExit()
        If comPort <> "" Then
            sp.Write("e")
        End If
    End Sub

    'send data to connect to ard
    Public Sub sendSerialData()
        If comPort <> "" Then
            sp.Write("v")
        End If
    End Sub

    'connecting to arduino
    Public Sub establishConnection()
        Dim s As String = txtconn.Text.Trim

        'to check if connected
        If s = "r" Then
            activateOnce = True
            f.Delay(0.5)
            isConnected = True
            notConnected = True
        End If

        'to check if keypad code is correct
        If s = "k" Then
            'set hardware for scanning finger
            f.Delay(2)
            sp.Write("b")
        End If

        'wrong keypad password; save image
        If s = "v" Then
            'saveImage()
            notConnected = True
        End If

        ' wrong finger scanned
        If s = "w" Then
            notConnected = True
        End If
    End Sub

    '#scanner
    'initialize scanner
    Private Sub InitialAxZkfp()
        Try
            Controls.Add(ZkFprint)
            If (ZkFprint.InitEngine = 0) Then
                ZkFprint.FPEngineVersion = "9"
                ZkFprint.EnrollCount = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Finger print scanner not detected.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    'begin enroll
    Sub beginEnroll()
        ZkFprint.CancelEnroll()
        ZkFprint.EnrollCount = 0
        ZkFprint.BeginEnroll()
    End Sub

    '# end comport and scanner

    Private Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0
        Do
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)
            'If bReturn Then lstDevices.Items.Add(strName.Trim)
            x += 1
        Loop Until bReturn = False
    End Sub

    Private Sub OpenPreviewWindow()
        Dim iHeight As Integer = picCapture.Height
        Dim iWidth As Integer = picCapture.Width
        hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, 480, picCapture.Handle.ToInt32, 0)
        If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
            SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)
            SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)
            SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)
            SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height, SWP_NOMOVE Or SWP_NOZORDER)
        Else
            DestroyWindow(hHwnd)
        End If
    End Sub

    Private Sub ClosePreviewWindow()
        SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)
        DestroyWindow(hHwnd)
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

    Private Sub vaultMonitoring64_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDeviceList()

        openCamera()

        InitialAxZkfp()
        beginEnroll()

        'get comport
        getComPort()

        initPort()
    End Sub

    Private Sub vaultMonitoring64_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Sub openCamera()
        OpenPreviewWindow()
    End Sub

    Sub stopCamera()
        ClosePreviewWindow()
    End Sub

    Sub saveImage()
        saveVidToImage()

        f.Delay(0.5)

        Try
            Dim name = DateTime.Now.ToString("yyyy-MM-dd hhmm tt")
            pbTest.Image.Save(filepath & name & ".jpg")

            f.Delay(0.5)
            pbTest.Image = Nothing
        Catch ex As Exception
            MessageBox.Show("Error saving image: " & vbNewLine & ex.Message)
        End Try
    End Sub

    Sub saveVidToImage()
        pbTest.Image = Nothing
        Dim data As IDataObject
        Dim bmap As Image
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            pbTest.Image = bmap
        End If
    End Sub

    Private Sub vaultMonitoring64_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        stopCamera()

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

            template = "" 'clear
            template = q.returnTemplate(txtId.Text)

            If template = "" Then
                ' null so not allowed to open
                ' display to LCD
                f.Delay(2)
                sp.Write("c")
            Else
                'has the template now; validate keypad; returns k if correct keypad code
                notConnected = False
                f.Delay(2)
                sp.Write("a")
            End If
        End If
    End Sub

    Private Sub ZkFprint_OnCapture(sender As Object, e As IZKFPEngXEvents_OnCaptureEvent) Handles ZkFprint.OnCapture
        Dim RegChanged As Boolean = False
        Dim sTemp As String = ZkFprint.GetTemplateAsString()

        If ZkFprint.VerFingerFromStr(template, sTemp, False, RegChanged) Then
            'save image and open vault; display LCD; send SMS
            saveImage()
            f.Delay(1)
            sp.Write("a")
            notConnected = True
        Else
            'wrong finger scan;
            saveImage()
            f.Delay(1)
            sp.Write("b")
            notConnected = True
        End If
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

    Private Sub vaultMonitoring64_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If activateOnce = False Then
            connectArd()
        End If
    End Sub

    Private Sub vaultMonitoring64_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        sendSerialExit()
    End Sub

End Class