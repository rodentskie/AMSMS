<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payrolls
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.lbltotalminutes = New System.Windows.Forms.Label()
        Me.lbltotalhours = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.dtpfrom = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpto = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblid = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.txtFilter = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.lblph = New System.Windows.Forms.Label()
        Me.lblsss = New System.Windows.Forms.Label()
        Me.lblpg = New System.Windows.Forms.Label()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.lblRate = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblgross = New System.Windows.Forms.Label()
        Me.lblnet = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.gbMain.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.GroupBox5)
        Me.gbMain.Controls.Add(Me.GroupBox4)
        Me.gbMain.Controls.Add(Me.GroupBox3)
        Me.gbMain.Controls.Add(Me.GroupBox2)
        Me.gbMain.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.gbMain.Location = New System.Drawing.Point(531, 12)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(511, 376)
        Me.gbMain.TabIndex = 86
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Payslip Information"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnPrint)
        Me.GroupBox5.Controls.Add(Me.lblnet)
        Me.GroupBox5.Controls.Add(Me.lblgross)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.lbltotalminutes)
        Me.GroupBox5.Controls.Add(Me.lbltotalhours)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Location = New System.Drawing.Point(11, 255)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(494, 115)
        Me.GroupBox5.TabIndex = 11
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Rate Information"
        '
        'lbltotalminutes
        '
        Me.lbltotalminutes.AutoSize = True
        Me.lbltotalminutes.Location = New System.Drawing.Point(151, 73)
        Me.lbltotalminutes.Name = "lbltotalminutes"
        Me.lbltotalminutes.Size = New System.Drawing.Size(25, 13)
        Me.lbltotalminutes.TabIndex = 3
        Me.lbltotalminutes.Text = "min"
        '
        'lbltotalhours
        '
        Me.lbltotalhours.AutoSize = True
        Me.lbltotalhours.Location = New System.Drawing.Point(139, 33)
        Me.lbltotalhours.Name = "lbltotalhours"
        Me.lbltotalhours.Size = New System.Drawing.Size(25, 13)
        Me.lbltotalhours.TabIndex = 2
        Me.lbltotalhours.Text = "hrs"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(139, 13)
        Me.Label12.TabIndex = 1
        Me.Label12.Text = "Total Minutes Worked :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(127, 13)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Total Hours Worked :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lblRate)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.lblpg)
        Me.GroupBox4.Controls.Add(Me.lblsss)
        Me.GroupBox4.Controls.Add(Me.lblph)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Location = New System.Drawing.Point(279, 21)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(220, 216)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Deductions"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 121)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "PAG-IBIG :"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 71)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "SSS :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Philhealth :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnCalculate)
        Me.GroupBox3.Controls.Add(Me.dtpfrom)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.dtpto)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 118)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(262, 131)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Date Covered"
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
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "From :"
        '
        'dtpto
        '
        Me.dtpto.Location = New System.Drawing.Point(9, 77)
        Me.dtpto.Name = "dtpto"
        Me.dtpto.Size = New System.Drawing.Size(238, 20)
        Me.dtpto.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "To :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.lblid)
        Me.GroupBox2.Controls.Add(Me.lblName)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 22)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(262, 81)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Employee Information"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Employee ID : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Name :"
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblid.Location = New System.Drawing.Point(103, 29)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(19, 13)
        Me.lblid.TabIndex = 2
        Me.lblid.Text = "id"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(55, 46)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(31, 13)
        Me.lblName.TabIndex = 3
        Me.lblName.Text = "name"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Black
        Me.Panel1.Controls.Add(Me.dgvData)
        Me.Panel1.Location = New System.Drawing.Point(12, 57)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(513, 331)
        Me.Panel1.TabIndex = 196
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.dgvData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvData.ColumnHeadersHeight = 30
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvData.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.EnableHeadersVisualStyles = False
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvData.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvData.RowHeadersVisible = False
        Me.dgvData.RowTemplate.Height = 30
        Me.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvData.Size = New System.Drawing.Size(513, 331)
        Me.dgvData.TabIndex = 0
        '
        'txtFilter
        '
        Me.txtFilter.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.txtFilter.Location = New System.Drawing.Point(12, 31)
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(331, 20)
        Me.txtFilter.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.btnSearch.Location = New System.Drawing.Point(349, 29)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblph
        '
        Me.lblph.AutoSize = True
        Me.lblph.Location = New System.Drawing.Point(101, 24)
        Me.lblph.Name = "lblph"
        Me.lblph.Size = New System.Drawing.Size(43, 13)
        Me.lblph.TabIndex = 11
        Me.lblph.Text = "Label1"
        '
        'lblsss
        '
        Me.lblsss.AutoSize = True
        Me.lblsss.Location = New System.Drawing.Point(101, 71)
        Me.lblsss.Name = "lblsss"
        Me.lblsss.Size = New System.Drawing.Size(43, 13)
        Me.lblsss.TabIndex = 12
        Me.lblsss.Text = "Label4"
        '
        'lblpg
        '
        Me.lblpg.AutoSize = True
        Me.lblpg.Location = New System.Drawing.Point(101, 121)
        Me.lblpg.Name = "lblpg"
        Me.lblpg.Size = New System.Drawing.Size(49, 13)
        Me.lblpg.TabIndex = 13
        Me.lblpg.Text = "Label10"
        '
        'btnClear
        '
        Me.btnClear.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.btnClear.Location = New System.Drawing.Point(450, 29)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(75, 23)
        Me.btnClear.TabIndex = 197
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblRate
        '
        Me.lblRate.AutoSize = True
        Me.lblRate.Location = New System.Drawing.Point(101, 178)
        Me.lblRate.Name = "lblRate"
        Me.lblRate.Size = New System.Drawing.Size(49, 13)
        Me.lblRate.TabIndex = 15
        Me.lblRate.Text = "Label10"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 165)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 26)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "RATE PER " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "MIN :"
        '
        'btnCalculate
        '
        Me.btnCalculate.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.btnCalculate.Location = New System.Drawing.Point(75, 102)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(106, 23)
        Me.btnCalculate.TabIndex = 198
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(248, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Gross :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(248, 33)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 13)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Net :"
        '
        'lblgross
        '
        Me.lblgross.AutoSize = True
        Me.lblgross.Location = New System.Drawing.Point(314, 16)
        Me.lblgross.Name = "lblgross"
        Me.lblgross.Size = New System.Drawing.Size(49, 13)
        Me.lblgross.TabIndex = 6
        Me.lblgross.Text = "Gross :"
        '
        'lblnet
        '
        Me.lblnet.AutoSize = True
        Me.lblnet.Location = New System.Drawing.Point(314, 33)
        Me.lblnet.Name = "lblnet"
        Me.lblnet.Size = New System.Drawing.Size(49, 13)
        Me.lblnet.TabIndex = 7
        Me.lblnet.Text = "Gross :"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Consolas", 8.25!)
        Me.btnPrint.Location = New System.Drawing.Point(251, 63)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(106, 23)
        Me.btnPrint.TabIndex = 199
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'payrolls
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1054, 400)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtFilter)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "payrolls"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payroll"
        Me.gbMain.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents gbMain As GroupBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents lbltotalminutes As Label
    Friend WithEvents lbltotalhours As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents dtpfrom As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpto As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblid As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents txtFilter As TextBox
    Friend WithEvents btnSearch As Button
    Friend WithEvents lblpg As Label
    Friend WithEvents lblsss As Label
    Friend WithEvents lblph As Label
    Friend WithEvents btnClear As Button
    Friend WithEvents lblRate As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnCalculate As Button
    Friend WithEvents lblnet As Label
    Friend WithEvents lblgross As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPrint As Button
End Class
