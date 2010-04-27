ALTER TABLE [dbo].[Content]
    ADD CONSTRAINT [FK_Content_ContentType] FOREIGN KEY ([ContentTypeId]) REFERENCES [dbo].[ContentType] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

