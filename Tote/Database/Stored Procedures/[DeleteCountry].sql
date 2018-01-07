GO


CREATE PROC [dbo].[DeleteCountry]
@CountryId int
AS

IF (SELECT TOP(1)1 
FROM Team
WHERE Team.CountryId=@CountryId)=1
BEGIN 
	UPDATE Country 
	SET DeleteStatus='True'
	WHERE CountryId=@CountryId
END
ELSE
BEGIN 
	DELETE Country
	WHERE Country.CountryId=@CountryId
END

/*UPDATE Country 
SET DeleteStatus='True'
WHERE CountryId=@CountryId*/

/*
DELETE Country
WHERE CountryId=@CountryId
*/

GO


