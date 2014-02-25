CREATE TABLE [dbo].[GameTable]
(
	[gameId] INT NOT NULL PRIMARY KEY, 
    [invalid] BIT NULL, 
    [gameMode] VARCHAR(50) NULL, 
    [gameType] VARCHAR(50) NULL, 
    [subType] VARCHAR(50) NULL, 
    [mapId] INT NULL, 
    [teamId] INT NULL, 
    [championId] INT NULL, 
    [spell1] INT NULL, 
    [spell2] INT NULL, 
    [level] INT NULL, 
    [createDate] DATETIME NULL, 
    [statsId] INT NOT NULL, 
    [summonerId] INT NOT NULL
)
