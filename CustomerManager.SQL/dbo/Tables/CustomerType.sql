CREATE TABLE [dbo].[CustomerType]
(
	[Id] INT IDENTITY NOT NULL,
	[TypeName] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	[CreatedBy] NVARCHAR(450) NULL,
	[UpdatedAt] DATETIME2 NULL,
	[UpdatedBy] NVARCHAR(450) NULL,	
	CONSTRAINT PK_CustomerType_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_CustomerType_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE SET NULL
)

GO
CREATE TRIGGER TRG_CustomerType_SetUpdatedAt ON [dbo].[CustomerType]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ct
    SET ct.UpdatedAt = SYSDATETIME()
    FROM [dbo].[CustomerType] ct
    INNER JOIN inserted i ON ct.Id = i.Id;
END;
