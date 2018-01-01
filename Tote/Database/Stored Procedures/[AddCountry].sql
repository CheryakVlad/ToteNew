
GO


CREATE PROC [dbo].[AddCountry]
@Name nvarchar(50)
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM Country WHERE Country.Name=@Name)
	INSERT INTO Country VALUES(@Name, 'False')



GO


