
GO


CREATE PROC [dbo].[AddMatch]
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
--AND Match.TournamentId=@TournamentId 
AND (TeamMatchHome.TeamId=@TeamHomeId
OR TeamMatchGuest.TeamId=@TeamGuestId))
BEGIN 
	IF @Score='0' set @Score=''
	BEGIN
		INSERT INTO Match VALUES(@DateMatch,@ResultId,@TournamentId,@Score,'False')
		DECLARE @MatchId int
		
		SELECT @MatchId=MAX(Match.MatchId)
		FROM Match
		
		INSERT INTO TeamMatch VALUES(@MatchId,@TeamHomeId,'True')
		INSERT INTO TeamMatch VALUES(@MatchId,@TeamGuestId,'False')
	END

END

GO


