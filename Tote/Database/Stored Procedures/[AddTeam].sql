GO


CREATE PROC [dbo].[AddTeam]
@Name nvarchar(50),
@CountryId int,
@SportId int
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM Team WHERE Team.Name=@Name AND Team.SportId=@SportId AND Team.CountryId=@CountryId)
	INSERT INTO Team VALUES(@Name,@CountryId,@SportId,'False')



GO


