CREATE PROCEDURE [dbo].[RoleExistUser]
@UserId int,
@RoleId int
AS
DECLARE @Count int
SET @Count=(SELECT COUNT(*) 
FROM User_
INNER JOIN RoleUser ON User_.UserId=RoleUser.UserId
INNER JOIN Role ON RoleUser.RoleId=Role.RoleId
WHERE Role.RoleId=@RoleId AND User_.UserId=@UserId)
DECLARE @Result bit
IF @Count>0
SET @Result='True'
ELSE 
SET @Result='False'
RETURN @Result;



