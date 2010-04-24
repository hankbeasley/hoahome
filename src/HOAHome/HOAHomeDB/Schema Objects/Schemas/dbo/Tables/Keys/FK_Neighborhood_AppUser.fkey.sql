ALTER TABLE [dbo].[Neighborhood]
    ADD CONSTRAINT [FK_Neighborhood_AppUser] FOREIGN KEY ([PrimaryContactId]) REFERENCES [dbo].[AppUser] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

