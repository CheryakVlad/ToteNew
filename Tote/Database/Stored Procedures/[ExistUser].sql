
GO

CREATE PROCEDURE [dbo].[ExistUser]
@Login nvarchar(50),
@Password nvarchar(50)
AS
DECLARE @Count int

SET @Count=(SELECT COUNT(*) 
FROM User_
WHERE User_.Login=@Login 
AND User_.Password=@Password
AND User_.DeleteStatus='False')

DECLARE @Result bit

IF @Count>0
	SET @Result='True'
ELSE 
	SET @Result='False'
RETURN @Result;
GO


