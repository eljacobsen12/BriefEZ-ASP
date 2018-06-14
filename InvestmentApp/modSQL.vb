Imports System.Text.RegularExpressions
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Net
Imports HtmlAgilityPack
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Module modSQL

    '*************************************
    '           SQL FUNCTIONS
    '*************************************

    Public Function sqlGetDBconnection(ByVal db As String)
        Dim dbConnectionString As String = Nothing
        Select Case db
            Case "ncaafb"
                dbConnectionString = "Server=EJPC1;Uid=EJadmin;Pwd=Look@me3times;Database=ncaafb;"
            Case "ncaab"
                dbConnectionString = "Server=EJPC1;Uid=EJadmin;Pwd=Look@me3times;Database=ncaab;"
            Case "nfl"
                dbConnectionString = "Server=EJPC1;Uid=EJadmin;Pwd=Look@me3times;Database=nfl;"
            Case "nba"
                dbConnectionString = "Server=EJPC1;Uid=EJadmin;Pwd=Look@me3times;Database=nba;"
            Case "mlb"
                dbConnectionString = "Server=EJPC1;Uid=EJadmin;Pwd=Look@me3times;Database=mlb;"
        End Select
        Return dbConnectionString
    End Function

    'Get the connection string from a Config file
    Private Function sqlGetConnectionString(ByVal DBName As String) As String
        ' To avoid storing the connection string in your code, 
        ' you can retrieve it from a configuration file. 
        Select Case DBName
            Case "ncaafb"
                Return "server=192.168.0.26; user id=root; password=Look@me3times; database=ncaafb"
            Case "ncaab"
                Return "server=192.168.0.26; user id=root; password=Look@me3times; database=ncaab"
            Case "nfl"
                Return "server=192.168.0.26; user id=root; password=Look@me3times; database=nfl"
            Case "nba"
                Return "server=192.168.0.26; user id=root; password=Look@me3times; database=nba"
            Case "mlb"
                Return "server=192.168.0.26; user id=root; password=Look@me3times; database=mlb"
            Case Else
                Return Nothing
        End Select
    End Function

    ' NEED TO FINISH
    Private Function sqlGetColumnMappings(ByVal db As String, ByVal table As String)
        Dim lstColMaps As New List(Of IColumnMappingCollection)
        Dim ColMappings As IColumnMappingCollection = Nothing

        'lstColMaps.

        ColMappings.Add("", "")
        Return ColMappings
    End Function

    ' Return MySQL String: Create Table
    Public Function sqlGetCreateTableCommand(ByVal dbName As String, ByVal tableName As String)
        Dim strSQL As String = "CREATE TABLE IF NOT EXISTS " & GetProperString(tableName) & " (id INT(6) NOT NULL, " '
        Dim cols As String() = GetDatasource(dbName.ToUpper & "-" & tableName)
        For Each str As String In cols

            If str = cols.Last Then
                strSQL += GetProperString(str.ToLower) & " INT(6) DEFAULT NULL"
            Else
                If str.Contains("team") Then
                    strSQL += GetProperString(tableName) & "_team VARCHAR(30) DEFAULT NULL,"
                Else
                    strSQL += GetProperString(str.ToLower) & " INT(6) DEFAULT NULL,"
                End If
            End If
        Next
        strSQL += ");"
        Return strSQL
    End Function

    Public Function sqlGetSelectTableCommand(ByVal dbName As String, ByVal tableName As String, ByVal year As String)
        Dim strSQL As String = ""
        If tableName = "ALL" Then tableName = "*"
        If year = "ALL" Then
            strSQL = "SELECT * FROM " & GetProperString(dbName) & "." & GetProperString(tableName)
        Else
            strSQL = "SELECT * FROM " & GetProperString(dbName) & "." & GetProperString(tableName) & " WHERE CAST(" & GetProperString(tableName) & "_year AS UNSIGNED)" & "=" & year
        End If
        Return strSQL
    End Function

    Public Function sqlSelectTable(ByVal db As String, ByVal table As String, ByVal year As String) As Data.DataTable
        Dim dbProper As String = Nothing
        Select Case db
            Case "NCAA BASKETBALL"
                dbProper = "ncaab"
            Case "NCAA FOOTBALL"
                dbProper = "ncaafb"
            Case "NBA"
                dbProper = "nba"
            Case "NFL"
                dbProper = "nfl"
            Case "MLB"
                dbProper = "mlb"
        End Select
        Dim connStr As String = "server=EJPC1;user=EJadmin;password=Look@me3;database=" & dbProper & ";port=3306"
        Dim conn As New MySqlConnection(connStr)
        Dim dt As New System.Data.DataTable
        Using dbcon As New MySqlConnection(connStr)
            dbcon.Open()

            ' Create the Table and Columns
            Dim sqlSelect As String
            Try
                sqlSelect = sqlGetSelectTableCommand(dbProper, GetProperString(table), GetProperString(year))
                Dim cmd As New MySqlCommand(sqlSelect, dbcon)
                Dim da As New MySqlDataAdapter(cmd)
                da.Fill(dt)
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try
        End Using
        Return dt
    End Function

    ' Insert DataTable into Database Table
    Public Sub sqlInsertDataTable(ByVal ToDB As String, ByVal ToTable As String, ByVal FromTable As DataTable)
        Dim strConnection As String = sqlGetConnectionString(ToDB)        'Function needs to be completed

        ' Open a connection to the MMMDB
        Using sourceConnection As SqlConnection = New SqlConnection(strConnection)
            sourceConnection.Open()

            ' Perform an intial count on the destination table
            Dim commandRowCount As New SqlCommand("SELECT COUNT(*) FROM <insertDB>;", sourceConnection)
            Dim countStart As Long = System.Convert.ToInt32(commandRowCount.ExecuteScalar())

            ' Get data from the source table as a SqlDataReader
            Dim commandSourceData As SqlCommand = New SqlCommand("SELECT <columns>, <columns> FROM <table>;", sourceConnection)
            Dim reader As SqlDataReader = commandSourceData.ExecuteReader

            ' Set up the bulk copy object
            Using bulkCopy As SqlBulkCopy = New SqlBulkCopy(strConnection)
                bulkCopy.DestinationTableName = ToTable

                Dim colMappings As IColumnMappingCollection = sqlGetColumnMappings(vbNull, vbNull) 'FIX THIS!!!

                ' Set up the column mappings by name.
                Dim mapID As New SqlBulkCopyColumnMapping("", "")
                bulkCopy.ColumnMappings.Add(mapID)

                Dim mapName As New SqlBulkCopyColumnMapping("", "")
                bulkCopy.ColumnMappings.Add(mapName)

                Dim mapNumber As New SqlBulkCopyColumnMapping("", "")
                bulkCopy.ColumnMappings.Add(mapNumber)

                ' Write from the source to the destination
                Try
                    bulkCopy.WriteToServer(reader)
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    ' Close the SqlDataReader. The SqlBulkCopy object is automatically closed at the end of the Using block.
                    reader.Close()
                End Try
            End Using

            ' Perform a final count on the destination table to see how many rows were added.
            Dim countEnd As Long = System.Convert.ToInt32(commandRowCount.ExecuteScalar())
            MsgBox("Ending row count = {0}", countEnd)
            MsgBox("{0} rows were added.", countEnd - countStart)
        End Using
    End Sub

    ' Drops MySQL Database Table.
    Public Sub sqlDropDBtable(ByVal db As String, ByVal dt As String)
        Dim connStr As String = "server=EJPC1;user=EJadmin;password=Look@me3;database=" & db & ";port=3306"
        Dim conn As New MySqlConnection(connStr)

        Dim sql As String = "DROP TABLE " & db & "." & dt
        Dim result As Integer
        Try
            conn.Open()
            Dim cmd As New MySql.Data.MySqlClient.MySqlCommand
            With cmd
                .Connection = conn
                .CommandText = sql
                result = cmd.ExecuteNonQuery
                If result > 0 Then
                    MsgBox("Error in dropping Field! - Command: {" & cmd.CommandText)
                Else
                    MsgBox(db & "." & dt & " has Successfully dropped!")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        conn.Close()
    End Sub

    ' Import CSV file to MySQL Database Table.
    Public Sub sqlImportCSVtoMySQL(ByVal db As String, ByVal csvTableName As String, ByVal filepath As String)
        Dim connStr As String = "server=EJPC1;user=EJadmin;password=Look@me3;database=" & db & ";port=3306"
        Dim conn As New MySqlConnection(connStr)

        Dim csvLine As String, cols() As String
        Dim sr As New StreamReader(filepath)

        csvLine = sr.ReadLine()
        sr.Close()
        cols = Split(csvLine, ";")

        Dim rows As Int32 = 0
        Using dbcon As New MySqlConnection(connStr)
            dbcon.Open()

            ' Create the Table and Columns
            Dim createSql As String
            Try
                createSql = sqlGetCreateTableCommand(db, csvTableName)
                Dim cmd As New MySqlCommand(createSql, dbcon)
                cmd.ExecuteNonQuery()
                cmd.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                conn.Close()
            End Try

            Dim bulk = New MySqlBulkLoader(dbcon)

            bulk.TableName = GetProperString(csvTableName)
            bulk.FieldTerminator = ";"
            bulk.LineTerminator = "\r\n"    ' == CR/LF
            bulk.FileName = filepath         ' full file path name to CSV 
            bulk.NumberOfLinesToSkip = 1    ' has a header (default)

            bulk.Columns.Clear()
            For Each s In cols
                s = s.Replace("/", "_per_")
                bulk.Columns.Add(s)         ' specify col order in file
            Next
            rows = bulk.Load()
        End Using
    End Sub

End Module
