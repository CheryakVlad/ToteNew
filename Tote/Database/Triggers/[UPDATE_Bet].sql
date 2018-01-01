
GO


CREATE TRIGGER [dbo].[UPDATE_Bet] ON [dbo].[Bet] 
AFTER UPDATE 
AS

CREATE TABLE #Rates1 (RateId int, CountBet int)
INSERT INTO #Rates1 (RateId, CountBet)
SELECT Rate.RateId, COUNT(Bet.BetId)
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
LEFT JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN inserted ON Bet.BetId=inserted.BetId
GROUP BY Rate.RateId

CREATE TABLE #RatesCountBet(RateId int, CountBet int)
INSERT INTO #RatesCountBet (RateId, CountBet)
SELECT Rate.RateId, COUNT(Bet.BetId)
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
INNER JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN #Rates1 ON Rate.RateId=#Rates1.RateId
GROUP BY Rate.RateId

CREATE TABLE #Rates2 (RateId int, CountTrue int)
INSERT INTO #Rates2 (RateId, CountTrue)
SELECT Rate.RateId, COUNT(Bet.BetId)
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
INNER JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN #Rates1 ON Rate.RateId=#Rates1.RateId
WHERE Bet.Status='True'
GROUP BY Rate.RateId


CREATE TABLE #Rates3 (RateId int, Total money)
INSERT INTO #Rates3 (RateId, Total)
SELECT #Rates2.RateId, 1
FROM #Rates2
INNER JOIN #RatesCountBet ON #Rates2.RateId=#RatesCountBet.RateId
WHERE #Rates2.CountTrue=#RatesCountBet.CountBet 

CREATE TABLE #Rates4 (RateId int, Total money)
INSERT INTO #Rates4 (RateId, Total)
SELECT #Rates2.RateId, 1
FROM #RatesCountBet
LEFT JOIN #Rates2 ON #RatesCountBet.RateId=#Rates2.RateId
WHERE #Rates2.CountTrue!=#RatesCountBet.CountBet 

CREATE TABLE #CoefficientRates4(RateId int, Coefficient float)
INSERT INTO #CoefficientRates4 
select #Rates4.RateId, exp(SUM(log(EventMatch.Coefficient)))
FROM Bet
INNER JOIN BetRate ON Bet.BetId=BetRate.BetId
INNER JOIN #Rates4 ON BetRate.RateId=#Rates4.RateId
INNER JOIN EventMatch ON  EventMatch.MatchId=Bet.MatchId
INNER JOIN Event ON Bet.EventId=Event.EventId
INNER JOIN Event as EventBet ON EventBet.EventId=EventMatch.EventId
WHERE EventBet.Name=Event.Name
GROUP BY #Rates4.RateId

UPDATE #Rates4
SET Total=#CoefficientRates4.Coefficient
FROM #CoefficientRates4
INNER JOIN #Rates4 ON #Rates4.RateId=#CoefficientRates4.RateId

UPDATE User_ 
SET User_.Money=User_.Money-(#Rates4.Total*Rate.RateAmount)
FROM #Rates4
INNER JOIN Rate ON #Rates4.RateId=Rate.RateId
INNER JOIN User_ ON User_.UserId=Rate.UserId
WHERE Rate.StatusWin='True'

UPDATE Rate
SET Rate.StatusWin='False'
FROM Rate
INNER JOIN #Rates1 ON Rate.RateId=#Rates1.RateId
INNER JOIN #Rates2 ON #Rates1.RateId=#Rates2.RateId
WHERE #Rates2.CountTrue!=#Rates1.CountBet

UPDATE Rate
SET Rate.StatusWin='True'
FROM Rate
INNER JOIN #Rates3 ON Rate.RateId=#Rates3.RateId
WHERE #Rates3.RateId=Rate.RateId

CREATE TABLE #Coefficient(RateId int, Coefficient float)
INSERT INTO #Coefficient 
select #Rates3.RateId, exp(SUM(log(EventMatch.Coefficient)))
FROM Bet
INNER JOIN BetRate ON Bet.BetId=BetRate.BetId
INNER JOIN #Rates3 ON BetRate.RateId=#Rates3.RateId
INNER JOIN EventMatch ON  EventMatch.MatchId=Bet.MatchId
INNER JOIN Event ON Bet.EventId=Event.EventId
INNER JOIN Event as EventBet ON EventBet.EventId=EventMatch.EventId
WHERE Bet.Status='True' AND EventBet.Name=Event.Name
GROUP BY #Rates3.RateId

UPDATE #Rates3
SET Total=#Coefficient.Coefficient
FROM #Coefficient
INNER JOIN #Rates3 ON #Rates3.RateId=#Coefficient.RateId

select * from #Rates3

UPDATE User_ 
SET User_.Money=User_.Money+(#Rates3.Total*Rate.RateAmount)
FROM #Rates3
INNER JOIN Rate ON #Rates3.RateId=Rate.RateId
INNER JOIN User_ ON User_.UserId=Rate.UserId


GO


