Public Class employees
    Private q As New queries
    Private p As New dgvPaging
    Private dtSource As DataTable
    Public Property id As String                'need when dgv is click store ID

    Dim bool As Boolean = False                  'not show data on load

    ' 1348, 645

    Private Sub employees_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxPagesize.SelectedIndex = 2
        lblError.Text = ""
    End Sub

    Private Sub employees_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub dgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvData.CellFormatting
        Me.dgvData.RowsDefaultCellStyle.BackColor = Color.White
        Me.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
    End Sub

    Private Sub dgvData_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvData.DataBindingComplete
        dgvData.ClearSelection()

        If dgvData.Rows.Count > 0 Then
            lblError.Text = ""
        Else
            lblError.Text = "No results found..."
        End If
    End Sub

    Private Sub btnFirst_Click(sender As Object, e As EventArgs) Handles btnFirst.Click
        dtSource = q.SQL.DBDT
        p.tofirstpage(dtSource, dgvData, cbxPagesize.Text)
        p.DisplayPageInfo(lblPage)
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        dtSource = q.SQL.DBDT
        p.previouspage(dtSource, dgvData, cbxPagesize.Text)
        p.DisplayPageInfo(lblPage)
    End Sub

    Public Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        dtSource = q.SQL.DBDT
        p.nextpage(dtSource, dgvData, cbxPagesize.Text)
        p.DisplayPageInfo(lblPage)
    End Sub

    Private Sub btnLast_Click(sender As Object, e As EventArgs) Handles btnLast.Click
        dtSource = q.SQL.DBDT
        p.tolastpage(dtSource, dgvData, cbxPagesize.Text)
        p.DisplayPageInfo(lblPage)
    End Sub

    Private Sub dgvData_Click(sender As Object, e As EventArgs) Handles dgvData.Click
        If dgvData.Rows.Count = 0 Then
            'do nothing
            Exit Sub
        Else
            If dgvData.SelectedRows.Count > 0 Then
                id = dgvData.CurrentRow.Cells(0).Value
            End If
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        bool = True
        loads()
    End Sub


    Public Sub loads()
        q.employeesLoadDgv(dgvData, txtFilter.Text)

        dgvData.ClearSelection()
        id = ""
        'for adjusting data to display
        dtSource = q.SQL.DBDT
        p.fillDgv(cbxPagesize.Text, dtSource)
        p.LoadPage(dtSource, dgvData, cbxPagesize.Text)
        p.DisplayPageInfo(lblPage)

        If p.PageCount = 1 Then
            btnNext.Enabled = False
            btnLast.Enabled = False
        Else
            btnNext.Enabled = True
            btnLast.Enabled = True
        End If
        '--
    End Sub

    Private Sub txtFilter_TextChanged(sender As Object, e As EventArgs) Handles txtFilter.TextChanged
        If bool = True Then
            loads()
        End If
    End Sub

    Private Sub cbxPagesize_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPagesize.SelectedIndexChanged
        If bool = True Then
            loads()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        mainform.Enabled = False
        Me.Enabled = False
        employeeAdd.Show()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If id <> "" Then
            mainform.Enabled = False
            Me.Enabled = False
            employeeUpdate.Show()
        End If
    End Sub
End Class