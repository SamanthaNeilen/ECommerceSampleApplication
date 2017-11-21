/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS(SELECT TOP(1) [Name] FROM Customer)
BEGIN
	INSERT INTO Customer ([Name],[Emailadress],[Phonenumber],[Street], [Housenumber], [HousenumberExtension], [Zipcode], [City], [Country])
		VALUES ('My test customer 1', 'company@testcompany1.com', '0123456789', 'TestStreet', 4, NULL, '1111AA', 'TestCity', 'TestCountry');
	INSERT INTO Customer ([Name],[Emailadress],[Phonenumber],[Street], [Housenumber], [HousenumberExtension], [Zipcode], [City], [Country])
		VALUES ('My test customer 2', 'info@somecompany.com', '0112233445', 'SomeStreet', 2, 'a', '5555UD', 'SomeCity', 'TestCountry');
	INSERT INTO Customer ([Name],[Emailadress],[Phonenumber],[Street], [Housenumber], [HousenumberExtension], [Zipcode], [City], [Country])
		VALUES ('My test customer 3', 'company3@test.com', '0997654432', 'StreetStuff', 4, NULL, '8261SK', 'CityStuff', 'TestCountry');
END