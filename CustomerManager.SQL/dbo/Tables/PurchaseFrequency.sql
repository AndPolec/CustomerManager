CREATE TABLE [dbo].[PurchaseFrequency]
(
	[Id] INT IDENTITY NOT NULL,
    [FrequencyName] NVARCHAR(50) NOT NULL,
    [MultiplierInDays] INT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_PurchaseFrequency_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_PurchaseFrequency_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION

)
