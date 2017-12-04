USE [Tote]
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentById]    Script Date: 11/30/2017 16:29:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTournamentById]
@TournamentId int
AS
SELECT *
FROM Tournament
WHERE TournamentId=@TournamentId 
RETURN