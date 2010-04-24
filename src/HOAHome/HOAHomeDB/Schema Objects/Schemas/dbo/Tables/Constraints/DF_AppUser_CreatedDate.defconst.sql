ALTER TABLE [dbo].[AppUser]
    ADD CONSTRAINT [DF_AppUser_CreatedDate] DEFAULT (getdate()) FOR [CreatedDate];

