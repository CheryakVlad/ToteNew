GO

CREATE PROC [dbo].[AddBasket]
@UserId int,
@MatchId int,
@EventId int
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM Basket WHERE UserId=@UserId AND MatchId=@MatchId)
BEGIN
	INSERT INTO Basket VALUES(@UserId,@MatchId,@EventId)
END
GO


