CREATE TABLE [dbo].[Customer]
(
	[Id] INT IDENTITY NOT NULL,
    [Email] NVARCHAR(256) NULL,
    [Phone] NVARCHAR(20) NULL,
    [CompanyName] NVARCHAR(255) NOT NULL,
    [CustomerTypeId] INT NOT NULL,
    [CustomerPotentialId] INT NOT NULL,
    [CustomerActivityId] INT NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [AssignedUserId] NVARCHAR(450) NOT NULL,
    [CreatedBy] NVARCHAR(450) NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_Customer_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_Customer_CustomerType_CustomerTypeId FOREIGN KEY ([CustomerTypeId]) REFERENCES [CustomerType]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Customer_CustomerPotential_CustomerPotentialId FOREIGN KEY ([CustomerPotentialId]) REFERENCES [CustomerPotential]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Customer_CustomerActivity_CustomerActivityId FOREIGN KEY ([CustomerActivityId]) REFERENCES [CustomerActivity]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Customer_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Customer_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_Customer_AspNetUsers_AssignedUser FOREIGN KEY ([AssignedUserId]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
)

GO
CREATE INDEX IX_Customer_CompanyName ON Customer(CompanyName);

GO
CREATE TRIGGER TRG_Customer_SetUpdatedAt ON [dbo].[Customer]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE c
    SET c.UpdatedAt = SYSDATETIME()
    FROM [dbo].[Customer] c
    INNER JOIN inserted i ON c.Id = i.Id;
END;