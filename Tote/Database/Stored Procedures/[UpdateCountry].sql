
GO


CREATE PROC [dbo].[UpdateCountry]
@CountryId int,
@Name nvarchar(50)
AS
IF (SELECT TOP(1)1 FROM Country WHERE Country.Name=@Name)=0
BEGIN
	UPDATE Country
	SET Name=@Name
	WHERE CountryId=@CountryId
END


GO

