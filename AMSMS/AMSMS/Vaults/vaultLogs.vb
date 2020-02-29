Public Class vaultLogs
    Private q As New queries
    Private p As New dgvPaging
    Private dtSource As DataTable
    Public Property path As String = ""         'store image path

    Private Sub vaultLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxPagesize.SelectedIndex = 2
    End Sub

    Private Sub vaultLogs_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub dgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvData.CellFormatting
        Me.dgvData.RowsDefaultCellStyle.BackColor = Color.White
        Me.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
    End Sub

    Private Sub dgvData_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvData.DataBindingComplete
        dgvData.ClearSelection()
    End Sub

    Public Sub loads()
        Dim from = dtpfrom.Value.ToString("MM/dd/yyyy")
        Dim tos = dtpto.Value.ToString("MM/dd/yyyy")

        q.vaultLogsLoadDgv(dgvData, from, tos)

        dgvData.ClearSelection()

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
                path = dgvData.CurrentRow.Cells(3).Value
                showImage(path)
            End If
        End If
    End Sub

    'show image
    Sub showImage(paths As String)
        If Not String.IsNullOrWhiteSpace(paths) Then
            'if not empty
            pbTest.Image = Image.FromFile(paths)
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        loads()
    End Sub

End Class