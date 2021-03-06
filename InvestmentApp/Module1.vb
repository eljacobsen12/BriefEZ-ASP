﻿Imports System.Text.RegularExpressions
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Net
Imports HtmlAgilityPack
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Module Module1

    '***********************************
    '*********COMMON FUNCTIONS**********
    '***********************************

    'Return String in Proper Case with no spaces
    Public Function GetProperString(ByVal str As String)
        Dim strProper As String = StrConv(str, VbStrConv.Lowercase)
        strProper = strProper.Replace("/", "_per_")
        strProper = strProper.Replace(" ", "_")
        strProper = strProper.Replace("%", "_pct")
        strProper = strProper.Replace("+", "_plus")
        strProper = strProper.Replace("-", "_")
        Return strProper
    End Function

    'MARCH MADNESS: Calculate Team Grade from Spreadsheet Row
    Public Function calculateTeamGrade(ByRef dr As DataRow)
        Dim intAPRank As Integer = dr.Item(0)
        Dim intBPIRank As Integer = dr.Item(2)
        Dim intWins As Integer = dr.Item(3)
        Dim intGamesPlayed As Integer = dr.Item(4)
        Dim intStrengthOfSched As Integer = dr.Item(5)
        Dim intLast10Games As Integer = dr.Item(6)
        Dim intStreak As Integer = dr.Item(7)
        Dim intAvgPointsScored As Integer = dr.Item(8)
        Dim intAvgPointsAllowed As Integer = dr.Item(9)
        Dim intDistanceFrom As Integer = dr.Item(10)
        Dim intAvgYearOfStarters As Integer = dr.Item(11)
        Dim intVegasOdds As Integer = dr.Item(12)
        Dim intTeamGrade As Integer = Nothing

        intAPRank = (351 + 1) - intAPRank / 351
        intBPIRank = (351 + 1) - intBPIRank / 351
        intWins = intWins / intGamesPlayed
        intStrengthOfSched = (351 + 1) - intStrengthOfSched / 351
        intLast10Games = (10 + 1) - intLast10Games / 10
        intStreak = (8 + 1) - intStreak / 8
        intAvgPointsScored = (90 + 1) - intAvgPointsScored / 90
        intAvgPointsAllowed = (90 + 1) - intAvgPointsAllowed / 90
        intDistanceFrom = (500 + 1) - intDistanceFrom / 500
        intAvgYearOfStarters = (4 + 1) - intAvgYearOfStarters / 4
        intTeamGrade = intAPRank + intBPIRank + intWins + intStrengthOfSched + intLast10Games + intStreak + intAvgPointsScored + intAvgPointsAllowed + intDistanceFrom + intAvgYearOfStarters + intVegasOdds / 12

        Return intTeamGrade
    End Function

    'Calculate Implied Probability
    Public Function getImpliedProbability(ByRef intRisk As Integer, ByRef intReturn As Integer)
        Dim intImpliedProbability As Integer = Nothing
        intImpliedProbability = intRisk / intReturn
        Return intImpliedProbability
    End Function

    'Convert Decimal Odds to Line Odds
    Public Function getLineOdds(ByRef intDecimalOdds As Integer)
        Dim intLineOdds As Integer

        If intDecimalOdds <> Nothing Then
            If intDecimalOdds < 0 Then
                intLineOdds = (100 / intDecimalOdds) + 1
            ElseIf intDecimalOdds > 0 Then
                intLineOdds = (intDecimalOdds / 100) + 1
            Else
                intLineOdds = 0
            End If
        End If
        Return intLineOdds
    End Function

    'Return Decimal Odds based on Line Odds
    Public Function getDecimalOdds(ByVal odds As Integer)
        Dim decimalOdds As Decimal = Nothing
        If CInt(odds) > 0 Then
            decimalOdds = CInt(odds) / 100
        ElseIf CInt(odds) < 100 Then
            decimalOdds = Math.Abs(CInt(odds) / 10)
            decimalOdds = (10 / CInt(odds))
        Else
            decimalOdds = 1
        End If
        Return decimalOdds
    End Function

    'Convert Line Odds to Percentage Odds
    Public Function lineToPercent(ByRef intLine As Integer)
        Dim intPercent As Integer = intLine / 100
        Return intPercent
    End Function

    'Convert Line Odds to Decimal Odds
    'Public Function getDecimalOdds(ByRef intLineOdds As Decimal)
    '    Dim intDecimalOdds As Decimal

    '    If intLineOdds <> Nothing Then
    '        If intLineOdds < 0 Then
    '            intDecimalOdds = (100 / intLineOdds) + 1
    '        ElseIf intLineOdds > 0 Then
    '            intDecimalOdds = (intLineOdds / 100) + 1
    '        Else
    '            intDecimalOdds = 0
    '        End If
    '    End If
    '    Return intDecimalOdds
    'End Function

    'Calculate Kelly Criterion
    Public Function getKellyCriterion(ByRef intDecimalOdds As Integer, ByRef intProbSuccess As Integer, ByRef strKellyFraction As String)
        'f* = (BP - Q)/B    B=decimal odds minus 1; P=probability of success; Q=probability of failure
        Dim intKellyCriterion As Integer
        Dim b As Integer = intDecimalOdds - 1
        Dim q As Integer = 1 - intProbSuccess

        intKellyCriterion = (b * intProbSuccess - q) / b
        If strKellyFraction.Contains("2") Then
            intKellyCriterion = intKellyCriterion / 2
        ElseIf strKellyFraction.Contains("4") Then
            intKellyCriterion = intKellyCriterion / 4
        End If
        Return intKellyCriterion
    End Function

    'Calculate estimated Profit
    Public Function getProfit(ByRef intStake As Integer, ByRef intLine As Integer, ByRef strBetType As String)
        Dim intProfit As Integer = 0
        Select Case strBetType
            Case "Spread"
                intProfit = intStake * lineToPercent(intLine)
            Case "Moneyline"

            Case "OverUnder"

            Case "Parlay"

            Case "Futures"

            Case "Specials"

        End Select
        Return intProfit
    End Function

    'Returns Odds for NCAA Basketball based on Spread
    Public Function getNCAABasketballOdds(ByRef intSpread As Integer)
        Dim intFavorite As Integer = Nothing
        Select Case intSpread
            Case 0
                intFavorite = 50
            Case 0.5
                intFavorite = 50
            Case 1
                intFavorite = 51.7
            Case 1.5
                intFavorite = 53.5
            Case 2
                intFavorite = 55.4
            Case 2.5
                intFavorite = 57.4
            Case 3
                intFavorite = 59.7
            Case 3.5
                intFavorite = 62.1
            Case 4
                intFavorite = 64.1
            Case 4.5
                intFavorite = 66.2
            Case 5
                intFavorite = 68.2
            Case 5.5
                intFavorite = 70.2
            Case 6
                intFavorite = 72
            Case 6.5
                intFavorite = 73.7
            Case 7
                intFavorite = 75.8
            Case 7.5
                intFavorite = 77.8
            Case 8
                intFavorite = 79.8
            Case 8.5
                intFavorite = 81.7
            Case 9
                intFavorite = 83.8
            Case 9.5
                intFavorite = 85.9
            Case 10
                intFavorite = 88.1
            Case 10.5
                intFavorite = 90.3
            Case 11
                intFavorite = 92.4
            Case 11.5
                intFavorite = 94.5
            Case 12
                intFavorite = 96.7
            Case 12.5
                intFavorite = 98.9
            Case >= 13
                intFavorite = 100
        End Select
        Return intFavorite
    End Function

    'Returns Odds for NBA Basketball based on Spread
    Public Function getNBABasketballOdds(ByRef intSpread As Integer)
        Dim intFavorite As Integer = Nothing
        Select Case intSpread
            Case 0
                intFavorite = 50
            Case 0.5
                intFavorite = 50
            Case 1
                intFavorite = 51.1
            Case 1.5
                intFavorite = 52.3
            Case 2
                intFavorite = 54.3
            Case 2.5
                intFavorite = 56.3
            Case 3
                intFavorite = 58.2
            Case 3.5
                intFavorite = 60.1
            Case 4
                intFavorite = 61.9
            Case 4.5
                intFavorite = 63.6
            Case 5
                intFavorite = 65.8
            Case 5.5
                intFavorite = 68
            Case 6
                intFavorite = 70.1
            Case 6.5
                intFavorite = 72.1
            Case 7
                intFavorite = 74.2
            Case 7.5
                intFavorite = 76.3
            Case 8
                intFavorite = 78.4
            Case 8.5
                intFavorite = 80.5
            Case 9
                intFavorite = 82.8
            Case 9.5
                intFavorite = 85.2
            Case 10
                intFavorite = 87.3
            Case 10.5
                intFavorite = 89.4
            Case 11
                intFavorite = 91.3
            Case 11.5
                intFavorite = 93.2
            Case 12
                intFavorite = 95
            Case 12.5
                intFavorite = 96.8
            Case 13
                intFavorite = 98.7
            Case >= 13.5
                intFavorite = 100
        End Select
        Return intFavorite
    End Function

    'Returns Odds for NCAA Football based on Spread
    Public Function getNCAAFootballOdds(ByRef intSpread As Integer)
        Dim intFavorite As Integer = Nothing
        Select Case intSpread
            Case 0
                intFavorite = 50
            Case 0.5
                intFavorite = 50
            Case 1
                intFavorite = 51.2
            Case 1.5
                intFavorite = 52.5
            Case 2
                intFavorite = 53.4
            Case 2.5
                intFavorite = 54.3
            Case 3
                intFavorite = 57.4
            Case 3.5
                intFavorite = 60.6
            Case 4
                intFavorite = 61.9
            Case 4.5
                intFavorite = 63.1
            Case 5
                intFavorite = 64.1
            Case 5.5
                intFavorite = 65.1
            Case 6
                intFavorite = 66.4
            Case 6.5
                intFavorite = 67.7
            Case 7
                intFavorite = 70.3
            Case 7.5
                intFavorite = 73
            Case 8
                intFavorite = 73.8
            Case 8.5
                intFavorite = 74.6
            Case 9
                intFavorite = 75.1
            Case 9.5
                intFavorite = 75.5
            Case 10
                intFavorite = 77.4
            Case 10.5
                intFavorite = 79.3
            Case 11
                intFavorite = 79.9
            Case 11.5
                intFavorite = 80.6
            Case 12
                intFavorite = 81.6
            Case 12.5
                intFavorite = 82.6
            Case 13
                intFavorite = 83
            Case 13.5
                intFavorite = 83.5
            Case 14
                intFavorite = 85.1
            Case 14.5
                intFavorite = 86.8
            Case 15
                intFavorite = 87.4
            Case 15.5
                intFavorite = 88.1
            Case 16
                intFavorite = 88.6
            Case 16.5
                intFavorite = 89.1
            Case 17
                intFavorite = 91.4
            Case 17.5
                intFavorite = 93.7
            Case 18
                intFavorite = 95
            Case 18.5
                intFavorite = 96.2
            Case 19
                intFavorite = 97.3
            Case 19.5
                intFavorite = 98.4
            Case >= 20
                intFavorite = 100
        End Select
        Return intFavorite
    End Function

    'Returns Odds for NFL Football based on Spread
    Public Function getNFLFootballOdds(ByRef intSpread As Integer)
        Dim intFavorite As Integer = Nothing
        Select Case intSpread
            Case 0
                intFavorite = 50
            Case 0.5
                intFavorite = 50
            Case 1
                intFavorite = 51.3
            Case 1.5
                intFavorite = 52.5
            Case 2
                intFavorite = 53.5
            Case 2.5
                intFavorite = 54.5
            Case 3
                intFavorite = 59.4
            Case 3.5
                intFavorite = 64.3
            Case 4
                intFavorite = 65.8
            Case 4.5
                intFavorite = 67.3
            Case 5
                intFavorite = 68.1
            Case 5.5
                intFavorite = 69
            Case 6
                intFavorite = 70.7
            Case 6.5
                intFavorite = 72.4
            Case 7
                intFavorite = 75.2
            Case 7.5
                intFavorite = 78.1
            Case 8
                intFavorite = 79.1
            Case 8.5
                intFavorite = 80.2
            Case 9
                intFavorite = 80.7
            Case 9.5
                intFavorite = 81.1
            Case 10
                intFavorite = 83.6
            Case 10.5
                intFavorite = 86
            Case 11
                intFavorite = 87.1
            Case 11.5
                intFavorite = 88.2
            Case 12
                intFavorite = 88.5
            Case 12.5
                intFavorite = 88.7
            Case 13
                intFavorite = 89.3
            Case 13.5
                intFavorite = 90
            Case 14
                intFavorite = 92.4
            Case 14.5
                intFavorite = 94.9
            Case 15
                intFavorite = 95.6
            Case 15.5
                intFavorite = 96.3
            Case 16
                intFavorite = 98.1
            Case 16.5
                intFavorite = 99.8
            Case >= 17
                intFavorite = 100
        End Select
        Return intFavorite
    End Function


    '****************************
    '*******EVENT HANDLERS*******
    '****************************

    'Handle Calculate Buttons
    Public Sub CalculateButton(ByRef strSport As String, ByRef strBetType As String)
        Select Case strSport
            Case "NCAA Basketball"
                Select Case strBetType
                    Case "Spread"

                    Case "Moneyline"

                    Case "Over/Under"

                    Case "Parlay"

                    Case "Futures"

                    Case "Specials"

                    Case "Arbitrage"

                End Select
            Case "NBA Basketball"
                Select Case strBetType
                    Case "Spread"

                    Case "Moneyline"

                    Case "Over/Under"

                    Case "Parlay"

                    Case "Futures"

                    Case "Specials"

                    Case "Arbitrage"

                End Select
            Case "NCAA Football"
                Select Case strBetType
                    Case "Spread"

                    Case "Moneyline"

                    Case "Over/Under"

                    Case "Parlay"

                    Case "Futures"

                    Case "Specials"

                    Case "Arbitrage"

                End Select
            Case "NFL Football"
                Select Case strBetType
                    Case "Spread"

                    Case "Moneyline"

                    Case "Over/Under"

                    Case "Parlay"

                    Case "Futures"

                    Case "Specials"

                    Case "Arbitrage"

                End Select
        End Select
    End Sub

    '**************************************
    '*************EXCEL FUNCTIONS**********
    '**************************************
    Public Sub ExportTableColumnsToCSV(ByRef dt As System.Data.DataTable)
        Dim stream As System.IO.StreamWriter
        stream = My.Computer.FileSystem.OpenTextFileWriter("Z:\EJ\MyPrograms\MoneyManager\CSVs\TableColumns.txt", True)
        Dim columns As String = ""
        For Each col As DataColumn In dt.Columns
            If dt.Columns.IndexOf(col) <> dt.Columns.Count Then
                columns &= Chr(34) & col.ColumnName & Chr(34) & ";"
            Else
                columns &= Chr(34) & col.ColumnName & Chr(34)
            End If
        Next
        stream.WriteLineAsync(columns)
        stream.Close()
    End Sub

    'DataGridView to CSV; Returns Path to File
    Public Sub DGVtoCSV(ByRef dgv As DataGridView, ByVal path As String)
        Dim headers = (From header As DataGridViewColumn In dgv.Columns.Cast(Of DataGridViewColumn)()
                       Select header.HeaderText).ToArray
        Dim rows = From row As DataGridViewRow In dgv.Rows.Cast(Of DataGridViewRow)()
                   Where Not row.IsNewRow
                   Select Array.ConvertAll(row.Cells.Cast(Of DataGridViewCell).ToArray, Function(c) If(c.Value IsNot Nothing, c.Value.ToString, ""))
        Using sw As New IO.StreamWriter(path)
            sw.WriteLine(String.Join(";", headers))
            For Each r In rows
                sw.WriteLine(String.Join(";", r))
            Next
            sw.Flush()
        End Using
    End Sub

    ' Datatable to CSV
    Public Sub DatatableToCSV(ByRef table As System.Data.DataTable, ByVal path As String)
        Dim headers = (From header As Data.DataColumn In table.Columns.Cast(Of DataColumn)()
                       Select header.ColumnName).ToArray
        Dim rows = From row As DataRow In table.Rows.Cast(Of DataRow)()
                   Where Not row.RowState = DataRowState.Detached
                   Select Array.ConvertAll(row.ItemArray.Cast(Of String).ToArray, Function(c) If(c IsNot Nothing, c.ToString, ""))
        Using sw As New IO.StreamWriter(path)
            sw.WriteLine(String.Join(";", headers))
            For Each r In rows
                sw.WriteLine(String.Join(";", r))
            Next
            sw.Flush()
        End Using
    End Sub


    'Imports an excel file, returns Dataset
    Public Function importExcel(ByVal strPath As String)
        Dim strSheetName As String = Nothing
        Dim strConnection As String = Nothing
        Dim strSQL As String = Nothing
        Dim dsDataSet As New DataSet
        Dim dtTablesList As Data.DataTable = Nothing
        Dim oleExcelCommand As OleDb.OleDbCommand = Nothing
        Dim oleExcelConnection As OleDb.OleDbConnection = Nothing

        strConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & strPath & ";Extended Properties=""Excel 12.0 Xml;HDR=YES;IMEX=1"";"     'HDR=Yes: first row has column names not data; IMEX=1 treats all data as text

        oleExcelConnection = New OleDb.OleDbConnection(strConnection)
        oleExcelConnection.Open()

        dtTablesList = oleExcelConnection.GetSchema("Tables")

        If dtTablesList.Rows.Count > 0 Then
            strSheetName = dtTablesList.Rows(0)("TABLE_NAME").ToString
        End If

        dtTablesList.Clear()
        dtTablesList.Dispose()

        If strSheetName <> "" Then
            oleExcelCommand = oleExcelConnection.CreateCommand()
            oleExcelCommand.CommandText = "Select * FROM [" & strSheetName & "]"
            oleExcelCommand.CommandType = CommandType.Text
            Dim dataAdapter As New OleDb.OleDbDataAdapter
            dataAdapter.SelectCommand = oleExcelCommand
            dataAdapter.Fill(dsDataSet)
        End If
        oleExcelConnection.Close()
        Return dsDataSet
    End Function

    'Returns the number of the next empty Row in Excel.Workheet
    Public Function getNextRowWS(ByRef ws As Worksheet)
        Dim intNextRow As Integer = ws.UsedRange.Rows.Count
        Return intNextRow + 1
    End Function

    'Returns the number of the next empty Row in DataTable
    Public Function getNextRowDT(ByRef dt As DataTable)
        Dim intNextRow As Integer = dt.Rows.Count
        Return intNextRow + 1
    End Function


    'Release Object
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    'Returns Excel Path based on Sport.
    Public Function getExcelPath(ByVal strSport As String)
        Dim strExcelPath As String = "E:\EJ\MyPrograms\MoneyManager\Bet Portfolio"
        Select Case strSport
            Case "NCAA Basketball"
                strExcelPath += "\Bets - NCAA Basketball.xlsx"
            Case "NCAA Football"
                strExcelPath += "\Bets - NCAA Football.xlsx"
            Case "NBA Basketball"
                strExcelPath += "\Bets - NBA Basketball.xlsx"
            Case "NFL Football"
                strExcelPath += "\Bets - NFL Football.xlsx"
        End Select
        Return strExcelPath
    End Function

    'Get correct Excel Sheet
    Public Function getExcelSheet(ByVal strSport As String, ByVal strBetType As String)
        Dim xlApp As Microsoft.Office.Interop.Excel.Application = Nothing
        Dim xlWorkBook As Workbook = Nothing
        Dim xlWorkSheet As Worksheet = Nothing

        Dim strExcelPath As String = getExcelPath(strSport)

        xlWorkBook = xlApp.Workbooks.Open(strExcelPath)
        xlApp.Visible = False

        Select Case strBetType
            Case "Spread"
                xlWorkSheet = xlWorkBook.Worksheets("Spread")
            Case "Moneyline"
                xlWorkSheet = xlWorkBook.Worksheets("Moneyline")
            Case "Over/Under"
                xlWorkSheet = xlWorkBook.Worksheets("OverUnder")
            Case "Parlay"
                xlWorkSheet = xlWorkBook.Worksheets("Parlay")
            Case "Futures"
                xlWorkSheet = xlWorkBook.Worksheets("Futures")
            Case "Specials"
                xlWorkSheet = xlWorkBook.Worksheets("Specials")
            Case "Arbitrage"
                xlWorkSheet = xlWorkBook.Worksheets("Arbitrage")
        End Select
        Return xlWorkSheet
    End Function

    'Returns DataSet from Excel Workbook, Worksheet
    Public Function getDataSet(ByRef myExcel As Workbook, ByVal strBetType As String)
        Dim MyConnection As System.Data.OleDb.OleDbConnection = Nothing
        Dim ds As DataSet = Nothing
        Dim MyCommand As OleDbDataAdapter = Nothing

        Try
            MyConnection = New OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + myExcel.Path + "';Extended Properties=Excel 8.0;")
            MyCommand = New OleDbDataAdapter("select * from " + strBetType, MyConnection)
            'MyCommand.TableMappings.Add(strBetType, strBetType)
            ds = New DataSet
            MyCommand.Fill(ds)
            MyConnection.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function

    'Returns a Dataset from a DataGridView
    Public Function DataGridViewToDataset(ByVal dgv As DataGridView)
        Dim ds As New DataSet
        Try
            ds.Tables.Add("Main")
            Dim col As DataColumn
            For Each dgvCol As DataGridViewColumn In dgv.Columns
                col = New DataColumn(dgvCol.Name)
                ds.Tables("Main").Columns.Add(col)
            Next
            Dim row As DataRow
            Dim colCount As Integer = dgv.Columns.Count - 1
            For i As Integer = 0 To dgv.Rows.Count - 1
                row = ds.Tables("Main").Rows.Add
                For Each column As DataGridViewColumn In dgv.Columns
                    row.Item(column.Index) = dgv.Rows.Item(0).Cells(column.Index).Value
                Next
            Next
            Return ds
        Catch ex As Exception
            MessageBox.Show("Error converting from DataGridView:" & ex.InnerException.ToString, "Error converting from DataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function


    'Checks if URL is valid
    Public Function UrlIsValid(ByVal url As String) As Boolean
        Dim isValid As Boolean = False
        If url.ToLower().StartsWith("www.") Then url = "http://" & url

        Dim webResponse As HttpWebResponse = Nothing
        Try
            Dim webRequest As HttpWebRequest = HttpWebRequest.Create(url)
            webResponse = DirectCast(webRequest.GetResponse(), HttpWebResponse)
            Return True
        Catch ex As Exception
            Return False
        Finally
            If Not (webResponse Is Nothing) Then webResponse.Close()
        End Try
    End Function

    Public Function checkURL(ByVal url As String)
        If Not url.ToLower.StartsWith("http://") AndAlso Not url.ToLower.StartsWith("https://") Then
            url = "http://" & url
        End If
        Return url
    End Function

    ' DataGridView to DataTable
    Public Function DGVtoDataTable(ByRef dgv As DataGridView)
        Dim dt As New System.Data.DataTable
        For Each col As DataGridViewColumn In dgv.Columns
            dt.Columns.Add(col.Name)
        Next

        For Each row As DataGridViewRow In dgv.Rows
            Dim dRow As DataRow = dt.NewRow()
            For Each cell As DataGridViewCell In row.Cells
                dRow(cell.ColumnIndex) = cell.Value
            Next
            dt.Rows.Add(dRow)
        Next
        Return dt
    End Function

    '   From Nodes to DataGridView
    Public Sub StatsToTable(ByVal StatNodes As HtmlNodeCollection, ByVal Table As DataGridView)
        Dim colCount As Integer = StatNodes(1).ChildNodes.Count - 1
        Table.ColumnCount = colCount + 1     'Set columns
        Dim rowStart As Integer = 0
        Dim colspans As New List(Of Integer)
        Dim colHeaders As New List(Of String)
        Dim colspan As Integer = 0
        If StatNodes(0).ChildNodes.Count <> Table.ColumnCount Then
            'Check for column headers
            For Each node As HtmlNode In StatNodes(0).ChildNodes
                colspan += CType(node.Attributes(0).Value, Integer)
                colspans.Add(colspan)
                colHeaders.Add(node.InnerText)
            Next
            rowStart = 1
        End If
        For i As Integer = 0 To colCount
            If colspans.Count <> 0 Then
                For Each value In colspans
                    If i < value Then
                        If colHeaders(colspans.IndexOf(value)) <> "&nbsp;" Then
                            Table.Columns(i).Name = GetProperString(colHeaders(colspans.IndexOf(value)) & "-" & GetProperString(StatNodes(rowStart).ChildNodes(i).InnerText))
                            Exit For
                        Else
                            Table.Columns(i).Name = GetProperString(StatNodes(rowStart).ChildNodes(i).InnerText)
                            Exit For
                        End If
                    End If
                Next
            Else
                Table.Columns(i).Name = GetProperString(StatNodes(rowStart).ChildNodes(i).InnerText)
            End If
        Next

        For i As Integer = 0 To StatNodes.Count - 1
            If StatNodes(i).ChildNodes.Count = Table.ColumnCount Then
                If StatNodes(i).FirstChild.InnerText <> "PER GAME" AndAlso StatNodes(i).FirstChild.InnerText <> "DATE" AndAlso StatNodes(i).FirstChild.InnerText <> "RK" Then     'Add data from nodes to rows
                    Dim rowNum As Integer = Table.Rows.Add()
                    For x As Integer = 0 To colCount
                        If Not StatNodes(i).ChildNodes(x).InnerText = "&nbsp;" Then
                            Table.Item(x, rowNum).Value = StatNodes(i).ChildNodes(x).InnerText
                        Else
                            Table.Item(x, rowNum).Value = ""
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    '   Nodes collection to DataTable for importing to database
    Public Function StatsToDataTable(ByVal StatNodes As HtmlNodeCollection, ByVal TableName As String) As System.Data.DataTable
        Dim Table As New System.Data.DataTable
        Dim colCount As Integer = StatNodes(1).ChildNodes.Count - 1
        For i = 0 To colCount
            Table.Columns.Add()
        Next
        Dim rowStart As Integer = 0
        If StatNodes(0).ChildNodes.Count <> colCount + 1 Then
            rowStart = 1
        End If
        Dim colspans As New List(Of Integer)
        Dim colHeaders As New List(Of String)
        Dim colspan As Integer = 0
        If StatNodes(0).ChildNodes.Count <> Table.Columns.Count Then
            'Check for column headers
            For Each node As HtmlNode In StatNodes(0).ChildNodes
                If node.Attributes.Count > 0 Then
                    colspan += CType(node.Attributes(0).Value, Integer)
                    colspans.Add(colspan)
                    colHeaders.Add(GetProperString(TableName) & "_" & node.InnerText)
                End If
            Next
            rowStart = 1
        End If
        For i As Integer = 0 To colCount
            If colspans.Count <> 0 Then
                For Each value In colspans
                    If i < value Then
                        If colHeaders(colspans.IndexOf(value)) <> GetProperString(TableName) & "_&nbsp;" Then
                            Try
                                Table.Columns(i).ColumnName = GetProperString(TableName & "_" & colspans.IndexOf(value) & "_" & StatNodes(rowStart).ChildNodes(i).InnerText).ToString.ToLower
                            Catch
                                Table.Columns(i).ColumnName = GetProperString(TableName & "_" & colspans.IndexOf(value) & "_" & StatNodes(rowStart).ChildNodes(i).InnerText & "1").ToString.ToLower
                            End Try
                            Exit For
                        Else
                            Table.Columns(i).ColumnName = GetProperString(TableName & "_" & StatNodes(rowStart).ChildNodes(i).InnerText).ToString.ToLower
                            Exit For
                        End If
                    End If
                Next
            Else
                Try
                    Table.Columns(i).ColumnName = GetProperString(TableName & "_" & StatNodes(rowStart).ChildNodes(i).InnerText).ToString.ToLower
                Catch
                    Table.Columns(i).ColumnName = GetProperString(TableName & "_" & StatNodes(rowStart).ChildNodes(i).InnerText & "1").ToString.ToLower
                End Try
            End If
        Next

        For i As Integer = 1 To StatNodes.Count - 1
            If StatNodes(i).ChildNodes.Count = Table.Columns.Count Then
                If StatNodes(i).FirstChild.InnerText <> "PER GAME" AndAlso StatNodes(i).FirstChild.InnerText <> "DATE" AndAlso StatNodes(i).FirstChild.InnerText <> "RK" Then     'Add data from nodes to rows
                    Table.Rows.Add()
                    Dim rowNum As Integer = Table.Rows.Count - 1
                    For x As Integer = 0 To colCount
                        If Not StatNodes(i).ChildNodes(x).InnerText = "&nbsp;" Then
                            Table.Rows(rowNum).Item(x) = (StatNodes(i).ChildNodes(x).InnerText).ToLower
                        Else
                            Table.Rows(rowNum).Item(x) = ""
                        End If
                    Next
                End If
            End If
        Next
        Return Table
    End Function

    'All Tables to CSV
    Public Sub ScrapeTablesToCSV()

    End Sub

    Public Sub AddCols(ByRef DT As System.Data.DataTable, ByVal Year As Integer, ByRef DGV As DataGridView)

        ' Add StatID Column
        Dim dcStatID As New DataColumn
        dcStatID.DataType = GetType(Integer)
        dcStatID.AutoIncrement = True
        dcStatID.ColumnName = "StatID"
        DT.Columns.Add(dcStatID)

        ' Add StatID Column
        Dim dcYear As New DataColumn
        dcYear.DataType = GetType(Integer)
        dcYear.ColumnName = "Year"
        dcYear.DefaultValue = Year
        DT.Columns.Add(dcYear)

        ' Add StatID Column
        Dim dcTeamID As New DataColumn
        dcTeamID.DataType = GetType(Integer)
        dcTeamID.ColumnName = "TeamID"
        dcTeamID.AllowDBNull = True
        DT.Columns.Add(dcTeamID)

        'POPULATE TEAM ID COLUMN

    End Sub

    Public Sub GetTeamIDs(ByRef DGV As DataGridView)
        Dim baseString As String = "http://www.espn.com/mens-college-basketball/team/_/id/"
        Dim downloadString As String = Nothing
        Dim sourceString As String = Nothing
        Dim html As String = Nothing
        Dim pattern As String = Nothing
        Dim title As String = Nothing
        Dim titles As New System.Data.DataTable
        Dim colID As DataColumn = titles.Columns.Add("ID", GetType(Integer))
        colID.Unique = True
        titles.Columns.Add("Title", GetType(String))
        Dim data As String = Nothing
        Dim x, y As Integer

        For i As Integer = 1 To 350
            downloadString = baseString & i.ToString
            Try
                sourceString = New System.Net.WebClient().DownloadString(downloadString)
                html = sourceString
                pattern = "<\s*title[^>]*>(.*?)<\s*/\s*title>"
                data = System.Text.RegularExpressions.Regex.Match(html, pattern).Value
                x = data.IndexOf("<title>") + "<title>".Length
                y = data.IndexOf("College Basketball") - x
                title = data.Substring(x, y).Trim
                If title IsNot "NCAA" Then
                    Dim R As DataRow = titles.NewRow
                    R("ID") = i
                    R("Title") = title
                    titles.Rows.Add(R)
                End If
            Catch ex As Exception

            End Try
        Next
        For a As Integer = titles.Rows.Count - 1 To 0 Step -1
            If titles.Rows(a).Item(titles.Columns.IndexOf("Title")) = "NCAA" Then
                titles.Rows(a).Delete()
                a -= 1
            End If
        Next
        DGV.DataSource = titles
    End Sub

    Public Sub FillTeamID(teamCount As Integer)
        ' Get DataTable
        Dim N As Long, i As Long, x As Long, y As Long, usedRowsCount As Long
        Dim xl As New Microsoft.Office.Interop.Excel.Application
        Dim sheet As New Microsoft.Office.Interop.Excel.Worksheet
        Dim path As String = "" ' Get path to teams csv.
        xl.Workbooks.Open("")
        sheet = xl.Workbooks("Sheet1")
        sheet.Range("B3").Value = ""
        usedRowsCount = sheet.UsedRange.Rows.Count

        N = sheet.Range(usedRowsCount, "A").End(XlDirection.xlUp).Row
        For i = 2 To N
            If sheet.Range(i, "A").Value = "" Then
                x = sheet.Range((i - 1), "A").Value
                If x = teamCount Then y = 1
            End If
        Next i
    End Sub

End Module