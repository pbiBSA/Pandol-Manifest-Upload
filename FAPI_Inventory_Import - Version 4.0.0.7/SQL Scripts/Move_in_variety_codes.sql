USE [ApplicationSettings]
GO

/*Used to move data from the imported famous commodity list into
the Variety Codes table. */

DELETE FROM dbo.Variety_Codes

insert dbo.Variety_Codes
Select OTHERNAMEINVC, OTHERNAME, NULL
FROM dbo.Famous_Commodity_List
WHERE [TYPEDESC] = 'Varieties'
ORDER BY OTHERNAMEINVC
