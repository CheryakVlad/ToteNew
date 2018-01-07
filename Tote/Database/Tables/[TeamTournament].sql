
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

ALTER TABLE [dbo].[TeamTournament]  WITH CHECK ADD  CONSTRAINT [FK_TeamTournament_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO

ALTER TABLE [dbo].[TeamTournament] CHECK CONSTRAINT [FK_TeamTournament_Team]
GO

ALTER TABLE [dbo].[TeamTournament]  WITH CHECK ADD  CONSTRAINT [FK_TeamTournament_Tournament] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournament] ([TournamentId])
GO

ALTER TABLE [dbo].[TeamTournament] CHECK CONSTRAINT [FK_TeamTournament_Tournament]
GO


