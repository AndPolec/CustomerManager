﻿CREATE TABLE [dbo].[SalesCallStatus]
(
	[Id] INT IDENTITY NOT NULL,
    [StatusName] NVARCHAR(50) NOT NULL,  
	[CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
	CONSTRAINT PK_SalesCallStatus_Id PRIMARY KEY ([Id]),
	CONSTRAINT FK_SalesCallStatus_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)
