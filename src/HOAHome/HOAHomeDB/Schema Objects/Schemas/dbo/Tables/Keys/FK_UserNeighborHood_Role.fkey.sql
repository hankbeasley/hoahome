ALTER TABLE [dbo].[UserNeighborHood]
    ADD CONSTRAINT [FK_UserNeighborHood_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

