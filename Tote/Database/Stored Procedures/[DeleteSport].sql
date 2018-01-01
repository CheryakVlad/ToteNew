
GO

CREATE PROC [dbo].[DeleteSport]
@SportId int
AS

IF (SELECT TOP(1)1 
FROM Tournament, Team
WHERE Tournament.SportId=@SportId 
OR Team.SportId=@SportId)=1
BEGIN 
	UPDATE Sport 
	SET DeleteStatus='True'
	WHERE SportId=@SportId
END 
ELSE
BEGIN
	DELETE Sport
	WHERE SportId=@SportId
END

GO


