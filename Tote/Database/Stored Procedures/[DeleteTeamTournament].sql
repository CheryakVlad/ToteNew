
GO


CREATE PROC [dbo].[DeleteTeamTournament]
@TeamId int,
@TournamentId int
AS
IF (SELECT TOP(1)1 
FROM Match
INNER JOIN Tournament ON Tournament.TournamentId=Match.TournamentId
INNER JOIN TeamMatch ON TeamMatch.MatchId=Match.MatchId
INNER JOIN Team ON TeamMatch.TeamId=Team.TeamId
WHERE Match.DeleteStatus='False' AND Tournament.DeleteStatus='False'
AND Team.DeleteStatus='False' AND Team.TeamId=@TeamId
AND Tournament.TournamentId=@TournamentId)=1
BEGIN
	UPDATE TeamTournament 
	SET DeleteStatus='True'
	WHERE TournamentId=@TournamentId AND TeamId=@TeamId
END
ELSE
BEGIN
	DELETE TeamTournament
	WHERE TournamentId=@TournamentId AND TeamId=@TeamId
END






GO


