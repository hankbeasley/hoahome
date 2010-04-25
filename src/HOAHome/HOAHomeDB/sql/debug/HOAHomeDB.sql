/*
Deployment script for HOAHomeDB
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "HOAHomeDB"
:setvar DefaultDataPath "E:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "E:\Program Files\Microsoft SQL Server\MSSQL10.MSSQLSERVER\MSSQL\DATA\"

GO
USE [master]

GO
:on error exit
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Creating $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [HOAHomeDB], FILENAME = N'$(DefaultDataPath)HOAHomeDB.mdf')
    LOG ON (NAME = [HOAHomeDB_log], FILENAME = N'$(DefaultLogPath)HOAHomeDB_log.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 100;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'The database settings cannot be modified. You must be a SysAdmin to apply these settings.';
    END


GO
USE [$(DatabaseName)]

GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
PRINT N'Creating [dbo].[AppUser]...';


GO
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
    [ModifiedBy]            VARCHAR (50)     NULL,
    [ModifiedDate]          DATETIME         NOT NULL
);


GO
PRINT N'Creating PK_Table_1...';


GO
ALTER TABLE [dbo].[AppUser]
    ADD CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[AppUser].[IX_Table_1]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Table_1]
    ON [dbo].[AppUser]([GoogleId] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0)
    ON [PRIMARY];


GO
PRINT N'Creating [dbo].[Home]...';


GO
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


GO
PRINT N'Creating PK_Home...';


GO
ALTER TABLE [dbo].[Home]
    ADD CONSTRAINT [PK_Home] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Neighborhood]...';


GO
CREATE TABLE [dbo].[Neighborhood] (
    [Id]               UNIQUEIDENTIFIER  NOT NULL,
    [Name]             VARCHAR (150)     NULL,
    [PrimaryContactId] UNIQUEIDENTIFIER  NOT NULL,
    [KML]              VARCHAR (MAX)     NULL,
    [Geo]              [sys].[geography] NULL
);


GO
PRINT N'Creating PK_Neighborhood...';


GO
ALTER TABLE [dbo].[Neighborhood]
    ADD CONSTRAINT [PK_Neighborhood] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating [dbo].[Neighborhood].[IX_Neighborhood]...';


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Neighborhood]
    ON [dbo].[Neighborhood]([Name] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF, ONLINE = OFF, MAXDOP = 0)
    ON [PRIMARY];


GO
PRINT N'Creating [dbo].[UserHome]...';


GO
CREATE TABLE [dbo].[UserHome] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [AppUserId]    UNIQUEIDENTIFIER NULL,
    [HomeId]       UNIQUEIDENTIFIER NULL,
    [RelationType] VARCHAR (50)     NULL,
    [Name]         VARCHAR (100)    NULL
);


GO
PRINT N'Creating PK_UserHome...';


GO
ALTER TABLE [dbo].[UserHome]
    ADD CONSTRAINT [PK_UserHome] PRIMARY KEY CLUSTERED ([Id] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF);


GO
PRINT N'Creating DF_AppUser_CreatedDate...';


GO
ALTER TABLE [dbo].[AppUser]
    ADD CONSTRAINT [DF_AppUser_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate];


GO
PRINT N'Creating DF_AppUser_ModifiedDate...';


GO
ALTER TABLE [dbo].[AppUser]
    ADD CONSTRAINT [DF_AppUser_ModifiedDate] DEFAULT (getdate()) FOR [ModifiedDate];


GO
PRINT N'Creating FK_Neighborhood_AppUser...';


GO
ALTER TABLE [dbo].[Neighborhood] WITH NOCHECK
    ADD CONSTRAINT [FK_Neighborhood_AppUser] FOREIGN KEY ([PrimaryContactId]) REFERENCES [dbo].[AppUser] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_UserHome_AppUser...';


GO
ALTER TABLE [dbo].[UserHome] WITH NOCHECK
    ADD CONSTRAINT [FK_UserHome_AppUser] FOREIGN KEY ([AppUserId]) REFERENCES [dbo].[AppUser] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating FK_UserHome_Home...';


GO
ALTER TABLE [dbo].[UserHome] WITH NOCHECK
    ADD CONSTRAINT [FK_UserHome_Home] FOREIGN KEY ([HomeId]) REFERENCES [dbo].[Home] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;


GO
PRINT N'Creating [dbo].[createGeometry]...';


GO
Create TRIGGER [dbo].[createGeometry]
ON [dbo].[Neighborhood]
FOR INSERT, UPDATE
AS
IF UPDATE(KML)
    UPDATE Neighborhood
    set Geo = geography::STPolyFromText(inserted.KML, 4326)
    FROM Neighborhood
    INNER JOIN inserted ON Neighborhood.Id = inserted.Id
GO
-- Refactoring step to update target server with deployed transaction logs
CREATE TABLE  [dbo].[__RefactorLog] (OperationKey UNIQUEIDENTIFIER NOT NULL PRIMARY KEY)
GO
sp_addextendedproperty N'microsoft_database_tools_support', N'refactoring log', N'schema', N'dbo', N'table', N'__RefactorLog'
GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

--EXEC sp_generate_inserts 'Neighborhood',@cols_to_exclude = "'Geo'"

INSERT INTO [AppUser] ([Id],[Email],[FirstName],[LastName],[DisplayName],[GoogleId],[AccessToken],[AccessTokenSecret],[LastLogin],[CompletedRegistration],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])VALUES('F421D52D-C47F-4D0E-AB9D-7CD85D8EC6B4','hankbeasleymail@gmail.com','Hank','Beasley','Beasley, Hank','https://www.google.com/accounts/o8/id?id=AItOawnDYrc6ZaxYrBHE1Vu-l2zYt_M11tZd0zs','1/Sj1JpvEF8kwTnhICj6Nfm-j-72cWCxm8LIwxBnWXHHM','izGUJ0nqNEFfQIGu4Y/9fBBF','Apr 24 2010  4:46:19:957PM',0,'021e34c9-5d15-43c5-9429-282fecef4e34','Apr 24 2010  4:46:19:957PM','021e34c9-5d15-43c5-9429-282fecef4e34','Apr 24 2010  4:46:19:957PM')

--Alief
INSERT INTO [Neighborhood] ([Id],[Name],[PrimaryContactId],[KML])VALUES('6B696DBE-616C-4421-9011-D080354977B6','Brays Village(Test)','F421D52D-C47F-4D0E-AB9D-7CD85D8EC6B4','POLYGON((-95.57532548904419 29.703478878844557,-95.57004690170288 29.712834801678493,-95.57438135147095 29.715220236151897,-95.57815790176392 29.704410782755083,-95.57532548904419 29.703478878844557))')

--Skyline
INSERT INTO [Neighborhood] ([Id],[Name],[PrimaryContactId],[KML])VALUES('BB88BDAF-41C8-48DC-B278-00633A6FF749','Skyline Village Park(Test)','F421D52D-C47F-4D0E-AB9D-7CD85D8EC6B4','POLYGON((-95.48691183328629 29.72821054132166,-95.48687428236008 29.72722295706981,-95.48611253499985 29.727246249263132,-95.48613399267197 29.728243150069847,-95.48691183328629 29.72821054132166))')

GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Neighborhood] WITH CHECK CHECK CONSTRAINT [FK_Neighborhood_AppUser];

ALTER TABLE [dbo].[UserHome] WITH CHECK CHECK CONSTRAINT [FK_UserHome_AppUser];

ALTER TABLE [dbo].[UserHome] WITH CHECK CHECK CONSTRAINT [FK_UserHome_Home];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        DECLARE @VarDecimalSupported AS BIT;
        SELECT @VarDecimalSupported = 0;
        IF ((ServerProperty(N'EngineEdition') = 3)
            AND (((@@microsoftversion / power(2, 24) = 9)
                  AND (@@microsoftversion & 0xffff >= 3024))
                 OR ((@@microsoftversion / power(2, 24) = 10)
                     AND (@@microsoftversion & 0xffff >= 1600))))
            SELECT @VarDecimalSupported = 1;
        IF (@VarDecimalSupported > 0)
            BEGIN
                EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
            END
    END


GO
