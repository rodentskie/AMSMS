<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class vaultLogs
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.pbTest = New System.Windows.Forms.PictureBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.btnView = New System.Windows.Forms.Button()
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpto = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.cbxPagesize = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.btnLast = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbTest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.dgvData)
        Me.Panel1.Location = New System.Drawing.Point(12, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(505, 203)
        Me.Panel1.TabIndex = 197
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvData.ColumnHeadersHeight = 30
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.EnableHeadersVisualStyles = False
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(505, 203)
        Me.dgvData.TabIndex = 0
        '
        'pbTest
        '
        Me.pbTest.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.pbTest.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbTest.Location = New System.Drawing.Point(523, 78)
        Me.pbTest.Name = "pbTest"
        Me.pbTest.Size = New System.Drawing.Size(246, 203)
        Me.pbTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbTest.TabIndex = 198
        Me.pbTest.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnView)
        Me.GroupBox3.Controls.Add(Me.dtpfrom)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.dtpto)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(754, 60)
        Me.GroupBox3.TabIndex = 199
        Me.GroupBox3.TabStop = False
        '
        'btnView
        '
        Me.btnView.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.btnView.Location = New System.Drawing.Point(642, 27)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(106, 23)
        Me.btnView.TabIndex = 198
        Me.btnView.Text = "View"
        Me.btnView.UseVisualStyleBackColor = True
        '
        'dtpfrom
        '
        Me.dtpfrom.Location = New System.Drawing.Point(9, 30)
        Me.dtpfrom.Name = "dtpfrom"
        Me.dtpfrom.Size = New System.Drawing.Size(238, 20)
        Me.dtpfrom.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "From :"
        '
        'dtpto
        '
        Me.dtpto.Location = New System.Drawing.Point(333, 30)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(238, 20)
        Me.dtpto.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(330, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "To :"
        '
        'lblPage
        '
        Me.lblPage.AutoSize = True
        Me.lblPage.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPage.Location = New System.Drawing.Point(531, 300)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(33, 16)
        Me.lblPage.TabIndex = 206
        Me.lblPage.Text = "Page"
        '
        'btnNext
        '
        Me.btnNext.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(347, 296)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 203
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrevious
        '
        Me.btnPrevious.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Location = New System.Drawing.Point(252, 296)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(75, 23)
        Me.btnPrevious.TabIndex = 202
        Me.btnPrevious.Text = "Previous"
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'cbxPagesize
        '
        Me.cbxPagesize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPagesize.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxPagesize.FormattingEnabled = True
        Me.cbxPagesize.Items.AddRange(New Object() {"1", "5", "10", "20", "50", "100"})
        Me.cbxPagesize.Location = New System.Drawing.Point(85, 297)
        Me.cbxPagesize.Name = "cbxPagesize"
        Me.cbxPagesize.Size = New System.Drawing.Size(70, 24)
        Me.cbxPagesize.TabIndex = 200
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 300)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 16)
        Me.Label1.TabIndex = 205
        Me.Label1.Text = "Page Size"
        '
        'btnFirst
        '
        Me.btnFirst.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFirst.Location = New System.Drawing.Point(171, 296)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(75, 23)
        Me.btnFirst.TabIndex = 201
        Me.btnFirst.Text = "First"
        Me.btnFirst.UseVisualStyleBackColor = True
        '
        'btnLast
        '
        Me.btnLast.Font = New System.Drawing.Font("Palatino Linotype", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLast.Location = New System.Drawing.Point(428, 296)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(75, 23)
        Me.btnLast.TabIndex = 204
        Me.btnLast.Text = "Last"
        Me.btnLast.UseVisualStyleBackColor = True
        '
        'vaultLogs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 325)
        Me.Controls.Add(Me.lblPage)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.cbxPagesize)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.pbTest)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "vaultLogs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Vault Logs"
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbTest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents pbTest As PictureBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents btnView As Button
    Friend WithEvents dtpfrom As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpto As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents lblPage As Label
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents cbxPagesize As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFirst As Button
    Friend WithEvents btnLast As Button
End Class
