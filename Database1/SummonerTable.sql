CREATE TABLE [dbo].[SummonerTable]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Summoner1Name] VARCHAR(50) NULL, 
    [Summoner1Id] INT NULL, 
    [Summoner2Name] VARCHAR(50) NULL, 
    [Summoner2Id] INT NULL, 
    [Summoner3Name] VARCHAR(50) NULL, 
    [Summoner3Id] INT NULL, 
    [Summoner4Name] VARCHAR(50) NULL, 
    [Summoner4Id] INT NULL, 
    [Summoner5Name] VARCHAR(50) NULL, 
    [Summoner5Id] INT NULL
)
