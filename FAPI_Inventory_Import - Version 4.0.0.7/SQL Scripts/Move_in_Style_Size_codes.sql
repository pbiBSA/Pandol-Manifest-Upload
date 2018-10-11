USE [ApplicationSettings]
GO

/*Used to move data from the imported famous commodity list into
the Variety Codes table. */

DELETE FROM dbo.Style_Size_Codes

insert dbo.Style_Size_Codes
Select OTHERNAMEINVC, OTHERNAME, NULL
FROM dbo.Famous_Commodity_List
WHERE [TYPEDESC] = 'Style/Size'
ORDER BY OTHERNAMEINVC
