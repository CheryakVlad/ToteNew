
GO


CREATE PROCEDURE [dbo].[GetTournamentsByTeamId]
@TeamId int
AS
SELECT Tournament.TournamentId, Tournament.Name, Tournament.SportId, Sport.Name
FROM Tournament 
INNER JOIN Sport ON Tournament.SportId=Sport.SportId
INNER JOIN TeamTournament ON TeamTournament.TournamentId=Tournament.TournamentId
INNER JOIN Team ON Team.TeamId=TeamTournament.TeamId
WHERE Team.TeamId=@TeamId AND Sport.DeleteStatus='False'
AND Tournament.DeleteStatus='False' AND Team.DeleteStatus='False'
RETURN
GO


