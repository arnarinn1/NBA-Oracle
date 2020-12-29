CREATE TABLE nba.Player
( Id               INT IDENTITY(1,1) NOT NULL
, Identifier       VARCHAR(128)      NOT NULL
, Name             VARCHAR(128)      NOT NULL
, BirthDate        DATE              NOT NULL
, BirthCountry     CHAR(2)           NOT NULL
, College          VARCHAR(128)      NOT NULL
)

ALTER TABLE nba.Player
ADD CONSTRAINT PK_Player PRIMARY KEY CLUSTERED(Id)
GO

CREATE NONCLUSTERED INDEX Idx_NonClu_Player_Identifier ON nba.Player (Identifier)
GO