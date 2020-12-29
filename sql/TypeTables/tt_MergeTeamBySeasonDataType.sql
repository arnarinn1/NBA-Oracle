CREATE TYPE nba.tt_MergeTeamBySeasonDataType AS TABLE
( SeasonId                  INT               NOT NULL
    
, TeamId                    INT               NOT NULL
, TeamIdentifier            CHAR(3)           NOT NULL
, TeamName                  VARCHAR(64)       NOT NULL

, Wins                      INT               NOT NULL
, Losses                    INT               NOT NULL
, MarginOfVictory           DECIMAL(4,2)      NOT NULL

, WinsLeagueRank            INT               NOT NULL
, LossesLeagueRank          INT               NOT NULL
, MarginOfVictoryLeagueRank INT               NOT NULL
)
GO