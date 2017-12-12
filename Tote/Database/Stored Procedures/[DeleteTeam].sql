
CREATE PROC [dbo].[DeleteTeam]
@TeamId int
AS

DELETE Team
WHERE TeamId=@TeamId

