BEGIN TRANSACTION
GO
CREATE TABLE dbo.Result
	(
	ResultId int NOT NULL IDENTITY (1, 1),
	Name nvarchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Result ADD CONSTRAINT
	PK_Result PRIMARY KEY CLUSTERED 
	(
	ResultId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Result SET (LOCK_ESCALATION = TABLE)
GO
COMMIT