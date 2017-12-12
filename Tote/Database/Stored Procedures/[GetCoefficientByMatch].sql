
CREATE PROCEDURE [dbo].[GetCoefficientByMatch]
@MatchId int
AS
SELECT Event.EventId, Name,EventMatch.Coefficient, EventMatch.MatchId
FROM dbo.EventMatch
INNER JOIN Event ON EventMatch.EventId=Event.EventId
WHERE EventMatch.MatchId=@MatchId



