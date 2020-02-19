Public Class attendance
    Private q As New queries
    Private p As New dgvPaging
    Private dtSource As DataTable
    Private WithEvents timers As New Timer

    Private Sub attendance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtId.Select()
        txtId.Focus()
        txtId.Focus()

        'fetch cut off time
        q.attendanceDisplayCutOff()

        loadMorning()

        timers.Start()
    End Sub

    'load morning
    Sub loadMorning()
        q.attendanceDGVMorning(dgvData)

        dgvData.ClearSelection()
        'for adjusting data to display
        dtSource = q.SQL.DBDT
        p.fillDgv("10", dtSource)
        p.LoadPage(dtSource, dgvData, "10")
    End Sub

    'load afternoon
    Sub loadAfternoon()
        q.attendanceDGVAfternoon(dgvData)

        dgvData.ClearSelection()
        'for adjusting data to display
        dtSource = q.SQL.DBDT
        p.fillDgv("10", dtSource)
        p.LoadPage(dtSource, dgvData, "10")
        '--
    End Sub

    Private Sub attendance_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub dgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvData.CellFormatting
        Me.dgvData.RowsDefaultCellStyle.BackColor = Color.White
        Me.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
    End Sub

    Private Sub dgvData_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvData.DataBindingComplete
        dgvData.ClearSelection()
    End Sub

    Private Sub timers_Tick(sender As Object, e As EventArgs) Handles timers.Tick
        lblTime.Text = Format$(Now, "hh:mm:ss tt")
    End Sub

End Class