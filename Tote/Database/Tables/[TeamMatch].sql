
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

ALTER TABLE [dbo].[TeamMatch]  WITH CHECK ADD  CONSTRAINT [FK_TeamMatch_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([MatchId])
GO

ALTER TABLE [dbo].[TeamMatch] CHECK CONSTRAINT [FK_TeamMatch_Match]
GO

ALTER TABLE [dbo].[TeamMatch]  WITH CHECK ADD  CONSTRAINT [FK_TeamMatch_Team] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Team] ([TeamId])
GO

ALTER TABLE [dbo].[TeamMatch] CHECK CONSTRAINT [FK_TeamMatch_Team]
GO


