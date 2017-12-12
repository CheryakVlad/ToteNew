
CREATE PROCEDURE [dbo].[GetSportById]
@SportId int
AS
SELECT *
FROM Sport 
Where SportId=@SportId
RETURN



