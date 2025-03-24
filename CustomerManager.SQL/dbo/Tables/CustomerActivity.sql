CREATE TABLE [dbo].[CustomerActivity]
(
	[Id] INT NOT NULL IDENTITY,
	[ActivityName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_CustomerActivity_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_CustomerActivity_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE SET NULL
)
