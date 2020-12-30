CREATE OR ALTER Procedure nba.sp_MergeTeamRoosterBySeason
( @Rooster nba.tt_MergeTeamRoosterBySeasonDataType readonly
)
AS 
BEGIN
  SET NOCOUNT ON;
   
   MERGE nba.TeamRoosterBySeason AS target
   USING 
   ( SELECT TeamBySeasonId
          , PlayerId
          , JerseyNumber
          , Position
          , Height
          , Weight
          , NumberOfYearInLeague
       FROM @Rooster
   ) AS source 
   ( TeamBySeasonId
   , PlayerId
   , JerseyNumber
   , Position
   , Height
   , Weight
   , NumberOfYearInLeague
   )
   ON (target.TeamBySeasonId = source.TeamBySeasonId AND target.PlayerId = source.PlayerId)
   WHEN MATCHED THEN 
     UPDATE SET JerseyNumber          = source.JerseyNumber
              , Position              = source.Position
              , Height                = source.Height
              , Weight                = source.Weight
              , NumberOfYearInLeague  = source.NumberOfYearInLeague
   WHEN NOT MATCHED THEN 
   INSERT
   ( TeamBySeasonId
   , PlayerId
   , JerseyNumber
   , Position
   , Height
   , Weight
   , NumberOfYearInLeague
   )
   VALUES 
   ( source.TeamBySeasonId
   , source.PlayerId
   , source.JerseyNumber
   , source.Position
   , source.Height
   , source.Weight
   , source.NumberOfYearInLeague
   );
END
GO