USE [Tote]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentsBySportId]    Script Date: 11/30/2017 16:32:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTournamentsBySportId]
@SportId int
AS
SELECT *
FROM Tournament
WHERE SportId=@SportId 
RETURN