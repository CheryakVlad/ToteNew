USE [Tote]
GO

/****** Object:  StoredProcedure [dbo].[GetSportsAll]    Script Date: 12/21/2017 13:39:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetSportsAll]
AS
SELECT *
FROM Sport 
WHERE DeleteStatus='False'
RETURN
GO


