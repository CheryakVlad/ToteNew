CREATE PROC [dbo].[AddEventMatch]
@MatchId int,
@Win float,
@Loss float,
@Draw float
AS
INSERT INTO EventMatch VALUES(1,@MatchId,@Win)
INSERT INTO EventMatch VALUES(2,@MatchId,@Loss)
INSERT INTO EventMatch VALUES(3,@MatchId,@Draw)



