Public Class attendanceCutOff
    Private q As New queries
    Private f As New functions

    Private Sub attendanceCutOff_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fetch existing
        q.attendanceFetchCutOff()
    End Sub

    Private Sub attendanceCutOff_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        q.attendanceSet()
    End Sub

End Class