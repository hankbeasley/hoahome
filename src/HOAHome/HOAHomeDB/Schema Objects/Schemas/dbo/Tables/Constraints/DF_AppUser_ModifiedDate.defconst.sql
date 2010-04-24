ALTER TABLE [dbo].[AppUser]
    ADD CONSTRAINT [DF_AppUser_ModifiedDate] DEFAULT (getdate()) FOR [ModifiedDate];

