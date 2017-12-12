
CREATE PROC [dbo].[AddUser]
@Login nvarchar(50),
@Password nvarchar(50),
@Email nvarchar(50),
@Money money,
@FIO nvarchar(50),
@RoleId int
AS
INSERT INTO User_ VALUES(@Login,@Password,@Email,@RoleId,@Money,@FIO,'')
DECLARE @UserId int
SELECT @UserId=MAX(User_.UserId) FROM User_
INSERT INTO RoleUser VALUES(@RoleId,@UserId)



