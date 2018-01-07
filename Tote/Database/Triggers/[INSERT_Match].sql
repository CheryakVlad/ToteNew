
GO

CREATE TRIGGER [dbo].[INSERT_Match] ON [dbo].[Match] 
FOR INSERT 
AS

INSERT INTO EventMatch (MatchId, EventId, Coefficient)
SELECT MatchId,1,1
FROM inserted

INSERT INTO EventMatch (MatchId, EventId, Coefficient)
SELECT MatchId,2,1
FROM inserted

INSERT INTO EventMatch (MatchId, EventId, Coefficient)
SELECT MatchId,3,1
FROM inserted




GO


