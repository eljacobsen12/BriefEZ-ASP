Imports System.Text.RegularExpressions

Public Class MoneyManager

    '*************************************
    '**************VALIDATORS*************
    Private Sub txtLineOdds_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not Char.IsNumber(e.KeyChar) AndAlso Not Char.IsControl(e.KeyChar) Then 'Add Decimals: AndAlso Not e.KeyChar = "."
            e.Handled = True
        End If
    End Sub

    Private Sub txtLineOdds_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim digitsOnly As Regex = New Regex("[^\d]")
        txtOdds1Spread.Text = digitsOnly.Replace(txtOdds1Spread.Text, "")
    End Sub
    '*************************************

    Private Sub MoneyManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSelectSport.SelectedText = "NCAA BASKETBALL"
        If cmbSelectSport.SelectedText.ToString <> "NCAA BASKETBALL" Then
            MarchMadnessToolStripMenuItem1.Visible = False
            MarchMadnessToolStripMenuItem1.Enabled = False
        ElseIf cmbSelectSport.SelectedText.ToString = "NFL FOOTBALL" Or cmbSelectSport.SelectedText.ToString = "NBA BASKETBALL" Then
            btnDKLinkSpread.Visible = True
            btnDKLinkSpread.Enabled = True
        End If
    End Sub


    Private Sub cmbWinLoss_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWinLossSpread.SelectedIndexChanged
        If cmbWinLossSpread.SelectedText = "Win" Then
            cmbWinLossSpread.ForeColor = Color.Green
        ElseIf cmbWinLossSpread.SelectedText = "Loss" Then
            cmbWinLossSpread.ForeColor = Color.Red
        End If
    End Sub

    Private Sub cmbWinLossMoneyline_SelectedIndexChanged(sender As Object, e As EventArgs)
        If cmbWinLossSpread.SelectedText = "Win" Then
            cmbWinLossSpread.ForeColor = Color.Green
        ElseIf cmbWinLossSpread.SelectedText = "Loss" Then
            cmbWinLossSpread.ForeColor = Color.Red
        End If
    End Sub

    Private Sub CompareTeamsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompareTeamsToolStripMenuItem.Click
        MarchMadnessForm.Show()
    End Sub

    Private Sub txtSpread1Spread_TextChanged(sender As Object, e As EventArgs) Handles txtSpread1Spread.TextChanged, txtSpread2Spread.TextChanged, txtOdds1Spread.TextChanged, txtOdds2Spread.TextChanged, txtStakeSpread.TextChanged
        If txtSpread1Spread.Text <> Nothing AndAlso txtSpread2Spread.Text <> Nothing AndAlso txtOdds1Spread.Text <> Nothing AndAlso txtOdds2Spread.Text <> Nothing Then
            If txtStakeSpread.Text <> Nothing Then
                Dim oddsTeam1 As Decimal = getDecimalOdds(Val(txtOdds1Spread.Text))
                Dim oddsTeam2 As Decimal = getDecimalOdds(Val(txtOdds2Spread.Text))
                txtProfit1Spread.Text = Val(txtStakeSpread.Text) * oddsTeam1
                txtProfit2Spread.Text = Val(txtStakeSpread.Text) * oddsTeam2
            Else
                txtProfit1Spread.Text = ""
                txtProfit2Spread.Text = ""
            End If

        End If
    End Sub

    Private Sub btnCommitToPortfolio_Click(sender As Object, e As EventArgs) Handles btnCommitSpread.Click
        If txtSpread1Spread.Text <> Nothing AndAlso txtSpread2Spread.Text <> Nothing AndAlso txtOdds1Spread.Text <> Nothing AndAlso txtOdds2Spread.Text <> Nothing AndAlso txtTeam1Spread.Text <> Nothing AndAlso txtTeam2Spread.Text <> Nothing AndAlso txtStakeSpread.Text <> Nothing AndAlso cmbWinLossSpread.Text <> Nothing Then
            If Not radTeam1Spread.Checked And Not radTeam2Spread.Checked Then
                MsgBox("Please select a team.")
            Else
                Dim myExcel As Microsoft.Office.Interop.Excel.Worksheet = Nothing
                Select Case cmbSelectSport.SelectedText
                    Case "NCAA BASKETBALL"
                        myExcel = getExcelSheet("NCAA BASKETBALL", tabsBets.SelectedTab.Text)
                    Case "NCAA FOOTBALL"
                        myExcel = getExcelSheet("NCAA FOOTBALL", tabsBets.SelectedTab.Text)
                    Case "NBA BASKETBALL"
                        myExcel = getExcelSheet("NBA BASKETBALL", tabsBets.SelectedTab.Text)
                    Case "NFL FOOTBALL"
                        myExcel = getExcelSheet("NFL FOOTBALL", tabsBets.SelectedTab.Text)
                End Select
                Dim rowNum As Integer = getNextRowWS(myExcel)
                myExcel.Cells(rowNum, 2) = Date.Today
                myExcel.Cells(rowNum, 3) = txtTeam1Spread.Text
                myExcel.Cells(rowNum, 4) = txtSpread1Spread.Text
                myExcel.Cells(rowNum, 5) = txtOdds1Spread.Text
                myExcel.Cells(rowNum, 6) = txtTeam2Spread.Text
                myExcel.Cells(rowNum, 7) = txtSpread2Spread.Text
                myExcel.Cells(rowNum, 8) = txtOdds2Spread.Text
                If radTeam1Spread.Checked = True Then
                    myExcel.Cells(rowNum, 9) = txtTeam1Spread.Text
                    myExcel.Cells(rowNum, 11) = txtProfit1Spread.Text
                End If
                If radTeam2Spread.Checked = True Then
                    myExcel.Cells(rowNum, 9) = txtTeam2Spread.Text
                    myExcel.Cells(rowNum, 11) = txtProfit2Spread.Text
                End If
                myExcel.Cells(rowNum, 10) = txtStakeSpread.Text
                myExcel.Cells(rowNum, 12) = cmbWinLossSpread.Text

                myExcel = Nothing
            End If
        Else
            MsgBox("Please make sure all entries are filled.")
        End If
    End Sub


    Private Sub btnBovadaLinkSpread_Click(sender As Object, e As EventArgs) Handles btnBovadaLinkSpread.Click, btnBovadaLinkMoneyline.Click, btnBovadaLinkOU.Click
        Dim webAddress As String = "https://sports.bovada.lv/"
        Process.Start(webAddress)
    End Sub

    Private Sub btnDKLinkSpread_Click(sender As Object, e As EventArgs) Handles btnDKLinkSpread.Click, btnDKLinkMoneyline.Click, btnDKLinkOU.Click
        Dim webAddress As String = "https://www.draftkings.com/"
        Process.Start(webAddress)
    End Sub

    Private Sub WebScraperTestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WebScraperTestToolStripMenuItem.Click
        WebScraperForm.Show()
    End Sub

    Private Sub OtherToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OtherToolStripMenuItem.Click
        ToolsForm.Show()
    End Sub
End Class
