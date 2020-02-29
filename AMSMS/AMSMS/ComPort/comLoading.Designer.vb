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
        Me.lblHeader = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.pbIn = New System.Windows.Forms.PictureBox()
        Me.pbOut = New System.Windows.Forms.PictureBox()
        CType(Me.pbIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbOut, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblHeader
        '
        Me.lblHeader.AutoSize = True
        Me.lblHeader.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeader.Location = New System.Drawing.Point(16, 17)
        Me.lblHeader.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHeader.Name = "lblHeader"
        Me.lblHeader.Size = New System.Drawing.Size(140, 22)
        Me.lblHeader.TabIndex = 28
        Me.lblHeader.Text = "Connecting..."
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.Location = New System.Drawing.Point(157, 133)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(144, 17)
        Me.lblStatus.TabIndex = 27
        Me.lblStatus.Text = "Please Wait . . ."
        '
        'pbIn
        '
        Me.pbIn.BackColor = System.Drawing.SystemColors.Highlight
        Me.pbIn.Location = New System.Drawing.Point(16, 82)
        Me.pbIn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbIn.Name = "pbIn"
        Me.pbIn.Size = New System.Drawing.Size(7, 28)
        Me.pbIn.TabIndex = 26
        Me.pbIn.TabStop = False
        '
        'pbOut
        '
        Me.pbOut.BackColor = System.Drawing.Color.White
        Me.pbOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbOut.Location = New System.Drawing.Point(16, 82)
        Me.pbOut.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbOut.Name = "pbOut"
        Me.pbOut.Size = New System.Drawing.Size(433, 28)
        Me.pbOut.TabIndex = 25
        Me.pbOut.TabStop = False
        '
        'comLoading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 165)
        Me.Controls.Add(Me.lblHeader)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.pbIn)
        Me.Controls.Add(Me.pbOut)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "comLoading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "comLoading"
        CType(Me.pbIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbOut, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHeader As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents pbIn As PictureBox
    Friend WithEvents pbOut As PictureBox
End Class
