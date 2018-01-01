
GO

CREATE PROC [dbo].[UpdateSport]
@SportId int,
@Name nvarchar(50)
AS
IF (SELECT TOP(1)1 FROM Sport WHERE Sport.Name=@Name)=0
BEGIN
	UPDATE Sport
	SET Name=@Name
	WHERE SportId=@SportId
END


GO


