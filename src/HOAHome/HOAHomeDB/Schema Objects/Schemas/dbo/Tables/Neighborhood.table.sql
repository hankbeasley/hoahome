CREATE TABLE [dbo].[Neighborhood] (
    [Id]               UNIQUEIDENTIFIER  NOT NULL,
    [Name]             VARCHAR (150)     NULL,
    [PrimaryContactId] UNIQUEIDENTIFIER  NOT NULL,
    [KML]              VARCHAR (MAX)     NULL,
    [Geo]              [sys].[geography] NULL
);

