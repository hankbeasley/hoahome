ALTER TABLE [dbo].[NeighborhoodHome]
    ADD CONSTRAINT [FK_NeighborhoodHome_Home] FOREIGN KEY ([HomeId]) REFERENCES [dbo].[Home] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

