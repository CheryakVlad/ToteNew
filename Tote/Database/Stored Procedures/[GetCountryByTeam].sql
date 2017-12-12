CREATE PROCEDURE [dbo].[GetCountryByTeam]
@TeamId int
AS
SELECT Country.CountryId, Country.Name
FROM Country 
INNER JOIN Team ON Country.CountryId=Team.CountryId
WHERE Team.TeamId=@TeamId
RETURN


