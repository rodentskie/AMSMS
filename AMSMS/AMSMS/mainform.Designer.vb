<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainform
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
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.AdminToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageAccountsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageEmployeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManagePositionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManagePositionsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.VaultMonitoringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AttendanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SetCutOffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonitoringToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMain
        '
        Me.msMain.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdminToolStripMenuItem, Me.EmployeesToolStripMenuItem, Me.VaultMonitoringToolStripMenuItem, Me.AttendanceToolStripMenuItem})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(736, 26)
        Me.msMain.TabIndex = 1
        Me.msMain.Text = "msMain"
        '
        'AdminToolStripMenuItem
        '
        Me.AdminToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManageAccountsToolStripMenuItem})
        Me.AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        Me.AdminToolStripMenuItem.Size = New System.Drawing.Size(61, 22)
        Me.AdminToolStripMenuItem.Text = "Admin"
        '
        'ManageAccountsToolStripMenuItem
        '
        Me.ManageAccountsToolStripMenuItem.Name = "ManageAccountsToolStripMenuItem"
        Me.ManageAccountsToolStripMenuItem.Size = New System.Drawing.Size(184, 22)
        Me.ManageAccountsToolStripMenuItem.Text = "Manage Accounts"
        '
        'EmployeesToolStripMenuItem
        '
        Me.EmployeesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManageEmployeesToolStripMenuItem, Me.ManagePositionsToolStripMenuItem, Me.ManagePositionsToolStripMenuItem1})
        Me.EmployeesToolStripMenuItem.Name = "EmployeesToolStripMenuItem"
        Me.EmployeesToolStripMenuItem.Size = New System.Drawing.Size(88, 22)
        Me.EmployeesToolStripMenuItem.Text = "Employees"
        '
        'ManageEmployeesToolStripMenuItem
        '
        Me.ManageEmployeesToolStripMenuItem.Name = "ManageEmployeesToolStripMenuItem"
        Me.ManageEmployeesToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ManageEmployeesToolStripMenuItem.Text = "Manage Employees"
        '
        'ManagePositionsToolStripMenuItem
        '
        Me.ManagePositionsToolStripMenuItem.Name = "ManagePositionsToolStripMenuItem"
        Me.ManagePositionsToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.ManagePositionsToolStripMenuItem.Text = "Manage Logins"
        '
        'ManagePositionsToolStripMenuItem1
        '
        Me.ManagePositionsToolStripMenuItem1.Name = "ManagePositionsToolStripMenuItem1"
        Me.ManagePositionsToolStripMenuItem1.Size = New System.Drawing.Size(196, 22)
        Me.ManagePositionsToolStripMenuItem1.Text = "Manage Positions"
        '
        'VaultMonitoringToolStripMenuItem
        '
        Me.VaultMonitoringToolStripMenuItem.Name = "VaultMonitoringToolStripMenuItem"
        Me.VaultMonitoringToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.VaultMonitoringToolStripMenuItem.Text = "Vault Monitoring"
        '
        'AttendanceToolStripMenuItem
        '
        Me.AttendanceToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SetCutOffToolStripMenuItem, Me.MonitoringToolStripMenuItem})
        Me.AttendanceToolStripMenuItem.Name = "AttendanceToolStripMenuItem"
        Me.AttendanceToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
        Me.AttendanceToolStripMenuItem.Text = "Attendance"
        '
        'SetCutOffToolStripMenuItem
        '
        Me.SetCutOffToolStripMenuItem.Name = "SetCutOffToolStripMenuItem"
        Me.SetCutOffToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SetCutOffToolStripMenuItem.Text = "Set Cut Off"
        '
        'MonitoringToolStripMenuItem
        '
        Me.MonitoringToolStripMenuItem.Name = "MonitoringToolStripMenuItem"
        Me.MonitoringToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MonitoringToolStripMenuItem.Text = "Monitoring"
        '
        'mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 320)
        Me.Controls.Add(Me.msMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.msMain
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "mainform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attendance Monitoring and Security Management System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents msMain As MenuStrip
    Friend WithEvents AdminToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageAccountsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageEmployeesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManagePositionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManagePositionsToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents VaultMonitoringToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AttendanceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SetCutOffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MonitoringToolStripMenuItem As ToolStripMenuItem
End Class
