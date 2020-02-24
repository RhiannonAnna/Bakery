CREATE TABLE [dbo].[Cars]
(
	[Id] TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Type] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Registration] TINYINT NULL
)