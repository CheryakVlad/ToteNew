
GO


CREATE PROC [dbo].[DeleteTeam]
@TeamId int
AS

IF (SELECT TOP(1)1 
FROM TeamTournament,TeamMatch
WHERE TeamTournament.TeamId=@TeamId
OR TeamMatch.TeamId=@TeamId)=1
BEGIN 
	UPDATE Team 
	SET DeleteStatus='True'
	WHERE TeamId=@TeamId
END 
ELSE
BEGIN
	DELETE Team
	WHERE TeamId=@TeamId	
END





GO


