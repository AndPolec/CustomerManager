CREATE TABLE [dbo].[SalesCallContactType]
(
	[Id] INT IDENTITY NOT NULL,
	[TypeName] NVARCHAR(50) NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
	[UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
	CONSTRAINT PK_SalesCallContactType_Id PRIMARY KEY ([Id]),
	CONSTRAINT FK_SalesCallContactType_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
	CONSTRAINT FK_SalesCallContactType_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_SalesCallContactType_SetUpdatedAt ON [dbo].[SalesCallContactType]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE scc
	SET scc.UpdatedAt = SYSDATETIME()
	FROM [dbo].[SalesCallContactType] scc
	INNER JOIN inserted i ON scc.Id = i.Id;
END;
