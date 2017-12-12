CREATE PROC [dbo].[UpdateTournament]
@TournamentId int,
@Name nvarchar(50),
@SportId int
AS
UPDATE Tournament
SET Name=@Name,SportId=@SportId
WHERE TournamentId=@TournamentId

