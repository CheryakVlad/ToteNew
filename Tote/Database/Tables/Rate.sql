

CREATE TABLE [dbo].[Rate](
	[RateId] [int] IDENTITY(1,1) NOT NULL,
	[DateRate] [datetime] NOT NULL,
	[RateAmount] [money] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_Rate] PRIMARY KEY CLUSTERED 
(
	[RateId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Rate]  WITH CHECK ADD  CONSTRAINT [FK_Rate_User_] FOREIGN KEY([UserId])
REFERENCES [dbo].[User_] ([UserId])
GO

ALTER TABLE [dbo].[Rate] CHECK CONSTRAINT [FK_Rate_User_]
GO


