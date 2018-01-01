
GO


CREATE TRIGGER [dbo].[INSERT_Rate] ON [dbo].[Rate] 
AFTER INSERT 
AS

UPDATE User_ 
SET User_.Money=User_.Money-inserted.RateAmount
FROM User_, inserted
WHERE inserted.UserId=User_.UserId


GO


