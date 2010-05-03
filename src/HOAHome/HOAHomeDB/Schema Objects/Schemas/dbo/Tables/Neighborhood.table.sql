CREATE TABLE [dbo].[Neighborhood] (
    [Id]               UNIQUEIDENTIFIER  NOT NULL,
    [Name]             VARCHAR (150)     NULL,
	[Location]         VARCHAR (150)     NULL,
    [PrimaryContactId] UNIQUEIDENTIFIER  NOT NULL,
    [KML]              VARCHAR (MAX)     NULL,
    [Geo]              [sys].[geography] NULL,
	[CreatedBy]             VARCHAR (50)     NULL,
    [CreatedDate]           DATETIME         NOT NULL  DEFAULT (getdate()),
    [ModifiedBy]            VARCHAR (50)     NULL ,
    [ModifiedDate]          DATETIME         NOT NULL DEFAULT (getdate())
);

