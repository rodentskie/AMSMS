Imports CrystalDecisions.CrystalReports.Engine
Public Class viewReports

    Private Sub viewReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub viewReports_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Sub disposerpt()
        Dim rpt As New ReportDocument
        rpt.Close()
        rpt.Dispose()
    End Sub

    Private Sub viewReports_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        disposerpt()
    End Sub

End Class