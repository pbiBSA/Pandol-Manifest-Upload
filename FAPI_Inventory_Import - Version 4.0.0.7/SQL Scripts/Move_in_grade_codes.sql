USE [ApplicationSettings]
GO

/*Used to move data from the imported famous commodity list into
the Grade Codes table. */

DELETE FROM dbo.Grade_Codes

insert dbo.Grade_Codes
Select OTHERNAMEINVC, OTHERNAME, NULL
FROM dbo.Famous_Commodity_List
WHERE [TYPEDESC] = 'Grades'
ORDER BY OTHERNAMEINVC
