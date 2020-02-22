Public Class comLoading
    Dim WithEvents oTimer As New Timer
    Private f As New functions
    Dim onceBool As Boolean = True 'run query once on loop

    Private Sub comLoading_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        oTimer.Start()
    End Sub

    Private Sub oTimer_Tick(sender As Object, e As EventArgs) Handles oTimer.Tick
        pbIn.Width += 15
        If pbIn.Width >= 320 Then
            oTimer.Stop()
            connecting()
        End If
    End Sub

    Sub connecting()
        If f.IsFormOpen(employeeAdd) Then
            pbIn.Width = 5
            oTimer.Start()
            employeeAdd.connectCounter += 1 'increment one

            If onceBool = True Then
                employeeAdd.sendSerialData()
                onceBool = False
            End If

            If employeeAdd.isConnected = True Then
                ' connected to arduino
                oTimer.Stop()
                employeeAdd.Enabled = True
                Me.Close()
                Exit Sub
            End If

            If employeeAdd.connectCounter = 5 Then
                'manual type
                oTimer.Stop()
                employeeAdd.activateOnce = True
                employeeAdd.txtId.ReadOnly = False
                employeeAdd.Enabled = True
                Me.Close()
                Exit Sub
            End If

        End If
    End Sub

End Class