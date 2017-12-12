CREATE PROC [dbo].[UpdateSport]
@SportId int,
@Name nvarchar(50)
AS
UPDATE Sport
SET Name=@Name
WHERE SportId=@SportId



