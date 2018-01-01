
GO


CREATE PROCEDURE [dbo].[GetCountriesAll]

AS

SELECT Country.CountryId, Country.Name
FROM Country 
WHERE Country.DeleteStatus='False'
RETURN
GO


