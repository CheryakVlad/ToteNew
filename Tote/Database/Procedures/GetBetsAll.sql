CREATE PROCEDURE GetBetsAll

AS

SELECT BetId, Win, Loss,Draw, TeamHome.Name, TeamGuest.Name,DateMatch, CountryHome.Name, CountryGuest.Name

FROM Bet 
INNER JOIN Match ON Bet.MatchId=Match.MatchId
INNER JOIN TeamMatch as TeamMatchHome ON TeamMatchHome.MatchId=Match.MatchId
INNER JOIN TeamMatch as TeamMatchGuest ON TeamMatchGuest.MatchId=Match.MatchId
INNER JOIN Team as TeamHome ON TeamHome.TeamId=TeamMatchHome.TeamId
INNER JOIN Team as TeamGuest ON TeamGuest.TeamId=TeamMatchGuest.TeamId
INNER JOIN Country as CountryHome ON CountryHome.CountryId=TeamHome.CountryId
INNER JOIN Country as CountryGuest ON CountryGuest.CountryId=TeamGuest.CountryId
INNER JOIN TeamTournament ON TeamHome.TeamId=TeamTournament.TeamId
INNER JOIN Tournament ON TeamTournament.TournamentId=Tournament.TournamentId
INNER JOIN Sport ON Tournament.SportId=Sport.SportId
WHERE TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False'

RETURN

