CREATE TABLE [dbo].[Address]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Street] NVARCHAR(100) NOT NULL, 
    [BuildingNumber] NVARCHAR(10) NOT NULL, 
    [FlatNumber] NVARCHAR(10) NULL, 
    [ZipCode] NVARCHAR(6) NOT NULL, 
    [City] NVARCHAR(100) NOT NULL, 
    [CustomerId] INT NOT NULL UNIQUE, 
    CONSTRAINT [FK_Address_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id])
)
