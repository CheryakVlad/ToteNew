
CREATE TRIGGER [dbo].[DELETE_Sport] ON [dbo].[Sport] 
FOR DELETE 
AS
IF (SELECT COUNT(*)  
FROM Tournament,deleted  
WHERE Tournament.SportId= deleted.SportId)>0
BEGIN
 ROLLBACK TRANSACTION
END
GO


