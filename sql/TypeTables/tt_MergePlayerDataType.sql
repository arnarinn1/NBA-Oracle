CREATE TYPE nba.tt_MergePlayerDataType AS TABLE
( Identifier     NVARCHAR(128)  NOT NULL
, Name           NVARCHAR(125)  NOT NULL
, BirthDate      DATE           NOT NULL
, BirthCountry   CHAR(2)        NOT NULL
, College        NVARCHAR(128)  NOT NULL
)
GO