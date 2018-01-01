
GO

CREATE PROC [dbo].[DeleteUser]
@UserId int
AS

IF (SELECT TOP(1)1 
FROM RoleUser
WHERE RoleUser.UserId=@UserId)=1
BEGIN 
	UPDATE User_ 
	SET DeleteStatus='True'
	WHERE UserId=@UserId
END
ELSE
BEGIN 
	DELETE User_
	WHERE User_.UserId=@UserId
END



/*DELETE RoleUser
WHERE RoleUser.UserId=@UserId*/
/*DELETE User_
WHERE User_.UserId=@UserId*/


GO


