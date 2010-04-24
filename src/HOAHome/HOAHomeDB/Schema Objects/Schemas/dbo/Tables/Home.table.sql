CREATE TABLE [dbo].[Home] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [AddressFull]     VARCHAR (200)    NULL,
    [AddressLine1]    VARCHAR (50)     NULL,
    [AddressLine2]    VARCHAR (50)     NULL,
    [City]            VARCHAR (50)     NULL,
    [State]           VARCHAR (50)     NULL,
    [Zip]             VARCHAR (50)     NULL,
    [GoogleFeatureId] VARCHAR (200)    NULL,
    [Latitude]        FLOAT            NULL,
    [Longitude]       FLOAT            NULL
);

