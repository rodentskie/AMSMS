Public Class empLoginUpdate
    Private q As New queries
    Dim bool As Boolean = False         'check if has add or not

    Private Sub empLoginUpdate_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mainform.Enabled = True
        empLogins.Enabled = True
        empLogins.Select()
        empLogins.Focus()
        empLogins.Focus()
        If bool = True Then
            'if user has added account; reload view
            empLogins.loads()
        End If
    End Sub

    Private Sub empLoginUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Text = empLogins.username 'pass selected username
        txtPw.Select()
        txtPw.Focus()
    End Sub

    Private Sub empLoginUpdate_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown, txtRePw.KeyDown, txtPw.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            updateAccount()
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        updateAccount()
    End Sub

    Sub updateAccount()
        Dim username = txtUsername.Text
        Dim pw = txtPw.Text
        Dim rePw = txtRePw.Text

        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Please enter username.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(pw) Then
            MessageBox.Show("Please enter password.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPw.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(rePw) Then
            MessageBox.Show("Please enter re enter password.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRePw.Focus()
            Exit Sub
        End If

        If pw <> rePw Then
            MessageBox.Show("Password doesn't match, please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


        'update db
        Dim updateBool = q.empLoginUpdates(empLogins.id)
        If updateBool = True Then
            bool = True
            Me.Close()
        Else
            txtUsername.Focus()
            Exit Sub
        End If
    End Sub

End Class