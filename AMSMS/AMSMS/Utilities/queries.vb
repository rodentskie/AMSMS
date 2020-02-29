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
                mainform.role = "admin"
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

    'officer login
    Public Function officerLogin(username As String, password As String)
        Dim bool As Boolean = False
        Dim int As Integer = 0

        SQL.AddParam("@uname", username)
        SQL.AddParam("@pw", f.GetHash(password))

        SQL.ExecQueryDT("SELECT * FROM officer_logins WHERE username = @uname AND password = @pw;")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            'successful login
            bool = True

            If (f.IsFormOpen(loginForm)) Then
                MessageBox.Show("Login successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                mainform.role = "officer"
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

    'get template from RFID scan
    Public Function returnTemplate(rfid As String)
        Dim temp As String = ""
        Dim id As String = rfid.Trim

        SQL.AddParam("@id", id)
        SQL.ExecQueryDT("SELECT template FROM employees WHERE employee_id = @id;")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                If Not IsDBNull(r(0)) Then
                    temp = r(0)
                End If
            Next
        End If

        Return temp
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
        SQL.AddParam("@id", employeeAdd.txtId.Text.Trim)
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

        'don't allow multiple managers
        SQL.AddParam("@pos", employeeAdd.cbxPositions.Text)
        SQL.ExecQueryDT("
            SELECT * FROM employees e
            LEFT JOIN positions p ON p.id = e.position
            WHERE LOWER(p.position_name) = @pos;
        ")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            MessageBox.Show("There is a manager already, this is not allowed.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim id = employeeAdd.txtId.Text
        SQL.AddParam("@id", id.Trim)
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

    'fetch data single employee
    Public Sub employeeSelectOne(id As String)
        SQL.AddParam("@id", id)
        SQL.ExecQueryDT("
            SELECT e.*,p.position_name FROM employees e LEFT JOIN positions p ON p.id = e.position
            WHERE employee_id = @id;
        ")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                If Not IsDBNull(r(0)) Then
                    employeeUpdate.txtId.Text = r(0)
                End If
                '--
                If Not IsDBNull(r(1)) Then
                    employeeUpdate.txtFn.Text = r(1)
                End If
                '--
                If Not IsDBNull(r(2)) Then
                    employeeUpdate.txtMn.Text = r(2)
                End If
                '--
                If Not IsDBNull(r(3)) Then
                    employeeUpdate.txtLn.Text = r(3)
                End If
                '--
                If Not IsDBNull(r(4)) Then
                    employeeUpdate.txtNick.Text = r(4)
                End If
                '--
                If Not IsDBNull(r(5)) Then
                    employeeUpdate.txtAddress.Text = r(5)
                End If
                '--
                If Not IsDBNull(r(6)) Then
                    employeeUpdate.cbxGender.Text = r(6)
                End If
                '--
                If Not IsDBNull(r(8)) Then
                    employeeUpdate.txtContact.Text = r(8)
                End If
                '--
                If Not IsDBNull(r(10)) Then
                    employeeUpdate.cbxPositions.Text = r(10)
                End If
                '--
            Next
        End If
    End Sub

    'update employee
    Public Function employeeSaveUpdate(id As String)
        Dim bool = False

        'check if employee already exist
        SQL.AddParam("@id", id)
        SQL.AddParam("@fn", employeeUpdate.txtFn.Text)
        SQL.AddParam("@ln", employeeUpdate.txtLn.Text)
        SQL.ExecQueryDT("
                SELECT * FROM employees WHERE LOWER(fname) = LOWER(@fn)
                AND LOWER(lname) = LOWER(@ln) AND employee_id <> @id;
        ")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            MessageBox.Show("Employee already exist!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return Nothing
        End If

        'check if there is finger scanned
        If employeeUpdate.template <> "" Then
            'if there is; update template
            SQL.AddParam("@id", id)
            SQL.AddParam("@fn", employeeUpdate.txtFn.Text)
            SQL.AddParam("@mn", employeeUpdate.txtMn.Text)
            SQL.AddParam("@ln", employeeUpdate.txtLn.Text)
            SQL.AddParam("@nick", employeeUpdate.txtNick.Text)
            SQL.AddParam("@address", employeeUpdate.txtAddress.Text)
            SQL.AddParam("@gender", employeeUpdate.cbxGender.Text)
            SQL.AddParam("@contact", employeeUpdate.txtContact.Text)
            SQL.AddParam("@pos", employeeUpdate.positionId)
            SQL.AddParam("@temp", employeeUpdate.template)

            SQL.ExecQueryDT("
            UPDATE employees SET fname=@fn, mname=@mn, lname=@ln, nick=@nick, address=@address,
            gender=@gender, contact_num=@contact, position=@pos, template=@temp WHERE employee_id=@id;
            ")
            If SQL.HasException(True) Then Return Nothing
            bool = True
            MessageBox.Show("Employee updated successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            employeeUpdate.txtId.Text = ""
            employeeUpdate.txtFn.Text = ""
            employeeUpdate.txtMn.Text = ""
            employeeUpdate.txtLn.Text = ""
            employeeUpdate.txtNick.Text = ""
            employeeUpdate.txtAddress.Text = ""
            employeeUpdate.cbxGender.SelectedIndex = 0
            employeeUpdate.cbxPositions.SelectedIndex = 0
            employeeUpdate.txtContact.Text = ""
            employeeUpdate.template = ""
            employeeUpdate.fpicture.Image = Nothing
        Else
            'if there is none; don't update template
            SQL.AddParam("@id", id)
            SQL.AddParam("@fn", employeeUpdate.txtFn.Text)
            SQL.AddParam("@mn", employeeUpdate.txtMn.Text)
            SQL.AddParam("@ln", employeeUpdate.txtLn.Text)
            SQL.AddParam("@nick", employeeUpdate.txtNick.Text)
            SQL.AddParam("@address", employeeUpdate.txtAddress.Text)
            SQL.AddParam("@gender", employeeUpdate.cbxGender.Text)
            SQL.AddParam("@contact", employeeUpdate.txtContact.Text)
            SQL.AddParam("@pos", employeeUpdate.positionId)

            SQL.ExecQueryDT("
            UPDATE employees SET fname=@fn, mname=@mn, lname=@ln, nick=@nick, address=@address,
            gender=@gender, contact_num=@contact, position=@pos WHERE employee_id=@id;
            ")
            If SQL.HasException(True) Then Return Nothing
            bool = True
            MessageBox.Show("Employee updated successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            employeeUpdate.txtId.Text = ""
            employeeUpdate.txtFn.Text = ""
            employeeUpdate.txtMn.Text = ""
            employeeUpdate.txtLn.Text = ""
            employeeUpdate.txtNick.Text = ""
            employeeUpdate.txtAddress.Text = ""
            employeeUpdate.cbxGender.SelectedIndex = 0
            employeeUpdate.cbxPositions.SelectedIndex = 0
            employeeUpdate.txtContact.Text = ""
            employeeUpdate.template = ""
            employeeUpdate.fpicture.Image = Nothing
        End If

        Return bool
    End Function

    'load dgv employees accounts
    Public Sub empLoginLoadDgv(dgv As DataGridView, filter As String)
        If filter <> "" Then
            SQL.AddParam("@filter", "%" & filter & "%")
            SQL.ExecQueryDT("
                SELECT o.id,CONCAT(e.lname,', ',e.fname) name, username,password FROM officer_logins o
                LEFT JOIN employees e ON e.employee_id = o.employee_id WHERE CONCAT(e.lname,', ',e.fname)
                LIKE @filter OR username LIKE @filter;
            ")
        Else
            SQL.ExecQueryDT("
                SELECT o.id,CONCAT(e.lname,', ',e.fname) name, username,password FROM officer_logins o
                LEFT JOIN employees e ON e.employee_id = o.employee_id;
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
        dgv.Columns(0).Visible = False
        dgv.Columns(1).HeaderText = "EMPLOYEE NAME"
        dgv.Columns(2).HeaderText = "USERNAME"
        dgv.Columns(3).HeaderText = "HASH PASSWORD"
        dgv.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.RowTemplate.Height = 30
    End Sub

    'load listbox of employee with no account
    Public Sub empLoginLoadLb(lb As ListBox, txt As TextBox)
        lb.Items.Clear()

        SQL.AddParam("@filter", "%" & txt.Text & "%")
        SQL.ExecQueryDT("
            SELECT CONCAT(e.employee_id,' | ',lname,', ',fname) emp FROM employees e
            LEFT JOIN officer_logins o ON o.employee_id = e.employee_id
            WHERE o.employee_id IS NULL AND e.employee_id LIKE @filter OR
            o.employee_id IS NULL AND e.lname LIKE @filter;
        ")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                lb.Items.Add(r(0))
            Next
        End If
    End Sub

    'insert to officer login table
    Public Function empLoginAdds()
        Dim bool = False

        'check if username exist
        SQL.AddParam("@uname", empLoginAdd.txtUname.Text)
        SQL.ExecQueryDT("SELECT * FROM officer_logins WHERE LOWER(username) = LOWER(@uname);")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            MessageBox.Show("Employee's username already exist. Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End If

        'insert to db
        SQL.AddParam("@id", empLoginAdd.id)
        SQL.AddParam("@uname", empLoginAdd.txtUname.Text)
        SQL.AddParam("@pw", f.GetHash(empLoginAdd.txtPw.Text))

        SQL.ExecQueryDT("
            INSERT INTO officer_logins (username,password,employee_id)
            VALUES (@uname,@pw,@id);
        ")
        If SQL.HasException(True) Then Return Nothing
        bool = True
        MessageBox.Show("Account added successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        empLoginAdd.id = ""
        empLoginAdd.txtUname.Text = ""
        empLoginAdd.txtPw.Text = ""
        empLoginAdd.txtRePw.Text = ""

        Return bool
    End Function

    'update employee accounts

    'update admin account
    Public Function empLoginUpdates(id As String)
        Dim bool = False

        'check if username exists
        SQL.AddParam("@id", id)
        SQL.AddParam("@uname", empLoginUpdate.txtUsername.Text)
        SQL.ExecQueryDT("SELECT * FROM officer_logins WHERE LOWER(username) = @uname AND id <> @id;")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            'username exists
            MessageBox.Show("Username already exist. Please try again.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return bool
        End If

        'update to db
        SQL.AddParam("@id", id)
        SQL.AddParam("@uname", empLoginUpdate.txtUsername.Text)
        SQL.AddParam("@hash", f.GetHash(empLoginUpdate.txtPw.Text))
        SQL.ExecQueryDT("UPDATE officer_logins SET username=@uname, password=@hash WHERE id=@id;")
        If SQL.HasException(True) Then Return Nothing
        MessageBox.Show("Account updated successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        empLoginUpdate.txtUsername.Text = ""
        empLoginUpdate.txtPw.Text = ""
        empLoginUpdate.txtRePw.Text = ""
        bool = True

        Return bool
    End Function

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

    '## attendance

    'set attendance cut off
    Public Sub attendanceSet()
        SQL.ExecQueryDT("SELECT * FROM cut_offs;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            'update
            Dim id As Integer = 0
            For Each r As DataRow In SQL.DBDT.Rows
                If Not IsDBNull(r(0)) Then
                    id = r(0)
                End If
            Next

            SQL.AddParam("@id", id)
            SQL.AddParam("@inAM", attendanceCutOff.dtpinAM.Value)
            SQL.AddParam("@break", attendanceCutOff.dtpLunchBreak.Value)
            SQL.AddParam("@inPM", attendanceCutOff.dtpinPM.Value)
            SQL.AddParam("@outPM", attendanceCutOff.dtpOutPM.Value)

            SQL.ExecQueryDT("
                UPDATE cut_offs SET morning_in=@inAM, lunch_break=@break, afternoon_in=@inPM,
                afternoon_out=@outPM WHERE id=@id;
            ")
            If SQL.HasException(True) Then Exit Sub
            MessageBox.Show("Updated successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        Else
            'insert
            SQL.AddParam("@inAM", attendanceCutOff.dtpinAM.Value)
            SQL.AddParam("@break", attendanceCutOff.dtpLunchBreak.Value)
            SQL.AddParam("@inPM", attendanceCutOff.dtpinPM.Value)
            SQL.AddParam("@outPM", attendanceCutOff.dtpOutPM.Value)

            SQL.ExecQueryDT("INSERT INTO cut_offs VALUES (@inAM,@break,@inPM,@outPM);")
            If SQL.HasException(True) Then Exit Sub
            MessageBox.Show("Added successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
    End Sub

    'fetch existing cut off
    Public Sub attendanceFetchCutOff()
        SQL.ExecQueryDT("SELECT * FROM cut_offs;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                If Not IsDBNull(r(1)) Then
                    attendanceCutOff.dtpinAM.Text = r(1).ToString()
                End If
                If Not IsDBNull(r(2)) Then
                    attendanceCutOff.dtpLunchBreak.Text = r(2).ToString()
                End If
                If Not IsDBNull(r(3)) Then
                    attendanceCutOff.dtpinPM.Text = r(3).ToString()
                End If
                If Not IsDBNull(r(4)) Then
                    attendanceCutOff.dtpOutPM.Text = r(4).ToString()
                End If
            Next
        End If
    End Sub

    'load afternoon view
    Public Sub attendanceDGVAfternoon(dgv As DataGridView)
        SQL.ExecQueryDT("
            SELECT c.employee_id,CONCAT(c.lname,', ',c.fname) name,a.date,
            CONVERT(varchar(15),a.time_in,100) inAM,
            CONVERT(varchar(15),a.time_out,100) outAM,
            CONVERT(varchar(15),b.time_in,100) inPM,
            CONVERT(varchar(15),b.time_out,100) outPM,b.elapsed_time
            FROM attendance_in a
            LEFT JOIN attendance_out b ON b.attendance_in_id = a.id
            LEFT JOIN employees c ON c.employee_id = a.employee_id ORDER BY a.updated_at DESC;
        ")
        If SQL.HasException(True) Then Exit Sub
        dgv.AllowUserToResizeColumns = False
        dgv.AllowUserToResizeRows = False
        dgv.AllowUserToAddRows = False
        dgv.DataSource = SQL.DBDT
        dgv.ClearSelection()
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        '##########
        dgv.Columns(7).Visible = False
        dgv.Columns(0).HeaderText = "EMPLOYEE ID"
        dgv.Columns(1).HeaderText = "NAME"
        dgv.Columns(2).HeaderText = "DATE"
        dgv.Columns(3).HeaderText = "MORNING IN"
        dgv.Columns(4).HeaderText = "LUNCH BREAK"
        dgv.Columns(5).HeaderText = "AFTERNOON IN"
        dgv.Columns(6).HeaderText = "AFTERNOON OUT"
        dgv.Columns(7).HeaderText = "ELAPSED"
        dgv.Columns(2).DefaultCellStyle.Format = "MM/dd/yyy"
        dgv.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.RowTemplate.Height = 30
    End Sub

    'load morning view
    Public Sub attendanceDGVMorning(dgv As DataGridView)
        SQL.ExecQueryDT("
            SELECT c.employee_id,CONCAT(c.lname,', ',c.fname) name,a.date,
            CONVERT(varchar(15),a.time_in,100) inAM,
            CONVERT(varchar(15),a.time_out,100) outAM,
            CONVERT(varchar(15),b.time_in,100) inPM,
            CONVERT(varchar(15),b.time_out,100) outPM,b.elapsed_time
            FROM attendance_in a
            LEFT JOIN attendance_out b ON b.attendance_in_id = a.id
            LEFT JOIN employees c ON c.employee_id = a.employee_id;
        ")
        If SQL.HasException(True) Then Exit Sub
        dgv.AllowUserToResizeColumns = False
        dgv.AllowUserToResizeRows = False
        dgv.AllowUserToAddRows = False
        dgv.DataSource = SQL.DBDT
        dgv.ClearSelection()
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        '##########
        dgv.Columns(5).Visible = False
        dgv.Columns(6).Visible = False
        dgv.Columns(7).Visible = False
        dgv.Columns(0).HeaderText = "EMPLOYEE ID"
        dgv.Columns(1).HeaderText = "NAME"
        dgv.Columns(2).HeaderText = "DATE"
        dgv.Columns(3).HeaderText = "MORNING IN"
        dgv.Columns(4).HeaderText = "LUNCH BREAK"
        dgv.Columns(5).HeaderText = "AFTERNOON IN"
        dgv.Columns(6).HeaderText = "AFTERNOON OUT"
        dgv.Columns(7).HeaderText = "ELAPSED"
        dgv.Columns(2).DefaultCellStyle.Format = "MM/dd/yyy"
        dgv.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.RowTemplate.Height = 30
    End Sub

    'display cut off time to attendance monitoring
    Public Sub attendanceDisplayCutOff()
        SQL.ExecQueryDT("
            SELECT id,
            CONVERT(varchar(15),morning_in,100) morning_in,
            CONVERT(varchar(15),lunch_break,100) lunch_break,
            CONVERT(varchar(15),afternoon_in,100) afternoon_in,
            CONVERT(varchar(15),afternoon_out,100) afternoon_out
            FROM cut_offs;
        ")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                If Not IsDBNull(r(1)) Then
                    attendance.lblin.Text = r(1).ToString()
                End If
                If Not IsDBNull(r(2)) Then
                    attendance.lblbreak.Text = r(2).ToString()
                End If
                If Not IsDBNull(r(3)) Then
                    attendance.lblinPM.Text = r(3).ToString()
                End If
                If Not IsDBNull(r(4)) Then
                    attendance.lblOut.Text = r(4).ToString()
                End If
            Next
        End If
    End Sub

    'time in earlier than cut off
    Public Sub attendanceInEarly(id As String, time As DateTime, inAM As DateTime)
        Dim dates = time.ToString("yyy-MM-dd")
        Dim now = time.ToString("HH:mm:ss")
        Dim credited = inAM.ToString("HH:mm:ss")

        SQL.AddParam("@id", id)
        SQL.AddParam("@date", dates)
        SQL.ExecQueryDT("SELECT * FROM attendance_in WHERE date = @date AND employee_id = @id;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            'already time in; do nothing
        Else
            'time in
            SQL.AddParam("@id", id)
            SQL.AddParam("@date", dates)
            SQL.AddParam("@now", now)
            SQL.AddParam("@credit", credited)
            SQL.ExecQueryDT("
                INSERT INTO attendance_in (employee_id,time_in,date,credited_time_in,updated_at)
                VALUES (@id,@now,@date,@credit,GETDATE());
            ")
            If SQL.HasException(True) Then Exit Sub
        End If
    End Sub

    'time in actual time
    Public Sub attendanceTimeInActual(id As String, time As DateTime)
        Dim dates = time.ToString("yyy-MM-dd")
        Dim now = time.ToString("HH:mm:ss")

        SQL.AddParam("@id", id)
        SQL.AddParam("@date", dates)
        SQL.ExecQueryDT("SELECT * FROM attendance_in WHERE date = @date AND employee_id = @id;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            'already time in; do nothing
        Else
            'time in
            SQL.AddParam("@id", id)
            SQL.AddParam("@date", dates)
            SQL.AddParam("@now", now)
            SQL.AddParam("@credit", now)
            SQL.ExecQueryDT("
                INSERT INTO attendance_in (employee_id,time_in,date,credited_time_in,updated_at)
                VALUES (@id,@now,@date,@credit,GETDATE());
            ")
            If SQL.HasException(True) Then Exit Sub
        End If
    End Sub

    'time lunch; actual lunch time; lucnh break or half day falls here
    Public Sub attendanceLunchScan(id As String, time As DateTime)
        Dim dates = time.ToString("yyy-MM-dd")
        Dim now = time.ToString("HH:mm:ss")

        SQL.AddParam("@id", id)
        SQL.AddParam("@date", dates)
        SQL.ExecQueryDT("SELECT * FROM attendance_in WHERE date = @date AND employee_id = @id;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                'lunch break; only without time out record
                If IsDBNull(r(3)) Then
                    Dim timeIn_id = r(0)

                    SQL.AddParam("@id", timeIn_id)
                    SQL.ExecQueryDT("SELECT * FROM attendance_out WHERE attendance_in_id = @id;")
                    If SQL.HasException(True) Then Exit Sub
                    If SQL.RecordCountDT > 0 Then
                        'there is a time out record; do nothing
                    Else
                        'update lunch out
                        SQL.AddParam("@id", timeIn_id)
                        SQL.AddParam("@now", now)
                        SQL.ExecQueryDT("UPDATE attendance_in SET time_out=@now,updated_at=GETDATE() WHERE id=@id;")
                        If SQL.HasException(True) Then Exit Sub
                    End If
                End If
            Next
        Else
            'if null; meaning no time in in morning; half day
            SQL.AddParam("@id", id)
            SQL.AddParam("@date", dates)
            SQL.ExecQueryDT("
                        INSERT INTO attendance_in (employee_id,date,updated_at)
                        VALUES (@id,@date,GETDATE());
                    ")
            If SQL.HasException(True) Then Exit Sub

            'get id of attendance_in;
            SQL.AddParam("@id", id)
            SQL.AddParam("@date", dates)
            SQL.ExecQueryDT("
                        SELECT * FROM attendance_in WHERE employee_id = @id
                        AND date = @date ORDER BY id DESC;
                    ")
            If SQL.HasException(True) Then Exit Sub
            If SQL.RecordCountDT > 0 Then
                For Each s As DataRow In SQL.DBDT.Rows
                    If Not IsDBNull(s(0)) Then
                        Dim timeIn_id = s(0)

                        SQL.AddParam("@id", timeIn_id)
                        SQL.AddParam("@now", now)
                        SQL.ExecQueryDT("
                                    INSERT INTO attendance_out (attendance_in_id,time_in)
                                    VALUES(@id,@now);
                                ")
                        If SQL.HasException(True) Then Exit Sub
                    End If
                Next
            End If
        End If
    End Sub

    'attendance exceed lunch out and half day
    Public Sub attendanceExceedAndHalf(id As String, time As DateTime, lunch As DateTime)
        Dim dates = time.ToString("yyy-MM-dd")
        Dim now = time.ToString("HH:mm:ss")
        Dim break = lunch.ToString("HH:mm:ss")

        SQL.AddParam("@id", id)
        SQL.AddParam("@date", dates)
        SQL.ExecQueryDT("SELECT * FROM attendance_in WHERE date = @date AND employee_id = @id;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                'lunch break; exceed time out
                If IsDBNull(r(3)) Then
                    Dim timeIn_id = r(0)
                    SQL.AddParam("@id", timeIn_id)
                    SQL.ExecQueryDT("SELECT * FROM attendance_out WHERE attendance_in_id = @id;")
                    If SQL.HasException(True) Then Exit Sub
                    If SQL.RecordCountDT > 0 Then
                        'update timeout
                        SQL.AddParam("@id", timeIn_id)
                        SQL.AddParam("@now", now)
                        SQL.ExecQueryDT("UPDATE attendance_out SET time_out=@now WHERE attendance_in_id=@id AND time_out IS NULL;")
                        If SQL.HasException(True) Then Exit Sub

                        'to display in latest
                        SQL.AddParam("@id", timeIn_id)
                        SQL.ExecQueryDT("UPDATE attendance_in SET updated_at=GETDATE() WHERE id=@id;")
                        If SQL.HasException(True) Then Exit Sub
                    Else
                        SQL.AddParam("@id", timeIn_id)
                        SQL.AddParam("@break", break)
                        SQL.ExecQueryDT("UPDATE attendance_in SET time_out=@break,updated_at=GETDATE() WHERE id=@id;")
                        If SQL.HasException(True) Then Exit Sub

                        SQL.AddParam("@id", timeIn_id)
                        SQL.AddParam("@now", now)
                        SQL.ExecQueryDT("
                                    INSERT INTO attendance_out (attendance_in_id,time_in)
                                    VALUES(@id,@now);
                                ")
                        If SQL.HasException(True) Then Exit Sub
                    End If
                Else
                    Dim timeIn_id = r(0)
                    SQL.AddParam("@id", timeIn_id)
                    SQL.ExecQueryDT("SELECT * FROM attendance_out WHERE attendance_in_id = @id;")
                    If SQL.HasException(True) Then Exit Sub
                    If SQL.RecordCountDT > 0 Then
                        'means has time out; early out
                        SQL.AddParam("@id", timeIn_id)
                        SQL.AddParam("@now", now)
                        SQL.ExecQueryDT("UPDATE attendance_out SET time_out=@now WHERE attendance_in_id=@id AND time_out IS NULL;")
                        If SQL.HasException(True) Then Exit Sub

                        'to display in latest
                        SQL.AddParam("@id", timeIn_id)
                        SQL.ExecQueryDT("UPDATE attendance_in SET updated_at=GETDATE() WHERE id=@id;")
                        If SQL.HasException(True) Then Exit Sub
                    Else
                        'time in afternoon
                        SQL.AddParam("@id", timeIn_id)
                        SQL.AddParam("@now", now)
                        SQL.ExecQueryDT("
                                    INSERT INTO attendance_out (attendance_in_id,time_in)
                                    VALUES(@id,@now);
                                ")
                        If SQL.HasException(True) Then Exit Sub
                    End If
                End If
            Next
        Else
            'if null; meaning no time in in morning; half day
            SQL.AddParam("@id", id)
            SQL.AddParam("@date", dates)
            SQL.ExecQueryDT("
                        INSERT INTO attendance_in (employee_id,date,updated_at)
                        VALUES (@id,@date,GETDATE());
                    ")
            If SQL.HasException(True) Then Exit Sub

            'get id of attendance_in;
            SQL.AddParam("@id", id)
            SQL.AddParam("@date", dates)
            SQL.ExecQueryDT("
                        SELECT * FROM attendance_in WHERE employee_id = @id
                        AND date = @date ORDER BY id DESC;
                    ")
            If SQL.HasException(True) Then Exit Sub
            If SQL.RecordCountDT > 0 Then
                For Each s As DataRow In SQL.DBDT.Rows
                    If Not IsDBNull(s(0)) Then
                        Dim timeIn_id = s(0)

                        SQL.AddParam("@id", timeIn_id)
                        SQL.AddParam("@now", now)
                        SQL.ExecQueryDT("
                                    INSERT INTO attendance_out (attendance_in_id,time_in)
                                    VALUES(@id,@now);
                                ")
                        If SQL.HasException(True) Then Exit Sub
                    End If
                Next
            End If
        End If
    End Sub

    'simple time out
    Public Sub attendanceScanOut(id As String, time As DateTime)
        Dim dates = time.ToString("yyy-MM-dd")
        Dim now = time.ToString("HH:mm:ss")
        SQL.AddParam("@id", id)
        SQL.AddParam("@date", dates)
        SQL.ExecQueryDT("SELECT * FROM attendance_in WHERE date = @date AND employee_id = @id;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                Dim timeIn_id = r(0)

                SQL.AddParam("@id", timeIn_id)
                SQL.AddParam("@now", now)
                SQL.ExecQueryDT("UPDATE attendance_out SET time_out=@now WHERE attendance_in_id=@id AND time_out IS NULL;")
                If SQL.HasException(True) Then Exit Sub

                'to display in latest
                SQL.AddParam("@id", timeIn_id)
                SQL.ExecQueryDT("UPDATE attendance_in SET updated_at=GETDATE() WHERE id=@id;")
                If SQL.HasException(True) Then Exit Sub
            Next
        End If
    End Sub

    '## payroll

    'load employees dgv
    Public Sub payrollLoadDgvEmployees(dgv As DataGridView, filter As String)
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
        dgv.Columns(2).Visible = False
        dgv.Columns(3).Visible = False
        dgv.Columns(4).Visible = False
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

    'return position rate on chosen employee
    Public Function payrollReturnRate(id As String)
        Dim rate As Double = 0

        SQL.AddParam("@id", id)
        SQL.ExecQueryDT("
            SELECT p.rate FROM employees e LEFT JOIN positions p
            ON p.id = e.position WHERE e.employee_id = @id;
        ")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                If Not IsDBNull(r(0)) Then
                    rate = r(0)
                End If
            Next
        End If

        Return rate
    End Function

    'get total seconds in morning only
    Public Function payrollTotalSecondsAM(id As String, fromDate As String, toDate As String)
        Dim seconds As Integer = 0

        SQL.AddParam("@id", id)
        SQL.AddParam("@from", fromDate)
        SQL.AddParam("@to", toDate)
        SQL.ExecQueryDT("
            SELECT id FROM attendance_in WHERE
            employee_id = @id AND date BETWEEN @from AND @to;
        ")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                If Not IsDBNull(r(0)) Then
                    'get total seconds per attendance
                    Dim in_id = r(0)

                    SQL.AddParam("@id", in_id)
                    SQL.ExecQueryDT("
                        SELECT SUM(DATEDIFF(SECOND, time_in, time_out)) AS mins FROM attendance_in
                        WHERE id = @id;
                    ")
                    If SQL.HasException(True) Then Return Nothing
                    If SQL.RecordCountDT > 0 Then
                        For Each s As DataRow In SQL.DBDT.Rows
                            If Not IsDBNull(s(0)) Then
                                seconds = seconds + s(0)
                            Else
                                seconds = seconds + 0
                            End If
                        Next
                    End If
                End If
            Next
        End If

        Return seconds

    End Function

    'get total seconds in afternoon only
    Public Function payrollTotalSecondsPM(id As String, fromDate As String, toDate As String)
        Dim seconds As Integer = 0

        SQL.AddParam("@id", id)
        SQL.AddParam("@from", fromDate)
        SQL.AddParam("@to", toDate)
        SQL.ExecQueryDT("
            SELECT a.id FROM attendance_out a LEFT JOIN attendance_in b
            ON a.attendance_in_id = b.id WHERE
            employee_id = @id AND date BETWEEN @from AND @to;
        ")
        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                If Not IsDBNull(r(0)) Then
                    'get total seconds per attendance
                    Dim out_id = r(0)

                    SQL.AddParam("@id", out_id)
                    SQL.ExecQueryDT("
                        SELECT SUM(DATEDIFF(SECOND, time_in, time_out)) AS mins FROM attendance_out
                        WHERE id = @id;
                    ")
                    If SQL.HasException(True) Then Return Nothing
                    If SQL.RecordCountDT > 0 Then
                        For Each s As DataRow In SQL.DBDT.Rows
                            If Not IsDBNull(s(0)) Then
                                seconds = seconds + s(0)
                            Else
                                seconds = seconds + 0
                            End If
                        Next
                    End If
                End If
            Next
        End If

        Return seconds

    End Function


    'GSM

    'return manager number
    Public Function returnManager()
        Dim num = ""

        SQL.ExecQueryDT("
            SELECT contact_num FROM employees e
            LEFT JOIN positions p ON p.id = e.position
            WHERE LOWER(p.position_name) = 'manager';
        ")

        If SQL.HasException(True) Then Return Nothing
        If SQL.RecordCountDT > 0 Then
            For Each r As DataRow In SQL.DBDT.Rows
                If Not IsDBNull(r(0)) Then
                    num = r(0)
                End If
            Next
        End If

        Return num
    End Function

    '# light LOGS

    'insert Logs
    Public Sub insertLightLogs(office As String, action As String)
        SQL.AddParam("@office", office)
        SQL.AddParam("@action", action)

        SQL.ExecQueryDT("INSERT INTO light_logs VALUES (@office,@action,GETDATE());")
        If SQL.HasException(True) Then Exit Sub
    End Sub

    'display logs 
    Public Sub lightLogsLoadDGV(dgv As DataGridView, from As String, tos As String)
        SQL.AddParam("@from", from)
        SQL.AddParam("@to", tos)
        SQL.ExecQueryDT("
            SELECT * FROM light_logs 
            WHERE convert(varchar, time, 101) BETWEEN @from AND @to
            ORDER BY time DESC;
        ")
        If SQL.HasException(True) Then Exit Sub
        dgv.AllowUserToResizeColumns = False
        dgv.AllowUserToResizeRows = False
        dgv.AllowUserToAddRows = False
        dgv.DataSource = SQL.DBDT
        dgv.ClearSelection()
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        '##########
        dgv.Columns(0).Visible = False
        dgv.Columns(1).HeaderText = "OFFICE"
        dgv.Columns(2).HeaderText = "ACTION"
        dgv.Columns(3).HeaderText = "DATE TIME"
        dgv.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(3).DefaultCellStyle.Format = "MM/dd/yyy hh:mm tt"
        dgv.RowTemplate.Height = 30
    End Sub

    'vault logs

    'insert vault logs
    Public Sub vaultLogsInsert(id As String, path As String)
        SQL.AddParam("@id", id)
        SQL.ExecQueryDT("SELECT * FROM employees WHERE LOWER(employee_id)=@id;")
        If SQL.HasException(True) Then Exit Sub
        If SQL.RecordCountDT > 0 Then
            SQL.AddParam("@id", id)
            SQL.AddParam("@path", path)
            SQL.ExecQueryDT("INSERT INTO vault_logs (employee_id,image_path) VALUES (@id,@path);")
            If SQL.HasException(True) Then Exit Sub
        Else
            SQL.AddParam("@path", path)
            SQL.ExecQueryDT("INSERT INTO vault_logs (image_path) VALUES (@path);")
            If SQL.HasException(True) Then Exit Sub
        End If
    End Sub

    'view vault logs
    Public Sub vaultLogsLoadDgv(dgv As DataGridView, from As String, tos As String)
        SQL.AddParam("@from", from)
        SQL.AddParam("@to", tos)
        SQL.ExecQueryDT("
            SELECT v.employee_id,CONCAT(e.lname,', ',e.fname) fullname,dates,image_path
            FROM vault_logs v 
            LEFT JOIN employees e ON e.employee_id = v.employee_id
            WHERE convert(varchar, dates, 101) BETWEEN @from AND @to
            ORDER BY dates DESC;
        ")
        If SQL.HasException(True) Then Exit Sub
        dgv.AllowUserToResizeColumns = False
        dgv.AllowUserToResizeRows = False
        dgv.AllowUserToAddRows = False
        dgv.DataSource = SQL.DBDT
        dgv.ClearSelection()
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        '##########
        dgv.Columns(3).Visible = False
        dgv.Columns(0).HeaderText = "ID #"
        dgv.Columns(1).HeaderText = "NAME"
        dgv.Columns(2).HeaderText = "DATE TIME"
        dgv.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        dgv.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        'wrap column
        dgv.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        'end wrap
        dgv.Columns(2).DefaultCellStyle.Format = "MM/dd/yyy hh:mm tt"
        dgv.Columns(0).Width = 150
        dgv.Columns(2).Width = 160
        dgv.RowTemplate.Height = 30
    End Sub
End Class
