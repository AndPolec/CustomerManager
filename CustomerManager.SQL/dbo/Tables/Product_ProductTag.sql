CREATE TABLE [dbo].[Product_ProductTag]
(
	[ProductId] INT NOT NULL,
    [TagId] INT NOT NULL,
    CONSTRAINT PK_Product_ProductTag PRIMARY KEY ([ProductId], [TagId]),
    CONSTRAINT FK_Product_ProductTag_Product FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_Product_ProductTag_Tag FOREIGN KEY ([TagId]) REFERENCES [ProductTag]([Id]) ON DELETE NO ACTION
)
