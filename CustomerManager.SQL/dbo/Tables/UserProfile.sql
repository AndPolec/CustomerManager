CREATE TABLE [dbo].[UserProfile]
(
	[Id] NVARCHAR(450) NOT NULL,
    [FirstName] NVARCHAR(100) NOT NULL,
    [LastName] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(256) NULL,
    [PhoneNumber] NVARCHAR(20) NULL,
    [JobTitleId] INT NULL,
    [IsActive] BIT NOT NULL DEFAULT 1,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	[CreatedBy] NVARCHAR(450) NULL,
	[UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_UserProfile_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_UserProfile_AspNetUsers_Id FOREIGN KEY ([Id]) REFERENCES [AspNetUsers]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_UserProfile_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE SET NULL,
    CONSTRAINT FK_UserProfile_JobTitle_JobTitleId FOREIGN KEY ([JobTitleId]) REFERENCES [JobTitle]([Id]) ON DELETE SET NULL,
    CONSTRAINT FK_UserProfile_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE SET NULL
)

GO
CREATE TRIGGER TRG_UserProfile_SetUpdatedAt ON [dbo].[UserProfile]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE up
    SET up.UpdatedAt = SYSDATETIME()
    FROM [dbo].[UserProfile] up
    INNER JOIN inserted i ON up.Id = i.Id;
END;