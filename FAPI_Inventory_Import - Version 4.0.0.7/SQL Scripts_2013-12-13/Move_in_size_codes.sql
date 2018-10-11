USE [ApplicationSettings]
GO

/*Used to move data from the imported famous Size table into
the Size Codes table. */

DELETE FROM dbo.Size_Codes

insert dbo.Size_Codes
Select NAMEINVC, NAME, NULL
FROM dbo.Famous_Size
ORDER BY NAMEINVC
