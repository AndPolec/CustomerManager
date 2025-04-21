CREATE TABLE [dbo].[CustomerNote]
(
	[Id] INT IDENTITY NOT NULL,
    [CustomerId] INT NOT NULL,
    [Note] NVARCHAR(MAX) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_CustomerNote_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_CustomerNote_Customer_CustomerId FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_CustomerNote_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_CustomerNote_SetUpdatedAt ON [dbo].[CustomerNote]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE cn
    SET cn.UpdatedAt = SYSDATETIME()
    FROM [dbo].[CustomerNote] cn
    INNER JOIN inserted i ON cn.Id = i.Id;
END;
