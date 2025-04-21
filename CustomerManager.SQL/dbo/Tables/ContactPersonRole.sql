CREATE TABLE [dbo].[ContactPersonRole]
(
	[Id] INT IDENTITY NOT NULL,
    [RoleName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(200) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_ContactPersonRole_Id PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT FK_ContactPersonRole_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_ContactPersonRole_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_ContactPersonRole_SetUpdatedAt ON [dbo].[ContactPersonRole]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE cpr
    SET cpr.UpdatedAt = SYSDATETIME()
    FROM [dbo].[ContactPersonRole] cpr
    INNER JOIN inserted i ON cpr.Id = i.Id;
END;
