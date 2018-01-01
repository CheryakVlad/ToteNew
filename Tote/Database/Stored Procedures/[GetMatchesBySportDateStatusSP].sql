
GO

CREATE proc [dbo].[GetMatchesBySportDateStatusSP]
@SportId int,
@DateMatch nvarchar(50),
@Status int
AS
SELECT * FROM dbo.GetMatchesBySportDateStatus(@SportId,@DateMatch,@Status);
GO


