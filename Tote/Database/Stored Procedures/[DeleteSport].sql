

CREATE PROC [dbo].[DeleteSport]
@SportId int
AS

DELETE Sport
WHERE SportId=@SportId

