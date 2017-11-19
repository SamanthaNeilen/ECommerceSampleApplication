CREATE TABLE [dbo].[Customer]
(
	[Id] INT IDENTITY(0,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(250) NOT NULL, 
    [Emailadress] NVARCHAR(250) NOT NULL, 
    [Phonenumber] NVARCHAR(20) NOT NULL, 
    [Street] NVARCHAR(100) NOT NULL, 
    [Housenumber] INT NOT NULL, 
    [HousenumberExtension] NVARCHAR(10) NULL, 
    [Zipcode] NVARCHAR(10) NOT NULL, 
    [City] NVARCHAR(100) NOT NULL, 
    [Country] NVARCHAR(100) NOT NULL
)
