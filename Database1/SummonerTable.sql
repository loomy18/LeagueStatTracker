CREATE TABLE [dbo].[SummonerTable]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Server] INT NOT NULL, 
    [ProfileIconId] INT NULL, 
    [RevisionDate] BIGINT NULL, 
)
