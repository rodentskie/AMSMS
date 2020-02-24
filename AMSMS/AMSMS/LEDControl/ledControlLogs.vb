Public Class ledControlLogs
    Private q As New queries
    Private p As New dgvPaging
    Private dtSource As DataTable
    Public Property id As String                'need when dgv is click store ID

    Dim bool As Boolean = False                  'not show data on load
    Private SQL As New SQLControl
    Public Property loadPrint As Boolean = False
    Private f As New functions

    Private Sub ledControlLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxPagesize.SelectedIndex = 2
    End Sub

    Private Sub ledControlLogs_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub dgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvData.CellFormatting
        Me.dgvData.RowsDefaultCellStyle.BackColor = Color.White
        Me.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
    End Sub

    Private Sub dgvData_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvData.DataBindingComplete
        dgvData.ClearSelection()
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

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        bool = True
        loads()
    End Sub

    Public Sub loads()
        Dim from = dtpFrom.Value.ToString("MM/dd/yyy")
        Dim tos = dtpTo.Value.ToString("MM/dd/yyy")

        q.lightLogsLoadDGV(dgvData, from, tos)

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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvData.Rows.Count > 0 Then
            loadPrint = False

            f.Delay(0.5)
            mainform.Enabled = False
            Me.Enabled = False
            loadingReport.Show()
        End If
    End Sub

    'print logs
    Public Sub print()
        Try
            Dim rpt As New lightlogs
            '--
            Dim from = dtpFrom.Value.ToString("MM/dd/yyy")
            Dim tos = dtpTo.Value.ToString("MM/dd/yyy")

            SQL.AddParam("@from", from)
            SQL.AddParam("@to", tos)
            SQL.ExecQueryDS("
                SELECT * FROM light_logs 
                WHERE convert(varchar, time, 101) BETWEEN @from AND @to
                ORDER BY time DESC;
            ")
            '--
            If SQL.HasException(True) Then Exit Sub
            loadPrint = True
            SQL.DBDA.TableMappings.Add("Table", "lightlogs")
            SQL.DBDA.Fill(SQL.DBDS)
            rpt.SetDataSource(SQL.DBDS)
            viewReports.crv.ReportSource = rpt
            viewReports.crv.Dock = DockStyle.Fill
            viewReports.crv.Refresh()
            viewReports.Text = "LIGHT LOGS"
            viewReports.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class