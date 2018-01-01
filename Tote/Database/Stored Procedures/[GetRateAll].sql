
GO


CREATE PROCEDURE [dbo].[GetRateAll]

AS
SELECT Rate.RateId, Rate.DateRate, Rate.RateAmount, Rate.UserId
FROM Rate 

RETURN
GO


