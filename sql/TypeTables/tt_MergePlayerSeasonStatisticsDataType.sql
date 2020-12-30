CREATE TYPE nba.tt_MergePlayerSeasonStatisticsDataType AS TABLE
( Id                               INT          NOT NULL
, PlayerId                         INT          NOT NULL

, ForRegularSeason                 BIT          NOT NULL

, GamesPlayed                      INT          NOT NULL
, MinutesPlayed                    INT          NOT NULL
, MinutedPlayedPerGame             DECIMAL(3,1) NOT NULL

, FieldGoalsMade                   INT          NOT NULL
, FieldGoalsAttempted              INT          NOT NULL
, FieldGoalPercentage              DECIMAL(4,3) NOT NULL

, ThreePointersMade                INT          NOT NULL
, ThreePointersAttempted           INT          NOT NULL
, ThreePointersPercentage          DECIMAL(4,3) NOT NULL

, TwoPointersMade                  INT          NOT NULL
, TwoPointersAttempted             INT          NOT NULL
, TwoPointersPercentage            DECIMAL(4,3) NOT NULL

, FreeThrowsMade                   INT          NOT NULL
, FreeThrowsAttempted              INT          NOT NULL
, FreeThrowsPercentage             DECIMAL(4,3) NOT NULL

, EffectiveFieldGoalPercentage     DECIMAL(4,3) NOT NULL

, OffensiveRebounds                INT          NOT NULL
, DefensiveRebounds                INT          NOT NULL
, TotalRebounds                    INT          NOT NULL
, ReboundsPerGame                  DECIMAL(3,1) NOT NULL

, Assists                          INT          NOT NULL
, AssistsPerGame                   DECIMAL(3,1) NOT NULL

, Steals                           INT          NOT NULL
, StealsPerGame                    DECIMAL(3,1) NOT NULL

, Blocks                           INT          NOT NULL
, BlocksPerGame                    DECIMAL(3,1) NOT NULL

, Turnovers                        INT          NOT NULL
, TurnoversPerGame                 DECIMAL(3,1) NOT NULL

, PersonalFouls                    INT          NOT NULL
, PersonalFoulsPerGame             DECIMAL(3,1) NOT NULL

, Points                           INT          NOT NULL
, PointsPerGame                    DECIMAL(3,1) NOT NULL

, PlusMinusOnCourt                 DECIMAL(3,1) NOT NULL
, PlusMinusNetOnCourt              DECIMAL(3,1) NOT NULL
)
GO