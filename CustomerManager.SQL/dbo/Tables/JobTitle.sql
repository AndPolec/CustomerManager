﻿CREATE TABLE [dbo].[JobTitle]
(
	[Id] INT NOT NULL PRIMARY KEY CLUSTERED IDENTITY,
	[TitleName] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	[CreatedBy] NVARCHAR(450) NULL,
	[UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
	CONSTRAINT FK_JobTitle_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]),
    CONSTRAINT FK_JobTitle_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id])
)
