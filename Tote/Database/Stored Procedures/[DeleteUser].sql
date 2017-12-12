
CREATE PROC [dbo].[DeleteUser]
@UserId int
AS
DELETE RoleUser
WHERE RoleUser.UserId=@UserId
DELETE User_
WHERE User_.UserId=@UserId


