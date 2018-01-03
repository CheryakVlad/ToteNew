USE [master]
GO
/****** Object:  Database [Tote12]    Script Date: 01/03/2018 15:45:36 ******/
CREATE DATABASE [Tote12] ON  PRIMARY 
( NAME = N'Tote12', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPR\MSSQL\DATA\Tote12.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Tote12_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPR\MSSQL\DATA\Tote12_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Tote12] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Tote12].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Tote12] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [Tote12] SET ANSI_NULLS OFF
GO
ALTER DATABASE [Tote12] SET ANSI_PADDING OFF
GO
ALTER DATABASE [Tote12] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [Tote12] SET ARITHABORT OFF
GO
ALTER DATABASE [Tote12] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [Tote12] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [Tote12] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [Tote12] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [Tote12] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [Tote12] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [Tote12] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [Tote12] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [Tote12] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [Tote12] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [Tote12] SET  DISABLE_BROKER
GO
ALTER DATABASE [Tote12] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [Tote12] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [Tote12] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [Tote12] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [Tote12] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [Tote12] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [Tote12] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [Tote12] SET  READ_WRITE
GO
ALTER DATABASE [Tote12] SET RECOVERY SIMPLE
GO
ALTER DATABASE [Tote12] SET  MULTI_USER
GO
ALTER DATABASE [Tote12] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [Tote12] SET DB_CHAINING OFF
GO
USE [Tote12]
GO
/****** Object:  User [vladDb]    Script Date: 01/03/2018 15:45:36 ******/
CREATE USER [vladDb] FOR LOGIN [vladDb] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [vlad]    Script Date: 01/03/2018 15:45:36 ******/
CREATE USER [vlad] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[TeamTournament]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamTournament](
	[TeamId] [int] NOT NULL,
	[TournamentId] [int] NOT NULL,
	[DeleteStatus] [bit] NULL,
 CONSTRAINT [PK_TeamTournament] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC,
	[TournamentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournament]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournament](
	[TournamentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[SportId] [int] NOT NULL,
	[DeleteStatus] [bit] NULL,
 CONSTRAINT [PK_Tournament] PRIMARY KEY CLUSTERED 
(
	[TournamentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sport]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sport](
	[SportId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DeleteStatus] [bit] NULL,
 CONSTRAINT [PK_Sport] PRIMARY KEY CLUSTERED 
(
	[SportId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddTournament]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddTournament]
@Name nvarchar(50),
@SportId int
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM Tournament WHERE Tournament.Name=@Name AND Tournament.SportId=@SportId)
	INSERT INTO Tournament VALUES(@Name,@SportId,'False')
GO
/****** Object:  StoredProcedure [dbo].[AddTeamTournament]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddTeamTournament]
@TeamId int,
@TournamentId int
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM TeamTournament 
WHERE TeamTournament.TeamId=@TeamId AND TeamTournament.TournamentId=@TournamentId)
	INSERT INTO TeamTournament VALUES(@TeamId,@TournamentId,'False')
GO
/****** Object:  Table [dbo].[Team]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Team](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
	[SportId] [int] NULL,
	[DeleteStatus] [bit] NULL,
 CONSTRAINT [PK_Team] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddTeam]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddTeam]
@Name nvarchar(50),
@CountryId int,
@SportId int
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM Team WHERE Team.Name=@Name AND Team.SportId=@SportId AND Team.CountryId=@CountryId)
	INSERT INTO Team VALUES(@Name,@CountryId,@SportId,'False')
GO
/****** Object:  StoredProcedure [dbo].[AddSport]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddSport]
@Name nvarchar(50)
AS

IF NOT EXISTS(SELECT TOP(1)1 FROM Sport WHERE Sport.Name=@Name)
	INSERT INTO Sport VALUES(@Name,'False')
GO
/****** Object:  Table [dbo].[EventMatch]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventMatch](
	[EventId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
	[Coefficient] [float] NOT NULL,
 CONSTRAINT [PK_EventMatch] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[MatchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddEventMatch]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddEventMatch]
@MatchId int,
@Win float,
@Loss float,
@Draw float
AS
INSERT INTO EventMatch VALUES(1,@MatchId,@Win)
INSERT INTO EventMatch VALUES(2,@MatchId,@Loss)
INSERT INTO EventMatch VALUES(3,@MatchId,@Draw)
GO
/****** Object:  Table [dbo].[Bet]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bet](
	[BetId] [int] IDENTITY(1,1) NOT NULL,
	[MatchId] [int] NOT NULL,
	[Status] [bit] NULL,
	[EventId] [int] NULL,
 CONSTRAINT [PK_Bet] PRIMARY KEY CLUSTERED 
(
	[BetId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetBetById]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBetById]
@BetId int
AS
SELECT Bet.BetId, Bet.MatchId, Bet.Status, Bet.EventId
FROM Bet 
WHERE Bet.BetId=@BetId 
RETURN
GO
/****** Object:  Table [dbo].[Basket]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Basket](
	[BasketId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[MatchId] [int] NOT NULL,
	[EventId] [int] NOT NULL,
 CONSTRAINT [PK_Basket] PRIMARY KEY CLUSTERED 
(
	[BasketId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[UpdateBasket]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateBasket]
@BasketId int,
@UserId int,
@MatchId int,
@EventId int
AS
UPDATE Basket
SET UserId=@UserId,MatchId=@MatchId, EventId=@EventId
WHERE BasketId=@BasketId
GO
/****** Object:  StoredProcedure [dbo].[GetBasketByUser]    Script Date: 01/03/2018 15:45:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBasketByUser]
@UserId int
AS

SELECT Basket.*
FROM Basket 
WHERE Basket.UserId=@UserId

RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetBasketById]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBasketById]
@BasketId int,
@UserId int
AS

SELECT Basket.*
FROM Basket 
WHERE Basket.UserId=@UserId AND Basket.BasketId=@BasketId

RETURN
GO
/****** Object:  Table [dbo].[BetRate]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BetRate](
	[BetId] [int] NOT NULL,
	[RateId] [int] NOT NULL,
 CONSTRAINT [PK_BetRate] PRIMARY KEY CLUSTERED 
(
	[BetId] ASC,
	[RateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddBet]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddBet]
@RateId int,
@MatchId int,
@EventId int,
@BasketId int
AS
BEGIN TRANSACTION
INSERT INTO Bet (MatchId,Status,EventId)
SELECT @MatchId, 'False', @EventId

DECLARE @BetId int
SELECT @BetId = scope_identity();

INSERT INTO BetRate VALUES(@BetId,@RateId)

DELETE Basket
WHERE BasketId=@BasketId

COMMIT
GO
/****** Object:  StoredProcedure [dbo].[AddBasket]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddBasket]
@UserId int,
@MatchId int,
@EventId int
AS

INSERT INTO Basket VALUES(@UserId,@MatchId,@EventId)
GO
/****** Object:  Table [dbo].[TeamMatch]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamMatch](
	[MatchId] [int] NOT NULL,
	[TeamId] [int] NOT NULL,
	[Home] [bit] NOT NULL,
 CONSTRAINT [PK_TeamMatch] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC,
	[TeamId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeam]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteTeam]
@TeamId int
AS

IF (SELECT TOP(1)1 
FROM TeamTournament,TeamMatch
WHERE TeamTournament.TeamId=@TeamId
OR TeamMatch.TeamId=@TeamId)=1
BEGIN 
	UPDATE Team 
	SET DeleteStatus='True'
	WHERE TeamId=@TeamId
END 
ELSE
BEGIN
	DELETE Team
	WHERE TeamId=@TeamId	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSport]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteSport]
@SportId int
AS

IF (SELECT TOP(1)1 
FROM Tournament, Team
WHERE Tournament.SportId=@SportId 
OR Team.SportId=@SportId)=1
BEGIN 
	UPDATE Sport 
	SET DeleteStatus='True'
	WHERE SportId=@SportId
END 
ELSE
BEGIN
	DELETE Sport
	WHERE SportId=@SportId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteEventMatch]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteEventMatch]
@MatchId int
AS
DELETE EventMatch
WHERE MatchId=@MatchId
GO
/****** Object:  StoredProcedure [dbo].[DeleteBasket]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteBasket]
@BasketId int
AS
DELETE Basket 
WHERE BasketId=@BasketId
GO
/****** Object:  Table [dbo].[Match]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Match](
	[MatchId] [int] IDENTITY(1,1) NOT NULL,
	[DateMatch] [datetime] NOT NULL,
	[ResultId] [int] NOT NULL,
	[TournamentId] [int] NOT NULL,
	[Score] [nvarchar](50) NULL,
	[DeleteStatus] [bit] NULL,
 CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetBetByRateID]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBetByRateID]
@RateId int
AS
SELECT Bet.BetId, Bet.MatchId, Bet.Status, Bet.EventId, Sport.Name, Tournament.Name
FROM Bet 
INNER JOIN BetRate ON Bet.BetId=BetRate.BetId
INNER JOIN Match ON Match.MatchId=Bet.MatchId
INNER JOIN Tournament ON Tournament.TournamentId=Match.TournamentId
INNER JOIN Sport ON Sport.SportId=Tournament.SportId
WHERE BetRate.RateId=@RateId 
RETURN
GO
/****** Object:  StoredProcedure [dbo].[DeleteTournament]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteTournament]
@TournamentId int
AS

IF (SELECT TOP(1)1 
FROM TeamTournament, Match
WHERE TeamTournament.TournamentId=@TournamentId 
OR Match.TournamentId=@TournamentId)=1
BEGIN 
	UPDATE Tournament 
	SET DeleteStatus='True'
	WHERE TournamentId=@TournamentId
END
ELSE
BEGIN 
	DELETE Tournament
	WHERE TournamentId=@TournamentId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeamTournament]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteTeamTournament]
@TeamId int,
@TournamentId int
AS
IF (SELECT TOP(1)1 
FROM Match
INNER JOIN Tournament ON Tournament.TournamentId=Match.TournamentId
INNER JOIN TeamMatch ON TeamMatch.MatchId=Match.MatchId
INNER JOIN Team ON TeamMatch.TeamId=Team.TeamId
WHERE Match.DeleteStatus='False' AND Tournament.DeleteStatus='False'
AND Team.DeleteStatus='False' AND Team.TeamId=@TeamId
AND Tournament.TournamentId=@TournamentId)=1
BEGIN
	UPDATE TeamTournament 
	SET DeleteStatus='True'
	WHERE TournamentId=@TournamentId AND TeamId=@TeamId
END
ELSE
BEGIN
	DELETE TeamTournament
	WHERE TournamentId=@TournamentId AND TeamId=@TeamId
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteMatch]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteMatch]
@MatchId int
AS

IF (SELECT TOP(1)1 
FROM Bet
WHERE Bet.MatchId=@MatchId)=1
BEGIN 
	UPDATE Match 
	SET DeleteStatus='True'
	WHERE MatchId=@MatchId
END 
ELSE
BEGIN
	DELETE TeamMatch 
	WHERE MatchId=@MatchId
	
	DELETE EventMatch 
	WHERE MatchId=@MatchId
	
	DELETE Basket 
	WHERE MatchId=@MatchId

	DELETE Match
	WHERE MatchId=@MatchId
END
GO
/****** Object:  StoredProcedure [dbo].[AddMatch]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddMatch]
@DateMatch datetime,
@ResultId int,
@TournamentId int,
@Score nvarchar(50),
@TeamHomeId int,
@TeamGuestId int
AS

IF NOT EXISTS(SELECT TOP(1)1 
FROM Match
INNER JOIN TeamMatch AS TeamMatchHome ON TeamMatchHome.MatchId=Match.MatchId 
INNER JOIN TeamMatch AS TeamMatchGuest ON TeamMatchGuest.MatchId=Match.MatchId
WHERE Match.DateMatch BETWEEN DATEADD(hour, -1, @DateMatch) AND DATEADD(hour, 1, @DateMatch)
--AND Match.TournamentId=@TournamentId 
AND (TeamMatchHome.TeamId=@TeamHomeId
OR TeamMatchGuest.TeamId=@TeamGuestId))
BEGIN 
	IF @Score='0' set @Score=''
	BEGIN
		INSERT INTO Match VALUES(@DateMatch,@ResultId,@TournamentId,@Score,'False')
		DECLARE @MatchId int
		
		SELECT @MatchId=MAX(Match.MatchId)
		FROM Match
		
		INSERT INTO TeamMatch VALUES(@MatchId,@TeamHomeId,'True')
		INSERT INTO TeamMatch VALUES(@MatchId,@TeamGuestId,'False')
	END

END
GO
/****** Object:  Table [dbo].[Country]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[DeleteStatus] [bit] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  UserDefinedFunction [dbo].[GetMatchesBySport]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetMatchesBySport](@SportId int)
RETURNS TABLE
AS
RETURN
(SELECT Match.MatchId,TeamHome.Name AS TeamHomeName, TeamGuest.Name AS TeamGuestName,
DateMatch, CountryHome.Name AS CountryHomeName, CountryGuest.Name AS CountryGuestName,
Match.ResultId, Match.Score, Tournament.Name AS Tournament

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
WHERE (TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False' AND @SportId<=0 AND Sport.DeleteStatus='False')
OR (TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False' AND @SportId>0 AND Sport.SportId=@SportId AND Sport.DeleteStatus='False')
)
GO
/****** Object:  UserDefinedFunction [dbo].[GetMatchesBySportDate]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetMatchesBySportDate](@SportId int, @DateMatch nvarchar(50))
RETURNS TABLE
AS
RETURN
(SELECT * 
FROM dbo.GetMatchesBySport(@SportId)
WHERE (@DateMatch!='' AND CAST(DateMatch AS DATE)=CAST(CONVERT(datetime,@DateMatch) AS DATE)) OR (@DateMatch='')
)
GO
/****** Object:  UserDefinedFunction [dbo].[GetMatchesBySportDateStatus]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetMatchesBySportDateStatus](@SportId int, @DateMatch nvarchar(50),@Status int)
RETURNS TABLE
AS
RETURN
(SELECT * 
FROM dbo.GetMatchesBySportDate(@SportId,@DateMatch)
WHERE (@Status=0) OR (@Status=1 AND DateMatch<GETDATE() AND Score!='')
OR (@Status=2 AND DateMatch<GETDATE() AND Score='')
OR(@Status=3 AND DateMatch>GETDATE() AND Score='')
)
GO
/****** Object:  StoredProcedure [dbo].[GetMatchesBySportDateStatusSP]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetMatchesBySportDateStatusSP]
@SportId int,
@DateMatch nvarchar(50),
@Status int
AS
SELECT * FROM dbo.GetMatchesBySportDateStatus(@SportId,@DateMatch,@Status);
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentsByTeamId]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTournamentsByTeamId]
@TeamId int
AS
SELECT Tournament.TournamentId, Tournament.Name, Tournament.SportId, Sport.Name
FROM Tournament 
INNER JOIN Sport ON Tournament.SportId=Sport.SportId
INNER JOIN TeamTournament ON TeamTournament.TournamentId=Tournament.TournamentId
INNER JOIN Team ON Team.TeamId=TeamTournament.TeamId
WHERE Team.TeamId=@TeamId AND Sport.DeleteStatus='False'
AND Tournament.DeleteStatus='False' AND Team.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentsBySportId]    Script Date: 01/03/2018 15:45:38 ******/
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
AND Tournament.DeleteStatus='False'
RETURN
GO
/****** Object:  UserDefinedFunction [dbo].[GetTournamentsBySport]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetTournamentsBySport](@SportId int)
RETURNS TABLE
AS
RETURN
(
SELECT * 
FROM Tournament
WHERE Tournament.SportId=@SportId
)
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentsAll]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTournamentsAll]
AS
SELECT Tournament.TournamentId, Tournament.Name, Tournament.SportId, Sport.Name
FROM Tournament INNER JOIN Sport ON Tournament.SportId=Sport.SportId
WHERE Tournament.DeleteStatus='False' AND Sport.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetTournamentById]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTournamentById]
@TournamentId int
AS
SELECT Tournament.TournamentId, Tournament.Name, Tournament.SportId, Sport.Name
FROM Tournament INNER JOIN Sport ON Tournament.SportId=Sport.SportId
WHERE TournamentId=@TournamentId AND Tournament.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetSportsAll]    Script Date: 01/03/2018 15:45:38 ******/
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
/****** Object:  StoredProcedure [dbo].[GetSportById]    Script Date: 01/03/2018 15:45:38 ******/
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
/****** Object:  StoredProcedure [dbo].[UpdateTournament]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateTournament]
@TournamentId int,
@Name nvarchar(50),
@SportId int
AS
IF (SELECT TOP(1)1 FROM Tournament WHERE Tournament.Name=@Name AND Tournament.SportId=@SportId)=0
BEGIN
	UPDATE Tournament
	SET Name=@Name,SportId=@SportId
	WHERE TournamentId=@TournamentId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTeam]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateTeam]
@TeamId int,
@Name nvarchar(50),
@CountryId int,
@SportId int
AS

IF (SELECT TOP(1)1 FROM Team WHERE Team.Name=@Name AND Team.SportId=@SportId)=0
BEGIN
UPDATE Team
SET Name=@Name,SportId=@SportId, CountryId=@CountryId
WHERE TeamId=@TeamId

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSport]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateSport]
@SportId int,
@Name nvarchar(50)
AS
IF (SELECT TOP(1)1 FROM Sport WHERE Sport.Name=@Name)=0
BEGIN
	UPDATE Sport
	SET Name=@Name
	WHERE SportId=@SportId
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateMatch]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateMatch]
@MatchId int,
@DateMatch datetime,
@ResultId int,
@TournamentId int,
@Score nvarchar(50),
@TeamHomeId int,
@TeamGuestId int
AS

IF NOT EXISTS (SELECT TOP(1)1
FROM Bet
INNER JOIN Match ON Match.MatchId=Bet.MatchId
WHERE Match.MatchId=@MatchId)
BEGIN 

	IF NOT EXISTS(SELECT TOP(1)1 
	FROM Match
	INNER JOIN TeamMatch AS TeamMatchHome ON TeamMatchHome.MatchId=Match.MatchId 
	INNER JOIN TeamMatch AS TeamMatchGuest ON TeamMatchGuest.MatchId=Match.MatchId
	WHERE Match.DateMatch BETWEEN DATEADD(hour, -1, @DateMatch) AND DATEADD(hour, 1, @DateMatch) 
	AND (TeamMatchHome.TeamId=@TeamHomeId
	OR TeamMatchGuest.TeamId=@TeamGuestId)
	AND Match.MatchId!=@MatchId)

	BEGIN
		UPDATE Match
		SET DateMatch=@DateMatch,ResultId=@ResultId, TournamentId=@TournamentId,Score=@Score
		WHERE MatchId=@MatchId
	
		UPDATE TeamMatch
		SET TeamId=@TeamHomeId
		WHERE MatchId=@MatchId AND Home='True'
	
		UPDATE TeamMatch
		SET TeamId=@TeamGuestId
		WHERE MatchId=@MatchId AND Home='False'
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateEventMatch]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateEventMatch]
@MatchId int,
@Win float,
@Loss float,
@Draw float
AS
UPDATE EventMatch
SET Coefficient=@Win
WHERE EventId=1 AND MatchId=@MatchId

UPDATE EventMatch
SET Coefficient=@Loss
WHERE EventId=2 AND MatchId=@MatchId

UPDATE EventMatch
SET Coefficient=@Draw
WHERE EventId=3 AND MatchId=@MatchId
GO
/****** Object:  Table [dbo].[User_]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[Money] [money] NOT NULL,
	[FIO] [nvarchar](70) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
	[DeleteStatus] [bit] NULL,
 CONSTRAINT [PK_User_] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Result]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Result](
	[ResultId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](5) NOT NULL,
 CONSTRAINT [PK_Result] PRIMARY KEY CLUSTERED 
(
	[ResultId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetTeamsAll]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTeamsAll]

AS

SELECT Team.TeamId, Team.Name, Team.SportId,Sport.Name, Team.CountryId, Country.Name

FROM Team 
INNER JOIN Country ON Country.CountryId=Team.CountryId
INNER JOIN Sport ON Team.SportId=Sport.SportId
WHERE Team.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetTeamByTournament]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTeamByTournament]
@TournamentId int
AS
SELECT Team.TeamId, Team.Name, Team.SportId,Sport.Name, Team.CountryId, Country.Name

FROM Team 
INNER JOIN Country ON Country.CountryId=Team.CountryId
INNER JOIN Sport ON Team.SportId=Sport.SportId
INNER JOIN TeamTournament ON TeamTournament.TeamId=Team.TeamId
INNER JOIN Tournament ON Tournament.TournamentId=TeamTournament.TournamentId
WHERE Tournament.TournamentId=@TournamentId AND Team.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetTeamById]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetTeamById]
@TeamId int
AS
SELECT Team.TeamId, Team.Name, Team.SportId,Sport.Name, Team.CountryId, Country.Name

FROM Team 
INNER JOIN Country ON Country.CountryId=Team.CountryId
INNER JOIN Sport ON Team.SportId=Sport.SportId
WHERE TeamId=@TeamId AND Team.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetMatchesAll]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMatchesAll]

AS

SELECT Match.MatchId,TeamHome.TeamId, TeamHome.Name, 
TeamGuest.TeamId,TeamGuest.Name,DateMatch,
CountryHome.CountryId, CountryHome.Name,CountryGuest.CountryId, CountryGuest.Name,
Tournament.TournamentId, Tournament.Name, Match.Score,
Match.ResultId, Result.Name, Sport.SportId, Sport.Name

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
INNER JOIN Result ON Match.ResultId=Result.ResultId
WHERE TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False'
AND Match.DeleteStatus='False'
RETURN
GO
/****** Object:  UserDefinedFunction [dbo].[GetMatches]    Script Date: 01/03/2018 15:45:38 ******/
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
/****** Object:  StoredProcedure [dbo].[GetMatchById]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMatchById]
@MatchId int
AS

SELECT Match.MatchId,TeamHome.TeamId, TeamHome.Name, 
TeamGuest.TeamId,TeamGuest.Name,DateMatch,
CountryHome.CountryId, CountryHome.Name,CountryGuest.CountryId, CountryGuest.Name,
Tournament.TournamentId, Tournament.Name, Match.Score,
Match.ResultId, Result.Name, Sport.SportId, Sport.Name

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
INNER JOIN Result ON Match.ResultId=Result.ResultId
WHERE TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False' AND Match.MatchId=@MatchId
AND Match.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetCountryByTeam]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCountryByTeam]
@TeamId int
AS
SELECT Country.CountryId, Country.Name
FROM Country 
INNER JOIN Team ON Country.CountryId=Team.CountryId
WHERE Team.TeamId=@TeamId AND Country.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetBetsBySportTournament]    Script Date: 01/03/2018 15:45:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBetsBySportTournament]
@SportId int,
@TournamentId int
AS
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
WHERE TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False' AND Sport.SportId=@SportId AND Tournament.TournamentId=@TournamentId
AND Match.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetBetsBySportDateTime]    Script Date: 01/03/2018 15:45:38 ******/
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
AND Match.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetBetsBySport]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBetsBySport]
@SportId int
AS
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
AND Match.DeleteStatus='False'

RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetBetsAll]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBetsAll]

AS

SELECT Match.MatchId, TeamHome.Name, TeamGuest.Name,DateMatch, CountryHome.Name, CountryGuest.Name

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
WHERE TeamMatchHome.Home='True' AND TeamMatchGuest.Home='False'
AND Match.DeleteStatus='False' 
RETURN
GO
/****** Object:  StoredProcedure [dbo].[DeleteCountry]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteCountry]
@CountryId int
AS

IF (SELECT TOP(1)1 
FROM Team
WHERE Team.CountryId=@CountryId)=1
BEGIN 
	UPDATE Country 
	SET DeleteStatus='True'
	WHERE CountryId=@CountryId
END
ELSE
BEGIN 
	DELETE Country
	WHERE Country.CountryId=@CountryId
END

/*UPDATE Country 
SET DeleteStatus='True'
WHERE CountryId=@CountryId*/

/*
DELETE Country
WHERE CountryId=@CountryId
*/
GO
/****** Object:  Table [dbo].[Event]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event](
	[EventId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetCoefficients]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCoefficients]
AS
SELECT Event.EventId, Name, Coefficient, Match.MatchId
FROM EventMatch
INNER JOIN Event ON EventMatch.EventId=Event.EventId
INNER JOIN Match ON Match.MatchId=EventMatch.MatchId
GO
/****** Object:  StoredProcedure [dbo].[GetCoefficientByMatch]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCoefficientByMatch]
@MatchId int
AS
SELECT Event.EventId, Name,EventMatch.Coefficient, EventMatch.MatchId
FROM dbo.EventMatch
INNER JOIN Event ON EventMatch.EventId=Event.EventId
WHERE EventMatch.MatchId=@MatchId
GO
/****** Object:  StoredProcedure [dbo].[ExistUser]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExistUser]
@Login nvarchar(50),
@Password nvarchar(50)
AS
DECLARE @Count int

SET @Count=(SELECT COUNT(*) 
FROM User_
WHERE User_.Login=@Login 
AND User_.Password=@Password
AND User_.DeleteStatus='False')

DECLARE @Result bit

IF @Count>0
	SET @Result='True'
ELSE 
	SET @Result='False'
RETURN @Result;
GO
/****** Object:  StoredProcedure [dbo].[AddCountry]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddCountry]
@Name nvarchar(50)
AS
IF NOT EXISTS(SELECT TOP(1)1 FROM Country WHERE Country.Name=@Name)
	INSERT INTO Country VALUES(@Name, 'False')
GO
/****** Object:  Table [dbo].[RoleUser]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleUser](
	[RoleId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_RoleUser] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC,
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetRoles]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetRoles]
AS
SELECT *
FROM Role
GO
/****** Object:  StoredProcedure [dbo].[GetResultsAll]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetResultsAll]

AS

SELECT Result.ResultId, Result.Name

FROM Result 

RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetCountryById]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCountryById]
@CountryId int
AS
SELECT Country.CountryId, Country.Name
FROM Country 
WHERE Country.CountryId=@CountryId AND Country.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetCountriesAll]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCountriesAll]

AS

SELECT Country.CountryId, Country.Name
FROM Country 
WHERE Country.DeleteStatus='False'
RETURN
GO
/****** Object:  Table [dbo].[Rate]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rate](
	[RateId] [int] IDENTITY(1,1) NOT NULL,
	[DateRate] [datetime] NOT NULL,
	[RateAmount] [money] NOT NULL,
	[UserId] [int] NOT NULL,
	[StatusWin] [bit] NULL,
 CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED 
(
	[RateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetRateByUserId]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRateByUserId]
@UserId int
AS

CREATE TABLE #Rates1 (RateId int, CountBet int, Status bit)
INSERT INTO #Rates1 (RateId, CountBet, Status)
SELECT Rate.RateId, COUNT(Bet.BetId),'False'
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
LEFT JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN User_ ON User_.UserId=Rate.UserId
WHERE User_.UserId=@UserId
GROUP BY Rate.RateId


CREATE TABLE #Rates2 (RateId int, CountTrue int)
INSERT INTO #Rates2 (RateId, CountTrue)
SELECT Rate.RateId, COUNT(Bet.BetId)
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
LEFT JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN User_ ON User_.UserId=Rate.UserId
WHERE Bet.Status='True' AND User_.UserId=@UserId
GROUP BY Rate.RateId

UPDATE #Rates1
SET Status='True'
FROM #Rates1
INNER JOIN #Rates2 ON #Rates1.RateId=#Rates2.RateId
WHERE #Rates1.CountBet=#Rates2.CountTrue
/*
CREATE TABLE #Rates3 (RateId int, Status bit)
INSERT INTO #Rates3 (RateId, Status)
SELECT #Rates2.RateId, 'True'
FROM #Rates2
INNER JOIN #Rates1 ON #Rates2.RateId=#Rates1.RateId
WHERE #Rates2.CountTrue=#Rates1.CountBet 

INSERT INTO #Rates3 (RateId, Status)
SELECT #Rates2.RateId, 'False'
FROM #Rates2
INNER JOIN #Rates1 ON #Rates2.RateId=#Rates1.RateId
WHERE #Rates2.CountTrue!=#Rates1.CountBet */

