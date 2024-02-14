CREATE TABLE [dbo].[SalesCall]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Objective] NVARCHAR(3000) NULL, 
    [Result] NCHAR(3000) NULL, 
    [Date] DATETIME2 NOT NULL DEFAULT getdate(), 
    [CustomerId] INT NOT NULL,
    [UserId] INT NOT NULL, 
    [CreatedDate] DATETIME2 NOT NULL DEFAULT getdate(), 
    [ModifiedDate] DATETIME2 NOT NULL DEFAULT getdate(),
    CONSTRAINT [FK_SalesCall_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]), 
    CONSTRAINT [FK_SalesCall_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])

)
