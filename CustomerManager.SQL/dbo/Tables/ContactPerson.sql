CREATE TABLE [dbo].[ContactPerson]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(100) NOT NULL,
	[LastName] NVARCHAR(100) NOT NULL,
	[PhoneNumber] NVARCHAR(20) NULL,
	[Email] NVARCHAR(100) NULL, 
    [ContactRole] INT NOT NULL, 
    [CustomerId] INT NOT NULL, 
	[CreatedDate] DATETIME2 NOT NULL DEFAULT getdate(), 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT getdate(),
    CONSTRAINT [FK_ContactPerson_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]), 


)