SELECT Rate.RateId, Rate.DateRate, Rate.RateAmount, Rate.UserId, #Rates1.Status
FROM Rate 
INNER JOIN #Rates1 ON #Rates1.RateId=Rate.RateId
WHERE Rate.UserId=@UserId

/*SELECT Rate.RateId, Rate.DateRate, Rate.RateAmount, Rate.UserId, #Rates3.Status
FROM Rate 
INNER JOIN #Rates3 ON #Rates3.RateId=Rate.RateId
WHERE Rate.UserId=@UserId */
RETURN
GO
/****** Object:  StoredProcedure [dbo].[UpdateCountry]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateCountry]
@CountryId int,
@Name nvarchar(50)
AS
IF (SELECT TOP(1)1 FROM Country WHERE Country.Name=@Name)=0
BEGIN
	UPDATE Country
	SET Name=@Name
	WHERE CountryId=@CountryId
END
GO
/****** Object:  StoredProcedure [dbo].[GetRateById]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRateById]
@RateId int
AS
SELECT Rate.RateId, Rate.DateRate, Rate.RateAmount, Rate.UserId
FROM Rate 
WHERE Rate.RateId=@RateId 
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetRateAll]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetRateAll]

AS
SELECT Rate.RateId, Rate.DateRate, Rate.RateAmount, Rate.UserId
FROM Rate 

RETURN
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[UpdateUser]
@UserId int,
@Login nvarchar(50),
@Password nvarchar(50),
@Email nvarchar(50),
@Money money,
@FIO nvarchar(50),
@RoleId int,
@PhoneNumber varchar(50)
AS
IF (SELECT TOP(1)1 
FROM User_ 
WHERE User_.UserId=@UserId 
AND User_.Login=@Login)=1
BEGIN
	UPDATE User_
	SET Password=@Password, Email=@Email, Money=@Money, FIO=@FIO, PhoneNumber=@PhoneNumber
	WHERE User_.UserId=@UserId
	IF (SELECT TOP(1)1 FROM RoleUser WHERE UserId=@UserId AND RoleId=@RoleId)=0
		BEGIN
			UPDATE RoleUser
			SET RoleId=@RoleId
			WHERE RoleUser.UserId=@UserId
		END
END
ELSE 
BEGIN
	IF (SELECT TOP(1)1 
	FROM User_ 
	WHERE User_.Login=@Login)=0
	BEGIN
		UPDATE User_
		SET User_.Login=@Login, Password=@Password, Email=@Email, Money=@Money, FIO=@FIO, PhoneNumber=@PhoneNumber
		WHERE User_.UserId=@UserId	
		IF (SELECT TOP(1)1 FROM RoleUser WHERE UserId=@UserId AND RoleId=@RoleId)=0
		BEGIN
			UPDATE RoleUser
			SET RoleId=@RoleId
			WHERE RoleUser.UserId=@UserId
		END	
	END
END
GO
/****** Object:  StoredProcedure [dbo].[GetUsersAll]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetUsersAll]
AS
SELECT  User_.*, Role.Name AS RoleName, Role.RoleId
FROM User_
INNER JOIN RoleUser ON User_.UserId=RoleUser.UserId
INNER JOIN Role ON RoleUser.RoleId=Role.RoleId
WHERE User_.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetUserByLoginPassword]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByLoginPassword]
@Login nvarchar(50),
@Password nvarchar(50)
AS
SELECT  User_.*, Role.Name AS RoleName, Role.RoleId
FROM User_
INNER JOIN RoleUser ON User_.UserId=RoleUser.UserId
INNER JOIN Role ON RoleUser.RoleId=Role.RoleId
WHERE User_.Login=@Login AND User_.Password=@Password
AND User_.DeleteStatus='False'

RETURN
GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[GetUserById]
@UserId int
AS
SELECT  User_.*, Role.Name AS RoleName, Role.RoleId
FROM User_
INNER JOIN RoleUser ON User_.UserId=RoleUser.UserId
INNER JOIN Role ON RoleUser.RoleId=Role.RoleId
WHERE User_.UserId=@UserId AND User_.DeleteStatus='False'
RETURN
GO
/****** Object:  StoredProcedure [dbo].[RoleExistUser]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleExistUser]
@UserId int,
@RoleId int
AS
DECLARE @Count int
SET @Count=(SELECT COUNT(*) 
FROM User_
INNER JOIN RoleUser ON User_.UserId=RoleUser.UserId
INNER JOIN Role ON RoleUser.RoleId=Role.RoleId
WHERE Role.RoleId=@RoleId AND User_.UserId=@UserId AND User_.DeleteStatus='False')
DECLARE @Result bit
IF @Count>0
SET @Result='True'
ELSE 
SET @Result='False'
RETURN @Result;
GO
/****** Object:  StoredProcedure [dbo].[AddRate]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddRate]
@DateRate datetime,
@RateAmount money,
@UserId int

AS
BEGIN TRANSACTION
INSERT INTO Rate VALUES(@DateRate,@RateAmount,@UserId,'False')

DECLARE @RateId int
SELECT @RateId = scope_identity();
SELECT @RateId
COMMIT
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[DeleteUser]
@UserId int
AS

IF (SELECT TOP(1)1 
FROM RoleUser
WHERE RoleUser.UserId=@UserId)=1
BEGIN 
	UPDATE User_ 
	SET DeleteStatus='True'
	WHERE UserId=@UserId
END
ELSE
BEGIN 
	DELETE User_
	WHERE User_.UserId=@UserId
END



/*DELETE RoleUser
WHERE RoleUser.UserId=@UserId*/
/*DELETE User_
WHERE User_.UserId=@UserId*/
GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 01/03/2018 15:45:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[AddUser]
@Login nvarchar(50),
@Password nvarchar(50),
@Email nvarchar(50),
@Money money,
@FIO nvarchar(50),
@RoleId int, 
@PhoneNumber nvarchar(50)
AS

