CREATE TABLE [dbo].[Product]
(
	[Id] INT IDENTITY NOT NULL,
    [SKU] NVARCHAR(50) NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
    [Description] NVARCHAR(MAX) NULL,
    [CategoryId] INT NOT NULL,
    [BaseUnitId] INT NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_Product_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_Product_ProductCategory_CategoryId FOREIGN KEY ([CategoryId]) REFERENCES [ProductCategory]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Product_UnitOfMeasure_BaseUnit FOREIGN KEY ([BaseUnitId]) REFERENCES [UnitOfMeasure]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Product_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Product_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE UNIQUE INDEX IX_Product_SKU ON Product(SKU)

GO
CREATE TRIGGER TRG_Product_SetUpdatedAt ON [dbo].[Product]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE p
    SET p.UpdatedAt = SYSDATETIME()
    FROM [dbo].[Product] p
    INNER JOIN inserted i ON p.Id = i.Id;
END;
