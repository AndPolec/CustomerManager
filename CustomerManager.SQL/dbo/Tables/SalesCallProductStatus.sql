CREATE TABLE [dbo].[SalesCallProductDecisionStatus]
(
	[Id] INT IDENTITY NOT NULL,
    [StatusName] NVARCHAR(50) NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
	[UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
	CONSTRAINT PK_SalesCallProductStatus_Id PRIMARY KEY ([Id]),
	CONSTRAINT FK_SalesCallProductStatus_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
	CONSTRAINT FK_SalesCallProductStatus_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)
GO
CREATE TRIGGER TRG_SalesCallProductStatus_SetUpdatedAt ON [dbo].[SalesCallProductDecisionStatus]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE scps
	SET scps.UpdatedAt = SYSDATETIME()
	FROM [dbo].[SalesCallProductDecisionStatus] scps
	INNER JOIN inserted i ON scps.Id = i.Id;
END;