IF NOT EXISTS(SELECT TOP(1)1 FROM User_ WHERE User_.Login=@Login)
BEGIN
	INSERT INTO User_ VALUES(@Login,@Password,@Email,@Money,@FIO,@PhoneNumber,'False')
	DECLARE @UserId int
	SELECT @UserId=MAX(User_.UserId) FROM User_
	INSERT INTO RoleUser VALUES(@RoleId,@UserId)
END
GO
/****** Object:  ForeignKey [FK_TeamTournament_Team]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[TeamTournament]  WITH CHECK ADD  CONSTRAINT [FK_TeamTournament_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[TeamTournament] CHECK CONSTRAINT [FK_TeamTournament_Team]
GO
/****** Object:  ForeignKey [FK_TeamTournament_Tournament]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[TeamTournament]  WITH CHECK ADD  CONSTRAINT [FK_TeamTournament_Tournament] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournament] ([TournamentId])
GO
ALTER TABLE [dbo].[TeamTournament] CHECK CONSTRAINT [FK_TeamTournament_Tournament]
GO
/****** Object:  ForeignKey [FK_Tournament_Sport]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[Tournament]  WITH CHECK ADD  CONSTRAINT [FK_Tournament_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([SportId])
GO
ALTER TABLE [dbo].[Tournament] CHECK CONSTRAINT [FK_Tournament_Sport]
GO
/****** Object:  ForeignKey [FK_Team_Country1]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Country1] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Country] ([CountryId])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Country1]
GO
/****** Object:  ForeignKey [FK_Team_Sport]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Team_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([SportId])
GO
ALTER TABLE [dbo].[Team] CHECK CONSTRAINT [FK_Team_Sport]
GO
/****** Object:  ForeignKey [FK_EventMatch_Event]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[EventMatch]  WITH CHECK ADD  CONSTRAINT [FK_EventMatch_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO
ALTER TABLE [dbo].[EventMatch] CHECK CONSTRAINT [FK_EventMatch_Event]
GO
/****** Object:  ForeignKey [FK_EventMatch_Match]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[EventMatch]  WITH CHECK ADD  CONSTRAINT [FK_EventMatch_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([MatchId])
GO
ALTER TABLE [dbo].[EventMatch] CHECK CONSTRAINT [FK_EventMatch_Match]
GO
/****** Object:  ForeignKey [FK_Bet_Event]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[Bet]  WITH CHECK ADD  CONSTRAINT [FK_Bet_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO
ALTER TABLE [dbo].[Bet] CHECK CONSTRAINT [FK_Bet_Event]
GO
/****** Object:  ForeignKey [FK_Bet_Match]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[Bet]  WITH CHECK ADD  CONSTRAINT [FK_Bet_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([MatchId])
GO
ALTER TABLE [dbo].[Bet] CHECK CONSTRAINT [FK_Bet_Match]
GO
/****** Object:  ForeignKey [FK_Basket_Event]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Event]
GO
/****** Object:  ForeignKey [FK_Basket_Match]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([MatchId])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Match]
GO
/****** Object:  ForeignKey [FK_Basket_User_]    Script Date: 01/03/2018 15:45:37 ******/
ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_User_] FOREIGN KEY([UserId])
REFERENCES [dbo].[User_] ([UserId])
GO
ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_User_]
GO
/****** Object:  ForeignKey [FK_BetRate_Bet]    Script Date: 01/03/2018 15:45:38 ******/
ALTER TABLE [dbo].[BetRate]  WITH CHECK ADD  CONSTRAINT [FK_BetRate_Bet] FOREIGN KEY([BetId])
REFERENCES [dbo].[Bet] ([BetId])
GO
ALTER TABLE [dbo].[BetRate] CHECK CONSTRAINT [FK_BetRate_Bet]
GO
/****** Object:  ForeignKey [FK_BetRate_Rate]    Script Date: 01/03/2018 15:45:38 ******/
ALTER TABLE [dbo].[BetRate]  WITH CHECK ADD  CONSTRAINT [FK_BetRate_Rate] FOREIGN KEY([RateId])
REFERENCES [dbo].[Rate] ([RateId])
GO
ALTER TABLE [dbo].[BetRate] CHECK CONSTRAINT [FK_BetRate_Rate]
GO
/****** Object:  ForeignKey [FK_TeamMatch_Match]    Script Date: 01/03/2018 15:45:38 ******/
ALTER TABLE [dbo].[TeamMatch]  WITH CHECK ADD  CONSTRAINT [FK_TeamMatch_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([MatchId])
GO
ALTER TABLE [dbo].[TeamMatch] CHECK CONSTRAINT [FK_TeamMatch_Match]
GO
/****** Object:  ForeignKey [FK_TeamMatch_Team]    Script Date: 01/03/2018 15:45:38 ******/
ALTER TABLE [dbo].[TeamMatch]  WITH CHECK ADD  CONSTRAINT [FK_TeamMatch_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO
ALTER TABLE [dbo].[TeamMatch] CHECK CONSTRAINT [FK_TeamMatch_Team]
GO
/****** Object:  ForeignKey [FK_Match_Result]    Script Date: 01/03/2018 15:45:38 ******/
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Result] FOREIGN KEY([ResultId])
REFERENCES [dbo].[Result] ([ResultId])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Result]
GO
/****** Object:  ForeignKey [FK_Match_Tournament]    Script Date: 01/03/2018 15:45:38 ******/
ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Tournament] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournament] ([TournamentId])
GO
ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Tournament]
GO
/****** Object:  ForeignKey [FK_RoleUser_Role]    Script Date: 01/03/2018 15:45:39 ******/
ALTER TABLE [dbo].[RoleUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleUser_Role] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Role] ([RoleId])
GO
ALTER TABLE [dbo].[RoleUser] CHECK CONSTRAINT [FK_RoleUser_Role]
GO
/****** Object:  ForeignKey [FK_RoleUser_User_]    Script Date: 01/03/2018 15:45:39 ******/
ALTER TABLE [dbo].[RoleUser]  WITH CHECK ADD  CONSTRAINT [FK_RoleUser_User_] FOREIGN KEY([UserId])
REFERENCES [dbo].[User_] ([UserId])
GO
ALTER TABLE [dbo].[RoleUser] CHECK CONSTRAINT [FK_RoleUser_User_]
GO
/****** Object:  ForeignKey [FK_Rate_User_]    Script Date: 01/03/2018 15:45:39 ******/
ALTER TABLE [dbo].[Rate]  WITH CHECK ADD  CONSTRAINT [FK_Rate_User_] FOREIGN KEY([UserId])
REFERENCES [dbo].[User_] ([UserId])
GO
ALTER TABLE [dbo].[Rate] CHECK CONSTRAINT [FK_Rate_User_]
GO

