
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

ALTER TABLE [dbo].[BetRate]  WITH CHECK ADD  CONSTRAINT [FK_BetRate_Bet] FOREIGN KEY([BetId])
REFERENCES [dbo].[Bet] ([BetId])
GO

ALTER TABLE [dbo].[BetRate] CHECK CONSTRAINT [FK_BetRate_Bet]
GO

ALTER TABLE [dbo].[BetRate]  WITH CHECK ADD  CONSTRAINT [FK_BetRate_Rate] FOREIGN KEY([RateId])
REFERENCES [dbo].[Rate] ([RateId])
GO

ALTER TABLE [dbo].[BetRate] CHECK CONSTRAINT [FK_BetRate_Rate]
GO


