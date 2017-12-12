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
UPDATE User_
SET Login=@Login, Password=@Password, Email=@Email, Money=@Money, FIO=@FIO, RoleId=@RoleId, PhoneNumber=@PhoneNumber
WHERE User_.UserId=@UserId

UPDATE RoleUser
SET RoleId=@RoleId
WHERE RoleUser.UserId=@UserId