insert into Country values('Italy','False');
insert into Country values('Belarus','False');
insert into Country values('Russia','False');
insert into Country values('Germany','False');
insert into Country values('Latvia','False');
insert into Country values('Spain','False');

insert into Sport values('Football','False');
insert into Sport values('Hockey','False');
insert into Sport values('Basketball','False');

insert into Tournament values('Seria A',1,'False');
insert into Tournament values('Bundesliga',1,'False');
insert into Tournament values('Spain Championship',1,'False');
insert into Tournament values('Euroliga',3,'False');
insert into Tournament values('KHL',2,'False');
insert into Tournament values('Champions League',1,'False');

insert into Team values('AC Milan',1,1,'False');
insert into Team values('Juventus',1,1,'False');
insert into Team values('Napoli',1,1,'False');
insert into Team values('Dinamo Minsk',2,2,'False');
insert into Team values('AK Bars',3,2,'False');
insert into Team values('Dinamo Riga',5,2,'False');
insert into Team values('CSKA Moscow',3,3,'False');
insert into Team values('Khimki',3,3,'False');
insert into Team values('Bayern Munich',4,1,'False');
insert into Team values('FC Real Madrid',6,1,'False');

insert into TeamTournament values(1,1,'False');
insert into TeamTournament values(2,1,'False');
insert into TeamTournament values(3,1,'False');
insert into TeamTournament values(4,5,'False');
insert into TeamTournament values(5,5,'False');
insert into TeamTournament values(6,5,'False');
insert into TeamTournament values(7,4,'False');
insert into TeamTournament values(8,4,'False');
insert into TeamTournament values(9,6,'False');
insert into TeamTournament values(10,6,'False');

