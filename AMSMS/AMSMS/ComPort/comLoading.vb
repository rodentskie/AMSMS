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

        '##

        If f.IsFormOpen(attendance) Then
            pbIn.Width = 5
            oTimer.Start()

            If onceBool = True Then
                attendance.sendSerialData()
                onceBool = False
            End If

            If attendance.isConnected = True Then
                ' connected to arduino
                oTimer.Stop()
                attendance.Enabled = True
                Me.Close()
                Exit Sub
            End If

        End If

        '##
        If f.IsFormOpen(setGSM) Then
            pbIn.Width = 5
            oTimer.Start()
            setGSM.sendSerialData()
            'If onceBool = True Then
            '    setGSM.sendSerialData()
            '    onceBool = False
            'End If

            If setGSM.isConnected = True Then
                ' connected to arduino
                oTimer.Stop()
                setGSM.Enabled = True
                Me.Close()
                Exit Sub
            End If

        End If

        '##
        If f.IsFormOpen(vaultMonitoring64) Then
            pbIn.Width = 5
            oTimer.Start()

            If onceBool = True Then
                vaultMonitoring64.sendSerialData()
                onceBool = False
            End If

            If vaultMonitoring64.isConnected = True Then
                ' connected to arduino
                oTimer.Stop()
                vaultMonitoring64.Enabled = True
                Me.Close()
                Exit Sub
            End If
        End If

        '##
        If f.IsFormOpen(controlLED) Then
            pbIn.Width = 5
            oTimer.Start()
            controlLED.sendSerialData()
            'If onceBool = True Then

            '    onceBool = False
            'End If

            If controlLED.isConnected = True Then
                ' connected to arduino
                oTimer.Stop()
                controlLED.Enabled = True
                Me.Close()
                Exit Sub
            End If
        End If
    End Sub

End Class