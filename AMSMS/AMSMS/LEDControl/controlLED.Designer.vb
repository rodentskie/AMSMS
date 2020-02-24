<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class controlLED
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnOffEmployees = New System.Windows.Forms.Button()
        Me.btnOnEmployees = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnOffManager = New System.Windows.Forms.Button()
        Me.btnOnManager = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnOffWaitArea = New System.Windows.Forms.Button()
        Me.btnOnWaitArea = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnOffTeller = New System.Windows.Forms.Button()
        Me.btnOnTeller = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnOffVault = New System.Windows.Forms.Button()
        Me.btnOnVault = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sp = New System.IO.Ports.SerialPort(Me.components)
        Me.txtconn = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.btnAllOn = New System.Windows.Forms.Button()
        Me.btnAllOff = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAllOff)
        Me.GroupBox1.Controls.Add(Me.btnAllOn)
        Me.GroupBox1.Controls.Add(Me.btnOffEmployees)
        Me.GroupBox1.Controls.Add(Me.btnOnEmployees)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnOffManager)
        Me.GroupBox1.Controls.Add(Me.btnOnManager)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnOffWaitArea)
        Me.GroupBox1.Controls.Add(Me.btnOnWaitArea)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnOffTeller)
        Me.GroupBox1.Controls.Add(Me.btnOnTeller)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnOffVault)
        Me.GroupBox1.Controls.Add(Me.btnOnVault)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 38)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(553, 351)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnOffEmployees
        '
        Me.btnOffEmployees.Location = New System.Drawing.Point(412, 290)
        Me.btnOffEmployees.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOffEmployees.Name = "btnOffEmployees"
        Me.btnOffEmployees.Size = New System.Drawing.Size(100, 28)
        Me.btnOffEmployees.TabIndex = 14
        Me.btnOffEmployees.Text = "OFF"
        Me.btnOffEmployees.UseVisualStyleBackColor = True
        '
        'btnOnEmployees
        '
        Me.btnOnEmployees.Location = New System.Drawing.Point(284, 290)
        Me.btnOnEmployees.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOnEmployees.Name = "btnOnEmployees"
        Me.btnOnEmployees.Size = New System.Drawing.Size(100, 28)
        Me.btnOnEmployees.TabIndex = 13
        Me.btnOnEmployees.Text = "ON"
        Me.btnOnEmployees.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(40, 290)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(166, 24)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "OTHER EMPLOYEES"
        '
        'btnOffManager
        '
        Me.btnOffManager.Location = New System.Drawing.Point(412, 233)
        Me.btnOffManager.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOffManager.Name = "btnOffManager"
        Me.btnOffManager.Size = New System.Drawing.Size(100, 28)
        Me.btnOffManager.TabIndex = 11
        Me.btnOffManager.Text = "OFF"
        Me.btnOffManager.UseVisualStyleBackColor = True
        '
        'btnOnManager
        '
        Me.btnOnManager.Location = New System.Drawing.Point(284, 233)
        Me.btnOnManager.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOnManager.Name = "btnOnManager"
        Me.btnOnManager.Size = New System.Drawing.Size(100, 28)
        Me.btnOnManager.TabIndex = 10
        Me.btnOnManager.Text = "ON"
        Me.btnOnManager.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(40, 233)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(160, 24)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "MANAGER OFFICE"
        '
        'btnOffWaitArea
        '
        Me.btnOffWaitArea.Location = New System.Drawing.Point(412, 178)
        Me.btnOffWaitArea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOffWaitArea.Name = "btnOffWaitArea"
        Me.btnOffWaitArea.Size = New System.Drawing.Size(100, 28)
        Me.btnOffWaitArea.TabIndex = 8
        Me.btnOffWaitArea.Text = "OFF"
        Me.btnOffWaitArea.UseVisualStyleBackColor = True
        '
        'btnOnWaitArea
        '
        Me.btnOnWaitArea.Location = New System.Drawing.Point(284, 178)
        Me.btnOnWaitArea.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOnWaitArea.Name = "btnOnWaitArea"
        Me.btnOnWaitArea.Size = New System.Drawing.Size(100, 28)
        Me.btnOnWaitArea.TabIndex = 7
        Me.btnOnWaitArea.Text = "ON"
        Me.btnOnWaitArea.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(40, 178)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(135, 24)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "WAITING AREA"
        '
        'btnOffTeller
        '
        Me.btnOffTeller.Location = New System.Drawing.Point(412, 123)
        Me.btnOffTeller.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOffTeller.Name = "btnOffTeller"
        Me.btnOffTeller.Size = New System.Drawing.Size(100, 28)
        Me.btnOffTeller.TabIndex = 5
        Me.btnOffTeller.Text = "OFF"
        Me.btnOffTeller.UseVisualStyleBackColor = True
        '
        'btnOnTeller
        '
        Me.btnOnTeller.Location = New System.Drawing.Point(284, 123)
        Me.btnOnTeller.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOnTeller.Name = "btnOnTeller"
        Me.btnOnTeller.Size = New System.Drawing.Size(100, 28)
        Me.btnOnTeller.TabIndex = 4
        Me.btnOnTeller.Text = "ON"
        Me.btnOnTeller.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 123)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 24)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "TELLER"
        '
        'btnOffVault
        '
        Me.btnOffVault.Location = New System.Drawing.Point(412, 63)
        Me.btnOffVault.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOffVault.Name = "btnOffVault"
        Me.btnOffVault.Size = New System.Drawing.Size(100, 28)
        Me.btnOffVault.TabIndex = 2
        Me.btnOffVault.Text = "OFF"
        Me.btnOffVault.UseVisualStyleBackColor = True
        '
        'btnOnVault
        '
        Me.btnOnVault.Location = New System.Drawing.Point(284, 63)
        Me.btnOnVault.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOnVault.Name = "btnOnVault"
        Me.btnOnVault.Size = New System.Drawing.Size(100, 28)
        Me.btnOnVault.TabIndex = 1
        Me.btnOnVault.Text = "ON"
        Me.btnOnVault.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(40, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "VAULT ROOM"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 11)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "LED Control"
        '
        'sp
        '
        '
        'txtconn
        '
        Me.txtconn.Location = New System.Drawing.Point(267, 15)
        Me.txtconn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtconn.Name = "txtconn"
        Me.txtconn.Size = New System.Drawing.Size(132, 22)
        Me.txtconn.TabIndex = 3
        Me.txtconn.Visible = False
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(428, 15)
        Me.txtId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(132, 22)
        Me.txtId.TabIndex = 4
        Me.txtId.Visible = False
        '
        'btnAllOn
        '
        Me.btnAllOn.Location = New System.Drawing.Point(284, 27)
        Me.btnAllOn.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAllOn.Name = "btnAllOn"
        Me.btnAllOn.Size = New System.Drawing.Size(100, 28)
        Me.btnAllOn.TabIndex = 15
        Me.btnAllOn.Text = "ALL ON"
        Me.btnAllOn.UseVisualStyleBackColor = True
        '
        'btnAllOff
        '
        Me.btnAllOff.Location = New System.Drawing.Point(412, 27)
        Me.btnAllOff.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAllOff.Name = "btnAllOff"
        Me.btnAllOff.Size = New System.Drawing.Size(100, 28)
        Me.btnAllOff.TabIndex = 16
        Me.btnAllOff.Text = "ALL OFF"
        Me.btnAllOff.UseVisualStyleBackColor = True
        '
        'controlLED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 404)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.txtconn)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "controlLED"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LED Control"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnOffEmployees As Button
    Friend WithEvents btnOnEmployees As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents btnOffManager As Button
    Friend WithEvents btnOnManager As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents btnOffWaitArea As Button
    Friend WithEvents btnOnWaitArea As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents btnOffTeller As Button
    Friend WithEvents btnOnTeller As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents btnOffVault As Button
    Friend WithEvents btnOnVault As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents sp As IO.Ports.SerialPort
    Friend WithEvents txtconn As TextBox
    Friend WithEvents txtId As TextBox
    Friend WithEvents btnAllOff As Button
    Friend WithEvents btnAllOn As Button
End Class
