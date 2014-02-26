CREATE TABLE [dbo].[UserTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] VARCHAR(50) NULL, 
    [SummonerName] VARCHAR(50) NULL, 
    [Pass] VARCHAR(50) NULL, 
    [SummonerId] INT NULL
)
