Public Class adminAdd
    Private q As New queries

    Dim bool As Boolean = False         'check if has add or not
    Private Sub adminAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtUsername.Focus()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        addAccount()
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown, txtRePw.KeyDown, txtPw.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            addAccount()
        End If
    End Sub

    Sub addAccount()
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


        'insert to db
        q.adminAddAccount()
        bool = True
    End Sub

    Private Sub adminAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mainform.Enabled = True
        admin.Enabled = True
        admin.Select()
        admin.Focus()
        admin.Focus()
        If bool = True Then
            'if user has added account; reload view
            admin.loads()
        End If
    End Sub

    Private Sub adminAdd_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

End Class