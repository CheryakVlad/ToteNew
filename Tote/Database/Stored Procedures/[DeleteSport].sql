USE [Tote]
GO

/****** Object:  StoredProcedure [dbo].[DeleteSport]    Script Date: 12/21/2017 13:41:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[DeleteSport]
@SportId int
AS

UPDATE Sport 
SET DeleteStatus='True'
WHERE SportId=@SportId

/*DELETE Sport
WHERE SportId=@SportId*/


GO


