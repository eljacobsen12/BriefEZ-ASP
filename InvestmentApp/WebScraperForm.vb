﻿Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions
Imports HtmlAgilityPack

Public Class WebScraperForm
    Private Sub WebScraperTEST_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbSelectSeason.DataSource = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002"}
        cmbSelectSport.DataSource = {"NFL", "NBA", "NCAA Football", "NCAA Basketball"}
        cmbSelectTeam.DataSource = {} 'PULL TEAMS FROM DB TABLE
    End Sub

    Private Sub btnExtract_Click(sender As Object, e As EventArgs) Handles btnExtract.Click
        dgvTableDisplay.Rows.Clear()
        Select Case cmbSelectSport.Text
            Case "NFL"
                If cmbSelectTeam.Text <> Nothing Then
                    'ScrapeNFLTeam()
                End If
                ScrapeNFL(cmbSelectStat.Text)
            Case "NBA"
                If cmbSelectTeam.Text <> Nothing Then
                    'ScrapeNBATeam()
                End If
                ScrapeNBA(cmbSelectStat.Text)
            Case "NCAA Football"
                If cmbSelectTeam.Text <> Nothing Then
                    'ScrapeNCAAFootballTeam()
                End If
                ScrapeNCAAFootball(cmbSelectStat.Text)
            Case "NCAA Basketball"
                If cmbSelectTeam.Text <> Nothing Then
                    'ScrapeNCAABasketballTeam()
                End If
                ScrapeNCAABasketball(cmbSelectStat.Text)
        End Select
        dgvTableDisplay.AutoResizeColumns()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    '**********************************************
    '**  Scrape and filter with HTMLAgilityPack  **
    '**********************************************
    Public Sub ScrapeNCAABasketball(ByVal Tag As String, Optional ByVal Team As String = Nothing)
        Select Case Tag
            Case "TEAMS"
                Dim baseURI As String = checkURL("www.espn.com/mens-college-basketball/teams")
                Dim doc As HtmlDocument = New HtmlWeb().Load(baseURI)  'Get raw HTML of page
                Dim teams As HtmlNodeCollection = doc.DocumentNode.SelectNodes("//div")    'Get collection of table elements

                lblTableName.Text = teams.Nodes.First.InnerText
            Case "TEAM SCHEDULE"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/schedule/_/id/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM STATS"   '***    TEST    ***
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/stats/_/id/", "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM ROSTER"  '***    TEST    ***
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/roster/_/id/", "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM STATS - SCORING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/scoring/sort/points/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Points"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - SCORING PER GAME"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/scoring-per-game/sort/avgPoints/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Points"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - REBOUNDS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/rebounds/sort/avgRebounds/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Rebounds"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 8)

            Case "TEAM STATS - FIELD GOALS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/field-goals/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Field Goals"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - FREE-THROWS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/free-throws/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Free-Throws"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 8)

            Case "TEAM STATS - 3-POINTS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/3-points/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball 3-Points"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - ASSISTS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/assists/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Assists"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 7)

            Case "TEAM STATS - STEALS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/steals/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Steals"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - BLOCKS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAB", "http://www.espn.com/mens-college-basketball/statistics/team/_/stat/blocks/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Basketball Blocks"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 6)

        End Select
        dgvTableDisplay.AutoResizeColumns()
    End Sub

    Public Sub ScrapeNCAAFootball(ByVal Tag As String, Optional ByVal Team As String = Nothing)
        Select Case Tag
            Case "TEAM SCHEDULE"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/schedule/_/id/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM STATS"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/stats/_/id/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM ROSTER"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/roster/_/id/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM STATS - TOTAL YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/sort/totalYards/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Total Yards Offense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - TOTAL YARDS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/position/defense/sort/totalYards/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Total Yards Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - DOWNS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/downs/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Downs"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - PASSING YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/passing/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Passing Offense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - PASSING YARDS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/passing/position/defense/sort/passingYards/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Passing Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - RUSHING YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/rushing/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Rushing Offense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 7)

            Case "TEAM STATS - RUSHING YARDS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/rushing/position/defense/sort/rushingYards/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Rushing Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 7)

            Case "TEAM STATS - RECEIVING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/receiving/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Receiving"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 7)

            Case "TEAM STATS - RETURNING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/returning/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Returning"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - KICKING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/kicking/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Kicking"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS- PUNTING"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/punting/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Punting"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - DEFENSE"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 12)

        End Select
    End Sub

    Public Sub ScrapeNBA(ByVal Tag As String, Optional ByVal Team As String = Nothing)
        Select Case Tag
            Case "TEAM SCHEDULE"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/schedule/_/name/" & teamID.ToString & "/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 4)

            Case "TEAM STATS - REGULAR"   '***    TEST    ***
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/stats/_/name/bos/year/" & "/year/" & "/seasontype/2", "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM STATS - POSTSEASON"   '***    TEST    ***
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/stats/_/name/" & teamID.ToString & "/year/", "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM ROSTER"  '***    TEST    ***
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/roster/_/name/" & teamID, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM STATS - OFFENSE"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/offense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Offense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - DEFENSE"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - DIFFERENTIAL"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/differential/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Differential"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 11)

            Case "TEAM STATS - REBOUNDS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/rebounds/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Rebounds"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 8)

            Case "TEAM STATS - MISCELLANEOUS"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/miscellaneous/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Miscellaneous"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 12)

        End Select
        dgvTableDisplay.AutoResizeColumns()
    End Sub

    Public Sub ScrapeNFL(ByVal Tag As String, Optional ByVal Team As String = Nothing)
        Select Case Tag
            Case "TEAM SCHEDULE"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/schedule/_/name/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 4)

            Case "TEAM STATS"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/stats/_/name/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM ROSTER"
                '******** GET TEAM ID *********
                Dim teamID As Integer
                Dim nodes As HtmlNodeCollection = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/roster/_/name/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 3)

            Case "TEAM STATS - TOTAL YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/total/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Total Yards Offense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - TOTAL YARDS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/total/position/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Total Yards Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - DOWNS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/downs/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Downs Offense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - DOWNS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/downs/position/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Downs Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - PASSING YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/passing/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Passing Offense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - PASSING YARDS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/passing/position/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Passing Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - RUSHING YARDS OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/rushing/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Rushing Offense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - RUSHING YARDS DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/rushing/position/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Rushing Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - RECEIVING OFF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/receiving/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Receiving Offense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - RECEIVING DEF"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/receiving/position/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Receiving Defense"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 9)

            Case "TEAM STATS - RETURNING OWN"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/returning/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Returning Own"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 12)

            Case "TEAM STATS - RETURNING OPP"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/returning/position/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Returning Opponent"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 12)

            Case "TEAM STATS - KICKING OWN"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/kicking/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Kicking Own"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - KICKING OPP"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/kicking/position/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Kicking Opponent"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS- PUNTING OWN"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/punting/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Punting Own"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS- PUNTING OPP"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/punting/position/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Punting Opponent"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 13)

            Case "TEAM STATS - DEFENSE OWN"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Defense Own"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 14)

            Case "TEAM STATS - DEFENSE OPP"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/defense/position/defense/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Defense Opponent"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 14)

            Case "TEAM STATS - GIVE/TAKE"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/givetake/year/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Give/Take"   'Set Table Name
                '****** CENTER LABEL *******
                StatsToTable(nodes, dgvTableDisplay, 8)

        End Select
    End Sub

    Public Function ScrapeLeagueStats(ByVal Sport As String, ByVal BaseURI As String, ByVal XPath As String)
        BaseURI = BaseURI & cmbSelectSeason.Text & "/count/"
        Dim doc As HtmlDocument = New HtmlWeb().Load(BaseURI & 1)
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

    Public Function ScrapeTeamStats(ByVal TeamID As Integer, ByVal Year As Integer, ByVal BaseURI As String, ByVal XPath As String)
        BaseURI = BaseURI & TeamID & "/year/" & Year

        Dim doc As HtmlDocument = New HtmlWeb().Load(BaseURI)  'Get raw HTML of page
        Dim nodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes(XPath)    'Get collection of table elements
        Return nodes
    End Function

    Public Sub StatsToTable(ByVal StatNodes As HtmlNodeCollection, ByVal Table As DataGridView, ByVal NumberOfCols As Integer)
        dgvTableDisplay.ColumnCount = StatNodes(1).ChildNodes.Count     'Set columns
        Dim rowStart As Integer = 0
        If StatNodes(0).ChildNodes.Count <> dgvTableDisplay.ColumnCount Then
            rowStart = 1
        End If
        For i As Integer = 0 To NumberOfCols
            dgvTableDisplay.Columns(i).Name = StatNodes(rowStart).ChildNodes(i).InnerText
        Next

        For i As Integer = 0 To StatNodes.Count - 1
            If StatNodes(i).ChildNodes.Count = dgvTableDisplay.ColumnCount Then
                If StatNodes(i).FirstChild.InnerText <> "PER GAME" AndAlso StatNodes(i).FirstChild.InnerText <> "DATE" AndAlso StatNodes(i).FirstChild.InnerText <> "RK" Then     'Add data from nodes to rows
                    Dim rowNum As Integer = dgvTableDisplay.Rows.Add()
                    For x As Integer = 0 To NumberOfCols
                        If Not StatNodes(i).ChildNodes(x).InnerText = "&nbsp;" Then
                            dgvTableDisplay.Item(x, rowNum).Value = StatNodes(i).ChildNodes(x).InnerText
                        Else
                            dgvTableDisplay.Item(x, rowNum).Value = ""
                        End If
                    Next
                End If
            End If
        Next
    End Sub

    Private Sub cmbSelectSport_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSelectSport.SelectedValueChanged
        Select Case cmbSelectSport.Text
            Case "NCAA Basketball"
                cmbSelectStat.DataSource = {"TEAM STATS - SCORING", "TEAM STATS - SCORING PER GAME", "TEAM STATS - REBOUNDS", "TEAM STATS - FIELD GOALS", "TEAM STATS - FREE-THROWS", "TEAM STATS - 3-POINTS", "TEAM STATS - ASSISTS", "TEAM STATS - STEALS", "TEAM STATS - BLOCKS", "TEAM SCHEDULE", "TEAM STATS", "TEAM ROSTER"}
            Case "NCAA Football"
                cmbSelectStat.DataSource = {"TEAM STATS - TOTAL YARDS OFF", "TEAM STATS - TOTAL YARDS DEF", "TEAM STATS - DOWNS", "TEAM STATS - PASSING YARDS OFF", "TEAM STATS - PASSING YARDS DEF", "TEAM STATS - RUSHING YARDS OFF", "TEAM STATS - RUSHING YARDS DEF", "TEAM STATS - RECEIVING", "TEAM STATS - RETURNING", "TEAM STATS - KICKING", "TEAM STATS- PUNTING", "TEAM STATS - DEFENSE", "TEAM SCHEDULE", "TEAM STATS", "TEAM ROSTER"}
            Case "NBA"
                cmbSelectStat.DataSource = {"TEAM STATS - OFFENSE", "TEAM STATS - DEFENSE", "TEAM STATS - DIFFERENTIAL", "TEAM STATS - REBOUNDS", "TEAM STATS - MISCELLANEOUS", "TEAM SCHEDULE", "TEAM STATS - REGULAR", "TEAM STATS - POSTSEASON", "TEAM ROSTER"}
            Case "NFL"
                cmbSelectStat.DataSource = {"TEAM STATS - TOTAL YARDS OFF", "TEAM STATS - TOTAL YARDS DEF", "TEAM STATS - DOWNS OWN", "TEAM STATS - DOWNS OPP", "TEAM STATS - PASSING YARDS OFF", "TEAM STATS - PASSING YARDS DEF", "TEAM STATS - RUSHING YARDS OFF", "TEAM STATS - RUSHING YARDS DEF", "TEAM STATS - RECEIVING OFF", "TEAM STATS - RECEIVING DEF", "TEAM STATS - RETURNING OWN", "TEAM STATS - RETURNING OPP", "TEAM STATS - KICKING OWN", "TEAM STATS - KICKING OPP", "TEAM STATS- PUNTING OWN", "TEAM STATS- PUNTING OPP", "TEAM STATS - DEFENSE OWN", "TEAM STATS - DEFENSE OPP", "TEAM STATS - GIVE/TAKE", "TEAM SCHEDULE", "TEAM STATS", "TEAM ROSTER"}
        End Select
    End Sub

End Class