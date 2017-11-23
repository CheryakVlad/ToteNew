CREATE FUNCTION GetTournamentsBySport(@SportId int)
RETURNS TABLE
AS
RETURN
(
SELECT * 
FROM Tournament
WHERE Tournament.SportId=@SportId
)