Public Class mainform
    Private q As New queries
    Public Property id As String = ""
    Public Property user As String = ""
    Public Property role As String = ""
    '#############

    Private Sub mainform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        changebgcolor(Color.SkyBlue)
        filterView()
    End Sub

    'filter view depending on login user
    Sub filterView()
        If role.ToLower = "officer" Then
            AdminToolStripMenuItem.Visible = False
        End If
    End Sub

    'change bgcolor
    Sub changebgcolor(colors As Color)
        Dim ctl As Control
        Dim ctlMDI As MdiClient

        ' Loop through all of the form's controls looking
        ' for the control of type MdiClient.
        For Each ctl In Me.Controls
            Try
                ' Attempt to cast the control to type MdiClient.
                ctlMDI = CType(ctl, MdiClient)

                ' Set the BackColor of the MdiClient control.
                ctlMDI.BackColor = colors
                ctlMDI.BackgroundImageLayout = ImageLayout.Center

            Catch exc As InvalidCastException
                ' Catch and ignore the error if casting failed.
            End Try
        Next
    End Sub

    'close all form open when clicking new form
    Sub closeForms()
        If MdiChildren.Length > 0 Then
            For Each r As Form In Me.MdiChildren
                r.Close()
            Next
        End If
    End Sub

    Private Sub mainform_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub mainform_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub ManageAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageAccountsToolStripMenuItem.Click
        closeForms()
        admin.MdiParent = Me
        admin.Show()
    End Sub

    Private Sub ManagePositionsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ManagePositionsToolStripMenuItem1.Click
        closeForms()
        positions.MdiParent = Me
        positions.Show()
    End Sub

    Private Sub ManageEmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManageEmployeesToolStripMenuItem.Click
        closeForms()
        employees.MdiParent = Me
        employees.Show()
    End Sub

    Private Sub ManagePositionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManagePositionsToolStripMenuItem.Click
        closeForms()
        empLogins.MdiParent = Me
        empLogins.Show()
    End Sub

    Private Sub mainform_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        loginForm.Show()
        loginForm.Select()
        loginForm.Focus()
        loginForm.Focus()
        loginForm.txtUname.Select()
        loginForm.txtUname.Focus()
        loginForm.txtUname.Focus()
    End Sub

    Private Sub VaultMonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VaultMonitoringToolStripMenuItem.Click
        If Environment.Is64BitOperatingSystem Then
            closeForms()
            vaultMonitoring64.MdiParent = Me
            vaultMonitoring64.Show()
        Else
            closeForms()
            'vaultMonitoring.MdiParent = Me
            'vaultMonitoring.Show()
        End If
    End Sub

    Private Sub SetCutOffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetCutOffToolStripMenuItem.Click
        closeForms()
        attendanceCutOff.MdiParent = Me
        attendanceCutOff.Show()
    End Sub

    Private Sub MonitoringToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonitoringToolStripMenuItem.Click
        closeForms()
        attendance.MdiParent = Me
        attendance.Show()
    End Sub

    Private Sub PayrollToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayrollToolStripMenuItem.Click
        closeForms()
        payrolls.MdiParent = Me
        payrolls.Show()
    End Sub

    Private Sub SetGSMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SetGSMToolStripMenuItem.Click
        closeForms()
        setGSM.MdiParent = Me
        setGSM.Show()
    End Sub
End Class