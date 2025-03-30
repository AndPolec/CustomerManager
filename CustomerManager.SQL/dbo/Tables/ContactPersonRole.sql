CREATE TABLE [dbo].[ContactPersonRole]
(
	[Id] INT IDENTITY NOT NULL,
    [RoleName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(200) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_ContactPersonRole_Id PRIMARY KEY CLUSTERED ([Id]),
    CONSTRAINT FK_ContactPersonRole_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)
