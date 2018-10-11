USE [ApplicationSettings]
GO

/*Used to move data from the imported famous commodity list into
the Label Codes table. */

DELETE FROM dbo.Label_Codes

insert dbo.Label_Codes
Select OTHERNAMEINVC, OTHERNAME, NULL
FROM dbo.Famous_Commodity_List
WHERE [TYPEDESC] = 'Labels'
ORDER BY OTHERNAMEINVC
