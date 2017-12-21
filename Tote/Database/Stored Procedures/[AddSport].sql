USE [Tote]
GO

/****** Object:  StoredProcedure [dbo].[AddSport]    Script Date: 12/21/2017 13:37:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[AddSport]
@Name nvarchar(50)
AS
INSERT INTO Sport VALUES(@Name,'False')



GO


