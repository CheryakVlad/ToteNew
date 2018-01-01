
GO

CREATE PROCEDURE [dbo].[GetSportById]
@SportId int
AS
SELECT *
FROM Sport 
Where SportId=@SportId AND DeleteStatus='False'
RETURN
GO


