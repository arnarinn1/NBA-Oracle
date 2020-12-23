CREATE TABLE nba.Season
( EndYear                  INT  NOT NULL
, RegularSeasonStartDate   DATE NOT NULL
, RegularSeasonEndDate     DATE     NULL
, PlayoffStartDate         DATE     NULL
, PlayoffEndDate           DATE     NULL
, FinalsWinnerTeamId       INT      NULL
, FinalsLoserTeamId        INT      NULL
)
GO

ALTER TABLE nba.Season
ADD CONSTRAINT PK_Season PRIMARY KEY CLUSTERED (EndYear);
GO