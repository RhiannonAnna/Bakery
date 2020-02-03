CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Age] TINYINT NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Gender] BIT NOT NULL, 
    [StartTimeEmployment] DATETIME NOT NULL, 
    [TypeIdEmploymentContract] TINYINT NOT NULL,
	 CONSTRAINT [FK_Employee_TypeEmployeeContract] FOREIGN KEY (TypeIdEmploymentContract) REFERENCES [dbo].[TypeEmploymentContract]([Id])
)
