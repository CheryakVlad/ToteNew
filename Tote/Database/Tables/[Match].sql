

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

ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Result] FOREIGN KEY([ResultId])
REFERENCES [dbo].[Result] ([ResultId])
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Result]
GO

ALTER TABLE [dbo].[Match]  WITH CHECK ADD  CONSTRAINT [FK_Match_Tournament] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournament] ([TournamentId])
GO

ALTER TABLE [dbo].[Match] CHECK CONSTRAINT [FK_Match_Tournament]
GO


