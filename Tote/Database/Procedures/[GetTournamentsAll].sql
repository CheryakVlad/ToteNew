USE [Tote]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentsAll]    Script Date: 11/30/2017 16:31:01 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTournamentsAll]
AS
SELECT *
FROM Tournament 
RETURN
