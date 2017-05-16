<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToolsForm
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
        Me.lblSeperatorMoneyline = New System.Windows.Forms.Label()
        Me.lblLine = New System.Windows.Forms.Label()
        Me.txtLine = New System.Windows.Forms.TextBox()
        Me.lblKellyFraction = New System.Windows.Forms.Label()
        Me.cmbKellyFraction = New System.Windows.Forms.ComboBox()
        Me.lblProbSuccess = New System.Windows.Forms.Label()
        Me.txtKellyCriterion = New System.Windows.Forms.TextBox()
        Me.lblDecimalOdds = New System.Windows.Forms.Label()
        Me.btnCalculateKelly = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtProbSuccess = New System.Windows.Forms.TextBox()
        Me.lblKellyCriterion = New System.Windows.Forms.Label()
        Me.txtDecimalOdds = New System.Windows.Forms.TextBox()
        Me.lblImpliedProb1Spread = New System.Windows.Forms.Label()
        Me.txtImpliedProb1Spread = New System.Windows.Forms.TextBox()
        Me.txtImpliedProb2Spread = New System.Windows.Forms.TextBox()
        Me.txtOdds2Spread = New System.Windows.Forms.TextBox()
        Me.lblOdds1Spread = New System.Windows.Forms.Label()
        Me.txtOdds1Spread = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'lblSeperatorMoneyline
        '
        Me.lblSeperatorMoneyline.AutoSize = True
        Me.lblSeperatorMoneyline.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeperatorMoneyline.Location = New System.Drawing.Point(15, 148)
        Me.lblSeperatorMoneyline.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSeperatorMoneyline.Name = "lblSeperatorMoneyline"
        Me.lblSeperatorMoneyline.Size = New System.Drawing.Size(879, 36)
        Me.lblSeperatorMoneyline.TabIndex = 150
        Me.lblSeperatorMoneyline.Text = "______________________________________________________"
        '
        'lblLine
        '
        Me.lblLine.AutoSize = True
        Me.lblLine.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLine.Location = New System.Drawing.Point(318, 51)
        Me.lblLine.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLine.Name = "lblLine"
        Me.lblLine.Size = New System.Drawing.Size(47, 23)
        Me.lblLine.TabIndex = 149
        Me.lblLine.Text = "Line"
        Me.lblLine.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtLine
        '
        Me.txtLine.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLine.Location = New System.Drawing.Point(281, 83)
        Me.txtLine.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLine.Name = "txtLine"
        Me.txtLine.Size = New System.Drawing.Size(132, 44)
        Me.txtLine.TabIndex = 148
        '
        'lblKellyFraction
        '
        Me.lblKellyFraction.AutoSize = True
        Me.lblKellyFraction.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKellyFraction.Location = New System.Drawing.Point(621, 22)
        Me.lblKellyFraction.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKellyFraction.Name = "lblKellyFraction"
        Me.lblKellyFraction.Size = New System.Drawing.Size(80, 46)
        Me.lblKellyFraction.TabIndex = 147
        Me.lblKellyFraction.Text = "Kelly" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Fraction"
        Me.lblKellyFraction.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbKellyFraction
        '
        Me.cmbKellyFraction.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKellyFraction.FormattingEnabled = True
        Me.cmbKellyFraction.Items.AddRange(New Object() {"1", "1/2", "1/4"})
        Me.cmbKellyFraction.Location = New System.Drawing.Point(622, 83)
        Me.cmbKellyFraction.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbKellyFraction.Name = "cmbKellyFraction"
        Me.cmbKellyFraction.Size = New System.Drawing.Size(104, 44)
        Me.cmbKellyFraction.TabIndex = 146
        '
        'lblProbSuccess
        '
        Me.lblProbSuccess.AutoSize = True
        Me.lblProbSuccess.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProbSuccess.Location = New System.Drawing.Point(424, 22)
        Me.lblProbSuccess.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProbSuccess.Name = "lblProbSuccess"
        Me.lblProbSuccess.Size = New System.Drawing.Size(125, 46)
        Me.lblProbSuccess.TabIndex = 145
        Me.lblProbSuccess.Text = "Probability of" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Success"
        Me.lblProbSuccess.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtKellyCriterion
        '
        Me.txtKellyCriterion.Enabled = False
        Me.txtKellyCriterion.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKellyCriterion.Location = New System.Drawing.Point(22, 83)
        Me.txtKellyCriterion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtKellyCriterion.Name = "txtKellyCriterion"
        Me.txtKellyCriterion.Size = New System.Drawing.Size(132, 44)
        Me.txtKellyCriterion.TabIndex = 144
        '
        'lblDecimalOdds
        '
        Me.lblDecimalOdds.AutoSize = True
        Me.lblDecimalOdds.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDecimalOdds.Location = New System.Drawing.Point(989, 51)
        Me.lblDecimalOdds.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDecimalOdds.Name = "lblDecimalOdds"
        Me.lblDecimalOdds.Size = New System.Drawing.Size(80, 23)
        Me.lblDecimalOdds.TabIndex = 143
        Me.lblDecimalOdds.Text = "Decimal"
        '
        'btnCalculateKelly
        '
        Me.btnCalculateKelly.Location = New System.Drawing.Point(750, 82)
        Me.btnCalculateKelly.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCalculateKelly.Name = "btnCalculateKelly"
        Me.btnCalculateKelly.Size = New System.Drawing.Size(196, 54)
        Me.btnCalculateKelly.TabIndex = 142
        Me.btnCalculateKelly.Text = "Calculate Kelly"
        Me.btnCalculateKelly.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(228, 86)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 36)
        Me.Label10.TabIndex = 141
        Me.Label10.Text = "="
        '
        'txtProbSuccess
        '
        Me.txtProbSuccess.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProbSuccess.Location = New System.Drawing.Point(442, 83)
        Me.txtProbSuccess.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtProbSuccess.Name = "txtProbSuccess"
        Me.txtProbSuccess.Size = New System.Drawing.Size(132, 44)
        Me.txtProbSuccess.TabIndex = 140
        '
        'lblKellyCriterion
        '
        Me.lblKellyCriterion.AutoSize = True
        Me.lblKellyCriterion.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKellyCriterion.Location = New System.Drawing.Point(16, 26)
        Me.lblKellyCriterion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblKellyCriterion.Name = "lblKellyCriterion"
        Me.lblKellyCriterion.Size = New System.Drawing.Size(224, 36)
        Me.lblKellyCriterion.TabIndex = 139
        Me.lblKellyCriterion.Text = "Kelly Criterion"
        '
        'txtDecimalOdds
        '
        Me.txtDecimalOdds.Enabled = False
        Me.txtDecimalOdds.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDecimalOdds.Location = New System.Drawing.Point(976, 83)
        Me.txtDecimalOdds.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDecimalOdds.Name = "txtDecimalOdds"
        Me.txtDecimalOdds.Size = New System.Drawing.Size(110, 44)
        Me.txtDecimalOdds.TabIndex = 138
        '
        'lblImpliedProb1Spread
        '
        Me.lblImpliedProb1Spread.AutoSize = True
        Me.lblImpliedProb1Spread.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImpliedProb1Spread.Location = New System.Drawing.Point(191, 207)
        Me.lblImpliedProb1Spread.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblImpliedProb1Spread.Name = "lblImpliedProb1Spread"
        Me.lblImpliedProb1Spread.Size = New System.Drawing.Size(102, 46)
        Me.lblImpliedProb1Spread.TabIndex = 156
        Me.lblImpliedProb1Spread.Text = "Implied" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Probability"
        Me.lblImpliedProb1Spread.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtImpliedProb1Spread
        '
        Me.txtImpliedProb1Spread.Enabled = False
        Me.txtImpliedProb1Spread.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpliedProb1Spread.Location = New System.Drawing.Point(193, 267)
        Me.txtImpliedProb1Spread.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtImpliedProb1Spread.Name = "txtImpliedProb1Spread"
        Me.txtImpliedProb1Spread.Size = New System.Drawing.Size(132, 44)
        Me.txtImpliedProb1Spread.TabIndex = 155
        '
        'txtImpliedProb2Spread
        '
        Me.txtImpliedProb2Spread.Enabled = False
        Me.txtImpliedProb2Spread.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImpliedProb2Spread.Location = New System.Drawing.Point(193, 343)
        Me.txtImpliedProb2Spread.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtImpliedProb2Spread.Name = "txtImpliedProb2Spread"
        Me.txtImpliedProb2Spread.Size = New System.Drawing.Size(132, 44)
        Me.txtImpliedProb2Spread.TabIndex = 154
        '
        'txtOdds2Spread
        '
        Me.txtOdds2Spread.Enabled = False
        Me.txtOdds2Spread.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOdds2Spread.Location = New System.Drawing.Point(52, 343)
        Me.txtOdds2Spread.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOdds2Spread.Name = "txtOdds2Spread"
        Me.txtOdds2Spread.Size = New System.Drawing.Size(132, 44)
        Me.txtOdds2Spread.TabIndex = 153
        '
        'lblOdds1Spread
        '
        Me.lblOdds1Spread.AutoSize = True
        Me.lblOdds1Spread.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOdds1Spread.Location = New System.Drawing.Point(80, 233)
        Me.lblOdds1Spread.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOdds1Spread.Name = "lblOdds1Spread"
        Me.lblOdds1Spread.Size = New System.Drawing.Size(53, 23)
        Me.lblOdds1Spread.TabIndex = 152
        Me.lblOdds1Spread.Text = "Odds"
        '
        'txtOdds1Spread
        '
        Me.txtOdds1Spread.Enabled = False
        Me.txtOdds1Spread.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOdds1Spread.Location = New System.Drawing.Point(52, 267)
        Me.txtOdds1Spread.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtOdds1Spread.Name = "txtOdds1Spread"
        Me.txtOdds1Spread.Size = New System.Drawing.Size(132, 44)
        Me.txtOdds1Spread.TabIndex = 151
        '
        'ToolsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1207, 491)
        Me.Controls.Add(Me.lblImpliedProb1Spread)
        Me.Controls.Add(Me.txtImpliedProb1Spread)
        Me.Controls.Add(Me.txtImpliedProb2Spread)
        Me.Controls.Add(Me.txtOdds2Spread)
        Me.Controls.Add(Me.lblOdds1Spread)
        Me.Controls.Add(Me.txtOdds1Spread)
        Me.Controls.Add(Me.lblSeperatorMoneyline)
        Me.Controls.Add(Me.lblLine)
        Me.Controls.Add(Me.txtLine)
        Me.Controls.Add(Me.lblKellyFraction)
        Me.Controls.Add(Me.cmbKellyFraction)
        Me.Controls.Add(Me.lblProbSuccess)
        Me.Controls.Add(Me.txtKellyCriterion)
        Me.Controls.Add(Me.lblDecimalOdds)
        Me.Controls.Add(Me.btnCalculateKelly)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtProbSuccess)
        Me.Controls.Add(Me.lblKellyCriterion)
        Me.Controls.Add(Me.txtDecimalOdds)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "ToolsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ToolsForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblSeperatorMoneyline As Label
    Friend WithEvents lblLine As Label
    Friend WithEvents txtLine As TextBox
    Friend WithEvents lblKellyFraction As Label
    Friend WithEvents cmbKellyFraction As ComboBox
    Friend WithEvents lblProbSuccess As Label
    Friend WithEvents txtKellyCriterion As TextBox
    Friend WithEvents lblDecimalOdds As Label
    Friend WithEvents btnCalculateKelly As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txtProbSuccess As TextBox
    Friend WithEvents lblKellyCriterion As Label
    Friend WithEvents txtDecimalOdds As TextBox
    Friend WithEvents lblImpliedProb1Spread As Label
    Friend WithEvents txtImpliedProb1Spread As TextBox
    Friend WithEvents txtImpliedProb2Spread As TextBox
    Friend WithEvents txtOdds2Spread As TextBox
    Friend WithEvents lblOdds1Spread As Label
    Friend WithEvents txtOdds1Spread As TextBox
End Class
