
GO

CREATE PROCEDURE [dbo].[GetBasketById]
@BasketId int,
@UserId int
AS

SELECT Basket.*
FROM Basket 
WHERE Basket.UserId=@UserId AND Basket.BasketId=@BasketId

RETURN
GO


