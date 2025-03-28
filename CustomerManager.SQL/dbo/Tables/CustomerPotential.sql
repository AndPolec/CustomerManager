CREATE TABLE [dbo].[CustomerPotential]
(
	[Id] INT IDENTITY NOT NULL,
    [PotentialName] NVARCHAR(100) NOT NULL,
    [Description] NVARCHAR(500) NULL,
    [CreatedAt] DATETIME2 NOT NULL DEFAULT SYSDATETIME(),
    [CreatedBy] NVARCHAR(450) NULL,
    [UpdatedAt] DATETIME2 NULL,
    [UpdatedBy] NVARCHAR(450) NULL,
    CONSTRAINT PK_CustomerPotential_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_CustomerPotential_AspNetUsers_CreatedBy FOREIGN KEY ([CreatedBy]) REFERENCES [AspNetUsers]([Id]) ON DELETE SET NULL
)

GO
CREATE TRIGGER TRG_CustomerPotential_SetUpdatedAt ON [dbo].[CustomerPotential]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE cpot
    SET cpot.UpdatedAt = SYSDATETIME()
    FROM [dbo].[CustomerPotential] cpot
    INNER JOIN inserted i ON cpot.Id = i.Id;
END;
