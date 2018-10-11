USE [ApplicationSettings]
GO

/*Used to move data from the imported famous Method ID into
the Method ID Codes table. */

DELETE FROM dbo.Method_ID_Codes

insert dbo.Method_ID_Codes
Select [NAME], [NAMEINVC], NULL
FROM dbo.Famous_MethodID
ORDER BY [NAMEINVC]
