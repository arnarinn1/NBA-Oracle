CREATE OR ALTER Procedure nba.sp_MergePlayers
( @Players nba.tt_MergePlayerDataType readonly
)
AS 
BEGIN
  SET NOCOUNT ON;
 
  MERGE nba.Player AS target
  USING 
  ( SELECT Identifier
         , Name
         , BirthDate
         , BirthCountry
         , College
      FROM @Players
  ) AS source 
  ( Identifier
  , Name
  , BirthDate
  , BirthCountry
  , College
  )
  ON (target.Identifier = source.Identifier)
  WHEN NOT MATCHED THEN 
  INSERT
  ( Identifier
  , Name
  , BirthDate
  , BirthCountry
  , College
  )
  VALUES 
  ( source.Identifier
  , source.Name
  , source.BirthDate
  , source.BirthCountry
  , source.College
  );

  SELECT p.Id              PlayerId 
       , p.Identifier      PlayerIdentifier
    FROM @Players pt
    JOIN nba.Player p
      ON p.identifier = pt.identifier
END
GO
