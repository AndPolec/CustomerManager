CREATE TABLE [dbo].[UserProfile]
(
	[Id] NVARCHAR(450) NOT NULL PRIMARY KEY CLUSTERED,
    [FirstName] NVARCHAR(100),
    [LastName] NVARCHAR(100),
    [Email] NVARCHAR(256),
    [PhoneNumber] NVARCHAR(20),
    [JobTitleId] INT NOT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	[CreatedBy] NVARCHAR(450) NULL,
	[UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT FK_UserProfile_Id FOREIGN KEY ([Id]) REFERENCES [AspNetUsers]([Id]),
    CONSTRAINT FK_UserProfile_JobTitle FOREIGN KEY ([JobTitleId]) REFERENCES [JobTitle]([Id]),
    CONSTRAINT FK_UserProfile_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]),
    CONSTRAINT FK_UserProfile_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]),
)
