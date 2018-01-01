
GO


CREATE PROCEDURE [dbo].[GetRateByUserId]
@UserId int
AS

CREATE TABLE #Rates1 (RateId int, CountBet int, Status bit)
INSERT INTO #Rates1 (RateId, CountBet, Status)
SELECT Rate.RateId, COUNT(Bet.BetId),'False'
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
LEFT JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN User_ ON User_.UserId=Rate.UserId
WHERE User_.UserId=@UserId
GROUP BY Rate.RateId


CREATE TABLE #Rates2 (RateId int, CountTrue int)
INSERT INTO #Rates2 (RateId, CountTrue)
SELECT Rate.RateId, COUNT(Bet.BetId)
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
LEFT JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN User_ ON User_.UserId=Rate.UserId
WHERE Bet.Status='True' AND User_.UserId=@UserId
GROUP BY Rate.RateId

UPDATE #Rates1
SET Status='True'
FROM #Rates1
INNER JOIN #Rates2 ON #Rates1.RateId=#Rates2.RateId
WHERE #Rates1.CountBet=#Rates2.CountTrue
/*
CREATE TABLE #Rates3 (RateId int, Status bit)
INSERT INTO #Rates3 (RateId, Status)
SELECT #Rates2.RateId, 'True'
FROM #Rates2
INNER JOIN #Rates1 ON #Rates2.RateId=#Rates1.RateId
WHERE #Rates2.CountTrue=#Rates1.CountBet 

INSERT INTO #Rates3 (RateId, Status)
SELECT #Rates2.RateId, 'False'
FROM #Rates2
INNER JOIN #Rates1 ON #Rates2.RateId=#Rates1.RateId
WHERE #Rates2.CountTrue!=#Rates1.CountBet */

SELECT Rate.RateId, Rate.DateRate, Rate.RateAmount, Rate.UserId, #Rates1.Status
FROM Rate 
INNER JOIN #Rates1 ON #Rates1.RateId=Rate.RateId
WHERE Rate.UserId=@UserId

/*SELECT Rate.RateId, Rate.DateRate, Rate.RateAmount, Rate.UserId, #Rates3.Status
FROM Rate 
INNER JOIN #Rates3 ON #Rates3.RateId=Rate.RateId
WHERE Rate.UserId=@UserId */
RETURN
GO


