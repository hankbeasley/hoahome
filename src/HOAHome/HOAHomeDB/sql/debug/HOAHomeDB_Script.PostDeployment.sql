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

INSERT INTO [AppUser] ([Id],[Email],[FirstName],[LastName],[DisplayName],[GoogleId],[AccessToken],[AccessTokenSecret],[LastLogin],[CompletedRegistration],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])VALUES('F421D52D-C47F-4D0E-AB9D-7CD85D8EC6B4','hankbeasleymail@gmail.com','Hank','Beasley','Beasley, Hank','https://www.google.com/accounts/o8/id?id=AItOawnDYrc6ZaxYrBHE1Vu-l2zYt_M11tZd0zs','1/Sj1JpvEF8kwTnhICj6Nfm-j-72cWCxm8LIwxBnWXHHM','izGUJ0nqNEFfQIGu4Y/9fBBF','Apr 24 2010  4:46:19:957PM',0,'021e34c9-5d15-43c5-9429-282fecef4e34','Apr 24 2010  4:46:19:957PM','021e34c9-5d15-43c5-9429-282fecef4e34','Apr 24 2010  4:46:19:957PM')
