
GO


CREATE TRIGGER [dbo].[UPDATE_Match] ON [dbo].[Match] 
AFTER UPDATE 
AS

UPDATE Bet 
SET Status='True'
FROM Bet
INNER JOIN inserted ON Bet.MatchId=inserted.MatchId
WHERE inserted.ResultId=Bet.EventId

UPDATE Bet 
SET Status='False'
FROM Bet
INNER JOIN inserted ON Bet.MatchId=inserted.MatchId
WHERE inserted.ResultId!=Bet.EventId AND inserted.ResultId!=4


GO