insert into Result values('Win');
insert into Result values('Loss');
insert into Result values('Draw');

insert into Match values(CONVERT(datetime,'2017-26-10 21:45:00.000'),1,1,'0:2','False');
insert into Match values(CONVERT(datetime,'2017-30-10 19:30:00.000'),	1,	2,	'2:1',	'False');
insert into Match values(CONVERT(datetime,'2017-05-11 19:30:00.000'),	1,	1,	'3:0',	'False');
insert into Match values(CONVERT(datetime,'2017-14-11 20:45:00.000'),	2,	5,	'4:4',	'False');
insert into Match values(CONVERT(datetime,'2017-26-11 20:45:00.000'),	3,	5,	'2:3',	'False');
insert into Match values(CONVERT(datetime,'2017-01-12 21:45:00.000'),	2,	4,	'0:0',	'False');
insert into Match values(CONVERT(datetime,'2017-05-12 21:45:00.000'),	1,	6,	'0:0',	'False');
insert into Match values(CONVERT(datetime,'2017-17-12 21:45:00.000'),	3,	6,	'0:0',	'False');

insert into TeamMatch values(1,	1,	'True');
insert into TeamMatch values(1,	2,	'False');
insert into TeamMatch values(2,	2,	'False');
insert into TeamMatch values(2,	3,	'True');
insert into TeamMatch values(3,	1,	'False');
insert into TeamMatch values(3,	3,	'True');
insert into TeamMatch values(4,	4,	'True');
insert into TeamMatch values(4,	6,	'False');
insert into TeamMatch values(5,	4,	'False');
insert into TeamMatch values(5,	5,	'True');
insert into TeamMatch values(6,	7,	'True');
insert into TeamMatch values(6,	8,	'False');
insert into TeamMatch values(7,	9,	'True');
insert into TeamMatch values(7,	10,	'False');
insert into TeamMatch values(8,	9,	'False');
insert into TeamMatch values(8,	10,	'True');


