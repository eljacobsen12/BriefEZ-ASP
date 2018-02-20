Module DataSources
    Dim Sports As String() = {"NFL", "NBA", "NCAA FOOTBALL", "NCAA BASKETBALL"}
    Dim YearsNCAAF As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004"}
    Dim YearsNCAAB As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002"}
    Dim YearsNBA As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002", "2001", "2000"}
    Dim YearsNFL As String() = {"2017", "2016", "2015", "2014", "2013", "2012", "2011", "2010", "2009", "2008", "2007", "2006", "2005", "2004", "2003", "2002"}
    Dim StatsNCAAF As String() = {"TEAM SCHEDULE",
                                  "TEAM STATS",
                                  "TEAM ROSTER",
                                  "TEAM STATS - TOTAL YARDS OFF",
                                  "TEAM STATS - TOTAL YARDS DEF",
                                  "TEAM STATS - DOWNS",
                                  "TEAM STATS - PASSING YARDS OFF",
                                  "TEAM STATS - PASSING YARDS DEF",
                                  "TEAM STATS - RUSHING YARDS OFF",
                                  "TEAM STATS - RUSHING YARDS DEF",
                                  "TEAM STATS - RECEIVING",
                                  "TEAM STATS - RETURNING",
                                  "TEAM STATS - KICKING",
                                  "TEAM STATS - PUNTING",
                                  "TEAM STATS - DEFENSE"
                                  }
    Dim StatsNCAAB As String() = {"TEAM SCHEDULE",
                                  "TEAM STATS",
                                  "TEAM ROSTER",
                                  "TEAM STATS - SCORING",
                                  "TEAM STATS - REBOUNDS",
                                  "TEAM STATS - FIELD GOALS",
                                  "TEAM STATS - FREE-THROWS",
                                  "TEAM STATS - 3-POINTS",
                                  "TEAM STATS - ASSISTS",
                                  "TEAM STATS - STEALS",
                                  "TEAM STATS - BLOCKS"
                                 }
    Dim StatsNBA As String() = {"TEAM SCHEDULE",
                                "TEAM STATS - REGULAR",
                                "TEAM STATS - POSTSEASON",
                                "TEAM ROSTER",
                                "TEAM STATS - OFFENSE",
                                "TEAM STATS - DEFENSE",
                                "TEAM STATS - DIFFERENTIAL",
                                "TEAM STATS - REBOUNDS",
                                "TEAM STATS - MISCELLANEOUS"
                                }
    Dim StatsNFL As String() = {"TEAM SCHEDULE",
                                "TEAM STATS",
                                "TEAM ROSTER",
                                "TEAM STATS - TOTAL YARDS OFF",
                                "TEAM STATS - DOWNS OFF",
                                "TEAM STATS - PASSING YARDS OFF",
                                "TEAM STATS - RUSHING YARDS OFF",
                                "TEAM STATS - RECEIVING OFF",
                                "TEAM STATS - RETURNING OWN",
                                "TEAM STATS - KICKING OWN",
                                "TEAM STATS - PUNTING OWN",
                                "TEAM STATS - DEFENSE OWN",
                                "TEAM STATS - GIVE/TAKE"
                                }

    Public Function GetDatasource(ByVal strDatasource As String)
        Dim datasource As String() = Nothing
        Select Case strDatasource
            Case "Sports"
                datasource = Sports
            Case "StatsNFL"
                datasource = StatsNFL
            Case "StatsNBA"
                datasource = StatsNBA
            Case "StatsNCAAF"
                datasource = StatsNCAAF
            Case "StatsNCAAB"
                datasource = StatsNCAAB
            Case "YearsNFL"
                datasource = YearsNFL
            Case "YearsNBA"
                datasource = YearsNBA
            Case "YearsNCAAB"
                datasource = YearsNCAAB
            Case "YearsNCAAF"
                datasource = YearsNCAAF
        End Select
        Return datasource
    End Function

    Public Function CheckColumnName(ByVal colName As String)
        Select Case colName
            Case ""
        End Select

    End Function
End Module
