
GO


CREATE PROC [dbo].[AddBet]
@RateId int,
@MatchId int,
@EventId int,
@BasketId int
AS
BEGIN TRANSACTION
INSERT INTO Bet (MatchId,Status,EventId)
SELECT @MatchId, 'False', @EventId

DECLARE @BetId int
SELECT @BetId = scope_identity();

INSERT INTO BetRate VALUES(@BetId,@RateId)

DELETE Basket
WHERE BasketId=@BasketId

COMMIT
GO


