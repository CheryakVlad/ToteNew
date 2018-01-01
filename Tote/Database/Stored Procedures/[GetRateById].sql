
GO


CREATE PROCEDURE [dbo].[GetRateById]
@RateId int
AS
SELECT Rate.RateId, Rate.DateRate, Rate.RateAmount, Rate.UserId
FROM Rate 
WHERE Rate.RateId=@RateId 
RETURN
GO


