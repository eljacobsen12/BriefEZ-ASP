Imports System.Data.SqlClient

Public Class MarchMadnessForm
    Private strDataSource As String = "E:\EJ\MyPrograms\MoneyManager\Application\InvestmentApp\MarchMadnessData.xlsx"  '"C:\Users\eljac\Desktop\MyApps\InvestmentApp\InvestmentApp\MarchMadnessData.xlsx"

    Private Sub btnGetData_Click(sender As Object, e As EventArgs) Handles btnGetData.Click
        Dim strTeam1 As String = txtTeam1.Text
        Dim strTeam2 As String = txtTeam2.Text
        Dim mySet As DataSet = importExcel(strDataSource)
        Dim myDataView As New DataView(mySet.Tables(0))
        Dim strRowFilter As String = "Team = '" & strTeam1 & "' OR Team = '" & strTeam2 & "'"

        myDataView.RowFilter = strRowFilter

        'DataGridView1.DataSource = importExcel(strDataSource)

        With DataGridView1
            .DataSource = myDataView
            .DefaultCellStyle.Font = New Font("Arial", 16, FontStyle.Regular, GraphicsUnit.Point)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoResizeColumns()
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None
            .Rows(0).Height = 55
            .Rows(1).Height = 55
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .ReadOnly = True
        End With

        'txtTeam1Grade.Text = calculateTeamGrade(myDataView.Table.Rows(1))
        'txtTeam2Grade.Text = calculateTeamGrade(myDataView.Table.Rows(2))

    End Sub

    Private Sub MarchMadness_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim mySet As DataSet = importExcel(strDataSource)
        Dim myDataView As New DataView(mySet.Tables(0))

        DataGridView1.DataSource = importExcel(strDataSource)

        With DataGridView1
            .DataSource = myDataView
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersDefaultCellStyle.Font = New Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            .AutoResizeColumns()
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .ReadOnly = True
        End With

    End Sub


End Class