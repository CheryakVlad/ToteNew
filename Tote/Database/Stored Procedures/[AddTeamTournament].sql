
GO


CREATE PROC [dbo].[AddTeamTournament]
@TeamId int,
@TournamentId int
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM TeamTournament 
WHERE TeamTournament.TeamId=@TeamId AND TeamTournament.TournamentId=@TournamentId)
	INSERT INTO TeamTournament VALUES(@TeamId,@TournamentId,'False')



GO


