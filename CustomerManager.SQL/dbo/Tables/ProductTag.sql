CREATE TABLE [dbo].[ProductTag]
(
	[Id] INT IDENTITY NOT NULL,
    [TagName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_ProductTag_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_ProductTag_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_ProductTag_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE UNIQUE INDEX IX_ProductTag_TagName ON ProductTag(TagName);

GO
CREATE TRIGGER TRG_ProductTag_SetUpdatedAt ON [dbo].[ProductTag]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE pt
    SET pt.UpdatedAt = SYSDATETIME()
    FROM [dbo].[ProductTag] pt
    INNER JOIN inserted i ON pt.Id = i.Id;
END;