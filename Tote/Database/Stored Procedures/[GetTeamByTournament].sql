
GO



CREATE PROCEDURE [dbo].[GetTeamByTournament]
@TournamentId int
AS
SELECT Team.TeamId, Team.Name, Team.SportId,Sport.Name, Team.CountryId, Country.Name

FROM Team 
INNER JOIN Country ON Country.CountryId=Team.CountryId
INNER JOIN Sport ON Team.SportId=Sport.SportId
INNER JOIN TeamTournament ON TeamTournament.TeamId=Team.TeamId
INNER JOIN Tournament ON Tournament.TournamentId=TeamTournament.TournamentId
WHERE Tournament.TournamentId=@TournamentId AND Team.DeleteStatus='False'
RETURN
GO


