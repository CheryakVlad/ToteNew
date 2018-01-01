
GO


CREATE PROC [dbo].[UpdateMatch]
@MatchId int,
@DateMatch datetime,
@ResultId int,
@TournamentId int,
@Score nvarchar(50),
@TeamHomeId int,
@TeamGuestId int
AS

IF NOT EXISTS(SELECT TOP(1)1 
FROM Match
INNER JOIN TeamMatch AS TeamMatchHome ON TeamMatchHome.MatchId=Match.MatchId 
INNER JOIN TeamMatch AS TeamMatchGuest ON TeamMatchGuest.MatchId=Match.MatchId
WHERE Match.DateMatch BETWEEN DATEADD(hour, -1, @DateMatch) AND DATEADD(hour, 1, @DateMatch)
AND (TeamMatchHome.TeamId=@TeamHomeId
OR TeamMatchGuest.TeamId=@TeamGuestId)
AND Match.MatchId!=@MatchId)

BEGIN
	UPDATE Match
	SET DateMatch=@DateMatch,ResultId=@ResultId, TournamentId=@TournamentId,Score=@Score
	WHERE MatchId=@MatchId
	
	UPDATE TeamMatch
	SET TeamId=@TeamHomeId
	WHERE MatchId=@MatchId AND Home='True'
	
	UPDATE TeamMatch
	SET TeamId=@TeamGuestId
	WHERE MatchId=@MatchId AND Home='False'
END


GO


