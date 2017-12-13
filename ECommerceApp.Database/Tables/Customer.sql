CREATE TABLE [dbo].[Customer]
(
	[Id] INT IDENTITY(0,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [EmailAdress] NVARCHAR(250) NOT NULL, 
    [PhoneNumber] NVARCHAR(20) NOT NULL, 
    [Street] NVARCHAR(100) NOT NULL, 
    [HouseNumber] INT NOT NULL, 
    [HouseNumberExtension] NVARCHAR(10) NULL, 
    [ZipCode] NVARCHAR(10) NOT NULL, 
    [City] NVARCHAR(100) NOT NULL, 
    [Country] NVARCHAR(100) NOT NULL, 
    [Deleted] BIT NOT NULL DEFAULT 0
)
