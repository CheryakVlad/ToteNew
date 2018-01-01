
GO

CREATE PROC [dbo].[DeleteBasket]
@BasketId int
AS
DELETE Basket 
WHERE BasketId=@BasketId
GO


