USE [Tote]
GO

/****** Object:  StoredProcedure [dbo].[UpdateSport]    Script Date: 12/21/2017 13:41:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[UpdateSport]
@SportId int,
@Name nvarchar(50)
AS
UPDATE Sport
SET Name=@Name
WHERE SportId=@SportId



GO


