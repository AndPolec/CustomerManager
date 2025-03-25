﻿CREATE TABLE [dbo].[UnitOfMeasure]
(
	[Id] INT IDENTITY NOT NULL,
	[Symbol] NVARCHAR(10) NOT NULL,
	[Name] NVARCHAR(10) NOT NULL,
	[Description] NVARCHAR(500) NULL,
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
	[CreatedBy] NVARCHAR(450) NULL,
	CONSTRAINT PK_UnitOfMeasure_Id PRIMARY KEY ([Id]),
	CONSTRAINT FK_UnitOfMeasure_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE SET NULL,
)
