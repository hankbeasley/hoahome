ALTER TABLE [dbo].[Content]
    ADD CONSTRAINT [FK_Content_Neighborhood] FOREIGN KEY ([NeighborhoodId]) REFERENCES [dbo].[Neighborhood] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

