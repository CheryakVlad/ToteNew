
CREATE PROC [dbo].[DeleteTournament]
@TournamentId int
AS

DELETE Tournament
WHERE TournamentId=@TournamentId


