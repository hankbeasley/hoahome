CREATE TABLE [dbo].[Content] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Text]           VARCHAR (MAX)    NULL,
    [ContentTypeId]  UNIQUEIDENTIFIER NULL,
    [NeighborhoodId] UNIQUEIDENTIFIER NULL
);

