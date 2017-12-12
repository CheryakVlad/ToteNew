
CREATE PROC [dbo].[AddTournament]
@Name nvarchar(50),
@SportId int
AS
INSERT INTO Tournament VALUES(@Name,@SportId)



