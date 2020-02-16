Imports System.IO
Public Class queries
    Public SQL As New SQLControl
    Private f As New functions


    'admin login
    Public Function adminLogin(username As String, password As String)
        Dim bool As Boolean = False
        Dim int As Integer = 0

        SQL.AddParam("@uname", username)
        SQL.AddParam("@pw", f.GetHash(password))

        SQL.ExecQueryDT("SELECT * FROM admin_logins WHERE username = @uname AND password = @pw;")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            'successful login
            bool = True

            If (f.IsFormOpen(loginForm)) Then
                MessageBox.Show("Login successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                mainform.Show()
                loginForm.Close()
            End If
        Else
            'invalid account
            bool = False
            MessageBox.Show("Invalid account, please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        Return bool
    End Function

    'display admin accounts
    Public Sub adminLoadAccounts(dgv As DataGridView, filter As String)
        If filter <> "" Then
            SQL.AddParam("@filter", "%" & filter & "%")
            SQL.ExecQueryDT("SELECT * FROM admin_logins WHERE username LIKE @filter;")
        Else
            SQL.ExecQueryDT("SELECT * FROM admin_logins;")
        End If

        If SQL.HasException(True) Then Exit Sub
        dgv.AllowUserToResizeColumns = False
        dgv.AllowUserToResizeRows = False
        dgv.AllowUserToAddRows = False
        dgv.DataSource = SQL.DBDT
        dgv.ClearSelection()
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        '##########
        dgv.Columns(0).Visible = False
        dgv.Columns(1).HeaderText = "USERNAME"
        dgv.Columns(2).HeaderText = "HASH PASSWORD"
        dgv.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.RowTemplate.Height = 30
    End Sub

    'add admin account
    Public Sub adminAddAccount()
        'check if username exists
        SQL.AddParam("@uname", adminAdd.txtUsername.Text)
        SQL.ExecQueryDT("SELECT * FROM admin_logins WHERE LOWER(username) = @uname;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            'username exists
            MessageBox.Show("Username already exist. Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'insert to db
        SQL.AddParam("@uname", adminAdd.txtUsername.Text)
        SQL.AddParam("@hash", f.GetHash(adminAdd.txtPw.Text))
        SQL.ExecQueryDT("INSERT INTO admin_logins (username,password) VALUES (@uname,@hash);")
        If SQL.HasException(True) Then Exit Sub
        MessageBox.Show("Account added successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        adminAdd.txtUsername.Text = ""
        adminAdd.txtPw.Text = ""
        adminAdd.txtRePw.Text = ""
        Exit Sub
    End Sub

    'update admin account
    Public Sub adminUpdateAccount(id As String)
        'check if username exists
        SQL.AddParam("@id", id)
        SQL.AddParam("@uname", adminEdit.txtUsername.Text)
        SQL.ExecQueryDT("SELECT * FROM admin_logins WHERE LOWER(username) = @uname AND id <> @id;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            'username exists
            MessageBox.Show("Username already exist. Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'update to db
        SQL.AddParam("@id", id)
        SQL.AddParam("@uname", adminEdit.txtUsername.Text)
        SQL.AddParam("@hash", f.GetHash(adminEdit.txtPw.Text))
        SQL.ExecQueryDT("UPDATE admin_logins SET username=@uname, password=@hash WHERE id=@id;")
        If SQL.HasException(True) Then Exit Sub
        MessageBox.Show("Account updated successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        adminEdit.txtUsername.Text = ""
        adminEdit.txtPw.Text = ""
        adminEdit.txtRePw.Text = ""
        Exit Sub
    End Sub

End Class
