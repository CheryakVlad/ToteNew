USE [Tote]
GO

/****** Object:  StoredProcedure [dbo].[GetSportById]    Script Date: 12/21/2017 13:39:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetSportById]
@SportId int
AS
SELECT *
FROM Sport 
Where SportId=@SportId AND DeleteStatus='False'
RETURN
GO


