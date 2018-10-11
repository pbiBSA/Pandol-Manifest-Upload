USE [ApplicationSettings]
GO

/*Used to move data from the imported famous Block ID into
the Grower Block ID Codes table. */

DELETE FROM dbo.Grower_Block_ID_Codes

insert dbo.Grower_Block_ID_Codes
Select [NAME], [ID], NULL
FROM dbo.Famous_BlockID
ORDER BY [NAME]
