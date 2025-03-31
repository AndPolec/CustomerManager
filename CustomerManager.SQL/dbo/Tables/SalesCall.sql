CREATE TABLE [dbo].[SalesCall]
(
	[Id] INT IDENTITY NOT NULL,
    [CustomerId] INT NOT NULL,
    [ContactPersonId] INT NULL,
    [UserId] NVARCHAR(450) NOT NULL,
    [ScheduledDate] DATETIME2 NULL,
    [VisitDate] DATETIME2 NULL,
    [ContactTypeId] INT NOT NULL,
    [Location] NVARCHAR(250) NULL,
    [Objective] NVARCHAR(MAX) NULL,
    [Result] NVARCHAR(MAX) NULL,
    [StatusId] INT NOT NULL,
    [IsReminderSent] BIT NOT NULL DEFAULT 0,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_SalesCall_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_SalesCall_Customer FOREIGN KEY ([CustomerId]) REFERENCES [Customer]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_SalesCall_ContactPerson FOREIGN KEY ([ContactPersonId]) REFERENCES [ContactPerson]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_SalesCall_User FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_SalesCall_ContactType FOREIGN KEY ([ContactTypeId]) REFERENCES [SalesCallContactType]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_SalesCall_Status FOREIGN KEY ([StatusId]) REFERENCES [SalesCallStatus]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_SalesCall_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_SalesCall_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_SalesCall_SetUpdatedAt ON [dbo].[SalesCall]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE sc
    SET sc.UpdatedAt = SYSDATETIME()
    FROM [dbo].[SalesCall] sc
    INNER JOIN inserted i ON sc.Id = i.Id;
END;