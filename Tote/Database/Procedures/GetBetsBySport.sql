CREATE PROCEDURE GetBetsBySport
@SportId int
AS
SELECT BetId, Win, Loss,Draw, TeamHome.Name as TeamHome, TeamGuest.Name as TeamGuest,DateMatch

FROM Bet 
INNER JOIN Match ON Bet.MatchId=Match.MatchId
INNER JOIN Team as TeamHome ON TeamHome.TeamId=Match.TeamHomeId
INNER JOIN Team as TeamGuest ON TeamGuest.TeamId=Match.TeamGuestId
INNER JOIN Sport ON TeamHome.SportId=Sport.SportId
where Sport.SportId=@SportId

RETURN

