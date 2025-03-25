CREATE TABLE [dbo].[ProductUnit]
(
    [Id] INT IDENTITY NOT NULL,
    [ProductId] INT NOT NULL,
    [UnitId] INT NOT NULL,
    [ConversionFactor] DECIMAL(10,2) NOT NULL,
    [IsDefault] BIT NOT NULL DEFAULT 0,
    CONSTRAINT PK_ProductUnit_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_ProductUnit_Product FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_ProductUnit_UnitOfMeasure FOREIGN KEY ([UnitId]) REFERENCES [UnitOfMeasure]([Id]) ON DELETE NO ACTION
 )
