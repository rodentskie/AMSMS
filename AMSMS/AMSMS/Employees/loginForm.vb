Public Class loginForm
    Private q As New queries

    Private Sub loginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUname.Focus()
    End Sub

    Private Sub loginForm_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        login()
    End Sub

    Private Sub txtUname_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUname.KeyDown, txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            e.SuppressKeyPress = True
            login()
        End If
    End Sub

    Sub login()
        If txtUname.Text = "" Then
            MessageBox.Show("Please enter username.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtUname.Focus()
            Exit Sub
        End If
        If txtPassword.Text = "" Then
            MessageBox.Show("Please enter password.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Focus()
            Exit Sub
        End If

        'login query
        Dim bool = q.adminLogin(txtUname.Text, txtPassword.Text)

        If bool = True Then
            txtUname.Text = ""
            txtPassword.Text = ""
            txtUname.Focus()
        End If

    End Sub
End Class