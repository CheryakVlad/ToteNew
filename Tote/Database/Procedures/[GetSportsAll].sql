USE [Tote]
GO
/****** Object:  StoredProcedure [dbo].[GetSportsAll]    Script Date: 11/30/2017 16:28:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetSportsAll]
AS
SELECT *
FROM Sport 
RETURN