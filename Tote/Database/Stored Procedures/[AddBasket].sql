
GO

CREATE PROC [dbo].[AddBasket]
@UserId int,
@MatchId int,
@EventId int
AS

INSERT INTO Basket VALUES(@UserId,@MatchId,@EventId)

GO


