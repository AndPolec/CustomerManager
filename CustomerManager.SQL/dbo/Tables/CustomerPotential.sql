CREATE TABLE [dbo].[CustomerPotential]
(
	[Id] INT IDENTITY NOT NULL,
    [PotentialName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_CustomerPotential_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_CustomerPotential_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE SET NULL
)
