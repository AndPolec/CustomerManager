CREATE TABLE [dbo].[SalesCallStatus]
(
	[Id] INT IDENTITY NOT NULL,
    [StatusName] NVARCHAR(50) NOT NULL,  
	CONSTRAINT PK_SalesCallStatus_Id PRIMARY KEY ([Id])
)
