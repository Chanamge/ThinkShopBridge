CREATE TABLE [dbo].[Product] (
    [Id]          INT            NOT NULL,
    [Name]        NVARCHAR (120) NOT NULL,
    [Description] NVARCHAR (250) NULL,
    [Price]       FLOAT (53)     NULL,
    [Type]        NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);