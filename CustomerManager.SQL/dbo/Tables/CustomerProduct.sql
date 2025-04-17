CREATE TABLE [dbo].[CustomerProduct] (
    [Id] INT IDENTITY NOT NULL,
    [CustomerId] INT NOT NULL,
    [ProductId] INT NOT NULL,
    [UnitOfMeasureId] INT NOT NULL,
    [Quantity] DECIMAL(10,2) NOT NULL,
    [PurchaseFrequencyId] INT NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate] DATE NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_CustomerProduct_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_CustomerProduct_Customer FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_CustomerProduct_Product FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_CustomerProduct_UnitOfMeasure FOREIGN KEY ([UnitOfMeasureId]) REFERENCES [UnitOfMeasure]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_CustomerProduct_PurchaseFrequency FOREIGN KEY ([PurchaseFrequencyId]) REFERENCES [PurchaseFrequency]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_CustomerProduct_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_CustomerProduct_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_CustomerProduct_SetUpdatedAt ON [dbo].[CustomerProduct]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE cp
    SET cp.UpdatedAt = SYSDATETIME()
    FROM [dbo].[CustomerProduct] cp
    INNER JOIN inserted i ON cp.Id = i.Id;
END;