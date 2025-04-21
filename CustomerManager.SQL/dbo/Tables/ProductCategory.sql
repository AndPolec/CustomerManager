CREATE TABLE [dbo].[ProductCategory]
(
	[Id] INT IDENTITY NOT NULL,
    [CategoryName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_ProductCategory_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_ProductCategory_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_ProductCategory_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)
GO
CREATE TRIGGER TRG_ProductCategory_SetUpdatedAt ON [dbo].[ProductCategory]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE pc
    SET pc.UpdatedAt = SYSDATETIME()
    FROM [dbo].[ProductCategory] pc
    INNER JOIN inserted i ON pc.Id = i.Id;
END;
