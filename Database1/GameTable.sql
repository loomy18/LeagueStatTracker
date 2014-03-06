CREATE TABLE [dbo].[GameTable]
(
	[gameId] INT NOT NULL PRIMARY KEY, 
    [invalid] BIT NULL, 
    [gameMode] VARCHAR(50) NULL, 
    [gameType] VARCHAR(50) NULL, 
    [subType] VARCHAR(50) NULL, 
    [mapId] INT NULL, 
    [createDate] BIGINT NULL 
)
