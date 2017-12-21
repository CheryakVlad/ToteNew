USE [Tote]
GO

/****** Object:  UserDefinedFunction [dbo].[GetMatches]    Script Date: 12/21/2017 13:44:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE FUNCTION [dbo].[GetMatches]()
RETURNS TABLE
AS
RETURN
(SELECT Match.MatchId,TeamHome.Name AS TeamHomeName, TeamGuest.Name AS TeamGuestName,
DateMatch, CountryHome.Name AS CountryHomeName, CountryGuest.Name AS CountryGuestName

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
WHERE TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False' AND Sport.DeleteStatus='False'
)

GO


