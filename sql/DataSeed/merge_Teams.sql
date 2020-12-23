MERGE nba.Team AS target
USING
( SELECT 1,  'ATL', 'Atlanta Hawks'           UNION
  SELECT 2,  'BOS', 'Boston Celtics'          UNION
  SELECT 3,  'BRL', 'Brooklyn Nets'           UNION
  SELECT 4,  'CHI', 'Chicago Bulls'           UNION
  SELECT 5,  'CHO', 'Charlotte Hornets'       UNION
  SELECT 6,  'CLE', 'Cleveland Cavaliers'     UNION
  SELECT 7,  'DAL', 'Dallas Mavericks'        UNION
  SELECT 8,  'DEN', 'Denver Nuggets'          UNION
  SELECT 9,  'DET', 'Detroit Pistons'         UNION
  SELECT 10, 'GSW', 'Golden State Warriors'   UNION
  SELECT 11, 'HOU', 'Houston Rockets'         UNION
  SELECT 12, 'IND', 'Indiana Pacers'          UNION
  SELECT 13, 'LAC', 'Los Angeles Clippers'    UNION
  SELECT 14, 'LAL', 'Los Angeles Lakers'      UNION
  SELECT 15, 'MEM', 'Memphis Grizzlies'       UNION
  SELECT 16, 'MIA', 'Miami Heat'              UNION
  SELECT 17, 'MIL', 'Milwaukee Bucks'         UNION
  SELECT 18, 'MIN', 'Minnesota Timberwolves'  UNION
  SELECT 19, 'NOP', 'New Orleans Pelicans'    UNION
  SELECT 20, 'NYK', 'New York Knicks'         UNION
  SELECT 21, 'OKC', 'Oklahoma City Thunder'   UNION
  SELECT 22, 'ORL', 'Orlando Magic'           UNION
  SELECT 23, 'PHI', 'Philadelphia 76ers'      UNION
  SELECT 24, 'PHO', 'Phoenix Suns'            UNION
  SELECT 25, 'POR', 'Portland Trail Blazers'  UNION
  SELECT 26, 'SAC', 'Sacramento Kings'        UNION
  SELECT 27, 'SAS', 'San Antonio Spurs'       UNION
  SELECT 28, 'TOR', 'Toronto Raptors'         UNION
  SELECT 29, 'UTA', 'Utah Jazz'               UNION
  SELECT 30, 'WAS', 'Washington Wizards' 
  
) AS source (Id, Identifier, Name)
ON (target.Id = source.Id)
WHEN MATCHED THEN
  UPDATE SET CurrentIdentifier = source.Identifier, CurrentName = source.name
WHEN NOT MATCHED THEN
  INSERT (Id, CurrentIdentifier, CurrentName)
  VALUES (source.Id, source.Identifier, source.Name);
GO