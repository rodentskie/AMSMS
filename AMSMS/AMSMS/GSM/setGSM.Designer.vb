<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class setGSM
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
        Me.btnSet = New System.Windows.Forms.Button()
        Me.txtBFP = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtManager = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.sp = New System.IO.Ports.SerialPort(Me.components)
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtconn = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSet)
        Me.GroupBox1.Controls.Add(Me.txtBFP)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtManager)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 59)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 233)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(135, 188)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(75, 23)
        Me.btnSet.TabIndex = 4
        Me.btnSet.Text = "Set"
        Me.btnSet.UseVisualStyleBackColor = True
        '
        'txtBFP
        '
        Me.txtBFP.Location = New System.Drawing.Point(40, 126)
        Me.txtBFP.Name = "txtBFP"
        Me.txtBFP.Size = New System.Drawing.Size(261, 23)
        Me.txtBFP.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "BFP"
        '
        'txtManager
        '
        Me.txtManager.Location = New System.Drawing.Point(40, 46)
        Me.txtManager.Name = "txtManager"
        Me.txtManager.ReadOnly = True
        Me.txtManager.Size = New System.Drawing.Size(261, 23)
        Me.txtManager.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Manager "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SET GSM #"
        '
        'sp
        '
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(147, 13)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(198, 20)
        Me.txtId.TabIndex = 3
        Me.txtId.Visible = False
        '
        'txtconn
        '
        Me.txtconn.Location = New System.Drawing.Point(147, 39)
        Me.txtconn.Name = "txtconn"
        Me.txtconn.Size = New System.Drawing.Size(198, 20)
        Me.txtconn.TabIndex = 4
        Me.txtconn.Visible = False
        '
        'setGSM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(357, 304)
        Me.Controls.Add(Me.txtconn)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "setGSM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "GSM"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnSet As Button
    Friend WithEvents txtBFP As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtManager As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents sp As IO.Ports.SerialPort
    Friend WithEvents txtId As TextBox
    Friend WithEvents txtconn As TextBox
End Class
