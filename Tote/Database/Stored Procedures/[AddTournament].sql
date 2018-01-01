
GO

CREATE PROC [dbo].[AddTournament]
@Name nvarchar(50),
@SportId int
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM Tournament WHERE Tournament.Name=@Name AND Tournament.SportId=@SportId)
	INSERT INTO Tournament VALUES(@Name,@SportId,'False')



GO


