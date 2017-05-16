<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MarchMadness
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
        Me.txtTeam2 = New System.Windows.Forms.TextBox()
        Me.txtTeam1 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtTeam1Grade = New System.Windows.Forms.TextBox()
        Me.txtTeam2Grade = New System.Windows.Forms.TextBox()
        Me.lblGrade = New System.Windows.Forms.Label()
        Me.btnGetData = New System.Windows.Forms.Button()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StocksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WatchListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveStockToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PortfolioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddStockToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.RemoveStockToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.BetsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddBetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarchMadnessToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompareTeamsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveBracketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblTeam = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtTeam2
        '
        Me.txtTeam2.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeam2.Location = New System.Drawing.Point(16, 185)
        Me.txtTeam2.Name = "txtTeam2"
        Me.txtTeam2.Size = New System.Drawing.Size(211, 44)
        Me.txtTeam2.TabIndex = 80
        '
        'txtTeam1
        '
        Me.txtTeam1.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeam1.Location = New System.Drawing.Point(16, 123)
        Me.txtTeam1.Name = "txtTeam1"
        Me.txtTeam1.Size = New System.Drawing.Size(211, 44)
        Me.txtTeam1.TabIndex = 79
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(244, 59)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1062, 190)
        Me.DataGridView1.TabIndex = 82
        '
        'txtTeam1Grade
        '
        Me.txtTeam1Grade.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeam1Grade.Location = New System.Drawing.Point(1315, 123)
        Me.txtTeam1Grade.Name = "txtTeam1Grade"
        Me.txtTeam1Grade.Size = New System.Drawing.Size(92, 44)
        Me.txtTeam1Grade.TabIndex = 83
        '
        'txtTeam2Grade
        '
        Me.txtTeam2Grade.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeam2Grade.Location = New System.Drawing.Point(1315, 185)
        Me.txtTeam2Grade.Name = "txtTeam2Grade"
        Me.txtTeam2Grade.Size = New System.Drawing.Size(92, 44)
        Me.txtTeam2Grade.TabIndex = 84
        '
        'lblGrade
        '
        Me.lblGrade.AutoSize = True
        Me.lblGrade.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrade.Location = New System.Drawing.Point(1312, 84)
        Me.lblGrade.Name = "lblGrade"
        Me.lblGrade.Size = New System.Drawing.Size(101, 36)
        Me.lblGrade.TabIndex = 85
        Me.lblGrade.Text = "Grade"
        '
        'btnGetData
        '
        Me.btnGetData.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGetData.Location = New System.Drawing.Point(664, 279)
        Me.btnGetData.Name = "btnGetData"
        Me.btnGetData.Size = New System.Drawing.Size(206, 61)
        Me.btnGetData.TabIndex = 86
        Me.btnGetData.Text = "Get Data"
        Me.btnGetData.UseVisualStyleBackColor = True
        '
        'MenuStrip
        '
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.StocksToolStripMenuItem, Me.BetsToolStripMenuItem, Me.MarchMadnessToolStripMenuItem1})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1424, 24)
        Me.MenuStrip.TabIndex = 87
        Me.MenuStrip.Text = "Menu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'StocksToolStripMenuItem
        '
        Me.StocksToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.WatchListToolStripMenuItem, Me.PortfolioToolStripMenuItem})
        Me.StocksToolStripMenuItem.Name = "StocksToolStripMenuItem"
        Me.StocksToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.StocksToolStripMenuItem.Text = "Stocks"
        '
        'WatchListToolStripMenuItem
        '
        Me.WatchListToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddStockToolStripMenuItem, Me.RemoveStockToolStripMenuItem})
        Me.WatchListToolStripMenuItem.Name = "WatchListToolStripMenuItem"
        Me.WatchListToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.WatchListToolStripMenuItem.Text = "Watch List"
        '
        'AddStockToolStripMenuItem
        '
        Me.AddStockToolStripMenuItem.Name = "AddStockToolStripMenuItem"
        Me.AddStockToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.AddStockToolStripMenuItem.Text = "Add Stock"
        '
        'RemoveStockToolStripMenuItem
        '
        Me.RemoveStockToolStripMenuItem.Name = "RemoveStockToolStripMenuItem"
        Me.RemoveStockToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.RemoveStockToolStripMenuItem.Text = "Remove Stock"
        '
        'PortfolioToolStripMenuItem
        '
        Me.PortfolioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddStockToolStripMenuItem1, Me.RemoveStockToolStripMenuItem1})
        Me.PortfolioToolStripMenuItem.Name = "PortfolioToolStripMenuItem"
        Me.PortfolioToolStripMenuItem.Size = New System.Drawing.Size(129, 22)
        Me.PortfolioToolStripMenuItem.Text = "Portfolio"
        '
        'AddStockToolStripMenuItem1
        '
        Me.AddStockToolStripMenuItem1.Name = "AddStockToolStripMenuItem1"
        Me.AddStockToolStripMenuItem1.Size = New System.Drawing.Size(149, 22)
        Me.AddStockToolStripMenuItem1.Text = "Add Stock"
        '
        'RemoveStockToolStripMenuItem1
        '
        Me.RemoveStockToolStripMenuItem1.Name = "RemoveStockToolStripMenuItem1"
        Me.RemoveStockToolStripMenuItem1.Size = New System.Drawing.Size(149, 22)
        Me.RemoveStockToolStripMenuItem1.Text = "Remove Stock"
        '
        'BetsToolStripMenuItem
        '
        Me.BetsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddBetToolStripMenuItem})
        Me.BetsToolStripMenuItem.Name = "BetsToolStripMenuItem"
        Me.BetsToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.BetsToolStripMenuItem.Text = "Bets"
        '
        'AddBetToolStripMenuItem
        '
        Me.AddBetToolStripMenuItem.Name = "AddBetToolStripMenuItem"
        Me.AddBetToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AddBetToolStripMenuItem.Text = "Add Bet"
        '
        'MarchMadnessToolStripMenuItem1
        '
        Me.MarchMadnessToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CompareTeamsToolStripMenuItem, Me.SaveBracketToolStripMenuItem})
        Me.MarchMadnessToolStripMenuItem1.Name = "MarchMadnessToolStripMenuItem1"
        Me.MarchMadnessToolStripMenuItem1.Size = New System.Drawing.Size(103, 20)
        Me.MarchMadnessToolStripMenuItem1.Text = "March Madness"
        '
        'CompareTeamsToolStripMenuItem
        '
        Me.CompareTeamsToolStripMenuItem.Name = "CompareTeamsToolStripMenuItem"
        Me.CompareTeamsToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.CompareTeamsToolStripMenuItem.Text = "Compare Teams"
        '
        'SaveBracketToolStripMenuItem
        '
        Me.SaveBracketToolStripMenuItem.Name = "SaveBracketToolStripMenuItem"
        Me.SaveBracketToolStripMenuItem.Size = New System.Drawing.Size(161, 22)
        Me.SaveBracketToolStripMenuItem.Text = "Save Bracket"
        '
        'lblTeam
        '
        Me.lblTeam.AutoSize = True
        Me.lblTeam.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTeam.Location = New System.Drawing.Point(72, 84)
        Me.lblTeam.Name = "lblTeam"
        Me.lblTeam.Size = New System.Drawing.Size(102, 36)
        Me.lblTeam.TabIndex = 81
        Me.lblTeam.Text = "Teams"
        '
        'MarchMadness
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1424, 352)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.btnGetData)
        Me.Controls.Add(Me.lblGrade)
        Me.Controls.Add(Me.txtTeam2Grade)
        Me.Controls.Add(Me.txtTeam1Grade)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtTeam2)
        Me.Controls.Add(Me.lblTeam)
        Me.Controls.Add(Me.txtTeam1)
        Me.Name = "MarchMadness"
        Me.Text = "MarchMadness"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtTeam2 As TextBox
    Friend WithEvents txtTeam1 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents txtTeam1Grade As TextBox
    Friend WithEvents txtTeam2Grade As TextBox
    Friend WithEvents lblGrade As Label
    Friend WithEvents btnGetData As Button
    Friend WithEvents MenuStrip As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents StocksToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WatchListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddStockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RemoveStockToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PortfolioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddStockToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents RemoveStockToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BetsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddBetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MarchMadnessToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents CompareTeamsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveBracketToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblTeam As Label
End Class
