
CREATE PROC [dbo].[AddSport]
@Name nvarchar(50)
AS
INSERT INTO Sport VALUES(@Name)



