CREATE TABLE [dbo].[ContactPerson]
(
	[Id] INT IDENTITY NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [PhoneNumber] NVARCHAR(20) NULL,
    [Email] NVARCHAR(256) NULL,
    [CustomerId] INT NOT NULL,
    [RoleId] INT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_ContactPerson_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_ContactPerson_Customer_CustomerId FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_ContactPerson_ContactPersonRole_ContactPersonRoleId FOREIGN KEY ([RoleId]) REFERENCES [ContactPersonRole]([Id]) ON DELETE SET NULL,
    CONSTRAINT FK_ContactPerson_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_ContactPerson_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)
GO
CREATE NONCLUSTERED INDEX IX_ContactPerson_Customer_CustomerId ON ContactPerson(CustomerId);

GO
CREATE TRIGGER TRG_ContactPerson_SetUpdatedAt ON [dbo].[ContactPerson]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE cp
    SET cp.UpdatedAt = SYSDATETIME()
    FROM [dbo].[ContactPerson] cp
    INNER JOIN inserted i ON cp.Id = i.Id;
END;
