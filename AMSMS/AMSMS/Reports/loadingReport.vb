Public Class loadingReport
    Dim WithEvents oTimer As New Timer
    Private f As New functions
    Dim onceBool As Boolean = True 'run query once on loop

    Private Sub loadingReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oTimer.Start()
    End Sub

    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        pbIn.Width += 15
        If pbIn.Width >= 320 Then
            oTimer.Stop()
            showReport()
        End If
    End Sub

    Sub showReport()
        '##
        If f.IsFormOpen(payrolls) Then
            While payrolls.loadPrint = False
                pbIn.Width = 5
                oTimer.Start()
                If onceBool = True Then
                    onceBool = False
                    payrolls.print()
                End If

                If payrolls.loadPrint = True Then
                    oTimer.Stop()
                    Me.Close()
                    mainform.Enabled = True
                    payrolls.Enabled = True
                    Exit Sub
                End If

                Exit Sub
            End While
        End If

        '##
        If f.IsFormOpen(ledControlLogs) Then
            While ledControlLogs.loadPrint = False
                pbIn.Width = 5
                oTimer.Start()
                If onceBool = True Then
                    onceBool = False
                    ledControlLogs.print()
                End If

                If ledControlLogs.loadPrint = True Then
                    oTimer.Stop()
                    Me.Close()
                    mainform.Enabled = True
                    ledControlLogs.Enabled = True
                    Exit Sub
                End If

                Exit Sub
            End While
        End If
    End Sub

End Class