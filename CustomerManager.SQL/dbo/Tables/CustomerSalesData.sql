CREATE TABLE [dbo].[CustomerSalesData]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Notes] NVARCHAR(5000) NULL, 
    [CustomerId] INT NOT NULL UNIQUE, 
    [DistributorId] INT NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getdate(), 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT getdate(),
    CONSTRAINT [FK_CustomerSalesData_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]),
    CONSTRAINT [FK_CustomerSalesData_Distributor] FOREIGN KEY ([DistributorId]) REFERENCES [Customer]([Id])


)
