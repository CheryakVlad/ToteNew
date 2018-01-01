

CREATE TABLE [dbo].[User_](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[RoleId] [int] NOT NULL,
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


