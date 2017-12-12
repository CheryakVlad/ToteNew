CREATE PROCEDURE [dbo].[GetBasketByUser]
@UserId int
AS

SELECT Basket.*
FROM Basket 
WHERE Basket.UserId=@UserId

RETURN



