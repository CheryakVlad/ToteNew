
GO


CREATE PROCEDURE [dbo].[GetCountryById]
@CountryId int
AS
SELECT Country.CountryId, Country.Name
FROM Country 
WHERE Country.CountryId=@CountryId AND Country.DeleteStatus='False'
RETURN
GO


