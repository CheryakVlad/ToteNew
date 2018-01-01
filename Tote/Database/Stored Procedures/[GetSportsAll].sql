
GO

CREATE PROCEDURE [dbo].[GetSportsAll]
AS
SELECT *
FROM Sport 
WHERE DeleteStatus='False'
RETURN
GO


