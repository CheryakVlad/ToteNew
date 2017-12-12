

create proc [dbo].[GetMatchesBySportDateStatusSP]
@SportId int,
@DateMatch nvarchar(50),
@Status int
AS
select * from dbo.GetMatchesBySportDateStatus(@SportId,@DateMatch,@Status);


