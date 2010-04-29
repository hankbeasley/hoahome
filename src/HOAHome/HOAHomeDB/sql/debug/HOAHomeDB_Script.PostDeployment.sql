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

--Roles
INSERT INTO Role (Id, Name) VALUES ('EC5FE847-90D9-4DE4-BF49-503EC4CEC8D5','Administrator');
INSERT INTO Role (Id, Name) VALUES ('8487A6E8-2857-4320-9936-B14A25D22410','Member');


--Content Type
INSERT INTO ContentType (Id, Name) VALUES ('49DEE62E-D6C1-4322-BD79-ADB350540AFB','HomePageMain')


INSERT INTO [AppUser] ([Id],[Email],[FirstName],[LastName],[DisplayName],[GoogleId],[AccessToken],[AccessTokenSecret],[LastLogin],[CompletedRegistration],[CreatedBy],[CreatedDate],[ModifiedBy],[ModifiedDate])VALUES('F421D52D-C47F-4D0E-AB9D-7CD85D8EC6B4','hankbeasleymail@gmail.com','Hank','Beasley','Beasley, Hank','https://www.google.com/accounts/o8/id?id=AItOawnDYrc6ZaxYrBHE1Vu-l2zYt_M11tZd0zs','1/Sj1JpvEF8kwTnhICj6Nfm-j-72cWCxm8LIwxBnWXHHM','izGUJ0nqNEFfQIGu4Y/9fBBF','Apr 24 2010  4:46:19:957PM',0,'021e34c9-5d15-43c5-9429-282fecef4e34','Apr 24 2010  4:46:19:957PM','021e34c9-5d15-43c5-9429-282fecef4e34','Apr 24 2010  4:46:19:957PM')

--Alief
INSERT INTO [Neighborhood] ([Id],[Name],[PrimaryContactId],[KML])VALUES('6B696DBE-616C-4421-9011-D080354977B6','Brays Village(Test)','F421D52D-C47F-4D0E-AB9D-7CD85D8EC6B4','POLYGON((-95.57532548904419 29.703478878844557,-95.57004690170288 29.712834801678493,-95.57438135147095 29.715220236151897,-95.57815790176392 29.704410782755083,-95.57532548904419 29.703478878844557))')
INSERT INTO UserNeighborhood (Id, UserId, NeighborhoodId, RoleId) VALUES ('1A17E75A-B37F-4E5A-B43C-2AD1CE3DAC2B','F421D52D-C47F-4D0E-AB9D-7CD85D8EC6B4','6B696DBE-616C-4421-9011-D080354977B6','EC5FE847-90D9-4DE4-BF49-503EC4CEC8D5')


--Skyline
INSERT INTO [Neighborhood] ([Id],[Name],[PrimaryContactId],[KML])VALUES('BB88BDAF-41C8-48DC-B278-00633A6FF749','Skyline Village Park(Test)','F421D52D-C47F-4D0E-AB9D-7CD85D8EC6B4','POLYGON((-95.48691183328629 29.72821054132166,-95.48687428236008 29.72722295706981,-95.48611253499985 29.727246249263132,-95.48613399267197 29.728243150069847,-95.48691183328629 29.72821054132166))')
INSERT INTO UserNeighborhood (Id, UserId, NeighborhoodId, RoleId) VALUES ('68F58336-FEB2-4AD2-92D1-4FEE7955E29F','F421D52D-C47F-4D0E-AB9D-7CD85D8EC6B4','BB88BDAF-41C8-48DC-B278-00633A6FF749','EC5FE847-90D9-4DE4-BF49-503EC4CEC8D5')
