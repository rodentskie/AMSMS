Public Class mainform
    Private q As New queries
    Public Property id As String = ""
    Public Property user As String = ""

    '#############

    Private Sub mainform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        changebgcolor(Color.SkyBlue)
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

End Class