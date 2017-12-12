
CREATE PROCEDURE [dbo].[GetTeamById]
@TeamId int
AS
SELECT Team.TeamId, Team.Name, Team.SportId,Sport.Name, Team.CountryId, Country.Name

FROM Team 
INNER JOIN Country ON Country.CountryId=Team.CountryId
INNER JOIN Sport ON Team.SportId=Sport.SportId
WHERE TeamId=@TeamId 
RETURN



