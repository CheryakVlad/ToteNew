BEGIN TRANSACTION
GO
CREATE TABLE dbo.Rate
	(
	RateId int NOT NULL IDENTITY (1, 1),
	DateRate datetime NOT NULL,
	RateAmount money NOT NULL,
	UserId int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Rate ADD CONSTRAINT
	PK_Rate PRIMARY KEY CLUSTERED 
	(
	RateId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Rate ADD CONSTRAINT
	FK_Rate_User FOREIGN KEY
	(
	UserId
	) REFERENCES dbo.[User]
	(
	UserId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Rate SET (LOCK_ESCALATION = TABLE)
GO
COMMIT