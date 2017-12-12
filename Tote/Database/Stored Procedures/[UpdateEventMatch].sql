CREATE PROC [dbo].[UpdateEventMatch]
@MatchId int,
@Win float,
@Loss float,
@Draw float
AS
UPDATE EventMatch
SET Coefficient=@Win
WHERE EventId=1 AND MatchId=@MatchId

UPDATE EventMatch
SET Coefficient=@Loss
WHERE EventId=2 AND MatchId=@MatchId

UPDATE EventMatch
SET Coefficient=@Draw
WHERE EventId=3 AND MatchId=@MatchId

