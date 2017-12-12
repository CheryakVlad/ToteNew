
CREATE PROC [dbo].[DeleteMatch]
@MatchId int
AS
DELETE TeamMatch 
WHERE MatchId=@MatchId

DELETE Match
WHERE MatchId=@MatchId