insert into Event values('Win');
insert into Event values('Loss');
insert into Event values('Draw');

insert into EventMatch values(1,1,1.5);
insert into EventMatch values(1,2,1.75);
insert into EventMatch values(1,3,1.11);
insert into EventMatch values(1,4,1.25);
insert into EventMatch values(1,5,3.5);
insert into EventMatch values(1,6,2.56);
insert into EventMatch values(1,7,1.61);
insert into EventMatch values(1,8,5.16);
insert into EventMatch values(2,1,3.12);
insert into EventMatch values(2,2,2.12);
insert into EventMatch values(2,3,5.17);
insert into EventMatch values(2,4,3.87);
insert into EventMatch values(2,5,3.72);
insert into EventMatch values(2,6,7.19);
insert into EventMatch values(2,7,4.58);
insert into EventMatch values(2,8,1.84);
insert into EventMatch values(3,1,2.26);
insert into EventMatch values(3,2,3.16);
insert into EventMatch values(3,3,3.17);
insert into EventMatch values(3,4,2.26);
insert into EventMatch values(3,5,1.26);
insert into EventMatch values(3,6,2.76);
insert into EventMatch values(3,7,2.45);
insert into EventMatch values(3,8,3.32);


insert into Role values('Admin');
insert into Role values('Editor');
insert into Role values('User');


insert into User_ values('admin',	'admin',	'admin@mail.ru',	1882.6600,	'Admin',	'123456789',	'False');
insert into User_ values('editor',	'editor',	'editor@mail.ru',	150.0000,	'EditorFIO',	NULL,	'False');
insert into User_ values('user',	'user',	'user@mail.ru',	13797.6800,	'User',	'123',	'False');

insert into RoleUser values(1,1);
insert into RoleUser values(2,2);
insert into RoleUser values(3,3);

insert into Bet values(1,	'True',	1);
insert into Bet values(1,	'True',	1);
insert into Bet values(2,	'True',	1);
insert into Bet values(2,	'False', 2);
insert into Bet values(3,	'True',	1);
insert into Bet values(4,	'False', 1);
insert into Bet values(5,	'False', 1);
insert into Bet values(6,	'False', 1);
insert into Bet values(7,	'True', 1);
insert into Bet values(8,	'False',	1);


insert into Rate values(CONVERT(datetime,'2017-25-10 21:45:00.000'),100.0000,1,'True');
insert into Rate values(CONVERT(datetime,'2017-24-10 19:30:00.000'),600.0000,3,'True');
insert into Rate values(CONVERT(datetime,'2017-28-10 20:45:00.000'),550.0000,3,'True');
insert into Rate values(CONVERT(datetime,'2017-29-10 20:45:00.000'),10.0000,1,'False');
insert into Rate values(CONVERT(datetime,'2017-03-11 20:45:00.000'),10.0000,1,'True');
insert into Rate values(CONVERT(datetime,'2017-10-11 20:45:00.000'),550.0000,3,'False');
insert into Rate values(CONVERT(datetime,'2017-23-11 20:45:00.000'),10.0000,3,'False');
insert into Rate values(CONVERT(datetime,'2017-25-11 20:45:00.000'),10.0000,1,'False');
insert into Rate values(CONVERT(datetime,'2017-23-11 20:45:00.000'),10.0000,3,'True');
insert into Rate values(CONVERT(datetime,'2017-25-11 20:45:00.000'),10.0000,1,'False');

