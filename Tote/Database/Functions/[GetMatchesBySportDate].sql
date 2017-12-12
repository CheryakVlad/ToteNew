
CREATE FUNCTION [dbo].[GetMatchesBySportDate](@SportId int, @DateMatch nvarchar(50))
RETURNS TABLE
AS
RETURN
(SELECT * 
FROM dbo.GetMatchesBySport(@SportId)
WHERE (@DateMatch!='' AND CAST(DateMatch AS DATE)=CAST(CONVERT(datetime,@DateMatch) AS DATE)) OR (@DateMatch='')
)
