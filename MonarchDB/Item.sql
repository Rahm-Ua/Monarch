CREATE TABLE [dbo].[Item]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1000, 1), 
    [LineNumber] INT NULL, 
    [Title] NVARCHAR(MAX) NOT NULL, 
    [Severity] TINYINT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [Description] TEXT NULL, 
    [Status] TINYINT NOT NULL, 
    [ResolutionId] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL DEFAULT getdate(), 
    [ModifiedDate] DATETIME NULL, 
    CONSTRAINT [FK_CategoryId_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]), 
    CONSTRAINT [FK_ResolutionId_Resolution] FOREIGN KEY ([ResolutionId]) REFERENCES [Resolution]([Id]) 
)
