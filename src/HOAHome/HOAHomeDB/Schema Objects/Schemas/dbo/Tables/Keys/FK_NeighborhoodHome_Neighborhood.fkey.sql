ALTER TABLE [dbo].[NeighborhoodHome]
    ADD CONSTRAINT [FK_NeighborhoodHome_Neighborhood] FOREIGN KEY ([NeighborhoodId]) REFERENCES [dbo].[Neighborhood] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

