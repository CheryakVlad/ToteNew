
GO


CREATE PROCEDURE [dbo].[GetBetByRateID]
@RateId int
AS
SELECT Bet.BetId, Bet.MatchId, Bet.Status, Bet.EventId, Sport.Name, Tournament.Name
FROM Bet 
INNER JOIN BetRate ON Bet.BetId=BetRate.BetId
INNER JOIN Match ON Match.MatchId=Bet.MatchId
INNER JOIN Tournament ON Tournament.TournamentId=Match.TournamentId
INNER JOIN Sport ON Sport.SportId=Tournament.SportId
WHERE BetRate.RateId=@RateId 
RETURN
GO


