Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Imports HtmlAgilityPack

Public Class WebScraperTEST
    Private Sub WebScraperTEST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSelectSeason.DataSource = {"CURRENT", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002"}
        cmbSelectSport.DataSource = {"NFL", "NBA", "NCAA FOOTBALL", "NCAA BASKETBALL"}
        cmbSelectStat.DataSource = {"TEAM SCHEDULE", "TEAM STATS - SCORING", "TEAM STATS - SCORING PER GAME", "TEAM STATS - REBOUNDS", "TEAM STATS - FIELD GOALS", "TEAM STATS - FREE THROWS", "TEAM STATS - 3 - POINTS", "TEAM STATS - ASSISTS", "TEAM STATS - STEALS", "TEAM STATS - BLOCKS"}
        cmbSelectTeam.DataSource = {} 'PULL TEAMS FROM DB TABLE
    End Sub

    Private Sub btnExtract_Click(sender As Object, e As EventArgs) Handles btnExtract.Click
        WebScrapeAgilityNCAABasketball(txtURL.Text, cmbSelectStat.Text)
        'ScrapeNCAABasketballTeams()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub


    Private Function UrlIsValid(ByVal url As String) As Boolean
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

    '**********************************************
    '**  Scrape and filter with HTMLAgilityPack  **
    '**********************************************
    Public Sub ScrapeNCAABasketballTeams()
        Dim baseURI As String = checkURL("www.espn.com/mens-college-basketball/teams")
        Dim doc As HtmlDocument = New HtmlWeb().Load(baseURI)  'Get raw HTML of page
        Dim teams As HtmlNodeCollection = doc.DocumentNode.SelectNodes("//div")    'Get collection of table elements

        lblTableName.Text = teams.Nodes.First.InnerText
    End Sub

    Public Sub WebScrapeAgilityNCAABasketball(ByVal url As String, ByVal tag As String)
        Select Case tag
            Case "TEAM SCHEDULE"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim baseURI As String = "http://www.espn.com/mens-college-basketball/team/schedule/_/id/" & teamID
                If cmbSelectSeason.Text <> "CURRENT" Then
                    baseURI = "http://www.espn.com/mens-college-basketball/team/schedule/_/id/" & teamID & "/year/" & cmbSelectSeason.Text
                End If

                Dim doc As HtmlDocument = New HtmlWeb().Load(baseURI)  'Get raw HTML of page
                Dim schedule As HtmlNodeCollection = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")    'Get collection of table elements

                lblTableName.Text = schedule.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                dgvTableDisplay.ColumnCount = schedule(1).ChildNodes.Count     'Set Columns
                For i As Integer = 0 To 3
                    dgvTableDisplay.Columns(i).Name = schedule(1).ChildNodes(i).InnerText
                Next

                For i = 0 To schedule.Count - 1
                    If schedule(i).ChildNodes.Count = dgvTableDisplay.ColumnCount AndAlso Not schedule(i).FirstChild.InnerText.Contains("DATE") Then     'Add data from nodes to rows
                        Dim rowNum As Integer = dgvTableDisplay.Rows.Add()  'Get Row number
                        For x As Integer = 0 To 3
                            dgvTableDisplay.Item(x, rowNum).Value = schedule(i).ChildNodes(x).InnerText
                        Next
                    End If
                Next
            Case "TEAM STATS - SCORING"
                Dim baseURI As String = "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/scoring/sort/points/count/"
                If cmbSelectSeason.Text <> "CURRENT" Then
                    baseURI = "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/scoring/sort/points/year/" & cmbSelectSeason.Text & "/count/"
                End If

                Dim doc As HtmlDocument = New HtmlWeb().Load(baseURI & 1)
                Dim ppgCollection As HtmlNodeCollection = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                For i As Integer = 41 To 351
                    doc = New HtmlWeb().Load(baseURI & i.ToString)  'Get raw HTML of page
                    Dim ppg As HtmlNodeCollection = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")    'Get collection of table elements
                    For Each node As HtmlNode In ppg
                        ppgCollection.Add(node)
                    Next
                    i += 40
                Next

                lblTableName.Text = "NCAA Basketball Points Per Game"   'Set Table Name
                '****** CENTER LABEL ********
                dgvTableDisplay.ColumnCount = ppgCollection(0).ChildNodes.Count     'Set columns
                For i As Integer = 0 To 9
                    dgvTableDisplay.Columns(i).Name = ppgCollection(0).ChildNodes(i).InnerText
                Next

                For i As Integer = 0 To ppgCollection.Count - 1
                    If ppgCollection(i).FirstChild.InnerText <> "RK" Then
                        Dim rowNum As Integer = dgvTableDisplay.Rows.Add()
                        For x As Integer = 0 To 9
                            If Not ppgCollection(i).ChildNodes(x).InnerText = "&nbsp;" Then
                                dgvTableDisplay.Item(x, rowNum).Value = ppgCollection(i).ChildNodes(x).InnerText
                            Else
                                dgvTableDisplay.Item(x, rowNum).Value = ""
                            End If
                        Next
                    End If
                Next
            Case "TEAM STATS - SCORING PER GAME"
                Dim baseURI As String = "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/scoring-per-game/sort/avgPoints/count/"
                If cmbSelectSeason.Text <> "CURRENT" Then
                    baseURI = "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/scoring-per-game/sort/avgPoints/year/" & cmbSelectSeason.Text & "/count/"
                End If
                Dim doc As HtmlDocument = New HtmlWeb().Load(baseURI & 1)
                Dim ppgCollection As HtmlNodeCollection = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                For i As Integer = 41 To 351
                    doc = New HtmlWeb().Load(baseURI & i.ToString)  'Get raw HTML of page
                    Dim ppg As HtmlNodeCollection = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")    'Get collection of table elements
                    For Each node As HtmlNode In ppg
                        ppgCollection.Add(node)
                    Next
                    i += 40
                Next

                lblTableName.Text = "NCAA Basketball Points Per Game"   'Set Table Name
                '****** CENTER LABEL ********
                dgvTableDisplay.ColumnCount = ppgCollection(0).ChildNodes.Count     'Set columns
                For i As Integer = 0 To 9
                    dgvTableDisplay.Columns(i).Name = ppgCollection(0).ChildNodes(i).InnerText
                Next

                For i As Integer = 0 To ppgCollection.Count - 1
                    If ppgCollection(i).FirstChild.InnerText <> "RK" Then
                        Dim rowNum As Integer = dgvTableDisplay.Rows.Add()
                        For x As Integer = 0 To 9
                            If Not ppgCollection(i).ChildNodes(x).InnerText = "&nbsp;" Then
                                dgvTableDisplay.Item(x, rowNum).Value = ppgCollection(i).ChildNodes(x).InnerText
                            Else
                                dgvTableDisplay.Item(x, rowNum).Value = ""
                            End If
                        Next
                    End If
                Next
            Case "TEAM STATS - REBOUNDS"
                Dim baseURI As String = "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/rebounds/sort/avgRebounds/count/"
                Dim doc As HtmlDocument = New HtmlWeb().Load(baseURI & 1)
                Dim ppgCollection As HtmlNodeCollection = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                For i As Integer = 41 To 351
                    doc = New HtmlWeb().Load(baseURI & i.ToString)  'Get raw HTML of page
                    Dim ppg As HtmlNodeCollection = doc.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")    'Get collection of table elements
                    For Each node As HtmlNode In ppg
                        ppgCollection.Add(node)
                    Next
                    i += 40
                Next

                lblTableName.Text = "NCAA Basketball Points Per Game"   'Set Table Name
                '****** CENTER LABEL ********
                dgvTableDisplay.ColumnCount = ppgCollection(0).ChildNodes.Count     'Set columns
                For i As Integer = 0 To 9
                    dgvTableDisplay.Columns(i).Name = ppgCollection(0).ChildNodes(i).InnerText
                Next

                For i As Integer = 0 To ppgCollection.Count - 1
                    If ppgCollection(i).FirstChild.InnerText <> "RK" Then
                        Dim rowNum As Integer = dgvTableDisplay.Rows.Add()
                        For x As Integer = 0 To 9
                            If Not ppgCollection(i).ChildNodes(x).InnerText = "&nbsp;" Then
                                dgvTableDisplay.Item(x, rowNum).Value = ppgCollection(i).ChildNodes(x).InnerText
                            Else
                                dgvTableDisplay.Item(x, rowNum).Value = ""
                            End If
                        Next
                    End If
                Next
            Case "TEAM STATS - FIELD GOALS"
            Case "TEAM STATS - FREE-THROWS"
            Case "TEAM STATS - 3-POINTS"
            Case "TEAM STATS - ASSISTS"
            Case "TEAM STATS - STEALS"
            Case "TEAM STATS - BLOCKS"

        End Select

        dgvTableDisplay.AutoResizeColumns()
    End Sub



End Class