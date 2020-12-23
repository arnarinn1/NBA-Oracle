CREATE TABLE nba.Team
( Id                  INT         NOT NULL
, CurrentIdentifier   CHAR(3)     NOT NULL
, CurrentName         VARCHAR(64) NOT NULL
)
GO

ALTER TABLE nba.Team
ADD CONSTRAINT PK_Team PRIMARY KEY CLUSTERED (Id);
GO