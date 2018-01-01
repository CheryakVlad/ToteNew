
GO

CREATE PROC [dbo].[DeleteTournament]
@TournamentId int
AS

IF (SELECT TOP(1)1 
FROM TeamTournament, Match
WHERE TeamTournament.TournamentId=@TournamentId 
OR Match.TournamentId=@TournamentId)=1
BEGIN 
	UPDATE Tournament 
	SET DeleteStatus='True'
	WHERE TournamentId=@TournamentId
END
ELSE
BEGIN 
	DELETE Tournament
	WHERE TournamentId=@TournamentId
END





GO


