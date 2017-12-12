

CREATE PROC [dbo].[AddMatch]
@DateMatch datetime,
@ResultId int,
@TournamentId int,
@Score nvarchar(50),
@TeamHomeId int,
@TeamGuestId int
AS
IF @Score='0' set @Score=''
INSERT INTO Match VALUES(@DateMatch,@ResultId,@TournamentId,@Score)
DECLARE @MatchId int
SELECT @MatchId=MAX(Match.MatchId)
FROM Match

INSERT INTO TeamMatch VALUES(@MatchId,@TeamHomeId,'True')
INSERT INTO TeamMatch VALUES(@MatchId,@TeamGuestId,'False')


