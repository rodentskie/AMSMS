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
        Me.txtconn = New System.Windows.Forms.TextBox()
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
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(1165, 657)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'lblGuide
        '
        Me.lblGuide.AutoSize = True
        Me.lblGuide.Location = New System.Drawing.Point(876, 21)
        Me.lblGuide.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGuide.Name = "lblGuide"
        Me.lblGuide.Size = New System.Drawing.Size(91, 21)
        Me.lblGuide.TabIndex = 82
        Me.lblGuide.Text = "Finger Print"
        '
        'fpicture
        '
        Me.fpicture.BackColor = System.Drawing.SystemColors.Window
        Me.fpicture.Location = New System.Drawing.Point(880, 43)
        Me.fpicture.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
        Me.picCapture.Location = New System.Drawing.Point(8, 16)
        Me.picCapture.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(863, 633)
        Me.picCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCapture.TabIndex = 80
        Me.picCapture.TabStop = False
        '
        'pbTest
        '
        Me.pbTest.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pbTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbTest.Location = New System.Drawing.Point(693, 694)
        Me.pbTest.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbTest.Name = "pbTest"
        Me.pbTest.Size = New System.Drawing.Size(201, 174)
        Me.pbTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbTest.TabIndex = 81
        Me.pbTest.TabStop = False
        '
        'sp
        '
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(161, 750)
        Me.txtId.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(523, 22)
        Me.txtId.TabIndex = 82
        '
        'txtconn
        '
        Me.txtconn.Location = New System.Drawing.Point(161, 782)
        Me.txtconn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtconn.Name = "txtconn"
        Me.txtconn.Size = New System.Drawing.Size(523, 22)
        Me.txtconn.TabIndex = 83
        '
        'vaultMonitoring64
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1197, 826)
        Me.Controls.Add(Me.txtconn)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.pbTest)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "vaultMonitoring64"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vault Monitoring"
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
    Friend WithEvents txtconn As TextBox
End Class