insert into BetRate values(1,1);
insert into BetRate values(2,2);
insert into BetRate values(3,3);
insert into BetRate values(4,4);
insert into BetRate values(5,5);
insert into BetRate values(6,6);
insert into BetRate values(7,7);
insert into BetRate values(8,8);
insert into BetRate values(9,9);
insert into BetRate values(10,10);



GO



CREATE TRIGGER [dbo].[INSERT_Match] ON [dbo].[Match] 
FOR INSERT 
AS

INSERT INTO EventMatch (MatchId, EventId, Coefficient)
SELECT MatchId,1,1
FROM inserted

INSERT INTO EventMatch (MatchId, EventId, Coefficient)
SELECT MatchId,2,1
FROM inserted

INSERT INTO EventMatch (MatchId, EventId, Coefficient)
SELECT MatchId,3,1
FROM inserted




GO

GO


CREATE TRIGGER [dbo].[INSERT_Rate] ON [dbo].[Rate] 
AFTER INSERT 
AS

UPDATE User_ 
SET User_.Money=User_.Money-inserted.RateAmount
FROM User_, inserted
WHERE inserted.UserId=User_.UserId


GO



GO


CREATE TRIGGER [dbo].[UPDATE_Bet] ON [dbo].[Bet] 
AFTER UPDATE 
AS

CREATE TABLE #Rates1 (RateId int, CountBet int)
INSERT INTO #Rates1 (RateId, CountBet)
SELECT Rate.RateId, COUNT(Bet.BetId)
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
LEFT JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN inserted ON Bet.BetId=inserted.BetId
GROUP BY Rate.RateId

CREATE TABLE #RatesCountBet(RateId int, CountBet int)
INSERT INTO #RatesCountBet (RateId, CountBet)
SELECT Rate.RateId, COUNT(Bet.BetId)
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
INNER JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN #Rates1 ON Rate.RateId=#Rates1.RateId
GROUP BY Rate.RateId

CREATE TABLE #Rates2 (RateId int, CountTrue int)
INSERT INTO #Rates2 (RateId, CountTrue)
SELECT Rate.RateId, COUNT(Bet.BetId)
FROM Rate
INNER JOIN BetRate ON Rate.RateId=BetRate.RateId
INNER JOIN Bet ON BetRate.BetId=Bet.BetId
INNER JOIN #Rates1 ON Rate.RateId=#Rates1.RateId
WHERE Bet.Status='True'
GROUP BY Rate.RateId


CREATE TABLE #Rates3 (RateId int, Total money)
INSERT INTO #Rates3 (RateId, Total)
SELECT #Rates2.RateId, 1
FROM #Rates2
INNER JOIN #RatesCountBet ON #Rates2.RateId=#RatesCountBet.RateId
WHERE #Rates2.CountTrue=#RatesCountBet.CountBet 

CREATE TABLE #Rates4 (RateId int, Total money)
INSERT INTO #Rates4 (RateId, Total)
SELECT #Rates2.RateId, 1
FROM #RatesCountBet
LEFT JOIN #Rates2 ON #RatesCountBet.RateId=#Rates2.RateId
WHERE #Rates2.CountTrue!=#RatesCountBet.CountBet 

CREATE TABLE #CoefficientRates4(RateId int, Coefficient float)
INSERT INTO #CoefficientRates4 
select #Rates4.RateId, exp(SUM(log(EventMatch.Coefficient)))
FROM Bet
INNER JOIN BetRate ON Bet.BetId=BetRate.BetId
INNER JOIN #Rates4 ON BetRate.RateId=#Rates4.RateId
INNER JOIN EventMatch ON  EventMatch.MatchId=Bet.MatchId
INNER JOIN Event ON Bet.EventId=Event.EventId
INNER JOIN Event as EventBet ON EventBet.EventId=EventMatch.EventId
WHERE EventBet.Name=Event.Name
GROUP BY #Rates4.RateId

UPDATE #Rates4
SET Total=#CoefficientRates4.Coefficient
FROM #CoefficientRates4
INNER JOIN #Rates4 ON #Rates4.RateId=#CoefficientRates4.RateId

UPDATE User_ 
SET User_.Money=User_.Money-(#Rates4.Total*Rate.RateAmount)
FROM #Rates4
INNER JOIN Rate ON #Rates4.RateId=Rate.RateId
INNER JOIN User_ ON User_.UserId=Rate.UserId
WHERE Rate.StatusWin='True'

UPDATE Rate
SET Rate.StatusWin='False'
FROM Rate
INNER JOIN #Rates1 ON Rate.RateId=#Rates1.RateId
INNER JOIN #Rates2 ON #Rates1.RateId=#Rates2.RateId
WHERE #Rates2.CountTrue!=#Rates1.CountBet

UPDATE Rate
SET Rate.StatusWin='True'
FROM Rate
INNER JOIN #Rates3 ON Rate.RateId=#Rates3.RateId
WHERE #Rates3.RateId=Rate.RateId

CREATE TABLE #Coefficient(RateId int, Coefficient float)
INSERT INTO #Coefficient 
select #Rates3.RateId, exp(SUM(log(EventMatch.Coefficient)))
FROM Bet
INNER JOIN BetRate ON Bet.BetId=BetRate.BetId
INNER JOIN #Rates3 ON BetRate.RateId=#Rates3.RateId
INNER JOIN EventMatch ON  EventMatch.MatchId=Bet.MatchId
INNER JOIN Event ON Bet.EventId=Event.EventId
INNER JOIN Event as EventBet ON EventBet.EventId=EventMatch.EventId
WHERE Bet.Status='True' AND EventBet.Name=Event.Name
GROUP BY #Rates3.RateId

UPDATE #Rates3
SET Total=#Coefficient.Coefficient
FROM #Coefficient
INNER JOIN #Rates3 ON #Rates3.RateId=#Coefficient.RateId

select * from #Rates3

UPDATE User_ 
SET User_.Money=User_.Money+(#Rates3.Total*Rate.RateAmount)
FROM #Rates3
INNER JOIN Rate ON #Rates3.RateId=Rate.RateId
INNER JOIN User_ ON User_.UserId=Rate.UserId


GO

GO


CREATE TRIGGER [dbo].[UPDATE_Match] ON [dbo].[Match] 
AFTER UPDATE 
AS

UPDATE Bet 
SET Status='True'
FROM Bet
INNER JOIN inserted ON Bet.MatchId=inserted.MatchId
WHERE inserted.ResultId=Bet.EventId

UPDATE Bet 
SET Status='False'
FROM Bet
INNER JOIN inserted ON Bet.MatchId=inserted.MatchId
WHERE inserted.ResultId!=Bet.EventId AND inserted.ResultId!=4


GO







