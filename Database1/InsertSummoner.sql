CREATE PROCEDURE [dbo].[InsertSummoner]
@UserId  uniqueidentifier,
@Summoner1Name VARCHAR(50),
@Summoner2Name VARCHAR(50) = null,
@Summoner3Name VARCHAR(50) = null,
@Summoner4Name VARCHAR(50) = null,
@Summoner5Name VARCHAR(50) = null,
@Summoner1Id int,
@Summoner2Id int = null,
@Summoner3Id int = null,
@Summoner4Id int = null,
@Summoner5Id int = null

AS
  BEGIN
      SET NOCOUNT ON;
      IF EXISTS (SELECT 1 FROM SummonerTable WHERE UserId = @UserId)
        UPDATE SummonerTable
        SET 
			Summoner1Name = @Summoner1Name, 
			Summoner1Id = @Summoner1Id, 
			Summoner2Name = @Summoner2Name,
			Summoner2Id = @Summoner2Id,
			Summoner3Name = @Summoner3Name, 
			Summoner3Id = @Summoner3Id, 
			Summoner4Name = @Summoner4Id,
			Summoner4Id = @Summoner4Id, 
			Summoner5Name = @Summoner5Id, 
			Summoner5Id = @Summoner5Id

        ELSE

        INSERT INTO SummonerTable(UserId, Summoner1Name, Summoner1Id, Summoner2Name, Summoner2Id, Summoner3Name, Summoner3Id, Summoner4Name, Summoner4Id, Summoner5Name, Summoner5Id)
        VALUES                   (@UserId, @Summoner1Name, @Summoner1Id, @Summoner2Name, @Summoner2Id, @Summoner3Name, @Summoner3Id, @Summoner4Name, @Summoner4Id, @Summoner5Name, @Summoner5Id)
  END