CREATE TABLE [dbo].[ProductSalesActivity]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SalesActivityType] INT NOT NULL,
	[SalesActivityResult] INT NOT NULL,
	[UnitOfMeasure] INT NOT NULL,
	[PurchaseFrequency] INT NOT NULL,
	[Quantity] INT NOT NULL, 
    [SalesCallId] INT NOT NULL,
	[ProductId] INT NOT NULL,
	CONSTRAINT [FK_ProductSalesActivity_SalesCall] FOREIGN KEY ([SalesCallId]) REFERENCES [SalesCall]([Id]),
	CONSTRAINT [FK_ProductSalesActivity_Product] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])


)
