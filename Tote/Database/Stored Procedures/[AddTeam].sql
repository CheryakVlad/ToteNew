
CREATE PROC [dbo].[AddTeam]
@Name nvarchar(50),
@CountryId int,
@SportId int
AS
INSERT INTO Team VALUES(@Name,@CountryId,@SportId)


