CREATE TABLE [dbo].[PurchasedProductDetails]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Quantity] INT NOT NULL, 
    [UnitOfMeasure] INT NOT NULL, 
    [PurchaseFrequency] INT NOT NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [StartPurchaseDate] DATETIME2 NOT NULL DEFAULT getdate(), 
    [EndPurchaseDate] DATETIME2 NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getdate(), 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT getdate(), 
    [CustomerSalesDataId] INT NOT NULL,
    [ProductId] INT NOT NULL, 
    CONSTRAINT [FK_PurchasedProductDetails_CustomerSalesData] FOREIGN KEY ([CustomerSalesDataId]) REFERENCES [CustomerSalesData] ([Id]),
    CONSTRAINT [FK_PurchasedProductDetails_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])

)
