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
                cmbSelectSeason.DataSource = GetDatasource("YearsNCAAFB")
            Case "NBA"
                cmbSelectSeason.DataSource = GetDatasource("YearsNBA")
            Case "NFL"
                cmbSelectSeason.DataSource = GetDatasource("YearsNFL")
            Case "MLB"
                cmbSelectSeason.DataSource = GetDatasource("YearsMLB")
        End Select
        cmbSelectTeam1.DataSource = ScrapeTeams(cmbSelectSport.Text) 'PULL TEAMS FROM DB TABLE
    End Sub

    '   Populate comboboxes on form based on selected sport
    Private Sub cmbSelectSport_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSelectSport.SelectedValueChanged
        Select Case cmbSelectSport.Text
            Case "NCAA BASKETBALL"
                cmbSelectStat.DataSource = GetDatasource("StatsNCAAB")
            Case "NCAA FOOTBALL"
                cmbSelectStat.DataSource = GetDatasource("StatsNCAAFB")
            Case "NBA"
                cmbSelectStat.DataSource = GetDatasource("StatsNBA")
            Case "NFL"
                cmbSelectStat.DataSource = GetDatasource("StatsNFL")
            Case "MLB"
                cmbSelectStat.DataSource = GetDatasource("StatsMLB")
        End Select
    End Sub

    Private Sub btnScrape_Click(sender As Object, e As EventArgs) Handles btnScrape.Click
        If cmbSelectTeam1.Text <> Nothing Then
            Select Case cmbSelectSport.Text
                Case "NFL"
                    Dim count As Integer = 0
                    Dim data As System.Data.DataTable = Nothing
                    While data Is Nothing Or count > 5
                        data = ScrapeNFL(cmbSelectStat.Text, cmbSelectSeason.Text)
                        count += 1
                    End While
                    dgvTableDisplay.DataSource = data
                Case "NBA"
                    dgvTableDisplay.DataSource = ScrapeNBA(cmbSelectStat.Text, cmbSelectSeason.Text)
                Case "MLB"
                    dgvTableDisplay.DataSource = ScrapeMLB(cmbSelectStat.Text, cmbSelectSeason.Text)
                Case "NCAA FOOTBALL"
                    dgvTableDisplay.DataSource = ScrapeNCAAFootball(cmbSelectStat.Text, cmbSelectSeason.Text)
                Case "NCAA BASKETBALL"
                    dgvTableDisplay.DataSource = ScrapeNCAABasketball(cmbSelectStat.Text, cmbSelectSeason.Text)
            End Select
        End If
        dgvTableDisplay.AutoResizeColumns()
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
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/sort/totalYards/year/" & year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
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
            Case "MLB"
                Dim nodes As HtmlNodeCollection = ScrapeLeagueStats("MLB", "http://www.espn.com/mlb/stats/team/_/stat/batting/year" & year.ToString, "//tr[@class]")
                Dim children As HtmlNodeCollection = Nothing
                For i As Integer = 2 To nodes.Count - 1
                    children = nodes(i).ChildNodes
                    If children.Item(1).InnerText <> "66" Then
                        lstChildren.Add(children.Item(1).InnerText)
                    End If
                Next
        End Select
        Return lstChildren
    End Function


    Public Function ScrapeNCAABasketball(ByVal Tag As String, ByVal year As String, Optional ByVal Team1 As String = Nothing, Optional ByVal Team2 As String = Nothing)
        '******** GET TEAM ID *********
        Dim teamID As Integer
        Dim nodes As HtmlNodeCollection = Nothing

        Select Case Tag
            Case "TEAM SCHEDULE"
                nodes = ScrapeTeamSchedules(cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/team/schedule/_/id/150", "//tr[@class]")   ' "/html[1]/body[1]/div[6]/section[1]/section[1]/div[1]/section[1]/div[1]/div[2]/div[2]/div[1]/div[1]/table[1]/tr"
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
        Else
            Return Nothing
        End If
        dgvTableDisplay.AutoResizeColumns()
    End Function

    Public Function ScrapeNCAAFootball(ByVal Tag As String, ByVal Year As String, Optional ByVal Team1 As String = Nothing, Optional ByVal Team2 As String = Nothing)
        '******** GET TEAM ID *********
        Dim teamID As Integer
        Dim nodes As HtmlNodeCollection = Nothing

        Select Case Tag
            Case "TEAM SCHEDULE"
                nodes = ScrapeTeamSchedules(cmbSelectSeason.Text, "http://www.espn.com/mens-college-basketball/schedule/_/date/20151122/group/50", "//*[@id=""sched-container""]/div[2]/div/div[1]/table/tbody/tr[1]/td[1]/a")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM STATS"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/stats/_/id/58/", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM ROSTER"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/college-football/team/roster/_/id/58/south-florida-bulls", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TOTAL YARDS OFF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/sort/totalYards/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Total Yards Offense"   'Set Table Name
            Case "TOTAL YARDS DEF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/total/position/defense/sort/totalYards/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Total Yards Defense"   'Set Table Name
            Case "DOWNS"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/downs/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Downs"   'Set Table Name
            Case "PASSING YARDS OFF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/passing/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Passing Offense"   'Set Table Name
            Case "PASSING YARDS DEF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/passing/position/defense/sort/passingYards/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Passing Defense"   'Set Table Name
            Case "RUSHING YARDS OFF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/rushing/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Rushing Offense"   'Set Table Name
            Case "RUSHING YARDS DEF"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/rushing/position/defense/sort/rushingYards/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Rushing Defense"   'Set Table Name
            Case "RECEIVING"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/receiving/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Receiving"   'Set Table Name
            Case "RETURNING"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/returning/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Returning"   'Set Table Name
            Case "KICKING"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/kicking/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Kicking"   'Set Table Name
            Case "PUNTING"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/punting/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Punting"   'Set Table Name
            Case "DEFENSE"
                nodes = ScrapeLeagueStats("NCAAFB", "http://www.espn.com/college-football/statistics/team/_/stat/defense/year/" & Year.ToString, "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NCAA Football Defense"   'Set Table Name
        End Select
        If nodes IsNot Nothing Then
            Return StatsToDataTable(nodes, Tag)
        Else
            Return Nothing
        End If
        dgvTableDisplay.AutoResizeColumns()
    End Function

    Public Function ScrapeNBA(ByVal Tag As String, ByVal Year As String, Optional ByVal Team1 As String = Nothing, Optional ByVal Team2 As String = Nothing) 'Add Year as a variable
        Dim teamID As Integer = Nothing
        Dim nodes As HtmlNodeCollection = Nothing
        Select Case Tag
            Case "TEAM SCHEDULE"
                nodes = ScrapeTeamSchedules(cmbSelectSeason.Text, "http://www.espn.com/nba/schedule/_/date/20160405", "")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "REGULAR"   '***    TEST    ***
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/stats/_/name/" & teamID.ToString & "/year/" & Year.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "POSTSEASON"   '***    TEST    ***
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/stats/_/name/" & teamID.ToString & "/year/" & Year.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM ROSTER"  '***    TEST    ***
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/roster/_/name/" & teamID.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "OFFENSE"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/offense-per-game/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Offense"   'Set Table Name
            Case "DEFENSE"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/defense-per-game/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Defense"   'Set Table Name
            Case "DIFFERENTIAL"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/differential-per-game/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Differential"   'Set Table Name
            Case "REBOUNDS"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/rebounds-per-game/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Rebounds"   'Set Table Name
            Case "MISCELLANEOUS"
                nodes = ScrapeLeagueStats("NBA", "http://www.espn.com/nba/statistics/team/_/stat/miscellaneous-per-game/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NBA Miscellaneous"   'Set Table Name
        End Select
        If nodes IsNot Nothing Then
            Return StatsToDataTable(nodes, Tag)
        Else
            Return Nothing
        End If
        dgvTableDisplay.AutoResizeColumns()
    End Function

    Public Function ScrapeNFL(ByVal Tag As String, ByVal Year As String, Optional ByVal Team1 As String = Nothing, Optional ByVal Team2 As String = Nothing) As System.Data.DataTable
        Dim teamID As Integer = Nothing
        Dim nodes As HtmlNodeCollection = Nothing
        Select Case Tag
            Case "TEAM SCHEDULE"
                nodes = ScrapeTeamSchedules(cmbSelectSeason.Text, "http://www.espn.com/nfl/schedule/_/week/2/year/2017", "")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM STATS"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/stats/_/name/" & teamID.ToString & "/year/" & Year.ToString & "/type/team", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM ROSTER"
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nfl/team/roster/_/name/" & teamID.ToString & "/dallas-cowboys", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[4]/div[2]/div[1]/div[1]/table[1]/tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TOTAL YARDS OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/total/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Total Yards Offense"   'Set Table Name
            Case "DOWNS OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/downs/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Downs Offense"   'Set Table Name
            Case "PASSING YARDS OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/returning/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Passing Offense"   'Set Table Name
            Case "RUSHING YARDS OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/rushing/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Rushing Offense"   'Set Table Name
            Case "RECEIVING OFF"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/receiving/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Receiving Offense"   'Set Table Name
            Case "RETURNING OWN"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/returning/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Returning Own"   'Set Table Name
            Case "KICKING OWN"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/kicking/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Kicking Own"   'Set Table Name
            Case "PUNTING OWN"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/punting/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Punting Own"   'Set Table Name
            Case "DEFENSE OWN"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/defense/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Defense Own"   'Set Table Name
            Case "GIVE-TAKE"
                nodes = ScrapeLeagueStats("NFL", "http://www.espn.com/nfl/statistics/team/_/stat/givetake/year/" & Year.ToString & "/seasontype/2", "/html[1]/body[1]/div[1]/div[2]/div[1]/div[2]/div[3]/div[1]/div[1]/div[2]/table[1]/tr")
                lblTableName.Text = cmbSelectSeason.Text & " " & "NFL Football Give/Take"   'Set Table Name
        End Select
        If nodes IsNot Nothing Then
            Return StatsToDataTable(nodes, Tag)
        Else
            Return Nothing
        End If
        dgvTableDisplay.AutoResizeColumns()
    End Function

    Public Function ScrapeMLB(ByVal Tag As String, ByVal Year As String, Optional ByVal Team1 As String = Nothing, Optional ByVal Team2 As String = Nothing) 'Add Year as a variable
        Dim teamID As Integer = Nothing
        Dim nodes As HtmlNodeCollection = Nothing
        Select Case Tag
            Case "TEAM SCHEDULE"
                nodes = ScrapeTeamSchedules(cmbSelectSeason.Text, "http://www.espn.com/mlb/team/schedule/_/name/cin/year/2017/half/1", "//tr[@class]") ' Second Half: http://www.espn.com/mlb/team/schedule/_/name/cin/year/2017
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "TEAM ROSTER"  '***    TEST    ***
                nodes = ScrapeTeamStats(teamID, cmbSelectSeason.Text, "http://www.espn.com/nba/team/roster/_/name/" & teamID.ToString, "//*[@id=""my-teams-table""]//tr")
                lblTableName.Text = nodes.First.InnerText   'Set Table Name
            Case "BATTING"
                nodes = ScrapeLeagueStats("MLB", "http://www.espn.com/mlb/stats/team/_/stat/batting/year/" & Year.ToString & "/seasontype/2", "//tr[@class]")
                lblTableName.Text = cmbSelectSeason.Text & " " & "MLB Batting"   'Set Table Name
            Case "PITCHING"
                nodes = ScrapeLeagueStats("MLB", "http://www.espn.com/mlb/stats/team/_/stat/pitching/year/" & Year.ToString & "/seasontype/2", "//tr[@class]")
                lblTableName.Text = cmbSelectSeason.Text & " " & "MLB Pitching"   'Set Table Name
            Case "FIELDING"
                nodes = ScrapeLeagueStats("MLB", "http://www.espn.com/mlb/stats/team/_/stat/fielding/year/" & Year.ToString & "/seasontype/2", "//tr[@class]")
                lblTableName.Text = cmbSelectSeason.Text & " " & "MLB Fielding"   'Set Table Name
        End Select
        If nodes IsNot Nothing Then
            Return StatsToDataTable(nodes, Tag)
        Else
            Return Nothing
        End If
        dgvTableDisplay.AutoResizeColumns()
    End Function

    '   League Stats: Create Nodes object of scraped data
    Public Function ScrapeLeagueStats(ByVal Sport As String, ByVal BaseURI As String, ByVal XPath As String)
        Dim doc As HtmlDocument = New HtmlWeb().Load(BaseURI)
        Dim nodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes(XPath)
        ' Because sometime the page doesn't load first try??? 3/12/18
        If nodes Is Nothing Then
            doc = New HtmlWeb().Load(BaseURI)
            nodes = doc.DocumentNode.SelectNodes(XPath)
        End If

        nodes = doc.DocumentNode.SelectNodes(XPath)
        If Sport = "NCAAB" Then
            For i As Integer = 41 To 351
                doc = New HtmlWeb().Load(BaseURI & "/count/" & i.ToString)  'Get raw HTML of page
                Dim nodes2 As HtmlNodeCollection = doc.DocumentNode.SelectNodes(XPath)    'Get collection of table elements
                If nodes2 IsNot Nothing Then
                    For Each node As HtmlNode In nodes2
                        nodes.Add(node)
                    Next
                End If
                i += 40
            Next
        End If
        Return nodes
    End Function

    '   Team Stats: Create Nodes oject of scraped data.
    Public Function ScrapeTeamStats(ByVal TeamID As Integer, ByVal Year As Integer, ByVal BaseURI As String, ByVal XPath As String)
        Dim doc As HtmlDocument = New HtmlWeb().Load(BaseURI)  'Get raw HTML of page.
        Dim nodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes(XPath)    'Get collection of table elements.
        Return nodes
    End Function

    '   Team Schedules: Create Nodes object of scraped data.
    Public Function ScrapeTeamSchedules(ByVal Year As Integer, ByVal BaseURI As String, ByVal XPath As String)
        Dim doc As HtmlDocument = New HtmlWeb().Load(BaseURI)  'Get raw HTML of page.
        Dim nodes As HtmlNodeCollection = doc.DocumentNode.SelectNodes(XPath)    'Get collection of table elements.
        Return nodes
    End Function

    '   Populate Teams combobox on form.
    Private Sub cmbSelectSport_TextChanged(sender As Object, e As EventArgs) Handles cmbSelectSport.TextChanged
        cmbSelectTeam1.DataSource = ScrapeTeams(cmbSelectSport.Text) 'PULL TEAMS FROM DB TABLE.
    End Sub

    '   Populate Teams combobox on form.
    Private Sub cmbSelectTeam1_TextChanged(sender As Object, e As EventArgs) Handles cmbSelectTeam1.TextChanged
        If cmbSelectTeam1.Text <> "ALL" Then
            cmbSelectTeam2.Enabled = True
            cmbSelectTeam2.DataSource = ScrapeTeams(cmbSelectSport.Text) 'PULL TEAMS FROM DB TABLE.
        Else
            cmbSelectTeam2.Enabled = False
        End If
    End Sub

    Private Sub btnPull_Click(sender As Object, e As EventArgs) Handles btnPull.Click
        'GetTeamIDs(dgvTableDisplay)
        Dim dt As DataTable = sqlSelectTable(cmbSelectSport.Text, cmbSelectStat.Text, cmbSelectSeason.Text)
        dgvTableDisplay.DataSource = dt
        If cmbSelectTeam1.Text <> "ALL" Then
            Dim custDV As New DataView(dt)
            custDV.RowFilter = cmbSelectStat.Text.ToLower & "_team='" & cmbSelectTeam1.Text.ToLower & "' OR " & cmbSelectStat.Text.ToLower & "_team='" & cmbSelectTeam2.Text.ToLower & "'"
            dgvTableDisplay.DataSource = custDV
        End If
        dgvTableDisplay.AutoSize = True
    End Sub

    Private Sub btnToExcel_Click(sender As Object, e As EventArgs) Handles btnToExcel.Click
        Dim db As String = Nothing
        Dim table As String = Nothing
        Dim year As String = Nothing
        ' Single Table to Excel.
        Dim sport As String = GetProperString(cmbSelectSport.Text)

        Select Case sport.ToLower
            Case "ncaa_basketball"
                db = "ncaab"
            Case "ncaa_football"
                db = "ncaafb"
            Case "nba"
                db = "nba"
            Case "nfl"
                db = "nfl"
        End Select
        table = GetProperString(cmbSelectStat.Text)
        year = cmbSelectSeason.Text
        If db <> Nothing AndAlso table <> Nothing AndAlso year <> Nothing Then
            Dim filename As String = year & "_" & db & "_" & table
            Dim path As String = "Z:\EJ\MyPrograms\MoneyManager\CSVs\" & db & "\" & filename & ".txt"
            Dim dt As DataTable = Nothing
            'Select Case db
            '    Case "ncaab"
            '        dt = ScrapeNCAABasketball(table, year)
            '        If dt Is Nothing Then dt = ScrapeNCAABasketball(table, year)
            '    Case "ncaafb"
            '        dt = ScrapeNCAAFootball(table, year)
            '        If dt Is Nothing Then dt = ScrapeNCAAFootball(table, year)
            '    Case "nba"
            '        dt = ScrapeNBA(table, year)
            '        If dt Is Nothing Then dt = ScrapeNBA(table, year)
            '    Case "nfl"
            '        dt = ScrapeNFL(table, year)
            '        If dt Is Nothing Then dt = ScrapeNFL(table, year)
            'End Select
            'Dim newColumn As New System.Data.DataColumn(GetProperString(table) & "_year", GetType(System.String))
            'newColumn.DefaultValue = CInt(year)
            'dt.Columns.Add(newColumn)
            'DatatableToCSV(dt, path)
            DGVtoCSV(dgvTableDisplay, path)
            'ImportCSVtoMySQL(db, table, path)
        End If
    End Sub

    Private Sub btnUpdateDB_Click(sender As Object, e As EventArgs) Handles btnUpdateDB.Click
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
                    db = "ncaafb"
                Case "nfl"
                    db = "nfl"
                Case "nba"
                    db = "nba"
                Case "mlb"
                    db = "mlb"
            End Select
            For Each year In GetDatasource("Years" & db.ToUpper)
                For Each table In GetDatasource("Stats" & db.ToUpper)
                    If db <> Nothing AndAlso table <> Nothing AndAlso year <> Nothing Then
                        Dim filename As String = year & "_" & db & "_" & GetProperString(table)
                        Dim path As String = "Z:\EJ\MyPrograms\MoneyManager\CSVs\" & db & "\" & filename & ".txt"
                        Dim dt As DataTable = Nothing
                        Select Case db
                            Case "ncaab"
                                dt = ScrapeNCAABasketball(table, year)
                                If dt Is Nothing Then dt = ScrapeNCAABasketball(table, year)
                            Case "ncaafb"
                                dt = ScrapeNCAAFootball(table, year)
                                If dt Is Nothing Then dt = ScrapeNCAAFootball(table, year)
                            Case "nfl"
                                dt = ScrapeNFL(table, year)
                                If dt Is Nothing Then dt = ScrapeNFL(table, year)
                            Case "nba"
                                dt = ScrapeNBA(table, year)
                                If dt Is Nothing Then dt = ScrapeNBA(table, year)
                            Case "mlb"
                                dt = ScrapeMLB(table, year)
                                If dt Is Nothing Then dt = ScrapeMLB(table, year)
                        End Select
                        If dt Is Nothing Then
                            Dim strFile As String = "Z:\EJ\MyPrograms\MoneyManager\CSVs\MissingTables.txt"
                            If System.IO.File.Exists(strFile) = True Then
                                Dim objWriter As New System.IO.StreamWriter(strFile)
                                objWriter.Write(db & "," & table & "," & year & "," & DateAndTime.Now)
                                objWriter.Close()
                            End If
                        Else
                            Dim newColumn As New System.Data.DataColumn(GetProperString(table) & "_year", GetType(System.String))     'Add Year Column to DataTable
                            newColumn.DefaultValue = CInt(year)
                            dt.Columns.Add(newColumn)
                            DatatableToCSV(dt, path)
                            'DGVtoCSV(dgvTableDisplay, path)
                            ' Test path
                            'If Not Directory.Exists(path) Then
                            'DatatableToCSV(dt, path)
                            'End If
                            sqlImportCSVtoMySQL(db, table, path)
                            ' Write columns to TXT File
                            'ExportTableColumnsToCSV(dt)
                        End If
                    End If
                Next
            Next
        Next
        file.Close()
    End Sub

    ' Export Table to Database
    Private Sub btnExportTable_Click(sender As Object, e As EventArgs) Handles btnExportTable.Click
        Dim db As String = Nothing
        Dim table As String = cmbSelectStat.Text
        Dim year As String = cmbSelectSeason.Text
        Dim count As Integer = 0
        Dim file As System.IO.StreamWriter = Nothing
        file = My.Computer.FileSystem.OpenTextFileWriter("Z:\EJ\MyPrograms\MoneyManager\Columns.txt", True)

        Select Case GetProperString(cmbSelectSport.Text)
            Case "ncaa_basketball"
                db = "ncaab"
            Case "ncaa_football"
                db = "ncaafb"
            Case "nfl"
                db = "nfl"
            Case "nba"
                db = "nba"
        End Select
        If db <> Nothing AndAlso table <> Nothing AndAlso year <> Nothing Then
            Dim filename As String = year & "_" & db & "_" & GetProperString(table)
            Dim path As String = "Z:\EJ\MyPrograms\MoneyManager\CSVs\" & db & "\" & filename & ".txt"
            Dim dt As DataTable = Nothing
            Select Case db
                Case "ncaab"
                    dt = ScrapeNCAABasketball(table, year)
                    If dt Is Nothing Then dt = ScrapeNCAABasketball(table, year)
                Case "ncaafb"
                    dt = ScrapeNCAAFootball(table, year)
                    If dt Is Nothing Then dt = ScrapeNCAAFootball(table, year)
                Case "nfl"
                    dt = ScrapeNFL(table, year)
                    If dt Is Nothing Then dt = ScrapeNFL(table, year)
                Case "nba"
                    dt = ScrapeNBA(table, year)
                    If dt Is Nothing Then dt = ScrapeNBA(table, year)
            End Select
            If dt Is Nothing Then
                Dim strFile As String = "Z:\EJ\MyPrograms\MoneyManager\CSVs\MissingTables.txt"
                If System.IO.File.Exists(strFile) = True Then
                    Dim objWriter As New System.IO.StreamWriter(strFile)
                    objWriter.Write(db & "," & table & "," & year & "," & DateAndTime.Now)
                    objWriter.Close()
                End If
            Else
                Dim newColumn As New System.Data.DataColumn(GetProperString(table) & "_year", GetType(System.String))     'Add Year Column to DataTable
                newColumn.DefaultValue = CInt(year)
                dt.Columns.Add(newColumn)
                'DatatableToCSV(dt, path)
                'DGVtoCSV(dgvTableDisplay, path)
                sqlImportCSVtoMySQL(db, table, path)
                ' Write columns to TXT File
                'ExportTableColumnsToCSV(dt)
            End If
        End If
        file.Close()
    End Sub

    Private Sub cmbSelectSport_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelectSport.SelectedIndexChanged

    End Sub
End Class