
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

ALTER TABLE [dbo].[EventMatch]  WITH CHECK ADD  CONSTRAINT [FK_EventMatch_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO

ALTER TABLE [dbo].[EventMatch] CHECK CONSTRAINT [FK_EventMatch_Event]
GO

ALTER TABLE [dbo].[EventMatch]  WITH CHECK ADD  CONSTRAINT [FK_EventMatch_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([MatchId])
GO

ALTER TABLE [dbo].[EventMatch] CHECK CONSTRAINT [FK_EventMatch_Match]
GO


