CREATE PROC [dbo].[UpdateMatch]
@MatchId int,
@DateMatch datetime,
@ResultId int,
@TournamentId int,
@Score nvarchar(50)
AS
UPDATE Match
SET DateMatch=@DateMatch,ResultId=@ResultId, TournamentId=@TournamentId,Score=@Score
WHERE MatchId=@MatchId


