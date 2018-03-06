<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WebScraperForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnScrape = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblSelectSport = New System.Windows.Forms.Label()
        Me.dgvTableDisplay = New System.Windows.Forms.DataGridView()
        Me.lblTableName = New System.Windows.Forms.Label()
        Me.cmbSelectSport = New System.Windows.Forms.ComboBox()
        Me.cmbSelectStat = New System.Windows.Forms.ComboBox()
        Me.lblSelectStat = New System.Windows.Forms.Label()
        Me.cmbSelectSeason = New System.Windows.Forms.ComboBox()
        Me.lblSelectSeason = New System.Windows.Forms.Label()
        Me.cmbSelectTeam1 = New System.Windows.Forms.ComboBox()
        Me.lblSelectTeam1 = New System.Windows.Forms.Label()
        Me.btnUpdateDB = New System.Windows.Forms.Button()
        Me.btnToExcel = New System.Windows.Forms.Button()
        Me.cmbSelectTeam2 = New System.Windows.Forms.ComboBox()
        Me.lblSelectTeam2 = New System.Windows.Forms.Label()
        Me.btnAddCols = New System.Windows.Forms.Button()
        Me.txtFilename = New System.Windows.Forms.TextBox()
        Me.lblFilename = New System.Windows.Forms.Label()
        CType(Me.dgvTableDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnScrape
        '
        Me.btnScrape.BackColor = System.Drawing.Color.Azure
        Me.btnScrape.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnScrape.Location = New System.Drawing.Point(549, 31)
        Me.btnScrape.Name = "btnScrape"
        Me.btnScrape.Size = New System.Drawing.Size(152, 47)
        Me.btnScrape.TabIndex = 2
        Me.btnScrape.Text = "Scrape"
        Me.btnScrape.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Azure
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(549, 91)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(152, 47)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'lblSelectSport
        '
        Me.lblSelectSport.AutoSize = True
        Me.lblSelectSport.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectSport.Location = New System.Drawing.Point(29, 8)
        Me.lblSelectSport.Name = "lblSelectSport"
        Me.lblSelectSport.Size = New System.Drawing.Size(107, 31)
        Me.lblSelectSport.TabIndex = 7
        Me.lblSelectSport.Text = "SPORT"
        '
        'dgvTableDisplay
        '
        Me.dgvTableDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTableDisplay.Location = New System.Drawing.Point(19, 289)
        Me.dgvTableDisplay.Name = "dgvTableDisplay"
        Me.dgvTableDisplay.Size = New System.Drawing.Size(711, 406)
        Me.dgvTableDisplay.TabIndex = 8
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Font = New System.Drawing.Font("Modern No. 20", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableName.Location = New System.Drawing.Point(200, 239)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(0, 35)
        Me.lblTableName.TabIndex = 9
        '
        'cmbSelectSport
        '
        Me.cmbSelectSport.BackColor = System.Drawing.Color.Honeydew
        Me.cmbSelectSport.FormattingEnabled = True
        Me.cmbSelectSport.Items.AddRange(New Object() {"NFL", "NBA", "NCAA BASKETBALL", "NCAA FOOTBALL"})
        Me.cmbSelectSport.Location = New System.Drawing.Point(157, 7)
        Me.cmbSelectSport.Name = "cmbSelectSport"
        Me.cmbSelectSport.Size = New System.Drawing.Size(350, 33)
        Me.cmbSelectSport.TabIndex = 10
        '
        'cmbSelectStat
        '
        Me.cmbSelectStat.BackColor = System.Drawing.Color.Honeydew
        Me.cmbSelectStat.FormattingEnabled = True
        Me.cmbSelectStat.Location = New System.Drawing.Point(157, 163)
        Me.cmbSelectStat.Name = "cmbSelectStat"
        Me.cmbSelectStat.Size = New System.Drawing.Size(350, 33)
        Me.cmbSelectStat.TabIndex = 12
        '
        'lblSelectStat
        '
        Me.lblSelectStat.AutoSize = True
        Me.lblSelectStat.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectStat.Location = New System.Drawing.Point(45, 164)
        Me.lblSelectStat.Name = "lblSelectStat"
        Me.lblSelectStat.Size = New System.Drawing.Size(87, 31)
        Me.lblSelectStat.TabIndex = 11
        Me.lblSelectStat.Text = "STAT"
        '
        'cmbSelectSeason
        '
        Me.cmbSelectSeason.BackColor = System.Drawing.Color.Honeydew
        Me.cmbSelectSeason.FormattingEnabled = True
        Me.cmbSelectSeason.Location = New System.Drawing.Point(157, 46)
        Me.cmbSelectSeason.Name = "cmbSelectSeason"
        Me.cmbSelectSeason.Size = New System.Drawing.Size(350, 33)
        Me.cmbSelectSeason.TabIndex = 14
        '
        'lblSelectSeason
        '
        Me.lblSelectSeason.AutoSize = True
        Me.lblSelectSeason.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectSeason.Location = New System.Drawing.Point(13, 48)
        Me.lblSelectSeason.Name = "lblSelectSeason"
        Me.lblSelectSeason.Size = New System.Drawing.Size(128, 31)
        Me.lblSelectSeason.TabIndex = 13
        Me.lblSelectSeason.Text = "SEASON"
        '
        'cmbSelectTeam1
        '
        Me.cmbSelectTeam1.BackColor = System.Drawing.Color.Honeydew
        Me.cmbSelectTeam1.FormattingEnabled = True
        Me.cmbSelectTeam1.Location = New System.Drawing.Point(157, 85)
        Me.cmbSelectTeam1.Name = "cmbSelectTeam1"
        Me.cmbSelectTeam1.Size = New System.Drawing.Size(350, 33)
        Me.cmbSelectTeam1.TabIndex = 16
        '
        'lblSelectTeam1
        '
        Me.lblSelectTeam1.AutoSize = True
        Me.lblSelectTeam1.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectTeam1.Location = New System.Drawing.Point(27, 85)
        Me.lblSelectTeam1.Name = "lblSelectTeam1"
        Me.lblSelectTeam1.Size = New System.Drawing.Size(114, 31)
        Me.lblSelectTeam1.TabIndex = 15
        Me.lblSelectTeam1.Text = "TEAM1"
        '
        'btnUpdateDB
        '
        Me.btnUpdateDB.BackColor = System.Drawing.Color.Azure
        Me.btnUpdateDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateDB.Location = New System.Drawing.Point(452, 715)
        Me.btnUpdateDB.Name = "btnUpdateDB"
        Me.btnUpdateDB.Size = New System.Drawing.Size(175, 47)
        Me.btnUpdateDB.TabIndex = 17
        Me.btnUpdateDB.Text = "Update DB"
        Me.btnUpdateDB.UseVisualStyleBackColor = False
        '
        'btnToExcel
        '
        Me.btnToExcel.BackColor = System.Drawing.Color.Azure
        Me.btnToExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToExcel.Location = New System.Drawing.Point(147, 715)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(185, 47)
        Me.btnToExcel.TabIndex = 18
        Me.btnToExcel.Text = "To Excel"
        Me.btnToExcel.UseVisualStyleBackColor = False
        '
        'cmbSelectTeam2
        '
        Me.cmbSelectTeam2.BackColor = System.Drawing.Color.Honeydew
        Me.cmbSelectTeam2.Enabled = False
        Me.cmbSelectTeam2.FormattingEnabled = True
        Me.cmbSelectTeam2.Location = New System.Drawing.Point(157, 124)
        Me.cmbSelectTeam2.Name = "cmbSelectTeam2"
        Me.cmbSelectTeam2.Size = New System.Drawing.Size(350, 33)
        Me.cmbSelectTeam2.TabIndex = 20
        '
        'lblSelectTeam2
        '
        Me.lblSelectTeam2.AutoSize = True
        Me.lblSelectTeam2.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectTeam2.Location = New System.Drawing.Point(27, 124)
        Me.lblSelectTeam2.Name = "lblSelectTeam2"
        Me.lblSelectTeam2.Size = New System.Drawing.Size(114, 31)
        Me.lblSelectTeam2.TabIndex = 19
        Me.lblSelectTeam2.Text = "TEAM2"
        '
        'btnAddCols
        '
        Me.btnAddCols.BackColor = System.Drawing.Color.Azure
        Me.btnAddCols.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAddCols.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddCols.Location = New System.Drawing.Point(549, 149)
        Me.btnAddCols.Name = "btnAddCols"
        Me.btnAddCols.Size = New System.Drawing.Size(152, 47)
        Me.btnAddCols.TabIndex = 21
        Me.btnAddCols.Text = "Add Cols"
        Me.btnAddCols.UseVisualStyleBackColor = False
        '
        'txtFilename
        '
        Me.txtFilename.Location = New System.Drawing.Point(193, 203)
        Me.txtFilename.Name = "txtFilename"
        Me.txtFilename.Size = New System.Drawing.Size(314, 30)
        Me.txtFilename.TabIndex = 22
        '
        'lblFilename
        '
        Me.lblFilename.AutoSize = True
        Me.lblFilename.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFilename.Location = New System.Drawing.Point(12, 203)
        Me.lblFilename.Name = "lblFilename"
        Me.lblFilename.Size = New System.Drawing.Size(175, 31)
        Me.lblFilename.TabIndex = 23
        Me.lblFilename.Text = "FILENAME"
        '
        'WebScraperForm
        '
        Me.AcceptButton = Me.btnScrape
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(740, 774)
        Me.Controls.Add(Me.lblFilename)
        Me.Controls.Add(Me.txtFilename)
        Me.Controls.Add(Me.btnAddCols)
        Me.Controls.Add(Me.cmbSelectTeam2)
        Me.Controls.Add(Me.lblSelectTeam2)
        Me.Controls.Add(Me.btnToExcel)
        Me.Controls.Add(Me.btnUpdateDB)
        Me.Controls.Add(Me.cmbSelectTeam1)
        Me.Controls.Add(Me.lblSelectTeam1)
        Me.Controls.Add(Me.cmbSelectSeason)
        Me.Controls.Add(Me.lblSelectSeason)
        Me.Controls.Add(Me.cmbSelectStat)
        Me.Controls.Add(Me.lblSelectStat)
        Me.Controls.Add(Me.cmbSelectSport)
        Me.Controls.Add(Me.lblTableName)
        Me.Controls.Add(Me.dgvTableDisplay)
        Me.Controls.Add(Me.lblSelectSport)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnScrape)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "WebScraperForm"
        Me.Text = "WebScraperTEST"
        CType(Me.dgvTableDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnScrape As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents lblSelectSport As Label
    Friend WithEvents dgvTableDisplay As DataGridView
    Friend WithEvents lblTableName As Label
    Friend WithEvents cmbSelectSport As ComboBox
    Friend WithEvents cmbSelectStat As ComboBox
    Friend WithEvents lblSelectStat As Label
    Friend WithEvents cmbSelectSeason As ComboBox
    Friend WithEvents lblSelectSeason As Label
    Friend WithEvents cmbSelectTeam1 As ComboBox
    Friend WithEvents lblSelectTeam1 As Label
    Friend WithEvents btnUpdateDB As Button
    Friend WithEvents btnToExcel As Button
    Friend WithEvents cmbSelectTeam2 As ComboBox
    Friend WithEvents lblSelectTeam2 As Label
    Friend WithEvents btnAddCols As Button
    Friend WithEvents txtFilename As TextBox
    Friend WithEvents lblFilename As Label
End Class
