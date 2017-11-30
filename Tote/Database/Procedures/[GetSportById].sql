USE [Tote]
GO
/****** Object:  StoredProcedure [dbo].[GetSportById]    Script Date: 11/30/2017 16:27:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSportById]
@SportId int
AS
SELECT *
FROM Sport 
Where SportId=@SportId
RETURN