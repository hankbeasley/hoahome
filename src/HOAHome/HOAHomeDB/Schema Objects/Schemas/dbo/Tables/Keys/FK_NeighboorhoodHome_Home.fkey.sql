ALTER TABLE [dbo].[NeighboorhoodHome]
    ADD CONSTRAINT [FK_NeighboorhoodHome_Home] FOREIGN KEY ([HomeId]) REFERENCES [dbo].[Home] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

