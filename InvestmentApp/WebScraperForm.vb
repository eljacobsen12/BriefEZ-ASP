Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Imports HtmlAgilityPack
Imports MySql

Public Class WebScraperForm
    Private Sub WebScraperTEST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSelectSport.DataSource = GetDatasource("Sports")
        Select Case cmbSelectSport.Text
            Case "NCAA BASKETBALL"
                cmbSelectSeason.DataSource = GetDatasource("YearsNCAAB")
            Case "NCAA FOOTBALL"
                cmbSelectSeason.DataSource = GetDatasource("YearsNCAAF")
            Case "NBA"
                cmbSelectSeason.DataSource = GetDatasource("YearsNBA")
            Case "NFL"
                cmbSelectSeason.DataSource = GetDatasource("YearsNFL")
        End Select
        cmbSelectTeam1.DataSource = ScrapeTeams(cmbSelectSport.Text) 'PULL TEAMS FROM DB TABLE
    End Sub

    '   Populate comboboxes on form based on selected sport
    Private Sub cmbSelectSport_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSelectSport.SelectedValueChanged
        Select Case cmbSelectSport.Text
            Case "NCAA BASKETBALL"
                cmbSelectStat.DataSource = GetDatasource("StatsNCAAB")
            Case "NCAA FOOTBALL"
                cmbSelectStat.DataSource = GetDatasource("StatsNCAAF")
            Case "NBA"
                cmbSelectStat.DataSource = GetDatasource("StatsNBA")
            Case "NFL"
                cmbSelectStat.DataSource = GetDatasource("StatsNFL")
        End Select
    End Sub

    Private Sub btnExtract_Click(sender As Object, e As EventArgs) Handles btnScrape.Click
        'Try
        '    dgvTableDisplay.Rows.Clear()
        'Finally
        If cmbSelectTeam1.Text <> Nothing Then
            Select Case cmbSelectSport.Text
                Case "NFL"
                    ScrapeNFL(cmbSelectStat.Text)
                Case "NBA"
                    ScrapeNBA(cmbSelectStat.Text)
                Case "NCAA FOOTBALL"
                    ScrapeNCAAFootball(cmbSelectStat.Text)
                Case "NCAA BASKETBALL"
                    ScrapeNCAABasketball(cmbSelectStat.Text)
            End Select
        End If
        dgvTableDisplay.AutoResizeColumns()
        'End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '**********************************************
    '**  Scrape and filter with HTMLAgilityPack  **
    '**********************************************

    '   Scrape ESPN for list of teams
    Public Function ScrapeTeams(ByRef Sport As String) As List(Of String)
        Dim year As String = cmbSelectSeason.Text
        Dim lstChildren As New List(Of String)
        Select Case Sport
            Case "NCAA BASKETBALL"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/scoring/sort/points/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                Dim children As HtmlNodeCollection = Nothing
                For i As Integer = 1 To nodes.Count - 1
                    children = nodes(i).ChildNodes
                    lstChildren.Add(children.Item(1).InnerText)
                Next
            Case "NCAA FOOTBALL"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/sort/totalYards/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                Dim children As HtmlNodeCollection = Nothing
                For i As Integer = 1 To nodes.Count - 1
                    children = nodes(i).ChildNodes
                    lstChildren.Add(children.Item(1).InnerText)
                Next
            Case "NBA"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/offense/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                Dim children As HtmlNodeCollection = Nothing
                For i As Integer = 1 To nodes.Count - 1
                    children = nodes(i).ChildNodes
                    If children.Item(1).InnerText <> "TEAM" Then
                        lstChildren.Add(children.Item(1).InnerText)
                    End If
                Next
            Case "NFL"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/total/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                Dim children As HtmlNodeCollection = Nothing
                For i As Integer = 1 To nodes.Count - 1
                    children = nodes(i).ChildNodes
                    lstChildren.Add(children.Item(1).InnerText)
                Next
        End Select
        Return lstChildren
    End Function


    Public Sub ScrapeNCAABasketball(ByVal Tag As String, Optional ByVal Team As String = Nothing)
        Dim year As String = cmbSelectSeason.Text
        '******** GET TEAM ID *********
        Dim teamID As Integer

        Select Case Tag
            Case "TEAM SCHEDULE"
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/schedule/_/id/2166/year/2017", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS"   '***    TEST    ***
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/stats/_/id/2166/year/2017", "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM ROSTER"  '***    TEST    ***
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/roster/_/id/2166/davidson-wildcats", "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - SCORING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/scoring-per-game/sort/avgPoints/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Points"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - REBOUNDS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/rebounds/sort/avgRebounds/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Rebounds"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - FIELD GOALS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/field-goals/sort/fieldGoalPct/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Field Goals"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - FREE-THROWS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/free-throws/sort/freeThrowPct/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Free-Throws"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - 3-POINTS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/3-points/sort/threePointFieldGoalPct/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball 3-Points"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - ASSISTS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/assists/sort/avgAssists/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Assists"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - STEALS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/steals/sort/avgSteals/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Steals"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - BLOCKS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/blocks/sort/avgBlocks/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Blocks"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

        End Select
        dgvTableDisplay.AutoResizeColumns()
    End Sub

    Public Sub ScrapeNCAAFootball(ByVal Tag As String, Optional ByVal Team As String = Nothing)
        Dim year As String = cmbSelectSeason.Text
        '******** GET TEAM ID *********
        Dim teamID As Integer

        Select Case Tag
            Case "TEAM SCHEDULE"
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/schedule/_/id/58/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS"
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/stats/_/id/58/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM ROSTER"
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/roster/_/id/58/south-florida-bulls", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - TOTAL YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/sort/totalYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Total Yards Offense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - TOTAL YARDS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/position/defense/sort/totalYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Total Yards Defense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - DOWNS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/downs/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Downs"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - PASSING YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/passing/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Passing Offense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - PASSING YARDS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/passing/position/defense/sort/passingYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Passing Defense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - RUSHING YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/rushing/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Rushing Offense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - RUSHING YARDS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/rushing/position/defense/sort/rushingYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Rushing Defense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - RECEIVING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/receiving/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Receiving"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - RETURNING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/returning/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Returning"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - KICKING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/kicking/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Kicking"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - PUNTING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/punting/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Punting"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - DEFENSE"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/defense/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Defense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

        End Select
    End Sub

    Public Sub ScrapeNBA(ByVal Tag As String, Optional ByVal Team As String = Nothing) 'Add Year as a variable
        Dim year As String = cmbSelectSeason.Text
        Select Case Tag
            Case "TEAM SCHEDULE"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/schedule/_/name/" & teamID.ToString & "/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - REGULAR"   '***    TEST    ***
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/stats/_/name/" & teamID.ToString & "/year/" & year.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - POSTSEASON"   '***    TEST    ***
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/stats/_/name/" & teamID.ToString & "/year/" & year.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM ROSTER"  '***    TEST    ***
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/roster/_/name/" & teamID.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - OFFENSE"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/offense-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Offense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - DEFENSE"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/defense-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Defense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - DIFFERENTIAL"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/differential-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Differential"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - REBOUNDS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/rebounds-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Rebounds"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - MISCELLANEOUS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/miscellaneous-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Miscellaneous"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

        End Select
        dgvTableDisplay.AutoResizeColumns()
    End Sub

    Public Sub ScrapeNFL(ByVal Tag As String, Optional ByVal Team As String = Nothing)
        Dim year As String = cmbSelectSeason.Text
        Select Case Tag
            Case "TEAM SCHEDULE"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/schedule/_/name/" & teamID.ToString & "/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/stats/_/name/" & teamID.ToString & "/year/" & year.ToString & "/type/team", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM ROSTER"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/roster/_/name/" & teamID.ToString & "/dallas-cowboys", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - TOTAL YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/total/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Total Yards Offense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - DOWNS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/downs/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Downs Offense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    Dim dt As DataTable = StatsToDataTable(nodes)
                    dgvTableDisplay.DataSource = dt
                End If

            Case "TEAM STATS - PASSING YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/returning/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Passing Offense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - RUSHING YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/rushing/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Rushing Offense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - RECEIVING OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/receiving/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Receiving Offense"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - RETURNING OWN"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/returning/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Returning Own"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - KICKING OWN"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/kicking/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Kicking Own"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS- PUNTING OWN"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/punting/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Punting Own"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - DEFENSE OWN"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/defense/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Defense Own"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If

            Case "TEAM STATS - GIVE/TAKE"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/givetake/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Give/Take"   'Set Table Name
                '****** CENTER LABEL *******
                If nodes IsNot Nothing Then
                    StatsToTable(nodes, dgvTableDisplay)
                End If
        End Select
    End Sub

    '   League Stats: Create Nodes object of scraped data
    Public Function ScrapeLeagueStats(ByVal Sport As String, ByVal BaseURI As String, ByVal XPath As String)
        Dim doc As HtmlDocument = New HtmlWeb().Load(BaseURI)
        Dim nodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes(XPath)
        If Sport = "NCAAB" Then
            For i As Integer = 41 To 351
                doc = New HtmlWeb().Load(BaseURI & i.ToString)  'Get raw HTML of page
                Dim nodes2 As HtmlNodeCollection = doc.DocumentNode.SelectNodes(XPath)    'Get collection of table elements
                For Each node As HtmlNode In nodes2
                    nodes.Add(node)
                Next
                i += 40
            Next
        End If
        Return nodes
    End Function

    '   Team Stats: Create Nodes oject of scraped data
    Public Function ScrapeTeamStats(ByVal TeamID As Integer, ByVal Year As Integer, ByVal BaseURI As String, ByVal XPath As String)
        Dim doc As HtmlDocument = New HtmlWeb().Load(BaseURI)  'Get raw HTML of page
        Dim nodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes(XPath)    'Get collection of table elements
        Return nodes
    End Function

    '   From Nodes to DataGridView
    Public Sub StatsToTable(ByVal StatNodes As HtmlNodeCollection, ByVal Table As DataGridView)
        Dim colCount As Integer = StatNodes(1).ChildNodes.Count - 1
        Table.ColumnCount = colCount + 1     'Set columns
        Dim rowStart As Integer = 0
        Dim colspans As List(Of String) = Nothing
        Dim colHeaders As List(Of String) = Nothing
        Dim colspan As String
        If StatNodes(0).ChildNodes.Count <> Table.ColumnCount Then
            'Check for column headers
            For Each node As HtmlNode In StatNodes(0).ChildNodes
                colspan = node.Attributes(0).Value
                colspans.Add(colspan)
                colHeaders.Add(node.Name)
            Next
            rowStart = 1
        End If
        For i As Integer = 0 To colCount
            If colspans IsNot Nothing Then
                Dim count As Integer = 0
                For Each col In colspans
                    count += CType(col, Integer)
                    If i <= count Then

                    End If
                Next
            End If
            Table.Columns(i).Name = StatNodes(rowStart).ChildNodes(i).InnerText
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

    '   From Nodes to DataGridView
    Public Function StatsToDataTable(ByVal StatNodes As HtmlNodeCollection)
        Dim Table As New DataTable
        Dim colCount As Integer = StatNodes(1).ChildNodes.Count - 1
        For i = 0 To colCount
            Table.Columns.Add()
        Next
        Dim rowStart As Integer = 0
        If StatNodes(0).ChildNodes.Count <> colCount + 1 Then
            rowStart = 1
        End If
        For i As Integer = 0 To colCount
            Table.Columns(i).ColumnName = StatNodes(rowStart).ChildNodes(i).InnerText
        Next

        For i As Integer = 0 To StatNodes.Count - 1
            If StatNodes(i).ChildNodes.Count = Table.Columns.Count Then
                If StatNodes(i).FirstChild.InnerText <> "PER GAME" AndAlso StatNodes(i).FirstChild.InnerText <> "DATE" AndAlso StatNodes(i).FirstChild.InnerText <> "RK" Then     'Add data from nodes to rows
                    Table.Rows.Add()
                    Dim rowNum As Integer = Table.Rows.Count - 1
                    For x As Integer = 0 To colCount
                        If Not StatNodes(i).ChildNodes(x).InnerText = "&nbsp;" Then
                            Table.Rows(rowNum).Item(x) = StatNodes(i).ChildNodes(x).InnerText
                            'Table.Item(x, rowNum).Value = StatNodes(i).ChildNodes(x).InnerText
                        Else
                            Table.Rows(rowNum).Item(x) = ""
                        End If
                    Next
                End If
            End If
        Next
        Return Table
    End Function

    '   Nodes collection to DataTable for importing to database
    Public Function StatsToDataTable2(ByVal StatNodes As HtmlNodeCollection)
        Dim dt As New DataTable
        Dim colCount As Integer = StatNodes(1).ChildNodes.Count - 1
        For i As Integer = 0 To colCount   'Set columns
            Dim dataCol As New DataColumn
            dataCol.ColumnName = StatNodes(0).ChildNodes(i).InnerText
            dt.Columns.Add(dataCol)
        Next

        For i As Integer = 0 To StatNodes.Count - 1
            If StatNodes(i).ChildNodes.Count = dt.Columns.Count Then
                If StatNodes(i).FirstChild.InnerText <> "PER GAME" AndAlso StatNodes(i).FirstChild.InnerText <> "DATE" AndAlso StatNodes(i).FirstChild.InnerText <> "RK" Then     'Add data from nodes to rows
                    Dim rowNum As Integer = dt.Rows.Count + 1
                    For x As Integer = 0 To colCount
                        Dim newRow As DataRow = dt.Rows.Add
                        If Not StatNodes(i).ChildNodes(x).InnerText = "&nbsp;" Then
                            newRow.Item(x) = StatNodes(i).ChildNodes(x).InnerText
                        Else
                            newRow.Item(x) = ""
                        End If
                    Next
                End If
            End If
        Next
        Return dt
    End Function

    '   Populate Teams combobox on form
    Private Sub cmbSelectSport_TextChanged(sender As Object, e As EventArgs) Handles cmbSelectSport.TextChanged
        cmbSelectTeam1.DataSource = ScrapeTeams(cmbSelectSport.Text) 'PULL TEAMS FROM DB TABLE
    End Sub

    '   Populate Teams combobox on form
    Private Sub cmbSelectTeam1_TextChanged(sender As Object, e As EventArgs) Handles cmbSelectTeam1.TextChanged
        If cmbSelectTeam1.Text <> "ALL" Then
            cmbSelectTeam2.Enabled = True
            cmbSelectTeam2.DataSource = ScrapeTeams(cmbSelectSport.Text) 'PULL TEAMS FROM DB TABLE
        Else
            cmbSelectTeam2.Enabled = False
        End If
    End Sub

    Private Sub btnUpdateDB_Click(sender As Object, e As EventArgs) Handles btnUpdateDB.Click
        'ImportTableToDB(dt)
    End Sub

    Private Sub btnAddCols_Click(sender As Object, e As EventArgs) Handles btnAddCols.Click
        GetTeamIDs(dgvTableDisplay)
    End Sub

    Private Sub btnToExcel_Click(sender As Object, e As EventArgs) Handles btnToExcel.Click
        'Dim dt As System.Data.DataTable = DGVtoDataTable(dgvTableDisplay)
        Dim db As String = Nothing
        Dim table As String = Nothing
        Dim year As String = Nothing
        Select Case cmbSelectSport.Text
            Case "NCAA BASKETBALL"
                db = "NCAAB"
            Case "NCAA FOOTBALL"
                db = "NCAAFB"
            Case "NBA"
                db = "NBA"
            Case "NFL"
                db = "NFL"
        End Select
        table = cmbSelectStat.Text
        year = cmbSelectSeason.Text
        If db <> Nothing AndAlso table <> Nothing AndAlso year <> Nothing Then
            Dim filename As String = year & "." & db & "." & table
            Dim path As String = "Z:\EJ\MyPrograms\MoneyManager\CSVs\" & db & "\" & filename & ".txt"
            DGVtoCSV(dgvTableDisplay, path)
            'ImportCSVtoMySQL("", "", path) '<<<<<<<<<< FINISH; use getSQLString()
        End If
    End Sub
End Class