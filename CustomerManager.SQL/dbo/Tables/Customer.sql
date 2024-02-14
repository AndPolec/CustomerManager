CREATE TABLE [dbo].[Customer]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(200) NOT NULL, 
    [PhoneNumber] NVARCHAR(20) NULL,
    [Email] NVARCHAR(100) NULL, 
    [IsActive] BIT NOT NULL DEFAULT 1, 
    [ClientType] INT NOT NULL, 
    [FoodServiceType] INT NOT NULL,
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getdate(), 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT getdate()
)
