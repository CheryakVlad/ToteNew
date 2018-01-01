
GO

CREATE PROC [dbo].[GetUsersAll]
AS
SELECT  User_.*, Role.Name AS RoleName, Role.RoleId
FROM User_
INNER JOIN RoleUser ON User_.UserId=RoleUser.UserId
INNER JOIN Role ON RoleUser.RoleId=Role.RoleId
WHERE User_.DeleteStatus='False'
RETURN
GO


