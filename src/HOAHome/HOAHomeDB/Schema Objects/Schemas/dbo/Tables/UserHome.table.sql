CREATE TABLE [dbo].[UserHome] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [AppUserId]    UNIQUEIDENTIFIER NULL,
    [HomeId]       UNIQUEIDENTIFIER NULL,
    [RelationType] VARCHAR (50)     NULL,
    [Name]         VARCHAR (100)    NULL
);

