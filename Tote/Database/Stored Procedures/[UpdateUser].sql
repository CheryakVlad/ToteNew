
GO

CREATE PROC [dbo].[UpdateUser]
@UserId int,
@Login nvarchar(50),
@Password nvarchar(50),
@Email nvarchar(50),
@Money money,
@FIO nvarchar(50),
@RoleId int,
@PhoneNumber varchar(50)
AS
IF EXISTS(SELECT TOP(1)1 
FROM User_ 
WHERE User_.UserId=@UserId 
AND User_.Login=@Login)
BEGIN
	UPDATE User_
	SET Password=@Password, Email=@Email, Money=@Money, FIO=@FIO, PhoneNumber=@PhoneNumber
	WHERE User_.UserId=@UserId
	IF (SELECT TOP(1)1 FROM RoleUser WHERE UserId=@UserId AND RoleId=@RoleId)=0
		BEGIN
			UPDATE RoleUser
			SET RoleId=@RoleId
			WHERE RoleUser.UserId=@UserId
		END
END
ELSE 
BEGIN
	IF NOT EXISTS(SELECT TOP(1)1 
	FROM User_ 
	WHERE User_.Login=@Login)
	BEGIN
		UPDATE User_
		SET User_.Login=@Login, Password=@Password, Email=@Email, Money=@Money, FIO=@FIO, PhoneNumber=@PhoneNumber
		WHERE User_.UserId=@UserId	
		IF (SELECT TOP(1)1 FROM RoleUser WHERE UserId=@UserId AND RoleId=@RoleId)=0
		BEGIN
			UPDATE RoleUser
			SET RoleId=@RoleId
			WHERE RoleUser.UserId=@UserId
		END	
	END
END



GO


