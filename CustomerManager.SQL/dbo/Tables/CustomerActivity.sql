CREATE TABLE [dbo].[CustomerActivity]
(
	[Id] INT NOT NULL IDENTITY,
	[ActivityName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_CustomerActivity_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_CustomerActivity_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_CustomerActivity_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_CustomerActivity_SetUpdatedAt ON [dbo].[CustomerActivity]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE ca
    SET ca.UpdatedAt = SYSDATETIME()
    FROM [dbo].[CustomerActivity] ca
    INNER JOIN inserted i ON ca.Id = i.Id;
END;
