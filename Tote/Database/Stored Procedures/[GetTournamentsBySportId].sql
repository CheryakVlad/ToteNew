USE [Tote]
GO

/****** Object:  StoredProcedure [dbo].[GetTournamentsBySportId]    Script Date: 12/21/2017 13:40:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetTournamentsBySportId]
@SportId int
AS
SELECT Tournament.TournamentId, Tournament.Name, Tournament.SportId, Sport.Name
FROM Tournament INNER JOIN Sport ON Tournament.SportId=Sport.SportId
WHERE Tournament.SportId=@SportId AND Sport.DeleteStatus='False'
RETURN
GO


