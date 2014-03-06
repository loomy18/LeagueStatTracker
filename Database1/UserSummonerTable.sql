CREATE TABLE [dbo].[UserSummonerTable]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Summoner1Id] INT NULL, 
    [Summoner2Id] INT NULL, 
    [Summoner3Id] INT NULL, 
    [Summoner4Id] INT NULL, 
    [Summoner5Id] INT NULL 
)
