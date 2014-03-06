CREATE PROCEDURE [dbo].[InsertSummoner]
@UserId  uniqueidentifier,
@SummonerName VARCHAR(50),
@SummonerId int,
@SummonerServer int,
@SummonerNumber int,
@ProfileIconId int,
@RevisionDate bigint

AS
  BEGIN
		IF(NOT EXISTS(SELECT 1 FROM UserSummonerTable WHERE UserID = @UserId))
			INSERT INTO UserSummonerTable(UserId)
			VALUES (@UserId)
		IF(@SummonerNumber = 1)
			UPDATE UserSummonerTable
			SET Summoner1Id = @SummonerId
			WHERE UserId = @UserId
		IF(@SummonerNumber = 2)
			UPDATE UserSummonerTable
			SET Summoner2Id = @SummonerId
			WHERE UserId = @UserId
		IF(@SummonerNumber = 3)
			UPDATE UserSummonerTable
			SET Summoner3Id = @SummonerId
			WHERE UserId = @UserId
		IF(@SummonerNumber = 4)
			UPDATE UserSummonerTable
			SET Summoner4Id = @SummonerId
			WHERE UserId = @UserId
		IF(@SummonerNumber = 5)
			UPDATE UserSummonerTable
			SET Summoner5Id = @SummonerId
			WHERE UserId = @UserId
		IF(NOT EXISTS(SELECT 1 FROM SummonerTable WHERE Id = @SummonerId))
			INSERT INTO SummonerTable(Id, Server, Name, ProfileIconId, RevisionDate)
			VALUES (@SummonerId, @SummonerServer, @SummonerName, @ProfileIconId, @RevisionDate)
  END