CREATE TABLE [dbo].[SalesCallProduct]
(
	[Id] INT IDENTITY NOT NULL,
    [SalesCallId] INT NOT NULL,
    [ProductId] INT NOT NULL,
    [UnitOfMeasureId] INT NOT NULL,
    [SalesDecisionStatusId] INT NOT NULL,
    [EstimatedQuantity] DECIMAL(10,2) NULL,
    [PurchaseFrequencyId] INT NULL,
    [StartDate] DATE NULL,
    [EndDate] DATE NULL,
    [FollowUpDate] DATE NULL,
    [FollowUpNote] NVARCHAR(500) NULL,
    [Note] NVARCHAR(1000) NULL,
    CONSTRAINT PK_SalesCallProduct_Id PRIMARY KEY ([Id]),
    CONSTRAINT FK_SalesCallProduct_SalesCall FOREIGN KEY ([SalesCallId]) REFERENCES [SalesCall]([Id]) ON DELETE CASCADE,
    CONSTRAINT FK_SalesCallProduct_Product FOREIGN KEY ([ProductId]) REFERENCES [Product]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_SalesCallProduct_UnitOfMeasure FOREIGN KEY ([UnitOfMeasureId]) REFERENCES [UnitOfMeasure]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_SalesCallProduct_DecisionStatus FOREIGN KEY ([SalesDecisionStatusId]) REFERENCES [SalesCallProductDecisionStatus]([Id]) ON DELETE NO ACTION,
    CONSTRAINT FK_SalesCallProduct_Frequency FOREIGN KEY ([PurchaseFrequencyId]) REFERENCES [PurchaseFrequency]([Id]) ON DELETE NO ACTION
)
