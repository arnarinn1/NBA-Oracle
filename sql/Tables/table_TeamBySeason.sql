CREATE TABLE nba.TeamBySeason
( Id                        INT IDENTITY(1,1) NOT NULL

, SeasonId                  INT               NOT NULL

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

ALTER TABLE nba.TeamBySeason
ADD CONSTRAINT PK_TeamBySeason PRIMARY KEY CLUSTERED(Id)
GO

ALTER TABLE nba.TeamBySeason
ADD CONSTRAINT FK_TeamBySeason_SeasonId FOREIGN KEY (SeasonId) REFERENCES nba.Season (EndYear)
GO

ALTER TABLE nba.TeamBySeason
ADD CONSTRAINT FK_TeamBySeason_TeamId FOREIGN KEY (TeamId) REFERENCES nba.Team (Id)
GO

CREATE NONCLUSTERED INDEX Idx_NonClu_TeamBySeason_SeasonId ON nba.TeamBySeason (SeasonId)
GO