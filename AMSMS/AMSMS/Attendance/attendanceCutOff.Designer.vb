<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class attendanceCutOff
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
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpinAM = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpinPM = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpOutPM = New System.Windows.Forms.DateTimePicker()
        Me.dtpLunchBreak = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtpinAM)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.dtpinPM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.dtpOutPM)
        Me.GroupBox1.Controls.Add(Me.dtpLunchBreak)
        Me.GroupBox1.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 51)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 264)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cut off time"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(110, 235)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(68, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(127, 13)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Time in starts(AM) :"
        '
        'dtpinAM
        '
        Me.dtpinAM.CustomFormat = "hh:mm:ss tt"
        Me.dtpinAM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpinAM.Location = New System.Drawing.Point(68, 35)
        Me.dtpinAM.Name = "dtpinAM"
        Me.dtpinAM.ShowUpDown = True
        Me.dtpinAM.Size = New System.Drawing.Size(164, 20)
        Me.dtpinAM.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(68, 123)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(127, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Time in starts(PM) :"
        '
        'dtpinPM
        '
        Me.dtpinPM.CustomFormat = "hh:mm:ss tt"
        Me.dtpinPM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpinPM.Location = New System.Drawing.Point(68, 139)
        Me.dtpinPM.Name = "dtpinPM"
        Me.dtpinPM.ShowUpDown = True
        Me.dtpinPM.Size = New System.Drawing.Size(164, 20)
        Me.dtpinPM.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(68, 174)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(139, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Time out cut off(PM) :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(68, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Lunch break :"
        '
        'dtpOutPM
        '
        Me.dtpOutPM.CustomFormat = "hh:mm:ss tt"
        Me.dtpOutPM.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpOutPM.Location = New System.Drawing.Point(68, 190)
        Me.dtpOutPM.Name = "dtpOutPM"
        Me.dtpOutPM.ShowUpDown = True
        Me.dtpOutPM.Size = New System.Drawing.Size(164, 20)
        Me.dtpOutPM.TabIndex = 4
        '
        'dtpLunchBreak
        '
        Me.dtpLunchBreak.CustomFormat = "hh:mm:ss tt"
        Me.dtpLunchBreak.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLunchBreak.Location = New System.Drawing.Point(68, 88)
        Me.dtpLunchBreak.Name = "dtpLunchBreak"
        Me.dtpLunchBreak.ShowUpDown = True
        Me.dtpLunchBreak.Size = New System.Drawing.Size(164, 20)
        Me.dtpLunchBreak.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 22)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Set Cut Off Time"
        '
        'attendanceCutOff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 327)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "attendanceCutOff"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cut Off Time"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnAdd As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpinAM As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpinPM As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpOutPM As DateTimePicker
    Friend WithEvents dtpLunchBreak As DateTimePicker
    Friend WithEvents Label1 As Label
End Class
