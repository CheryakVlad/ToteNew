
GO
ALTER FUNCTION [dbo].[GetTournamentsBySport](@SportId int)
RETURNS TABLE
AS
RETURN
(
SELECT * 
FROM Tournament
WHERE Tournament.SportId=@SportId
)