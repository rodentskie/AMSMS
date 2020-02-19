Imports AxZKFPEngXControl
Public Class employeeUpdate
    Private q As New queries
    Dim bool As Boolean = False         'check if has update or not

    Public Property template As String = ""            'store finger print template
    Public Property positionId As String = ""   'store position id from cbx

    'finger print module
    Dim WithEvents ZkFprint As New AxZKFPEngX
    Private f As New functions

    Private Sub employeeUpdate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mainform.Enabled = True
        employees.Enabled = True
        employees.Select()
        employees.Focus()
        employees.Focus()
        If bool = True Then
            'if user has added account; reload view
            employees.loads()
        End If
    End Sub

    Private Sub employeeUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxGender.SelectedIndex = 0
        lblGuide.Text = ""
        'load cbx positions
        q.positionLoadCbx(cbxPositions)

        'adjust drop down height
        cbxPositions.DropDownHeight = cbxPositions.ItemHeight * 8


        InitialAxZkfp()
        beginEnroll()

        'fetch data from single employee
        q.employeeSelectOne(employees.id)
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

    Private Sub employeeUpdate_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        fpicture.Image = Nothing
        template = ""

        beginEnroll()
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


    Sub updateEmployee()
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

        'update to db
        Dim updateBool = q.employeeSaveUpdate(employees.id)
        If updateBool = True Then
            bool = True
            Me.Close()
        End If

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        updateEmployee()
    End Sub

End Class