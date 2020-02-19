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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.pbTest = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.picCapture)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(660, 534)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
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
        'vaultMonitoring64
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 558)
        Me.Controls.Add(Me.pbTest)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "vaultMonitoring64"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vault Monitoring 64"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents picCapture As PictureBox
    Friend WithEvents pbTest As PictureBox
End Class
