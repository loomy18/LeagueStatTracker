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
@Summoner5Id int = null,
@Summoner1Server int,
@Summoner2Server int = null,
@Summoner3Server int = null,
@Summoner4Server int = null,
@Summoner5Server int = null

AS
  BEGIN
      SET NOCOUNT ON;
      IF EXISTS (SELECT 1 FROM UserSummonerTable WHERE UserId = @UserId)
        UPDATE UserSummonerTable
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

        INSERT INTO UserSummonerTable(UserId, Summoner1Name, Summoner1Id, Summoner2Name, Summoner2Id, Summoner3Name, Summoner3Id, Summoner4Name, Summoner4Id, Summoner5Name, Summoner5Id)
        VALUES                   (@UserId, @Summoner1Name, @Summoner1Id, @Summoner2Name, @Summoner2Id, @Summoner3Name, @Summoner3Id, @Summoner4Name, @Summoner4Id, @Summoner5Name, @Summoner5Id)

		IF((@Summoner1Id is not null) AND (NOT EXISTS (SELECT 1 FROM SummonerTable WHERE SummonerId = @Summoner1Id )))
			INSERT INTO SummonerTable(SummonerId, Name, Server)
			VALUES				     (@Summoner1Id, @Summoner1Name, @Summoner1Server)
		IF((@Summoner2Id is not null) AND (NOT EXISTS (SELECT 1 FROM SummonerTable WHERE SummonerId = @Summoner2Id )))
			INSERT INTO SummonerTable(SummonerId, Name, Server)
			VALUES				     (@Summoner2Id, @Summoner2Name, @Summoner2Server)
		IF((@Summoner3Id is not null) AND (NOT EXISTS (SELECT 1 FROM SummonerTable WHERE SummonerId = @Summoner3Id )))
			INSERT INTO SummonerTable(SummonerId, Name, Server)
			VALUES				     (@Summoner3Id, @Summoner3Name, @Summoner3Server)
		IF((@Summoner4Id is not null) AND (NOT EXISTS (SELECT 1 FROM SummonerTable WHERE SummonerId = @Summoner4Id )))
			INSERT INTO SummonerTable(SummonerId, Name, Server)
			VALUES				     (@Summoner4Id, @Summoner4Name, @Summoner4Server)
		IF((@Summoner5Id is not null) AND (NOT EXISTS (SELECT 1 FROM SummonerTable WHERE SummonerId = @Summoner5Id )))
			INSERT INTO SummonerTable(SummonerId, Name, Server)
			VALUES				     (@Summoner5Id, @Summoner5Name, @Summoner5Server)
  END