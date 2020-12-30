CREATE TABLE nba.TeamRoosterBySeason
( Id                     INT IDENTITY(1,1) NOT NULL
, TeamBySeasonId         INT               NOT NULL
, PlayerId               INT               NOT NULL
, JerseyNumber           VARCHAR(6)        NOT NULL
, Position               VARCHAR(2)        NOT NULL 
, Height                 DECIMAL(5,2)      NOT NULL
, Weight                 DECIMAL(5,2)      NOT NULL
, NumberOfYearInLeague   INT               NOT NULL
)

ALTER TABLE nba.TeamRoosterBySeason
ADD CONSTRAINT PK_TeamRoosterBySeason PRIMARY KEY CLUSTERED (Id)
GO

ALTER TABLE nba.TeamRoosterBySeason
ADD CONSTRAINT FK_TeamRoosterBySeason_TeamBySeasonId FOREIGN KEY (TeamBySeasonId) REFERENCES nba.TeamBySeason (Id)
GO

ALTER TABLE nba.TeamRoosterBySeason
ADD CONSTRAINT FK_TeamRoosterBySeason_PlayerId FOREIGN KEY (PlayerId) REFERENCES nba.Player (Id)
GO

CREATE NONCLUSTERED INDEX Idx_NonClu_TeamRoosterBySeason_TeamBySeasonId ON nba.TeamRoosterBySeason (TeamBySeasonId)
GO