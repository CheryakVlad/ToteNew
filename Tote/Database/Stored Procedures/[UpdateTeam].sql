CREATE PROC [dbo].[UpdateTeam]
@TeamId int,
@Name nvarchar(50),
@CountryId int,
@SportId int
AS
UPDATE Team
SET Name=@Name,SportId=@SportId, CountryId=@CountryId
WHERE TeamId=@TeamId


