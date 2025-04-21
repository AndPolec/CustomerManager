CREATE TABLE [dbo].[UnitOfMeasure]
(
	[Id] INT IDENTITY NOT NULL,
	[Symbol] NVARCHAR(10) NOT NULL,
	[Name] NVARCHAR(10) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	[CreatedBy] NVARCHAR(450) NOT NULL,
	[UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
	CONSTRAINT PK_UnitOfMeasure_Id PRIMARY KEY ([Id]),
	CONSTRAINT FK_UnitOfMeasure_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
	CONSTRAINT FK_UnitOfMeasure_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)
GO
CREATE TRIGGER TRG_UnitOfMeasure_SetUpdatedAt ON [dbo].[UnitOfMeasure]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE uom
	SET uom.UpdatedAt = SYSDATETIME()
	FROM [dbo].[UnitOfMeasure] uom
	INNER JOIN inserted i ON uom.Id = i.Id;
END;
