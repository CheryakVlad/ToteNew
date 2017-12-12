CREATE PROCEDURE [dbo].[GetTournamentsBySportId]
@SportId int
AS
SELECT Tournament.TournamentId, Tournament.Name, Tournament.SportId, Sport.Name
FROM Tournament INNER JOIN Sport ON Tournament.SportId=Sport.SportId
WHERE Tournament.SportId=@SportId 
RETURN



