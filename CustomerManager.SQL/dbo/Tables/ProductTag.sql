CREATE TABLE [dbo].[ProductTag]
(
	[Id] INT IDENTITY NOT NULL,
    [TagName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_ProductTag_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_ProductTag_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE UNIQUE INDEX IX_ProductTag_TagName ON ProductTag(TagName);