CREATE PROCEDURE [dbo].[insertGame]
	@gameId INT, 
    @invalid BIT, 
    @gameMode VARCHAR(50), 
    @gameType VARCHAR(50), 
    @subType VARCHAR(50), 
    @mapId INT, 
    @teamId INT, 
    @championId INT, 
    @spell1 INT, 
    @spell2 INT, 
    @level INT, 
    @createDate DATETIME, 
    @statsId INT, 
    @summonerId INT
AS
	IF EXISTS (SELECT * FROM GameTable WHERE gameId = @gameId)
	BEGIN
		
	END
	ELSE
	BEGIN
	SELECT @param1, @param2
	END
RETURN 0
