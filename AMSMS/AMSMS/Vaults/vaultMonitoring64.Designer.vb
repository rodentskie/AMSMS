<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vaultMonitoring64
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
        Me.lblGuide = New System.Windows.Forms.Label()
        Me.fpicture = New System.Windows.Forms.PictureBox()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.pbTest = New System.Windows.Forms.PictureBox()
        Me.sp = New System.IO.Ports.SerialPort(Me.components)
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.fpicture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblGuide)
        Me.GroupBox1.Controls.Add(Me.fpicture)
        Me.GroupBox1.Controls.Add(Me.picCapture)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(874, 534)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lblGuide
        '
        Me.lblGuide.AutoSize = True
        Me.lblGuide.Location = New System.Drawing.Point(657, 17)
        Me.lblGuide.Name = "lblGuide"
        Me.lblGuide.Size = New System.Drawing.Size(71, 15)
        Me.lblGuide.TabIndex = 82
        Me.lblGuide.Text = "Finger Print"
        '
        'fpicture
        '
        Me.fpicture.BackColor = System.Drawing.SystemColors.Window
        Me.fpicture.Location = New System.Drawing.Point(660, 35)
        Me.fpicture.Name = "fpicture"
        Me.fpicture.Size = New System.Drawing.Size(208, 205)
        Me.fpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.fpicture.TabIndex = 81
        Me.fpicture.TabStop = False
        '
        'picCapture
        '
        Me.picCapture.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCapture.Location = New System.Drawing.Point(6, 13)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(648, 515)
        Me.picCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCapture.TabIndex = 80
        Me.picCapture.TabStop = False
        '
        'pbTest
        '
        Me.pbTest.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pbTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbTest.Location = New System.Drawing.Point(520, 564)
        Me.pbTest.Name = "pbTest"
        Me.pbTest.Size = New System.Drawing.Size(152, 91)
        Me.pbTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbTest.TabIndex = 81
        Me.pbTest.TabStop = False
        '
        'sp
        '
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(297, 595)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(187, 20)
        Me.txtId.TabIndex = 82
        '
        'vaultMonitoring64
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(898, 558)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.pbTest)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "vaultMonitoring64"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vault Monitoring 64"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.fpicture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents picCapture As PictureBox
    Friend WithEvents pbTest As PictureBox
    Friend WithEvents lblGuide As Label
    Friend WithEvents fpicture As PictureBox
    Friend WithEvents sp As IO.Ports.SerialPort
    Friend WithEvents txtId As TextBox
End Class
