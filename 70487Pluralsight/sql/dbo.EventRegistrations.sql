CREATE TABLE [dbo].[EventRegistrations]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserName] NVARCHAR(256) NULL, 
    [EventTitle] NVARCHAR(500) NULL
)
