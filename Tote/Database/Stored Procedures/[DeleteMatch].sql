
GO

CREATE PROC [dbo].[DeleteMatch]
@MatchId int
AS

IF (SELECT TOP(1)1 
FROM Bet
WHERE Bet.MatchId=@MatchId)=1
BEGIN 
	UPDATE Match 
	SET DeleteStatus='True'
	WHERE MatchId=@MatchId
END 
ELSE
BEGIN
	DELETE TeamMatch 
	WHERE MatchId=@MatchId
	
	DELETE EventMatch 
	WHERE MatchId=@MatchId
	
	DELETE Basket 
	WHERE MatchId=@MatchId

	DELETE Match
	WHERE MatchId=@MatchId
END




GO


