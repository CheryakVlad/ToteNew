
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

ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Event] FOREIGN KEY([EventId])
REFERENCES [dbo].[Event] ([EventId])
GO

ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Event]
GO

ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_Match] FOREIGN KEY([MatchId])
REFERENCES [dbo].[Match] ([MatchId])
GO

ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_Match]
GO

ALTER TABLE [dbo].[Basket]  WITH CHECK ADD  CONSTRAINT [FK_Basket_User_] FOREIGN KEY([UserId])
REFERENCES [dbo].[User_] ([UserId])
GO

ALTER TABLE [dbo].[Basket] CHECK CONSTRAINT [FK_Basket_User_]
GO


