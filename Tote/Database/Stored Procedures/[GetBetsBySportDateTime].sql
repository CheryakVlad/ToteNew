USE [Tote]
GO

/****** Object:  StoredProcedure [dbo].[GetBetsBySportDateTime]    Script Date: 12/21/2017 13:43:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetBetsBySportDateTime]
@SportId int,
@DateMatch nvarchar(50),
@Status int
AS
DECLARE @DateTimeMatch datetime 
SET @DateTimeMatch=CONVERT(datetime,@DateMatch)
SELECT Match.MatchId,TeamHome.Name, TeamGuest.Name,DateMatch, CountryHome.Name, CountryGuest.Name

FROM Match 

INNER JOIN TeamMatch as TeamMatchHome ON TeamMatchHome.MatchId=Match.MatchId
INNER JOIN TeamMatch as TeamMatchGuest ON TeamMatchGuest.MatchId=Match.MatchId
INNER JOIN Team as TeamHome ON TeamHome.TeamId=TeamMatchHome.TeamId
INNER JOIN Team as TeamGuest ON TeamGuest.TeamId=TeamMatchGuest.TeamId
INNER JOIN Country as CountryHome ON CountryHome.CountryId=TeamHome.CountryId
INNER JOIN Country as CountryGuest ON CountryGuest.CountryId=TeamGuest.CountryId
INNER JOIN TeamTournament ON TeamHome.TeamId=TeamTournament.TeamId
INNER JOIN Tournament ON TeamTournament.TournamentId=Tournament.TournamentId
INNER JOIN Sport ON Tournament.SportId=Sport.SportId
WHERE TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False' AND Sport.SportId=@SportId 
AND CAST(Match.DateMatch AS DATE)=CAST(@DateTimeMatch AS DATE) AND Sport.DeleteStatus='False'

RETURN
GO


