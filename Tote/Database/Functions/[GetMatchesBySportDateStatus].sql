
CREATE FUNCTION [dbo].[GetMatchesBySportDateStatus](@SportId int, @DateMatch nvarchar(50),@Status int)
RETURNS TABLE
AS
RETURN
(SELECT * 
FROM dbo.GetMatchesBySportDate(@SportId,@DateMatch)
WHERE (@Status=0) OR (@Status=1 AND DateMatch<GETDATE() AND Score!='')
OR (@Status=2 AND DateMatch<GETDATE() AND Score='')
OR(@Status=3 AND DateMatch>GETDATE() AND Score='')
)

