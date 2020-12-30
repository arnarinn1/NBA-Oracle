CREATE TYPE nba.tt_MergeTeamRoosterBySeasonDataType AS TABLE
( TeamBySeasonId            INT           NOT NULL
, PlayerId                  INT           NOT NULL

, JerseyNumber              CHAR(2)       NOT NULL
, Position                  CHAR(2)       NOT NULL

, Height                    DECIMAL(5,2)  NOT NULL
, Weight                    DECIMAL(5,2)  NOT NULL
, NumberOfYearInLeague      INT           NOT NULL
)
GO