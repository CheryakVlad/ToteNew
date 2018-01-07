
GO

CREATE PROC [dbo].[AddUser]
@Login nvarchar(50),
@Password nvarchar(50),
@Email nvarchar(50),
@Money money,
@FIO nvarchar(50),
@RoleId int, 
@PhoneNumber nvarchar(50)
AS

IF NOT EXISTS(SELECT TOP(1)1 FROM User_ WHERE User_.Login=@Login)
BEGIN
	INSERT INTO User_ VALUES(@Login,@Password,@Email,@Money,@FIO,@PhoneNumber,'False')
	DECLARE @UserId int
	SELECT @UserId=MAX(User_.UserId) FROM User_
	INSERT INTO RoleUser VALUES(@RoleId,@UserId)
END

GO


