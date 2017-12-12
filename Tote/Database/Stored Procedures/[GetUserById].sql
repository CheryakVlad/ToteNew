CREATE PROC [dbo].[GetUserById]
@UserId int
AS
SELECT  User_.*, Role.Name AS RoleName, Role.RoleId
FROM User_
INNER JOIN RoleUser ON User_.UserId=RoleUser.UserId
INNER JOIN Role ON RoleUser.RoleId=Role.RoleId
WHERE User_.UserId=@UserId
RETURN



