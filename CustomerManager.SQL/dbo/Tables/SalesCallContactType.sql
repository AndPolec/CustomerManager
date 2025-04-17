﻿CREATE TABLE [dbo].[SalesCallContactType]
(
	[Id] INT IDENTITY NOT NULL,
	[TypeName] NVARCHAR(50) NOT NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
	CONSTRAINT PK_SalesCallContactType_Id PRIMARY KEY ([Id]),
	CONSTRAINT FK_SalesCallContactType_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)
