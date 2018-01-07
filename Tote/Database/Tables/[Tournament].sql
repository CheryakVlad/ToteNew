
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

ALTER TABLE [dbo].[Tournament]  WITH CHECK ADD  CONSTRAINT [FK_Tournament_Sport] FOREIGN KEY([SportId])
REFERENCES [dbo].[Sport] ([SportId])
GO

ALTER TABLE [dbo].[Tournament] CHECK CONSTRAINT [FK_Tournament_Sport]
GO


