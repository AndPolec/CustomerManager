﻿CREATE TABLE [dbo].[JobTitle]
(
	[Id] INT NOT NULL IDENTITY,
	[TitleName] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	[CreatedBy] NVARCHAR(450) NOT NULL,
	[UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
	CONSTRAINT PK_JobTitle_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_JobTitle_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
	CONSTRAINT FK_JobTitle_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_JobTitle_SetUpdatedAt ON [dbo].[JobTitle]
AFTER UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE jt
	SET jt.UpdatedAt = SYSDATETIME()
	FROM [dbo].[JobTitle] jt
	INNER JOIN inserted i ON jt.Id = i.Id;
END;
