
GO

CREATE PROCEDURE [dbo].[GetUserByLoginPassword]
@Login nvarchar(50),
@Password nvarchar(50)
AS
SELECT  User_.*, Role.Name AS RoleName, Role.RoleId
FROM User_
INNER JOIN RoleUser ON User_.UserId=RoleUser.UserId
INNER JOIN Role ON RoleUser.RoleId=Role.RoleId
WHERE User_.Login=@Login AND User_.Password=@Password
AND User_.DeleteStatus='False'

RETURN 
GO


