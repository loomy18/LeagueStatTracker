﻿CREATE PROCEDURE [dbo].[InsertGame]
	@gameId int, 
    @invalid BIT = 0, 
    @gameMode VARCHAR(50) = null, 
    @gameType VARCHAR(50) = null, 
    @subType VARCHAR(50) = null, 
    @mapId INT = null, 
    @teamId INT = null, 
    @championId INT = null, 
    @spell1 INT = null, 
    @spell2 INT = null, 
    @champLevel INT = null,
	@summonerLevel INT = null,  
    @createDate BIGINT = null,  
    @summonerId INT = null,
    @goldEarned INT = null, 
    @numDeaths INT = null, 
    @minionsKilled INT = null, 
    @championsKilled INT = null, 
    @goldSpent INT = null, 
    @totalDamageDealt INT = null, 
    @totalDamageTaken INT = null, 
    @doubleKills INT = null, 
    @tripleKills INT = null, 
    @killingSprees INT, 
    @largestKillingSpree INT = null, 
    @team INT = null, 
    @win BIT = null, 
    @neutralMinionsKilled INT = null, 
    @largestMultiKill INT = null, 
    @physicalDamageDealtPlayer INT = null, 
    @magicDamageDealtPlayer INT = null, 
    @physicalDamageTaken INT = null, 
    @magicDamageTaken INT = null, 
    @timePlayed INT = null, 
    @totalHeal INT = null, 
    @totalUnitsHealed INT = null, 
    @assists INT = null, 
    @item0 INT = null, 
    @item1 INT = null, 
    @item2 INT = null, 
    @item3 INT = null, 
    @item4 INT = null, 
    @item5 INT = null, 
    @item6 INT = null, 
    @sightWardsBought INT = null, 
    @physicalDamageDealtToChampions INT = null, 
    @totalDamageDealtToChampions INT = null, 
    @trueDamageDealtPlayer INT = null, 
    @trueDamageDealtToChampions INT = null, 
    @trueDamageTaken INT = null, 
    @wardPlaced INT = null, 
    @neutralMinionsKilledEnemyJungle INT = null, 
    @neutralMinionsKilledYourJungle INT = null, 
    @totalTimeCrowdControlDealt INT = null, 
    @barracksKilled INT = null, 
    @turretsKilled INT = null, 
    @largestCriticalStrike INT = null, 
    @magicDamageDealtToChampions INT = null, 
    @visionWardsBought INT = null
AS
	IF NOT EXISTS (SELECT 1 FROM GameTable WHERE (gameId = @gameId))
		BEGIN
			INSERT INTO GameTable (gameId, invalid, gameMode, gameType, subType, mapId, createDate)
			VALUES(@gameId, @invalid, @gameMode, @gameType, @subType, @mapId, @createDate)
		END
	IF NOT EXISTS (SELECT 1 FROM GameStatTable WHERE (gameId = @gameId AND summonerId = @summonerId))
		BEGIN
			INSERT INTO GameStatTable(statsId, gameId, teamId, championId, spell1, spell2, summonerLevel, champLevel, summonerId, goldEarned, numDeaths, minionsKilled, championsKilled, goldSpent, totalDamageDealt, totalDamageTaken, doubleKills, tripleKills, killingSprees, largestKillingSpree, team, win, neutralMinionsKilled, largestMultiKill, physicalDamageDealtPlayer, magicDamageDealtPlayer, physicalDamageTaken, magicDamageTaken, timePlayed, totalHeal, totalUnitsHealed, assists, item0, item1, item2, item3, item4, item5, item6, sightWardsBought, physicalDamageDealtToChampions, totalDamageDealtToChampions, trueDamageDealtPlayer, trueDamageDealtToChampions, trueDamageTaken, wardPlaced, neutralMinionsKilledEnemyJungle, neutralMinionsKilledYourJungle, totalTimeCrowdControlDealt, barracksKilled, turretsKilled, largestCriticalStrike, magicDamageDealtToChampions, visionWardsBought)
			VALUES(NEWID(), @gameId, @teamId, @championId, @spell1, @spell2, @summonerLevel, @champLevel, @summonerId, @goldEarned, @numDeaths, @minionsKilled, @championsKilled, @goldSpent, @totalDamageDealt, @totalDamageTaken, @doubleKills, @tripleKills, @killingSprees, @largestKillingSpree, @team, @win, @neutralMinionsKilled, @largestMultiKill, @physicalDamageDealtPlayer, @magicDamageDealtPlayer, @physicalDamageTaken, @magicDamageTaken, @timePlayed, @totalHeal, @totalUnitsHealed, @assists, @item0, @item1, @item2, @item3, @item4, @item5, @item6, @sightWardsBought, @physicalDamageDealtToChampions, @totalDamageDealtToChampions, @trueDamageDealtPlayer, @trueDamageDealtToChampions, @trueDamageTaken, @wardPlaced, @neutralMinionsKilledEnemyJungle, @neutralMinionsKilledYourJungle, @totalTimeCrowdControlDealt, @barracksKilled, @turretsKilled, @largestCriticalStrike, @magicDamageDealtToChampions, @visionWardsBought)
		END
RETURN 1 
