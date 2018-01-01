
GO

CREATE PROCEDURE [dbo].[GetTournamentsAll]
AS
SELECT Tournament.TournamentId, Tournament.Name, Tournament.SportId, Sport.Name
FROM Tournament INNER JOIN Sport ON Tournament.SportId=Sport.SportId
WHERE Tournament.DeleteStatus='False' AND Sport.DeleteStatus='False'
RETURN

GO


