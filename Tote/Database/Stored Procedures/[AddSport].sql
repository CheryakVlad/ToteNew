
GO

CREATE PROC [dbo].[AddSport]
@Name nvarchar(50)
AS

IF NOT EXISTS(SELECT TOP(1)1 FROM Sport WHERE Sport.Name=@Name)
	INSERT INTO Sport VALUES(@Name,'False')

GO


