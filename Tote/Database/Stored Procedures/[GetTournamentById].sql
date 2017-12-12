
CREATE PROCEDURE [dbo].[GetTournamentById]
@TournamentId int
AS
SELECT Tournament.TournamentId, Tournament.Name, Tournament.SportId, Sport.Name
FROM Tournament INNER JOIN Sport ON Tournament.SportId=Sport.SportId
WHERE TournamentId=@TournamentId 
RETURN



