
GO


CREATE PROC [dbo].[UpdateTeam]
@TeamId int,
@Name nvarchar(50),
@CountryId int,
@SportId int
AS

IF NOT EXISTS(SELECT TOP(1)1 FROM Team WHERE Team.Name=@Name AND Team.SportId=@SportId)
BEGIN
UPDATE Team
SET Name=@Name,SportId=@SportId, CountryId=@CountryId
WHERE TeamId=@TeamId

END

GO


