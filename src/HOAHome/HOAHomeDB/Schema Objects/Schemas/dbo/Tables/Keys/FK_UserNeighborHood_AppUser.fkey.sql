ALTER TABLE [dbo].[UserNeighborHood]
    ADD CONSTRAINT [FK_UserNeighborHood_AppUser] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AppUser] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

