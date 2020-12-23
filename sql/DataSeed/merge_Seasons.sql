MERGE nba.Season AS target
USING
( SELECT 2010, '2009-10-27', '2010-04-14', '2010-04-17', '2010-06-17', 14, 2   UNION
  SELECT 2011, '2010-10-26', '2011-04-13', '2011-04-16', '2011-06-12', 7, 16   UNION
  SELECT 2012, '2011-12-25', '2012-04-26', '2012-04-28', '2012-06-21', 16, 21  UNION
  SELECT 2013, '2012-10-30', '2013-04-17', '2013-04-20', '2013-06-20', 16, 27  UNION
  SELECT 2014, '2013-10-29', '2014-04-16', '2014-04-19', '2014-06-15', 27, 16  UNION
  SELECT 2015, '2014-10-28', '2015-04-15', '2015-04-18', '2015-06-16', 10, 6   UNION
  SELECT 2016, '2015-10-27', '2016-04-13', '2016-04-16', '2016-06-19', 6, 10   UNION
  SELECT 2017, '2016-10-25', '2017-04-12', '2017-04-15', '2017-06-12', 10, 6   UNION
  SELECT 2018, '2017-10-17', '2018-04-11', '2018-04-14', '2018-06-08', 10, 6   UNION
  SELECT 2019, '2018-10-16', '2019-04-10', '2019-04-13', '2019-06-13', 28, 10  UNION
  SELECT 2020, '2019-10-22', '2020-08-15', '2020-08-17', '2020-10-11', 14, 16  UNION
  SELECT 2021, '2020-12-22', null, null, null, null, null
) AS source ( EndYear
            , RegularSeasonStartDate
            , RegularSeasonEndDate
            , PlayoffStartDate
            , PlayoffEndDate
            , FinalsWinnerTeamId
            , FinalsLoserTeamId
            )
ON (target.EndYear = source.EndYear)
WHEN MATCHED THEN
  UPDATE SET RegularSeasonStartDate = source.RegularSeasonStartDate
           , RegularSeasonEndDate   = source.RegularSeasonEndDate
           , PlayoffStartDate       = source.PlayoffStartDate
           , PlayoffEndDate         = source.PlayoffEndDate
           , FinalsWinnerTeamId     = source.FinalsWinnerTeamId
           , FinalsLoserTeamId      = source.FinalsLoserTeamId
WHEN NOT MATCHED THEN
  INSERT ( EndYear
         , RegularSeasonStartDate
         , RegularSeasonEndDate
         , PlayoffStartDate
         , PlayoffEndDate
         , FinalsWinnerTeamId
         , FinalsLoserTeamId
         )
  VALUES ( source.EndYear
         , source.RegularSeasonStartDate
         , source.RegularSeasonEndDate
         , source.PlayoffStartDate
         , source.PlayoffEndDate
         , source.FinalsWinnerTeamId
         , source.FinalsLoserTeamId
         );
GO