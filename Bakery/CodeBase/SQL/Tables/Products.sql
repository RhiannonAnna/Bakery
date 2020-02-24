CREATE TABLE [dbo].[Products]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Name] NVARCHAR(50) NOT NULL, 
    [Price] DECIMAL NOT NULL, 
    [Weight] DECIMAL NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Quantity] INT NOT NULL
)