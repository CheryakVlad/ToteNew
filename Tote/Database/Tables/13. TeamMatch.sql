BEGIN TRANSACTION
GO
CREATE TABLE dbo.TeamMatch
	(
	MatchId int NOT NULL,
	TeamId int NOT NULL,
	Home bit NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TeamMatch ADD CONSTRAINT
	PK_TeamMatch PRIMARY KEY CLUSTERED 
	(
	MatchId,
	TeamId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.TeamMatch ADD CONSTRAINT
	FK_TeamMatch_Team1 FOREIGN KEY
	(
	TeamId
	) REFERENCES dbo.Team
	(
	TeamId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TeamMatch ADD CONSTRAINT
	FK_TeamMatch_Match FOREIGN KEY
	(
	MatchId
	) REFERENCES dbo.Match
	(
	MatchId
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TeamMatch SET (LOCK_ESCALATION = TABLE)
GO
COMMIT