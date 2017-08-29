<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WebScraperTEST
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
        Me.btnExtract = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.lblURL = New System.Windows.Forms.Label()
        Me.lblSelectSport = New System.Windows.Forms.Label()
        Me.dgvTableDisplay = New System.Windows.Forms.DataGridView()
        Me.lblTableName = New System.Windows.Forms.Label()
        Me.cmbSelectSport = New System.Windows.Forms.ComboBox()
        Me.cmbSelectStat = New System.Windows.Forms.ComboBox()
        Me.lblSelectStat = New System.Windows.Forms.Label()
        Me.cmbSelectSeason = New System.Windows.Forms.ComboBox()
        Me.lblSelectSeason = New System.Windows.Forms.Label()
        Me.cmbSelectTeam = New System.Windows.Forms.ComboBox()
        Me.lblSelectTeam = New System.Windows.Forms.Label()
        Me.btnUpdateDB = New System.Windows.Forms.Button()
        Me.btnToExcel = New System.Windows.Forms.Button()
        CType(Me.dgvTableDisplay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExtract
        '
        Me.btnExtract.BackColor = System.Drawing.Color.Azure
        Me.btnExtract.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExtract.Location = New System.Drawing.Point(550, 49)
        Me.btnExtract.Name = "btnExtract"
        Me.btnExtract.Size = New System.Drawing.Size(137, 41)
        Me.btnExtract.TabIndex = 2
        Me.btnExtract.Text = "Extract"
        Me.btnExtract.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.Azure
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(550, 95)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(137, 41)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'txtURL
        '
        Me.txtURL.BackColor = System.Drawing.Color.Honeydew
        Me.txtURL.Font = New System.Drawing.Font("Modern No. 20", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtURL.Location = New System.Drawing.Point(618, 22)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(69, 21)
        Me.txtURL.TabIndex = 5
        '
        'lblURL
        '
        Me.lblURL.AutoSize = True
        Me.lblURL.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblURL.Location = New System.Drawing.Point(545, 18)
        Me.lblURL.Name = "lblURL"
        Me.lblURL.Size = New System.Drawing.Size(74, 25)
        Me.lblURL.TabIndex = 4
        Me.lblURL.Text = "URL :"
        '
        'lblSelectSport
        '
        Me.lblSelectSport.AutoSize = True
        Me.lblSelectSport.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectSport.Location = New System.Drawing.Point(29, 42)
        Me.lblSelectSport.Name = "lblSelectSport"
        Me.lblSelectSport.Size = New System.Drawing.Size(88, 25)
        Me.lblSelectSport.TabIndex = 7
        Me.lblSelectSport.Text = "SPORT"
        '
        'dgvTableDisplay
        '
        Me.dgvTableDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTableDisplay.Location = New System.Drawing.Point(18, 206)
        Me.dgvTableDisplay.Name = "dgvTableDisplay"
        Me.dgvTableDisplay.Size = New System.Drawing.Size(711, 346)
        Me.dgvTableDisplay.TabIndex = 8
        '
        'lblTableName
        '
        Me.lblTableName.AutoSize = True
        Me.lblTableName.Font = New System.Drawing.Font("Modern No. 20", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTableName.Location = New System.Drawing.Point(200, 174)
        Me.lblTableName.Name = "lblTableName"
        Me.lblTableName.Size = New System.Drawing.Size(0, 29)
        Me.lblTableName.TabIndex = 9
        '
        'cmbSelectSport
        '
        Me.cmbSelectSport.BackColor = System.Drawing.Color.Honeydew
        Me.cmbSelectSport.FormattingEnabled = True
        Me.cmbSelectSport.Items.AddRange(New Object() {"NFL", "NBA", "NCAA BASKETBALL", "NCAA FOOTBALL"})
        Me.cmbSelectSport.Location = New System.Drawing.Point(121, 40)
        Me.cmbSelectSport.Name = "cmbSelectSport"
        Me.cmbSelectSport.Size = New System.Drawing.Size(350, 28)
        Me.cmbSelectSport.TabIndex = 10
        '
        'cmbSelectStat
        '
        Me.cmbSelectStat.BackColor = System.Drawing.Color.Honeydew
        Me.cmbSelectStat.FormattingEnabled = True
        Me.cmbSelectStat.Location = New System.Drawing.Point(121, 108)
        Me.cmbSelectStat.Name = "cmbSelectStat"
        Me.cmbSelectStat.Size = New System.Drawing.Size(350, 28)
        Me.cmbSelectStat.TabIndex = 12
        '
        'lblSelectStat
        '
        Me.lblSelectStat.AutoSize = True
        Me.lblSelectStat.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectStat.Location = New System.Drawing.Point(45, 110)
        Me.lblSelectStat.Name = "lblSelectStat"
        Me.lblSelectStat.Size = New System.Drawing.Size(72, 25)
        Me.lblSelectStat.TabIndex = 11
        Me.lblSelectStat.Text = "STAT"
        '
        'cmbSelectSeason
        '
        Me.cmbSelectSeason.BackColor = System.Drawing.Color.Honeydew
        Me.cmbSelectSeason.FormattingEnabled = True
        Me.cmbSelectSeason.Location = New System.Drawing.Point(120, 6)
        Me.cmbSelectSeason.Name = "cmbSelectSeason"
        Me.cmbSelectSeason.Size = New System.Drawing.Size(350, 28)
        Me.cmbSelectSeason.TabIndex = 14
        '
        'lblSelectSeason
        '
        Me.lblSelectSeason.AutoSize = True
        Me.lblSelectSeason.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectSeason.Location = New System.Drawing.Point(13, 9)
        Me.lblSelectSeason.Name = "lblSelectSeason"
        Me.lblSelectSeason.Size = New System.Drawing.Size(104, 25)
        Me.lblSelectSeason.TabIndex = 13
        Me.lblSelectSeason.Text = "SEASON"
        '
        'cmbSelectTeam
        '
        Me.cmbSelectTeam.BackColor = System.Drawing.Color.Honeydew
        Me.cmbSelectTeam.FormattingEnabled = True
        Me.cmbSelectTeam.Location = New System.Drawing.Point(121, 74)
        Me.cmbSelectTeam.Name = "cmbSelectTeam"
        Me.cmbSelectTeam.Size = New System.Drawing.Size(350, 28)
        Me.cmbSelectTeam.TabIndex = 16
        '
        'lblSelectTeam
        '
        Me.lblSelectTeam.AutoSize = True
        Me.lblSelectTeam.Font = New System.Drawing.Font("Modern No. 20", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSelectTeam.Location = New System.Drawing.Point(37, 76)
        Me.lblSelectTeam.Name = "lblSelectTeam"
        Me.lblSelectTeam.Size = New System.Drawing.Size(82, 25)
        Me.lblSelectTeam.TabIndex = 15
        Me.lblSelectTeam.Text = "TEAM"
        '
        'btnUpdateDB
        '
        Me.btnUpdateDB.BackColor = System.Drawing.Color.Azure
        Me.btnUpdateDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateDB.Location = New System.Drawing.Point(120, 558)
        Me.btnUpdateDB.Name = "btnUpdateDB"
        Me.btnUpdateDB.Size = New System.Drawing.Size(157, 41)
        Me.btnUpdateDB.TabIndex = 17
        Me.btnUpdateDB.Text = "Update DB"
        Me.btnUpdateDB.UseVisualStyleBackColor = False
        '
        'btnToExcel
        '
        Me.btnToExcel.BackColor = System.Drawing.Color.Azure
        Me.btnToExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnToExcel.Location = New System.Drawing.Point(440, 558)
        Me.btnToExcel.Name = "btnToExcel"
        Me.btnToExcel.Size = New System.Drawing.Size(157, 41)
        Me.btnToExcel.TabIndex = 18
        Me.btnToExcel.Text = "To Excel"
        Me.btnToExcel.UseVisualStyleBackColor = False
        '
        'WebScraperTEST
        '
        Me.AcceptButton = Me.btnExtract
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(740, 607)
        Me.Controls.Add(Me.btnToExcel)
        Me.Controls.Add(Me.btnUpdateDB)
        Me.Controls.Add(Me.cmbSelectTeam)
        Me.Controls.Add(Me.lblSelectTeam)
        Me.Controls.Add(Me.cmbSelectSeason)
        Me.Controls.Add(Me.lblSelectSeason)
        Me.Controls.Add(Me.cmbSelectStat)
        Me.Controls.Add(Me.lblSelectStat)
        Me.Controls.Add(Me.cmbSelectSport)
        Me.Controls.Add(Me.lblTableName)
        Me.Controls.Add(Me.dgvTableDisplay)
        Me.Controls.Add(Me.lblSelectSport)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.lblURL)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnExtract)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "WebScraperTEST"
        Me.Text = "WebScraperTEST"
        CType(Me.dgvTableDisplay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExtract As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents txtURL As TextBox
    Friend WithEvents lblURL As Label
    Friend WithEvents lblSelectSport As Label
    Friend WithEvents dgvTableDisplay As DataGridView
    Friend WithEvents lblTableName As Label
    Friend WithEvents cmbSelectSport As ComboBox
    Friend WithEvents cmbSelectStat As ComboBox
    Friend WithEvents lblSelectStat As Label
    Friend WithEvents cmbSelectSeason As ComboBox
    Friend WithEvents lblSelectSeason As Label
    Friend WithEvents cmbSelectTeam As ComboBox
    Friend WithEvents lblSelectTeam As Label
    Friend WithEvents btnUpdateDB As Button
    Friend WithEvents btnToExcel As Button
End Class
