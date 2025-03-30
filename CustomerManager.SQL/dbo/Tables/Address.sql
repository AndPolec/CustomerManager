CREATE TABLE [dbo].[Address]
(
	[Id] INT IDENTITY NOT NULL,
    [CustomerId] INT NOT NULL,
    [Street] NVARCHAR(150) NOT NULL,
    [BuildingNumber] NVARCHAR(10) NOT NULL,
    [FlatNumber] NVARCHAR(10) NULL,
    [City] NVARCHAR(100) NOT NULL,
    [ZipCode] NVARCHAR(20) NOT NULL,
    [Country] NVARCHAR(100) NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_Address_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_Address_Customer_CustomerId FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_Address_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Address_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_Address_SetUpdatedAt ON [dbo].[Address]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE a
    SET a.UpdatedAt = SYSDATETIME()
    FROM [dbo].[Address] a
    INNER JOIN inserted i ON a.Id = i.Id;
END;
