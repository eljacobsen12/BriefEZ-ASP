Module DataSources
    Dim Sports As String() = {"NCAA BASKETBALL", "NCAA FOOTBALL", "NBA"} ', "NFL"}
    Dim YearsNCAAFB As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004"}
    Dim YearsNCAAB As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002"}
    Dim YearsNBA As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002", "2001", "2000"}
    Dim YearsNFL As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002"}
    Dim StatsNCAAFB As String() = {"TOTAL YARDS OFF",
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

    Dim NFLTeamTotalOffense As String() = {"total_yards_off_rk", "total_yards_off_team", "total_yards_off_yds", "total_yards_off_yds_per_g", "total_yards_off_pass", "total_yards_off_p_yds_per_g", "total_yards_off_rush", "total_yards_off_r_yds_per_g", "total_yards_off_pts", "total_yards_off_pts_per_g", "total_yards_off_year"}
    Dim NFLTeamDownsOff As String() = {"downs_off_rk", "downs_off_team", "downs_off_1_total", "downs_off_1_rush", "downs_off_1_pass", "downs_off_1_pen", "downs_off_2_made", "downs_off_2_att", "downs_off_2_pct", "downs_off_3_made", "downs_off_3_att", "downs_off_3_pct", "downs_off_4_total", "downs_off_4_yds", "downs_off_year"}
    Dim NFLTeamPassingYardsOff As String() = {"passing_yards_off_rk", "passing_yards_off_team", "passing_yards_off_1_att", "passing_yards_off_1_yds", "passing_yards_off_1_avg", "passing_yards_off_1_lng", "passing_yards_off_1_td", "passing_yards_off_2_att", "passing_yards_off_2_yds", "passing_yards_off_2_avg", "passing_yards_off_2_lng", "passing_yards_off_2_td", "passing_yards_off_2_fc", "passing_yards_off_year"}
    Dim NFLTeamRushingYardsOff As String() = {"rushing_yards_off_rk", "rushing_yards_off_team", "rushing_yards_off_att", "rushing_yards_off_yds", "rushing_yards_off_yds_per_a", "rushing_yards_off_long", "rushing_yards_off_td", "rushing_yards_off_yds_per_g", "rushing_yards_off_fum", "rushing_yards_off_fuml", "rushing_yards_off_year"}
    Dim NFLTeamReceivingYardsOff As String() = {"receiving_off_rk", "receiving_off_team", "receiving_off_rec", "receiving_off_yds", "receiving_off_avg", "receiving_off_long", "receiving_off_td", "receiving_off_yds_per_g", "receiving_off_fum", "receiving_off_fuml", "receiving_off_year"}
    Dim NFLTeamReturningYardsOwn As String() = {"returning_own_rk", "returning_own_team", "returning_own_1_att", "returning_own_1_yds", "returning_own_1_avg", "returning_own_1_lng", "returning_own_1_td", "returning_own_2_att", "returning_own_2_yds", "returning_own_2_avg", "returning_own_2_lng", "returning_own_2_td", "returning_own_2_fc", "returning_own_year"}
    Dim NFLTeamKickingOwn As String() = {"kicking_own_rk", "kicking_own_team", "kicking_own_1_fgm", "kicking_own_1_fga", "kicking_own_1_pct", "kicking_own_1_lng", "kicking_own_1_1-19", "kicking_own_1_20-29", "kicking_own_1_30-39", "kicking_own_1_40-49", "kicking_own_1_50+", "kicking_own_2_xpm", "kicking_own_2_xpa", "kicking_own_2_pct", "kicking_own_year"}
    Dim NFLTeamPuntingOwn As String() = {"punting_own_rk", "punting_own_team", "punting_own_punts", "punting_own_yds", "punting_own_lng", "punting_own_avg", "punting_own_net", "punting_own_bp", "punting_own_in20", "punting_own_tb", "punting_own_fc", "punting_own_ret", "punting_own_rety", "punting_own_avg1", "punting_own_year"}
    Dim NFLTeamDefenseOwn As String() = {"defense_own_rk", "defense_own_team", "defense_own_1_solo", "defense_own_1_ast", "defense_own_1_total", "defense_own_2_sack", "defense_own_2_ydsl", "defense_own_3_pd", "defense_own_3_int", "defense_own_3_yds", "defense_own_3_long", "defense_own_3_td", "defense_own_4_ff", "defense_own_4_rec", "defense_own_4_td", "defense_own_year"}
    Dim NFLTeamGiveTake As String() = {"give_take_rk", "give_take_team", "give_take_1_int", "give_take_1_fum", "give_take_1_total", "give_take_2_int", "give_take_2_fum", "give_take_2_total", "Column9", "give_take_year"}
    Dim NBATeamOffense As String() = {"offense_rk", "offense_team", "offense_pts", "offense_fgm", "offense_fga", "offense_fg%", "offense_3pm", "offense_3pa", "offense_3p%", "offense_ftm", "offense_fta", "offense_ft%", "offense_pps", "offense_afg%", "offense_year"}
    Dim NBATeamDefense As String() = {"defense_rk", "defense_team", "defense_pts", "defense_fgm", "defense_fga", "defense_fg%", "defense_3pm", "defense_3pa", "defense_3p%", "defense_ftm", "defense_fta", "defense_ft%", "defense_pps", "defense_fg%1", "defense_year"}
    Dim NBATeamDifferential As String() = {"differential_rk", "differential_team", "differential_pts", "differential_fgm", "differential_fga", "differential_fg%", "differential_3pm", "differential_3pa", "differential_3p%", "differential_ftm", "differential_fta", "differential_ft%", "differential_pps", "differential_fg%1", "differential_year"}
    Dim NBATeamRebounds As String() = {"rebounds_rk", "rebounds_team", "rebounds_1_off", "rebounds_1_def", "rebounds_1_tot", "rebounds_2_own", "rebounds_2_opp", "rebounds_3_own", "rebounds_3_opp", "rebounds_4_own", "rebounds_4_opp", "rebounds_4_diff", "rebounds_year"}
    Dim NBATeamMiscellaneous As String() = {"miscellaneous_rk", "miscellaneous_team", "miscellaneous_1_own", "miscellaneous_1_opp", "miscellaneous_2_own", "miscellaneous_2_opp", "miscellaneous_3_own", "miscellaneous_3_opp", "miscellaneous_4_own", "miscellaneous_4_opp", "miscellaneous_4_diff", "miscellaneous_4_a/to", "miscellaneous_tech", "miscellaneous_year"}
    Dim NCAAFBTeamTotalYardsOff As String() = {"total_yards_off_rk", "total_yards_off_team", "total_yards_off_yds", "total_yards_off_yds_per_g", "total_yards_off_pass", "total_yards_off_p_yds_per_g", "total_yards_off_rush", "total_yards_off_r_yds_per_g", "total_yards_off_pts", "total_yards_off_pts_per_g", "total_yards_off_year"}
    Dim NCAAFBTeamTotalYardsDef As String() = {"total_yards_def_rk", "total_yards_def_team", "total_yards_def_yds", "total_yards_def_yds_per_g", "total_yards_def_pass", "total_yards_def_p_yds_per_g", "total_yards_def_rush", "total_yards_def_r_yds_per_g", "total_yards_def_pts", "total_yards_def_pts_per_g", "total_yards_def_year"}
    Dim NCAAFBTeamDowns As String() = {"downs_rk", "downs_team", "downs_1_total", "downs_1_rush", "downs_1_pass", "downs_1_pen", "downs_2_made", "downs_2_att", "downs_2_pct", "downs_3_made", "downs_3_att", "downs_3_pct", "downs_4_total", "downs_4_yds", "downs_year"}
    Dim NCAAFBTeamPassingYardsOff As String() = {"passing_yards_off_rk", "passing_yards_off_team", "passing_yards_off_att", "passing_yards_off_comp", "passing_yards_off_pct", "passing_yards_off_yds", "passing_yards_off_yds_per_a", "passing_yards_off_long", "passing_yards_off_td", "passing_yards_off_int", "passing_yards_off_sack", "passing_yards_off_ydsl", "passing_yards_off_rat", "passing_yards_off_yds_per_g", "passing_yards_off_year"}
    Dim NCAAFBTeamPassingYardsDef As String() = {"passing_yards_def_rk", "passing_yards_def_team", "passing_yards_def_att", "passing_yards_def_comp", "passing_yards_def_pct", "passing_yards_def_yds", "passing_yards_def_yds_per_a", "passing_yards_def_long", "passing_yards_def_td", "passing_yards_def_int", "passing_yards_def_sack", "passing_yards_def_ydsl", "passing_yards_def_rat", "passing_yards_def_yds_per_g", "passing_yards_def_year"}
    Dim NCAAFBTeamRushingYardsOff As String() = {"rushing_yards_off_rk", "rushing_yards_off_team", "rushing_yards_off_att", "rushing_yards_off_yds", "rushing_yards_off_yds_per_a", "rushing_yards_off_long", "rushing_yards_off_td", "rushing_yards_off_yds_per_g", "rushing_yards_off_year"}
    Dim NCAAFBTeamRushingYardsDef As String() = {"rushing_yards_def_rk", "rushing_yards_def_team", "rushing_yards_def_att", "rushing_yards_def_yds", "rushing_yards_def_yds_per_a", "rushing_yards_def_long", "rushing_yards_def_td", "rushing_yards_def_yds_per_g", "rushing_yards_def_year"}
    Dim NCAAFBTeamReceiving As String() = {"receiving_rk", "receiving_team", "receiving_rec", "receiving_yds", "receiving_avg", "receiving_long", "receiving_td", "receiving_yds_per_g", "receiving_year"}
    Dim NCAAFBTeamReturning As String() = {"returning_rk", "returning_team", "returning_1_att", "returning_1_yds", "returning_1_avg", "returning_1_att1", "returning_1_yds1", "returning_2_avg", "returning_2_lng", "returning_2_td", "returning_year"}
    Dim NCAAFBTeamKicking As String() = {"kicking_rk", "kicking_team", "kicking_1_fgm", "kicking_1_fga", "kicking_1_pct", "kicking_1_lng", "kicking_1_1-19", "kicking_1_20-29", "kicking_1_30-39", "kicking_1_40-49", "kicking_1_50+", "kicking_2_xpm", "kicking_2_xpa", "kicking_2_pct", "kicking_year"}
    Dim NCAAFBTeamPunting As String() = {"punting_rk", "punting_team", "punting_punts", "punting_yds", "punting_lng", "punting_avg", "punting_net", "punting_ret", "punting_rety", "punting_avg1", "punting_year"}
    Dim NCAAFBTeamDefense As String() = {"defense_rk", "defense_team", "defense_1_solo", "defense_1_ast", "defense_1_total", "defense_2_sack", "defense_2_ydsl", "defense_3_pd", "defense_3_int", "defense_3_yds", "defense_3_long", "defense_3_td", "defense_4_rec", "defense_year"}
    Dim NCAABTeamScoring As String() = {"scoring_rk", "scoring_team", "scoring_gp", "scoring_pts", "scoring_fgm_fga", "scoring_fg%", "scoring_3pm_3pa", "scoring_3p%", "scoring_ftm_fta", "scoring_ft%", "scoring_year"}
    Dim NCAABTeamRebounds As String() = {"rebounds_rk", "rebounds_team", "rebounds_gp", "rebounds_off", "rebounds_orpg", "rebounds_def", "rebounds_drpg", "rebounds_reb", "rebounds_rpg", "rebounds_year"}
    Dim NCAABTeamFieldGoals As String() = {"field_goals_rk", "field_goals_team", "field_goals_gp", "field_goals_ppg", "field_goals_1_fgm", "field_goals_1_fga", "field_goals_2_fgm", "field_goals_2_fga", "field_goals_fg%", "field_goals_2pm", "field_goals_2pa", "field_goals_2p%", "field_goals_pps", "field_goals_4_fg%", "field_goals_year"}
    Dim NCAABTeamFreeThrows As String() = {"free_throws_rk", "free_throws_team", "free_throws_gp", "free_throws_ppg", "free_throws_1_ftm", "free_throws_1_fta", "free_throws_2_ftm", "free_throws_2_fta", "free_throws_ft%", "free_throws_year"}
    Dim NCAABTeam3Points As String() = {"3_points_rk", "3_points_team", "3_points_gp", "3_points_ppg", "3_points_1_3pm", "3_points_1_3pa", "3_points_2_3pm", "3_points_2_3pa", "3_points_3p%", "3_points_2pm", "3_points_2pa", "3_points_2p%", "3_points_pps", "3_points_4_fg%", "3_points_year"}
    Dim NCAABTeamAssists As String() = {"assists_rk", "assists_team", "assists_gp", "assists_ast", "assists_apg", "assists_to", "assists_topg", "assists_ast_per_to", "assists_year"}
    Dim NCAABTeamSteals As String() = {"steals_rk", "steals_team", "steals_gp", "steals_stl", "steals_stpg", "steals_to", "steals_topg", "steals_pf", "steals_st_per_to", "steals_st_per_pf", "steals_year"}
    Dim NCAABTeamBlocks As String() = {"blocks_rk", "blocks_team", "blocks_gp", "blocks_blk", "blocks_pf", "blocks_blkpg", "blocks_blk_per_pf", "blocks_year"}

    Public Function GetDatasource(ByVal strDatasource As String)
        Select Case strDatasource
            Case "Sports"
                Return Sports
            Case "StatsNFL"
                Return StatsNFL
            Case "StatsNBA"
                Return StatsNBA
            Case "StatsNCAAFB"
                Return StatsNCAAFB
            Case "StatsNCAAB"
                Return StatsNCAAB
            Case "YearsNFL"
                Return YearsNFL
            Case "YearsNBA"
                Return YearsNBA
            Case "YearsNCAAB"
                Return YearsNCAAB
            Case "YearsNCAAFB"
                Return YearsNCAAFB
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
            Case "NCAAFB-TOTAL YARDS OFF"
                Return NCAAFBTeamTotalYardsOff
            Case "NCAAFB-TOTAL YARDS DEF"
                Return NCAAFBTeamTotalYardsDef
            Case "NCAAFB-DOWNS"
                Return NCAAFBTeamDowns
            Case "NCAAFB-PASSING YARDS OFF"
                Return NCAAFBTeamPassingYardsOff
            Case "NCAAFB-PASSING YARDS DEF"
                Return NCAAFBTeamPassingYardsDef
            Case "NCAAFB-RUSHING YARDS OFF"
                Return NCAAFBTeamRushingYardsOff
            Case "NCAAFB-RUSHING YARDS DEF"
                Return NCAAFBTeamRushingYardsDef
            Case "NCAAFB-RECEIVING"
                Return NCAAFBTeamReceiving
            Case "NCAAFB-RETURNING"
                Return NCAAFBTeamReturning
            Case "NCAAFB-KICKING"
                Return NCAAFBTeamKicking
            Case "NCAAFB-PUNTING"
                Return NCAAFBTeamPunting
            Case "NCAAFB-DEFENSE"
                Return NCAAFBTeamDefense
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
