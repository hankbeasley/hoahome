ALTER TABLE [dbo].[UserNeighborHood]
    ADD CONSTRAINT [FK_UserNeighborHood_Neighborhood] FOREIGN KEY ([NeighborhoodId]) REFERENCES [dbo].[Neighborhood] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

