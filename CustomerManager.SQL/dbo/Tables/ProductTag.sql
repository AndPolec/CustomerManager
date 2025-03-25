CREATE TABLE [dbo].[ProductTag]
(
	[Id] INT IDENTITY NOT NULL,
    [TagName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    CONSTRAINT PK_ProductTag_Id PRIMARY KEY ([Id])
)

GO
CREATE UNIQUE INDEX IX_ProductTag_TagName ON ProductTag(TagName);