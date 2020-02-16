Public Class positionAdd
    Private q As New queries
    Dim bool As Boolean = False         'check if has add or not

    Private Sub positionAdd_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mainform.Enabled = True
        positions.Enabled = True
        positions.Select()
        positions.Focus()
        positions.Focus()
        If bool = True Then
            'if user has added account; reload view
            positions.loads()
        End If
    End Sub

    Private Sub positionAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPosition.Select()
    End Sub

    Private Sub positionAdd_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Me.CenterToScreen()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        addPosition()
    End Sub

    Private Sub txtPosition_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRate.KeyDown, txtPosition.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            e.Handled = True
            addPosition()
        End If
    End Sub

    Private Sub txtRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRate.KeyPress
        'only numbers allowed
        Dim DecimalSeparator As String = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or
                         Asc(e.KeyChar) = 8 Or
                         (e.KeyChar = DecimalSeparator And sender.Text.IndexOf(DecimalSeparator) = -1))
    End Sub

    Sub addPosition()
        Dim pos = txtPosition.Text
        Dim rate = txtRate.Text

        If String.IsNullOrWhiteSpace(pos) Then
            MessageBox.Show("Please enter position.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPosition.Focus()
            Exit Sub
        End If

        If String.IsNullOrWhiteSpace(rate) Then
            MessageBox.Show("Please enter rate of position.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtRate.Focus()
            Exit Sub
        End If

        'insert to db
        q.positionAdds()
        bool = True
    End Sub

End Class