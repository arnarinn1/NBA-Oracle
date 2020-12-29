CREATE TYPE nba.tt_MergePlayerDataType AS TABLE
( Identifier     VARCHAR(128)  NOT NULL
, Name           VARCHAR(125)  NOT NULL
, BirthDate      DATE          NOT NULL
, BirthCountry   CHAR(2)       NOT NULL
, College        VARCHAR(128)  NOT NULL
)
GO