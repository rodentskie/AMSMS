Imports CrystalDecisions.CrystalReports.Engine

Public Class payrolls
    Private q As New queries
    Private p As New dgvPaging
    Private dtSource As DataTable
    Public Property id As String = ""        'need when dgv is click store ID
    Public Property names As String = ""              'need when dgv is click store name

    Dim bool As Boolean = False                  'not show data on load

    Public Property pagibig As Double = 250
    Public Property ph As Double = 150
    Public Property sss As Double = 180

    Public Property rate As Double = 0          'rate per position; per minute rate


    Public Property minutesAM As Double = 0
    Public Property minutesPM As Double = 0

    Dim printBool As Boolean = False

    Public Property loadPrint As Boolean = False

    Public Property grossReport As Double = 0
    Public Property totalDeductionReport As Double = 0
    Public Property netReport As Double = 0

    Private Sub payrolls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        clearDisplay()

        btnClear.Enabled = False
        gbMain.Enabled = False

    End Sub

    Private Sub payrolls_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub dgvData_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvData.CellFormatting
        Me.dgvData.RowsDefaultCellStyle.BackColor = Color.White
        Me.dgvData.AlternatingRowsDefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)
    End Sub

    Private Sub dgvData_DataBindingComplete(sender As Object, e As DataGridViewBindingCompleteEventArgs) Handles dgvData.DataBindingComplete
        dgvData.ClearSelection()
    End Sub

    Private Sub dgvData_Click(sender As Object, e As EventArgs) Handles dgvData.Click
        If dgvData.Rows.Count = 0 Then
            'do nothing
            Exit Sub
        Else
            If dgvData.SelectedRows.Count > 0 Then
                id = dgvData.CurrentRow.Cells(0).Value
                names = dgvData.CurrentRow.Cells(1).Value
            End If

            lblid.Text = id
            lblName.Text = names

            'get rate
            rate = q.payrollReturnRate(id)
            lblRate.Text = "₱" & rate.ToString("N2")

            deductions()

            gbMain.Enabled = True
            txtFilter.Enabled = False
            btnSearch.Enabled = False
            dgvData.Enabled = False
            btnClear.Enabled = True
        End If
    End Sub

    Public Sub loads()
        q.payrollLoadDgvEmployees(dgvData, txtFilter.Text)

        dgvData.ClearSelection()
        id = ""
        'for adjusting data to display
        dtSource = q.SQL.DBDT
        p.fillDgv("7", dtSource)
        p.LoadPage(dtSource, dgvData, "7")
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        loads()
    End Sub

    'clear display
    Sub clearDisplay()
        lblid.Text = ""
        lblName.Text = ""
        lbltotalhours.Text = ""
        lbltotalminutes.Text = ""
        lblsss.Text = ""
        lblpg.Text = ""
        lblph.Text = ""
        lblRate.Text = ""
        gbMain.Enabled = False
        lblnet.Text = ""
        lblgross.Text = ""
    End Sub

    'display deductions
    Sub deductions()
        lblph.Text = "₱" & ph.ToString("N2")
        lblpg.Text = "₱" & pagibig.ToString("N2")
        lblsss.Text = "₱" & sss.ToString("N2")
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clearDisplay()

        id = ""
        names = ""
        rate = 0
        minutesAM = 0
        minutesPM = 0

        txtFilter.Enabled = True
        btnSearch.Enabled = True
        dgvData.Enabled = True
        btnClear.Enabled = False
        dgvData.ClearSelection()

        'can't print
        printBool = False
    End Sub

    Private Sub btnCalculate_Click(sender As Object, e As EventArgs) Handles btnCalculate.Click
        Dim from = dtpfrom.Value.ToString("yyyy-MM-dd")
        Dim tos = dtpto.Value.ToString("yyyy-MM-dd")

        '##get total seconds all morning
        Dim totalSecAM = q.payrollTotalSecondsAM(id, from, tos)
        'total seconds divide 60 to get total minutes
        minutesAM = totalSecAM / 60

        '##get total seconds in all afternoon
        Dim totalSecPM = q.payrollTotalSecondsPM(id, from, tos)
        minutesPM = totalSecPM / 60


        Dim totalMinute = minutesAM + minutesPM

        lbltotalminutes.Text = totalMinute.ToString("N2")

        Dim totalHours = totalMinute / 60
        lbltotalhours.Text = totalHours.ToString("N2")

        'gross salary
        Dim gross = totalMinute * rate
        lblgross.Text = "₱" & gross.ToString("N2")
        grossReport = gross

        'total deductions
        Dim totalDec = sss + pagibig + ph
        totalDeductionReport = totalDec

        'net pay
        Dim net = gross - totalDec
        lblnet.Text = "₱" & net.ToString("N2")
        netReport = net

        'can print
        printBool = True
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If printBool = True Then
            print()
        End If
    End Sub

    'print payslip
    Public Sub print()
        Try
            '##declare rpt file

            Dim reportFile = "payroll" ' name of the .rpt file
            'path
            Dim strReportPath As String = Application.StartupPath & "\" &
                    "Reports" & "\" & reportFile & ".rpt"
            'check if exist
            If Not IO.File.Exists(strReportPath) Then
                Throw (New Exception("Unable to locate report file:" & vbCrLf & strReportPath))
            End If
            'declare .rpt file to load
            Dim rpt As New ReportDocument

            rpt.Load(strReportPath)

            '## end declare rpt file
            rpt.SetParameterValue("id", id)
            rpt.SetParameterValue("name", names)
            rpt.SetParameterValue("rate", rate)
            rpt.SetParameterValue("ph", ph)
            rpt.SetParameterValue("pg", pagibig)
            rpt.SetParameterValue("sss", sss)
            rpt.SetParameterValue("gross", grossReport)
            rpt.SetParameterValue("totalDeduction", totalDeductionReport)
            rpt.SetParameterValue("net", netReport)

            loadPrint = True
            viewReports.crv.ReportSource = rpt
            viewReports.crv.Dock = DockStyle.Fill
            viewReports.crv.Refresh()
            viewReports.Text = "Pay Slip"
            viewReports.Show()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class