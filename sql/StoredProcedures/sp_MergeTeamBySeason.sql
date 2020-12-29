CREATE OR ALTER Procedure nba.MergeTeamBySeason
( @Teams nba.tt_MergeTeamBySeasonDataType readonly
)
AS 
BEGIN
  SET NOCOUNT ON;
   
   MERGE nba.TeamBySeason AS target
   USING 
   ( SELECT SeasonId
          , TeamId
          , TeamIdentifier
          , TeamName
          , Wins
          , Losses
          , MarginOfVictory
          , WinsLeagueRank
          , LossesLeagueRank
          , MarginOfVictoryLeagueRank
       FROM @Teams
   ) AS source 
   ( SeasonId
   , TeamId
   , TeamIdentifier
   , TeamName
   , Wins
   , Losses
   , MarginOfVictory
   , WinsLeagueRank
   , LossesLeagueRank
   , MarginOfVictoryLeagueRank
   )
   ON (target.SeasonId = source.SeasonId AND target.TeamId = source.TeamId)
   WHEN MATCHED THEN 
     UPDATE SET Wins                      = source.Wins
              , Losses                    = source.Losses
              , MarginOfVictory           = source.MarginOfVictory
              , WinsLeagueRank            = source.WinsLeagueRank
              , LossesLeagueRank          = source.LossesLeagueRank
              , MarginOfVictoryLeagueRank = source.MarginOfVictoryLeagueRank
   WHEN NOT MATCHED THEN 
   INSERT
   ( SeasonId
   , TeamId
   , TeamIdentifier
   , TeamName
   , Wins
   , Losses
   , MarginOfVictory
   , WinsLeagueRank
   , LossesLeagueRank
   , MarginOfVictoryLeagueRank
   )
   VALUES 
   ( source.SeasonId
   , source.TeamId
   , source.TeamIdentifier
   , source.TeamName
   , source.Wins
   , source.Losses
   , source.MarginOfVictory
   , source.WinsLeagueRank
   , source.LossesLeagueRank
   , source.MarginOfVictoryLeagueRank
   );
END
GO
