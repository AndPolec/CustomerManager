CREATE TABLE [dbo].[SalesCallStatus]
(
	[Id] INT IDENTITY NOT NULL,
    [StatusName] NVARCHAR(50) NOT NULL,  
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
	[UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
	CONSTRAINT PK_SalesCallStatus_Id PRIMARY KEY ([Id]),
	CONSTRAINT FK_SalesCallStatus_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
	CONSTRAINT FK_SalesCallStatus_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_SalesCallStatus_SetUpdatedAt ON [dbo].[SalesCallStatus]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE scs
	SET scs.UpdatedAt = SYSDATETIME()
	FROM [dbo].[SalesCallStatus] scs
	INNER JOIN inserted i ON scs.Id = i.Id;
END;
