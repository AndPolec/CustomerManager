CREATE TABLE [dbo].[ProductUnit]
(
    [Id] INT IDENTITY NOT NULL,
    [ProductId] INT NOT NULL,
    [UnitId] INT NOT NULL,
    [ConversionFactor] DECIMAL(10,2) NOT NULL,
    [IsDefault] BIT NOT NULL DEFAULT 0,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_ProductUnit_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_ProductUnit_Product FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_ProductUnit_UnitOfMeasure FOREIGN KEY ([UnitId]) REFERENCES [UnitOfMeasure]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_ProductUnit_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_ProductUnit_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
 )

 GO
 CREATE TRIGGER TRG_ProductUnit_SetUpdatedAt ON [dbo].[ProductUnit]
 AFTER UPDATE
 AS
 BEGIN
     SET NOCOUNT ON;
     UPDATE pu
     SET pu.UpdatedAt = SYSDATETIME()
     FROM [dbo].[ProductUnit] pu
     INNER JOIN inserted i ON pu.Id = i.Id;
 END;
