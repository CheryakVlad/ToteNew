
GO

CREATE PROC [dbo].[UpdateTournament]
@TournamentId int,
@Name nvarchar(50),
@SportId int
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM Tournament WHERE Tournament.Name=@Name AND Tournament.SportId=@SportId)
BEGIN
	UPDATE Tournament
	SET Name=@Name,SportId=@SportId
	WHERE TournamentId=@TournamentId
END


GO


