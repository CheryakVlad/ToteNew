
GO


CREATE PROC [dbo].[AddRate]
@DateRate datetime,
@RateAmount money,
@UserId int

AS
BEGIN TRANSACTION
INSERT INTO Rate VALUES(@DateRate,@RateAmount,@UserId,'False')

DECLARE @RateId int
SELECT @RateId = scope_identity();
SELECT @RateId
COMMIT




GO


