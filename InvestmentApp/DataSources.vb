Module DataSources
    Dim Sports As String() = {"NFL", "NBA", "NCAA FOOTBALL", "NCAA BASKETBALL"}
    Dim YearsNCAAF As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004"}
    Dim YearsNCAAB As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002"}
    Dim YearsNBA As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002", "2001", "2000"}
    Dim YearsNFL As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002"}
    Dim StatsNCAAF As String() = {"TOTAL YARDS OFF",
                                  "TOTAL YARDS DEF",
                                  "DOWNS",
                                  "PASSING YARDS OFF",
                                  "PASSING YARDS DEF",
                                  "RUSHING YARDS OFF",
                                  "RUSHING YARDS DEF",
                                  "RECEIVING",
                                  "RETURNING",
                                  "KICKING",
                                  "PUNTING",
                                  "DEFENSE"
                                  }
    Dim StatsNCAAB As String() = {"SCORING",
                                  "REBOUNDS",
                                  "FIELD GOALS",
                                  "FREE-THROWS",
                                  "3-POINTS",
                                  "ASSISTS",
                                  "STEALS",
                                  "BLOCKS"
                                 }
    Dim StatsNBA As String() = {"OFFENSE",
                                "DEFENSE",
                                "DIFFERENTIAL",
                                "REBOUNDS",
                                "MISCELLANEOUS"
                                }
    Dim StatsNFL As String() = {"TOTAL YARDS OFF",
                                "DOWNS OFF",
                                "PASSING YARDS OFF",
                                "RUSHING YARDS OFF",
                                "RECEIVING OFF",
                                "RETURNING OWN",
                                "KICKING OWN",
                                "PUNTING OWN",
                                "DEFENSE OWN",
                                "GIVE-TAKE"
                                }

    Dim NFLTeamTotalOffense As String() = {"Rk”, ”Team”, ”Yds”, ”Yds/G”, ”Pass”, ”PYds/G”, ”Rush”, ”RYds/G”, ”Pts”, ”Pts/G”, "Year"}
    Dim NFLTeamDownsOff As String() = {"Rk”, ”Team”, ”FirstDowns_Total”, ”FirstDowns_Rush”, ”FirstDowns_Pass”, ”FirstDowns_Pen”, ”ThirdDowns_Made”, ”ThirdDowns_Att”, ”ThirdDowns_Pct”, ”FourthDowns_Made”, ”FourthDowns_Att”, ”FourthDowns_Pct”, ”Penalties_Total”, ”Penalties_Yds”, "Year"}
    Dim NFLTeamPassingYardsOff As String() = {"Rk”, ”Team”, ”Kickoffs_Att”, ”Kickoffs_Yds”, ”Kickoffs_Avg”, ”Kickoffs_Lng”, ”Kickoffs_Td”, ”Punts_Att”, ”Punts_Yds”, ”Punts_Avg”, ”Punts_Lng”, ”Punts_Td”, ”Punts_Fc”, "Year"}
    Dim NFLTeamRushingYardsOff As String() = {"Rk”, ”Team”, ”Att”, ”Yds”, ”Yds/A”, ”Long”, ”Td”, ”Yds/G”, ”Fum”, ”Fuml”, "Year"}
    Dim NFLTeamReceivingYardsOff As String() = {"Rk”, ”Team”, ”Rec”, ”Yds”, ”Avg”, ”Long”, ”Td”, ”Yds/G”, ”Fum”, ”Fuml”, "Year"}
    Dim NFLTeamReturningYardsOwn As String() = {"Rk”, ”Team”, ”Kickoffs_Att”, ”Kickoffs_Yds”, ”Kickoffs_Avg”, ”Kickoffs_Lng”, ”Kickoffs_Td”, ”Punts_Att”, ”Punts_Yds”, ”Punts_Avg”, ”Punts_Lng”, ”Punts_Td”, ”Punts_Fc”, "Year"}
    Dim NFLTeamKickingOwn As String() = {"Rk”, ”Team”, ”FieldGoals_Fgm”, ”FieldGoals_Fga”, ”FieldGoals_Pct”, ”FieldGoals_Lng”, ”FieldGoals_1_19”, ”FieldGoals_20_29”, ”FieldGoals_30_39”, ”FieldGoals_40_49”, ”FieldGoals_50+”, ”ExtraPoints_Xpm”, ”ExtraPoints_Xpa”, ”ExtraPoints_Pct”, "Year"}
    Dim NFLTeamPuntingOwn As String() = {"Rk”, ”Team”, ”Punts”, ”Yds”, ”Lng”, ”Avg”, ”Net”, ”Bp”, ”In20”, ”Tb”, ”Fc”, ”Ret”, ”Rety”, ”Avg1”, "Year"}
    Dim NFLTeamDefenseOwn As String() = {"Rk”, ”Team”, ”Tackles_Solo”, ”Tackles_Ast”, ”Tackles_Total”, ”Sacks_Sack”, ”Sacks_Ydsl”, ”Interceptions_Pd”, ”Interceptions_Int”, ”Interceptions_Yds”, ”Interceptions_Long”, ”Interceptions_Td”, ”Fumbles_Ff”, ”Fumbles_Rec”, ”Fumbles_Td”, "Year"}
    Dim NFLTeamGiveTake As String() = {"Rk”, ”Team”, ”Takeaway_Int”, ”Takeaway_Fum”, ”Takeaway_Total”, ”Giveaway_Int”, ”Giveaway_Fum”, ”Giveaway_Total”, ”TakeGiveDiff”, "Year"}
    Dim NBATeamOffense As String() = {"Rk”, ”Team”, ”Pts”, ”Fgm”, ”Fga”, ”Fg%”, ”3Pm”, ”3Pa”, ”3P%”, ”Ftm”, ”Fta”, ”Ft%”, ”Pps”, ”Afg%”, "Year"}
    Dim NBATeamDefense As String() = {"Rk”, ”Team”, ”Pts”, ”Fgm”, ”Fga”, ”Fg%”, ”3Pm”, ”3Pa”, ”3P%”, ”Ftm”, ”Fta”, ”Ft%”, ”Pps”, ”Fg%1”, "Year"}
    Dim NBATeamDifferential As String() = {"Rk”, ”Team”, ”Pts”, ”Fgm”, ”Fga”, ”Fg%”, ”3Pm”, ”3Pa”, ”3P%”, ”Ftm”, ”Fta”, ”Ft%”, ”Pps”, ”Fg%1”, "Year"}
    Dim NBATeamRebounds As String() = {"Rk”, ”Team”, ”ReboundPct_Off”, ”ReboundPct_Def”, ”ReboundPct_Tot”, ”Offensive_Own”, ”Offensive_Opp”, ”Defensive_Own”, ”Defensive_Opp”, ”Total_Own”, ”Total_Opp”, ”Total_Diff”, "Year"}
    Dim NBATeamMiscellaneous As String() = {"Rk”, ”Team”, ”Assists_Own”, ”Assists_Opp”, ”Steals_Own”, ”Steals_Opp”, ”Blocks_Own”, ”Blocks_Opp”, ”Turnovers_Own”, ”Turnovers_Opp”, ”Turnovers_Diff”, ”Turnovers_A/To”, ”Tech”, "Year"}
    Dim NCAAFTeamTotalYardsOff As String() = {"Rk”, ”Team”, ”Yds”, ”Yds/G”, ”Pass”, ”PYds/G”, ”Rush”, ”RYds/G”, ”Pts”, ”Pts/G”, "Year"}
    Dim NCAAFTeamTotalYardsDef As String() = {"Rk”, ”Team”, ”Yds”, ”Yds/G”, ”Pass”, ”PYds/G”, ”Rush”, ”RYds/G”, ”Pts”, ”Pts/G”, "Year"}
    Dim NCAAFTeamDowns As String() = {"Rk”, ”Team”, ”FirstDowns_Total”, ”FirstDowns_Rush”, ”FirstDowns_Pass”, ”FirstDowns_Pen”, ”ThirdDowns_Made”, ”ThirdDowns_Att”, ”ThirdDowns_Pct”, ”FourthDowns_Made”, ”FourthDowns_Att”, ”FourthDowns_Pct”, ”Penalties_Total”, ”Penalties_Yds”, "Year"}
    Dim NCAAFTeamPassingYardsOff As String() = {"Rk”, ”Team”, ”Att”, ”Comp”, ”Pct”, ”Yds”, ”Yds/A”, ”Long”, ”Td”, ”Int”, ”Sack”, ”Ydsl”, ”Rat”, ”Yds/G”, "Year"}
    Dim NCAAFTeamPassingYardsDef As String() = {"Rk”, ”Team”, ”Att”, ”Comp”, ”Pct”, ”Yds”, ”Yds/A”, ”Long”, ”Td”, ”Int”, ”Sack”, ”Ydsl”, ”Rat”, ”Yds/G”, "Year"}
    Dim NCAAFTeamRushingYardsOff As String() = {"Rk”, ”Team”, ”Att”, ”Yds”, ”Yds/A”, ”Long”, ”Td”, ”Yds/G”, "Year"}
    Dim NCAAFTeamRushingYardsDef As String() = {"Rk”, ”Team”, ”Att”, ”Yds”, ”Yds/A”, ”Long”, ”Td”, ”Yds/G”, "Year"}
    Dim NCAAFTeamReceiving As String() = {"Rk”, ”Team”, ”Rec”, ”Yds”, ”Avg”, ”Long”, ”Td”, ”Yds/G”, "Year"}
    Dim NCAAFTeamReturning As String() = {"Rk”, ”Team”, ”Kickoffs_Att”, ”Kickoffs_Yds”, ”Kickoffs_Avg”, ”Punts_Att”, ”Punts_Yds”, ”Punts_Avg”, ”Punts_Lng”, ”Punts_Td”, "Year"}
    Dim NCAAFTeamKicking As String() = {"Rk”, ”Team”, ”FieldGoals_Fgm”, ”FieldGoals_Fga”, ”FieldGoals_Pct”, ”FieldGoals_Lng”, ”FieldGoals_1_19”, ”FieldGoals_20_29”, ”FieldGoals_30_39”, ”FieldGoals_40_49”, ”FieldGoals_50+”, ”ExtraPoints_Xpm”, ”ExtraPoints_Xpa”, ”ExtraPoints_Pct”, "Year"}
    Dim NCAAFTeamPunting As String() = {"Rk”, ”Team”, ”Punts”, ”Yds”, ”Lng”, ”GrossAvg”, ”NetAvg”, ”Ret”, ”Rety”, ”AvgRety”, "Year"}
    Dim NCAAFTeamDefense As String() = {"Rk”, ”Team”, ”Tackles_Solo”, ”Tackles_Ast”, ”Tackles_Total”, ”Sacks_Sack”, ”Sacks_Ydsl”, ”Interceptions_Pd”, ”Interceptions_Int”, ”Interceptions_Yds”, ”Interceptions_Long”, ”Interceptions_Td”, ”Fumbles_Rec”, "Year"}
    Dim NCAABTeamScoring As String() = {"Rk”, ”Team”, ”Gp”, ”Pts”, ”Fgm_Fga”, ”Fg%”, ”3Pm_3Pa”, ”3P%”, ”Ftm_Fta”, ”Ft%”, "Year"}
    Dim NCAABTeamRebounds As String() = {"Rk”, ”Team”, ”Gp”, ”Off”, ”Orpg”, ”Def”, ”Drpg”, ”Reb”, ”Rpg”, "Year"}
    Dim NCAABTeamFieldGoals As String() = {"Rk”, ”Team”, ”Gp”, ”Ppg”, ”PerGame_Fgm”, ”PerGame_Fga”, ”Total_Fgm”, ”Total_Fga”, ”Fg%”, ”2Pm”, ”2Pa”, ”2P%”, ”Pps”, ”Adj_Fg%”, "Year"}
    Dim NCAABTeamFreeThrows As String() = {"Rk”, ”Team”, ”Gp”, ”Ppg”, ”PerGame_Ftm”, ”PerGame_Fta”, ”Total_Ftm”, ”Total_Fta”, ”Ft%”, "Year"}
    Dim NCAABTeam3Points As String() = {"Rk”, ”Team”, ”Gp”, ”Ppg”, ”PerGame_3Pm”, ”PerGame_3Pa”, ”Total_3Pm”, ”Total_3Pa”, ”3P%”, ”2Pm”, ”2Pa”, ”2P%”, ”Pps”, ”Adj_Fg%”, "Year"}
    Dim NCAABTeamAssists As String() = {"Rk”, ”Team”, ”Gp”, ”Ast”, ”Apg”, ”To”, ”Topg”, ”Ast/To”, "Year"}
    Dim NCAABTeamSteals As String() = {"Rk”, ”Team”, ”Gp”, ”Stl”, ”Stpg”, ”To”, ”Topg”, ”Pf”, ”St/To”, ”St/Pf”, "Year"}
    Dim NCAABTeamBlocks As String() = {"Rk”, ”Team”, ”Gp”, ”Blk”, ”Pf”, ”Blkpg”, ”Blk/Pf”, "Year"}

    Public Function GetDatasource(ByVal strDatasource As String)
        Select Case strDatasource
            Case "Sports"
                Return Sports
            Case "StatsNFL"
                Return StatsNFL
            Case "StatsNBA"
                Return StatsNBA
            Case "StatsNCAAF"
                Return StatsNCAAF
            Case "StatsNCAAB"
                Return StatsNCAAB
            Case "YearsNFL"
                Return YearsNFL
            Case "YearsNBA"
                Return YearsNBA
            Case "YearsNCAAB"
                Return YearsNCAAB
            Case "YearsNCAAF"
                Return YearsNCAAF
            Case "NFL-TOTAL YARDS OFF"
                Return NFLTeamTotalOffense
            Case "NFL-DOWNS OFF"
                Return NFLTeamDownsOff
            Case "NFL-PASSING YARDS OFF"
                Return NFLTeamPassingYardsOff
            Case "NFL-RUSHING YARDS OFF"
                Return NFLTeamRushingYardsOff
            Case "NFL-RECEIVING OFF"
                Return NFLTeamReceivingYardsOff
            Case "NFL-RETURNING OWN"
                Return NFLTeamReturningYardsOwn
            Case "NFL-KICKING OWN"
                Return NFLTeamKickingOwn
            Case "NFL-PUNTING OWN"
                Return NFLTeamPuntingOwn
            Case "NFL-DEFENSE OWN"
                Return NFLTeamDefenseOwn
            Case "NFL-GIVE-TAKE"
                Return NFLTeamGiveTake
            Case "NBA-OFFENSE"
                Return NBATeamOffense
            Case "NBA-DEFENSE"
                Return NBATeamDefense
            Case "NBA-DIFFERENTIAL"
                Return NBATeamDifferential
            Case "NBA-REBOUNDS"
                Return NBATeamRebounds
            Case "NBA-MISCELLANEOUS"
                Return NBATeamMiscellaneous
            Case "NCAAF-TOTAL YARDS OFF"
                Return NCAAFTeamTotalYardsOff
            Case "NCAAF-TOTAL YARDS DEF"
                Return NCAAFTeamTotalYardsDef
            Case "NCAAF-DOWNS"
                Return NCAAFTeamDowns
            Case "NCAAF-PASSING YARDS OFF"
                Return NCAAFTeamPassingYardsOff
            Case "NCAAF-PASSING YARDS DEF"
                Return NCAAFTeamPassingYardsDef
            Case "NCAAF-RUSHING YARDS OFF"
                Return NCAAFTeamRushingYardsOff
            Case "NCAAF-RUSHING YARDS DEF"
                Return NCAAFTeamRushingYardsDef
            Case "NCAAF-RECEIVING"
                Return NCAAFTeamReceiving
            Case "NCAAF-RETURNING"
                Return NCAAFTeamReturning
            Case "NCAAF-KICKING"
                Return NCAAFTeamKicking
            Case "NCAAF-PUNTING"
                Return NCAAFTeamPunting
            Case "NCAAF-DEFENSE"
                Return NCAAFTeamDefense
            Case "NCAAB-SCORING"
                Return NCAABTeamScoring
            Case "NCAAB-REBOUNDS"
                Return NCAABTeamRebounds
            Case "NCAAB-FIELD GOALS"
                Return NCAABTeamFieldGoals
            Case "NCAAB-FREE-THROWS"
                Return NCAABTeamFreeThrows
            Case "NCAAB-3-POINTS"
                Return NCAABTeam3Points
            Case "NCAAB-ASSISTS"
                Return NCAABTeamAssists
            Case "NCAAB-STEALS"
                Return NCAABTeamSteals
            Case "NCAAB-BLOCKS"
                Return NCAABTeamBlocks
            Case Else
                Return Nothing
        End Select
    End Function

End Module
