
GO

CREATE PROC [dbo].[UpdateSport]
@SportId int,
@Name nvarchar(50)
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM Sport WHERE Sport.Name=@Name)
BEGIN
	UPDATE Sport
	SET Name=@Name
	WHERE SportId=@SportId
END


GO


