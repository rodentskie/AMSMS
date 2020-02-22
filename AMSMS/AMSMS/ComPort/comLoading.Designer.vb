<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class comLoading
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pbIn = New System.Windows.Forms.PictureBox()
        Me.pbOut = New System.Windows.Forms.PictureBox()
        CType(Me.pbIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 18)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Establising Connection"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(118, 108)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(109, 13)
        Me.lblStatus.TabIndex = 27
        Me.lblStatus.Text = "Please Wait . . ."
        '
        'pbIn
        '
        Me.pbIn.BackColor = System.Drawing.SystemColors.Highlight
        Me.pbIn.Location = New System.Drawing.Point(12, 67)
        Me.pbIn.Name = "pbIn"
        Me.pbIn.Size = New System.Drawing.Size(5, 23)
        Me.pbIn.TabIndex = 26
        Me.pbIn.TabStop = False
        '
        'pbOut
        '
        Me.pbOut.BackColor = System.Drawing.Color.White
        Me.pbOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbOut.Location = New System.Drawing.Point(12, 67)
        Me.pbOut.Name = "pbOut"
        Me.pbOut.Size = New System.Drawing.Size(325, 23)
        Me.pbOut.TabIndex = 25
        Me.pbOut.TabStop = False
        '
        'comLoading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 134)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbIn)
        Me.Controls.Add(Me.pbOut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "comLoading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "comLoading"
        CType(Me.pbIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents pbIn As PictureBox
    Friend WithEvents pbOut As PictureBox
End Class
