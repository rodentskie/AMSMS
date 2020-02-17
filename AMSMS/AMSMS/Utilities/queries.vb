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
        dgv.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
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
    Public Function adminUpdateAccount(id As String)
        Dim bool = False

        'check if username exists
        SQL.AddParam("@id", id)
        SQL.AddParam("@uname", adminEdit.txtUsername.Text)
        SQL.ExecQueryDT("SELECT * FROM admin_logins WHERE LOWER(username) = @uname AND id <> @id;")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            'username exists
            MessageBox.Show("Username already exist. Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bool
        End If

        'update to db
        SQL.AddParam("@id", id)
        SQL.AddParam("@uname", adminEdit.txtUsername.Text)
        SQL.AddParam("@hash", f.GetHash(adminEdit.txtPw.Text))
        SQL.ExecQueryDT("UPDATE admin_logins SET username=@uname, password=@hash WHERE id=@id;")
        If SQL.HasException(True) Then Return Nothing
        MessageBox.Show("Account updated successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        adminEdit.txtUsername.Text = ""
        adminEdit.txtPw.Text = ""
        adminEdit.txtRePw.Text = ""
        bool = True

        Return bool
    End Function

    '## positions
    'display positions

    Public Sub positionsLoadDgv(dgv As DataGridView, filter As String)
        If filter <> "" Then
            SQL.AddParam("@filter", "%" & filter & "%")
            SQL.ExecQueryDT("SELECT * FROM positions WHERE position_name LIKE @filter;")
        Else
            SQL.ExecQueryDT("SELECT * FROM positions;")
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
        dgv.Columns(1).HeaderText = "POSITION"
        dgv.Columns(2).HeaderText = "RATE"
        dgv.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(2).DefaultCellStyle.Format = "C" 'make it to currency $
        dgv.Columns(2).DefaultCellStyle.FormatProvider = Globalization.CultureInfo.GetCultureInfo("en-PH") 'convert to peso sign
        dgv.RowTemplate.Height = 30
    End Sub

    'add position
    Public Sub positionAdds()
        'check if exist
        SQL.AddParam("@pos", positionAdd.txtPosition.Text)
        SQL.ExecQueryDT("SELECT * FROM positions WHERE LOWER(position_name) = @pos;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            'position exists
            MessageBox.Show("Position already exist. Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'insert to db
        SQL.AddParam("@pos", positionAdd.txtPosition.Text)
        SQL.AddParam("@rate", positionAdd.txtRate.Text)
        SQL.ExecQueryDT("INSERT INTO positions (position_name,rate) VALUES (@pos,@rate);")
        If SQL.HasException(True) Then Exit Sub
        MessageBox.Show("Position added successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        positionAdd.txtPosition.Text = ""
        positionAdd.txtRate.Text = ""
        Exit Sub
    End Sub

    'update position
    Public Function positionUpdate(id As String)
        Dim bool = False

        'check if exist
        SQL.AddParam("@id", id)
        SQL.AddParam("@pos", positionEdit.txtPosition.Text)
        SQL.ExecQueryDT("SELECT * FROM positions WHERE LOWER(position_name) = @pos AND id <> @id;")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            'position exists
            MessageBox.Show("Position already exist. Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bool
        End If

        'update db
        SQL.AddParam("@id", id)
        SQL.AddParam("@pos", positionEdit.txtPosition.Text)
        SQL.AddParam("@rate", positionEdit.txtRate.Text)
        SQL.ExecQueryDT("UPDATE positions SET position_name=@pos, rate=@rate WHERE id=@id;")
        If SQL.HasException(True) Then Return Nothing
        MessageBox.Show("Position updated successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        positionEdit.txtPosition.Text = ""
        positionEdit.txtRate.Text = ""
        bool = True

        Return bool
    End Function

    'load cbx of positions
    Public Sub positionLoadCbx(cbx As ComboBox)
        cbx.Items.Clear()
        SQL.ExecQueryDS("SELECT DISTINCT position_name FROM positions;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDS > 0 Then
            For Each r As DataRow In SQL.DBDS.Tables(0).Rows
                cbx.Items.Add(r("position_name"))
            Next
            cbx.SelectedIndex = 0
        End If
    End Sub

    'get position id 
    Public Function positionGetId(position As String)
        Dim id As String = ""

        '######

        SQL.AddParam("@pos", position)

        SQL.ExecQueryDT("SELECT id FROM positions WHERE LOWER(position_name) = LOWER(@pos);")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                id = r(0)
            Next
        End If
        Return id

    End Function


    '## employees
    'display all employees

    Public Sub employeesLoadDgv(dgv As DataGridView, filter As String)
        If filter <> "" Then
            SQL.AddParam("@filter", "%" & filter & "%")
            SQL.ExecQueryDT("
                SELECT employee_id, CONCAT(lname,', ',fname) name,gender,contact_num,position_name
                FROM employees e LEFT JOIN positions p ON p.id = e.position
                WHERE employee_id LIKE @filter OR CONCAT(lname,', ',fname) LIKE @filter;
            ")
        Else
            SQL.ExecQueryDT("
               SELECT employee_id, CONCAT(lname,', ',fname) name,gender,contact_num,position_name
               FROM employees e LEFT JOIN positions p ON p.id = e.position;
            ")
        End If

        If SQL.HasException(True) Then Exit Sub
        dgv.AllowUserToResizeColumns = False
        dgv.AllowUserToResizeRows = False
        dgv.AllowUserToAddRows = False
        dgv.DataSource = SQL.DBDT
        dgv.ClearSelection()
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        '##########
        'dgv.Columns(0).Visible = False
        dgv.Columns(0).HeaderText = "EMPLOYEE ID"
        dgv.Columns(1).HeaderText = "NAME"
        dgv.Columns(2).HeaderText = "GENDER"
        dgv.Columns(3).HeaderText = "CONTACT NUMBER"
        dgv.Columns(4).HeaderText = "POSITION"
        dgv.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.RowTemplate.Height = 30
    End Sub

    'add employee
    Public Sub employeesAdd()
        'check if employee id exist
        SQL.AddParam("@id", employeeAdd.txtId.Text)
        SQL.ExecQueryDT("SELECT employee_id FROM employees WHERE LOWER(employee_id) = LOWER(@id);")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            MessageBox.Show("Employee ID already exist. Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'check if employee is registered
        SQL.AddParam("@fn", employeeAdd.txtFn.Text)
        SQL.AddParam("@ln", employeeAdd.txtLn.Text)
        SQL.ExecQueryDT("
            SELECT * FROM employees WHERE LOWER(fname) = LOWER(@fn)
            AND LOWER(lname) = LOWER(@ln);
        ")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            MessageBox.Show("Employee already exist. Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        SQL.AddParam("@id", employeeAdd.txtId.Text)
        SQL.AddParam("@fn", employeeAdd.txtFn.Text)
        SQL.AddParam("@mn", employeeAdd.txtMn.Text)
        SQL.AddParam("@ln", employeeAdd.txtLn.Text)
        SQL.AddParam("@nick", employeeAdd.txtNick.Text)
        SQL.AddParam("@address", employeeAdd.txtAddress.Text)
        SQL.AddParam("@gender", employeeAdd.cbxGender.Text)
        SQL.AddParam("@pos", employeeAdd.positionId)
        SQL.AddParam("@contact", employeeAdd.txtContact.Text)
        SQL.AddParam("@template", employeeAdd.template)

        'insert to db
        SQL.ExecQueryDT("INSERT INTO employees VALUES (@id,@fn,@mn,@ln,@nick,@address,@gender,@pos,@contact,@template);")
        If SQL.HasException(True) Then Exit Sub
        MessageBox.Show("Employee added successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

        employeeAdd.txtId.Text = ""
        employeeAdd.txtFn.Text = ""
        employeeAdd.txtMn.Text = ""
        employeeAdd.txtLn.Text = ""
        employeeAdd.txtNick.Text = ""
        employeeAdd.txtAddress.Text = ""
        employeeAdd.cbxGender.SelectedIndex = 0
        employeeAdd.cbxPositions.SelectedIndex = 0
        employeeAdd.txtContact.Text = ""
        employeeAdd.template = ""
        employeeAdd.fpicture.Image = Nothing

        Exit Sub

    End Sub

    '## com ports

    'list all com port
    Public Function getSerialPorts()
        Dim list As New ArrayList

        ' Show all available COM ports.
        For Each sp As String In My.Computer.Ports.SerialPortNames
            list.Add(sp)
        Next

        Return list
    End Function

End Class
