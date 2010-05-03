CREATE TABLE [dbo].[AppUser] (
    [Id]                    UNIQUEIDENTIFIER NOT NULL,
    [Email]                 VARCHAR (50)     NULL,
    [FirstName]             VARCHAR (50)     NULL,
    [LastName]              VARCHAR (50)     NULL,
    [DisplayName]           VARCHAR (150)    NOT NULL,
    [GoogleId]              VARCHAR (100)    NULL,
    [AccessToken]           VARCHAR (50)     NULL,
    [AccessTokenSecret]     VARCHAR (50)     NULL,
    [LastLogin]             DATETIME         NULL,
    [CompletedRegistration] BIT              NOT NULL,
    [CreatedBy]             VARCHAR (50)     NULL,
    [CreatedDate]           DATETIME         NOT NULL,
    [ModifiedBy]            VARCHAR (50)     NULL ,
    [ModifiedDate]          DATETIME         NOT NULL
);

