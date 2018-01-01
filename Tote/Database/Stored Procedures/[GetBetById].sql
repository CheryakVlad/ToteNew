
GO


CREATE PROCEDURE [dbo].[GetBetById]
@BetId int
AS
SELECT Bet.BetId, Bet.MatchId, Bet.Status, Bet.EventId
FROM Bet 
WHERE Bet.BetId=@BetId 
RETURN
GO


