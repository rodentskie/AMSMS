Public Class empLoginAdd
    Private q As New queries
    Dim bool As Boolean = False         'check if has add or not
    Public Property id As String = ""

    Private Sub empLoginAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub empLoginAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        q.empLoginLoadLb(lbEmployees, txtFilter)
    End Sub

    Private Sub empLoginAdd_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        q.empLoginLoadLb(lbEmployees, txtFilter)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        addAccount()
    End Sub

    Sub addAccount()
        Dim username = txtUname.Text
        Dim pw = txtPw.Text
        Dim rePw = txtRePw.Text

        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Please enter username.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUname.Focus()
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

        If id = "" Then
            MessageBox.Show("Please select employee.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFilter.Focus()
            Exit Sub
        End If

        'insert to db
        Dim insertBool = q.empLoginAdds()
        If insertBool = True Then
            bool = True

            id = ""

            txtFilter.Enabled = True
            lbEmployees.Enabled = True
            txtFilter.Select()
            txtFilter.Focus()
            q.empLoginLoadLb(lbEmployees, txtFilter)
        End If
    End Sub

    'get id from selected item in listbox
    Function getIdFromSelected(str As String)
        Dim id As String = ""

        Dim strArr() As String
        strArr = str.Split(" | ")
        id = strArr(0)

        Return id
    End Function

    Private Sub lbEmployees_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbEmployees.SelectedIndexChanged
        id = getIdFromSelected(lbEmployees.Text)

        txtFilter.Enabled = False
        lbEmployees.Enabled = False
        txtUname.Select()
        txtUname.Focus()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        id = ""

        txtFilter.Enabled = True
        lbEmployees.Enabled = True
        lbEmployees.ClearSelected()
        txtFilter.Select()
        txtFilter.Focus()
    End Sub

End Class