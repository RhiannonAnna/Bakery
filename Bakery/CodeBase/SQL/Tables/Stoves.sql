﻿CREATE TABLE [dbo].[Stoves]
(
	[Id] TINYINT NOT NULL PRIMARY KEY IDENTITY(1,1),
    [Type] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(50) NULL
)