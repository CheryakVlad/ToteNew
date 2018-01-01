
GO


CREATE PROCEDURE [dbo].[GetCoefficients]
AS
SELECT Event.EventId, Name, Coefficient, Match.MatchId
FROM EventMatch
INNER JOIN Event ON EventMatch.EventId=Event.EventId
INNER JOIN Match ON Match.MatchId=EventMatch.MatchId

GO


