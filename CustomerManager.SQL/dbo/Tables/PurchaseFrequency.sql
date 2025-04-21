CREATE TABLE [dbo].[PurchaseFrequency]
(
	[Id] INT IDENTITY NOT NULL,
    [FrequencyName] NVARCHAR(50) NOT NULL,
    [MultiplierInDays] INT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NOT NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_PurchaseFrequency_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_PurchaseFrequency_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_PurchaseFrequency_AspNetUsers_UpdatedBy FOREIGN KEY ([UpdatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE NO ACTION
)

GO
CREATE TRIGGER TRG_PurchaseFrequency_SetUpdatedAt ON [dbo].[PurchaseFrequency]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE pf
    SET pf.UpdatedAt = SYSDATETIME()
    FROM [dbo].[PurchaseFrequency] pf
    INNER JOIN inserted i ON pf.Id = i.Id;
END;
