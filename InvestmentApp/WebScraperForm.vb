﻿Imports System.Text
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
                    dgvTableDisplay.DataSource = ScrapeNFL(cmbSelectStat.Text)
                Case "NBA"
                    dgvTableDisplay.DataSource = ScrapeNBA(cmbSelectStat.Text)
                Case "NCAA FOOTBALL"
                    dgvTableDisplay.DataSource = ScrapeNCAAFootball(cmbSelectStat.Text)
                Case "NCAA BASKETBALL"
                    dgvTableDisplay.DataSource = ScrapeNCAABasketball(cmbSelectStat.Text)
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
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAF", "http://www.espn.com/college-football/statistics/team/_/stat/total/sort/totalYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
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


    Public Function ScrapeNCAABasketball(ByVal Tag As String, Optional ByVal Team As String = Nothing)
        Dim year As String = cmbSelectSeason.Text
        '******** GET TEAM ID *********
        Dim teamID As Integer
        Dim nodes As HtmlNodeCollection = Nothing

        Select Case Tag
            Case "TEAM SCHEDULE"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/schedule/_/id/2166/year/2017", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM STATS"   '***    TEST    ***
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/stats/_/id/2166/year/2017", "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM ROSTER"  '***    TEST    ***
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/roster/_/id/2166/davidson-wildcats", "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "SCORING"
                nodes = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/scoring-per-game/sort/avgPoints/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Points"   'Set Table Name
            Case "REBOUNDS"
                nodes = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/rebounds/sort/avgRebounds/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Rebounds"   'Set Table Name
            Case "FIELD GOALS"
                nodes = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/field-goals/sort/fieldGoalPct/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Field Goals"   'Set Table Name
            Case "FREE-THROWS"
                nodes = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/free-throws/sort/freeThrowPct/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Free-Throws"   'Set Table Name
            Case "3-POINTS"
                nodes = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/3-points/sort/threePointFieldGoalPct/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball 3-Points"   'Set Table Name
            Case "ASSISTS"
                nodes = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/assists/sort/avgAssists/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Assists"   'Set Table Name
            Case "STEALS"
                nodes = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/steals/sort/avgSteals/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Steals"   'Set Table Name
            Case "BLOCKS"
                nodes = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/blocks/sort/avgBlocks/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Blocks"   'Set Table Name
        End Select
        If nodes IsNot Nothing Then
            Return StatsToDataTable(nodes, GetProperString(Tag))
            dgvTableDisplay.AutoResizeColumns()
        Else
            Return Nothing
        End If
    End Function

    Public Function ScrapeNCAAFootball(ByVal Tag As String, Optional ByVal Team As String = Nothing)
        Dim year As String = cmbSelectSeason.Text
        '******** GET TEAM ID *********
        Dim teamID As Integer
        Dim nodes As HtmlNodeCollection = Nothing

        Select Case Tag
            Case "TEAM SCHEDULE"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/schedule/_/id/58/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM STATS"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/stats/_/id/58/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM ROSTER"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/roster/_/id/58/south-florida-bulls", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TOTAL YARDS OFF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/sort/totalYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Total Yards Offense"   'Set Table Name
            Case "TOTAL YARDS DEF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/position/defense/sort/totalYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Total Yards Defense"   'Set Table Name
            Case "DOWNS"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/downs/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Downs"   'Set Table Name
            Case "PASSING YARDS OFF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/passing/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Passing Offense"   'Set Table Name
            Case "PASSING YARDS DEF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/passing/position/defense/sort/passingYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Passing Defense"   'Set Table Name
            Case "RUSHING YARDS OFF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/rushing/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Rushing Offense"   'Set Table Name
            Case "RUSHING YARDS DEF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/rushing/position/defense/sort/rushingYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Rushing Defense"   'Set Table Name
            Case "RECEIVING"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/receiving/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Receiving"   'Set Table Name
            Case "RETURNING"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/returning/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Returning"   'Set Table Name
            Case "KICKING"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/kicking/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Kicking"   'Set Table Name
            Case "PUNTING"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/punting/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Punting"   'Set Table Name
            Case "DEFENSE"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/defense/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Defense"   'Set Table Name
        End Select
        If nodes IsNot Nothing Then
            Return StatsToDataTable(nodes, Tag)
        Else
            Return Nothing
        End If
    End Function

    Public Function ScrapeNBA(ByVal Tag As String, Optional ByVal Team As String = Nothing) 'Add Year as a variable
        Dim year As String = cmbSelectSeason.Text
        Dim teamID As Integer = Nothing
        Dim nodes As HtmlNodeCollection = Nothing
        Select Case Tag
            Case "TEAM SCHEDULE"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/schedule/_/name/" & teamID.ToString & "/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "REGULAR"   '***    TEST    ***
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/stats/_/name/" & teamID.ToString & "/year/" & year.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "POSTSEASON"   '***    TEST    ***
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/stats/_/name/" & teamID.ToString & "/year/" & year.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM ROSTER"  '***    TEST    ***
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/roster/_/name/" & teamID.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "OFFENSE"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/offense-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Offense"   'Set Table Name
            Case "DEFENSE"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/defense-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Defense"   'Set Table Name
            Case "DIFFERENTIAL"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/differential-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Differential"   'Set Table Name
            Case "REBOUNDS"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/rebounds-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Rebounds"   'Set Table Name
            Case "MISCELLANEOUS"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/miscellaneous-per-game/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Miscellaneous"   'Set Table Name
        End Select
        If nodes IsNot Nothing Then
            Return StatsToDataTable(nodes, Tag)
        Else
            Return Nothing
        End If
        dgvTableDisplay.AutoResizeColumns()
    End Function

    Public Function ScrapeNFL(ByVal Tag As String, Optional ByVal Team As String = Nothing) As System.Data.DataTable
        Dim year As String = cmbSelectSeason.Text
        Dim teamID As Integer = Nothing
        Dim nodes As HtmlNodeCollection = Nothing
        Select Case Tag
            Case "TEAM SCHEDULE"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/schedule/_/name/" & teamID.ToString & "/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM STATS"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/stats/_/name/" & teamID.ToString & "/year/" & year.ToString & "/type/team", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM ROSTER"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/roster/_/name/" & teamID.ToString & "/dallas-cowboys", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TOTAL YARDS OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/total/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Total Yards Offense"   'Set Table Name
            Case "DOWNS OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/downs/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Downs Offense"   'Set Table Name
            Case "PASSING YARDS OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/returning/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Passing Offense"   'Set Table Name
            Case "RUSHING YARDS OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/rushing/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Rushing Offense"   'Set Table Name
            Case "RECEIVING OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/receiving/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Receiving Offense"   'Set Table Name
            Case "RETURNING OWN"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/returning/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Returning Own"   'Set Table Name
            Case "KICKING OWN"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/kicking/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Kicking Own"   'Set Table Name
            Case "PUNTING OWN"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/punting/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Punting Own"   'Set Table Name
            Case "DEFENSE OWN"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/defense/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Defense Own"   'Set Table Name
            Case "GIVE-TAKE"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/givetake/year/" & year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Give/Take"   'Set Table Name
        End Select
        If nodes IsNot Nothing Then
            Return StatsToDataTable(nodes, Tag)
        Else
            Return Nothing
        End If
    End Function

    '   League Stats: Create Nodes object of scraped data
    Public Function ScrapeLeagueStats(ByVal Sport As String, ByVal BaseURI As String, ByVal XPath As String)
        Dim doc As HtmlDocument = New HtmlWeb().Load(BaseURI)
        Dim nodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes(XPath)
        If Sport = "NCAAB" Then
            For i As Integer = 41 To 351
                doc = New HtmlWeb().Load(BaseURI & "/count/" & i.ToString)  'Get raw HTML of page
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

    Private Sub btnAddCols_Click(sender As Object, e As EventArgs) Handles btnAddCols.Click
        GetTeamIDs(dgvTableDisplay)
    End Sub

    Private Sub btnToExcel_Click(sender As Object, e As EventArgs) Handles btnToExcel.Click
        Dim db As String = Nothing
        Dim table As String = Nothing
        Dim year As String = Nothing
        ' Single Table to Excel
        Dim sport As String = cmbSelectSport.Text

        Select Case sport.ToLower
            Case "ncaa_basketball"
                db = "ncaab"
            Case "ncaa_football"
                db = "ncaaf"
            Case "nba"
                db = "nba"
            Case "nfl"
                db = "nfl"
        End Select
        table = cmbSelectStat.Text
        Year = cmbSelectSeason.Text
        If db <> Nothing AndAlso table <> Nothing AndAlso year <> Nothing Then
            Dim filename As String = year & "_" & db & "_" & table
            Dim path As String = "Z:\EJ\MyPrograms\MoneyManager\CSVs\" & db & "\" & filename & ".txt"
            Dim dt As DataTable
            Select Case db
                Case "ncaab"
                    dt = ScrapeNCAABasketball(table)
                Case "ncaaf"
                    dt = ScrapeNCAAFootball(table)
                Case "nba"
                    dt = ScrapeNBA(table)
                Case "nfl"
                    dt = ScrapeNFL(table)
            End Select
            Dim newColumn As New System.Data.DataColumn(GetProperString(table) & "_year", GetType(System.String))
            newColumn.DefaultValue = CInt(year)
            dt.Columns.Add(newColumn)
            DatatableToCSV(dt, path)
            'DGVtoCSV(dgvTableDisplay, path)
            'ImportCSVtoMySQL(db, table, path)
        End If
    End Sub

    Private Sub btnUpdateDB_Click(sender As Object, e As EventArgs) Handles btnUpdateDB.Click
        Dim dt As System.Data.DataTable = Nothing
        Dim db As String = Nothing
        Dim table As String = Nothing
        Dim year As String = Nothing
        Dim count As Integer = 0
        Dim file As System.IO.StreamWriter = Nothing
        file = My.Computer.FileSystem.OpenTextFileWriter("Z:\EJ\MyPrograms\MoneyManager\Columns.txt", True)

        For Each db In GetDatasource("Sports")
            db.ToLower()
            Select Case GetProperString(db)
                Case "ncaa_basketball"
                    db = "ncaab"
                Case "ncaa_football"
                    db = "ncaaf"
                Case "nfl"
                    db = "nfl"
                Case "nba"
                    db = "nba"
            End Select
            For Each year In GetDatasource("Years" & db.ToUpper)
                For Each table In GetDatasource("Stats" & db.ToUpper)
                    If db <> Nothing AndAlso table <> Nothing AndAlso year <> Nothing Then
                        Dim filename As String = year & "_" & db & "_" & GetProperString(table)
                        Dim path As String = "Z:\EJ\MyPrograms\MoneyManager\CSVs\" & db & "\" & filename & ".txt"
                        Select Case db
                            Case "ncaab"
                                dt = ScrapeNCAABasketball(table)
                            Case "ncaaf"
                                dt = ScrapeNCAAFootball(table)
                            Case "nfl"
                                dt = ScrapeNFL(table)
                            Case "nba"
                                dt = ScrapeNBA(table)
                        End Select
                        Dim newColumn As New System.Data.DataColumn(GetProperString(table) & "_year", GetType(System.String))     'Add Year Column to DataTable
                        newColumn.DefaultValue = CInt(year)
                        dt.Columns.Add(newColumn)
                        'DatatableToCSV(dt, path)
                        'DGVtoCSV(dgvTableDisplay, path)
                        ImportCSVtoMySQL(db, table, path)
                        ' Write columns to TXT File
                        'ExportTableColumnsToCSV(dt)
                    End If
                Next
            Next
        Next
        file.Close()
    End Sub

End Class