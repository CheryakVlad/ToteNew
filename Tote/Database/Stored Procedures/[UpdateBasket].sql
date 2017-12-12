CREATE PROC [dbo].[UpdateBasket]
@BasketId int,
@UserId int,
@MatchId int,
@EventId int
AS
UPDATE Basket
SET UserId=@UserId,MatchId=@MatchId, EventId=@EventId
WHERE BasketId=@BasketId



