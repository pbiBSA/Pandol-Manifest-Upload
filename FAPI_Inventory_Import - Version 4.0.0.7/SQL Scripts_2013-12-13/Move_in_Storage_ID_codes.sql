USE [ApplicationSettings]
GO

/*Used to move data from the imported famous Storage ID into
the Storage ID Codes table. */

DELETE FROM dbo.Storage_ID_Codes

insert dbo.Storage_ID_Codes
Select [NAME], [NAMEINVC], NULL
FROM dbo.Famous_StorageID
ORDER BY [NAMEINVC]
