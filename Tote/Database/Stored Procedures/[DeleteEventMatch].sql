
GO


CREATE PROC [dbo].[DeleteEventMatch]
@MatchId int
AS
DELETE EventMatch
WHERE MatchId=@MatchId




GO


