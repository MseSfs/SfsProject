CREATE TABLE [dbo].[Project] (
    [Id]          NVARCHAR (128)  NOT NULL,
    [Name]        NVARCHAR (256)  NULL,
    [Description] NVARCHAR (1000) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);