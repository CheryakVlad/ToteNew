
CREATE PROCEDURE [dbo].[GetMatchesAll]

AS

SELECT Match.MatchId,TeamHome.TeamId, TeamHome.Name, 
TeamGuest.TeamId,TeamGuest.Name,DateMatch,
CountryHome.CountryId, CountryHome.Name,CountryGuest.CountryId, CountryGuest.Name,
Tournament.TournamentId, Tournament.Name, Match.Score,
Match.ResultId, Result.Name, Sport.SportId

FROM Match 
INNER JOIN TeamMatch as TeamMatchHome ON TeamMatchHome.MatchId=Match.MatchId
INNER JOIN TeamMatch as TeamMatchGuest ON TeamMatchGuest.MatchId=Match.MatchId
INNER JOIN Team as TeamHome ON TeamHome.TeamId=TeamMatchHome.TeamId
INNER JOIN Team as TeamGuest ON TeamGuest.TeamId=TeamMatchGuest.TeamId
INNER JOIN Country as CountryHome ON CountryHome.CountryId=TeamHome.CountryId
INNER JOIN Country as CountryGuest ON CountryGuest.CountryId=TeamGuest.CountryId
INNER JOIN TeamTournament ON TeamHome.TeamId=TeamTournament.TeamId
INNER JOIN Tournament ON TeamTournament.TournamentId=Tournament.TournamentId
INNER JOIN Sport ON Tournament.SportId=Sport.SportId
INNER JOIN Result ON Match.ResultId=Result.ResultId
WHERE TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False'

RETURN



