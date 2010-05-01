ALTER TABLE [dbo].[NeighboorhoodHome]
    ADD CONSTRAINT [FK_NeighboorhoodHome_Neighborhood] FOREIGN KEY ([NeighborhoodId]) REFERENCES [dbo].[Neighborhood] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

