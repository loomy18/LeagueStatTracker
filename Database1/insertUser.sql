CREATE PROCEDURE [dbo].[insertUser]
	@UserName varchar(50),
	@SummonerName varchar(50),
	@Pass varchar(50),
	@SummonerId int
AS
	IF NOT EXISTS (SELECT * FROM UserTable WHERE UserName = @UserName)
	BEGIN
		INSERT INTO UserTable(UserName, SummonerName, Pass, SummonerId) 
		Values (@UserName, @SummonerName, @Pass, @SummonerId)
	END
RETURN 0
