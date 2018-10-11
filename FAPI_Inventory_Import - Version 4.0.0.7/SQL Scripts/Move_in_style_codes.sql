USE [ApplicationSettings]
GO

/*Used to move data from the imported famous Style table into
the Style Codes table. */

DELETE FROM dbo.Style_Codes

insert dbo.Style_Codes
Select NAMEINVC, NAME, NULL
FROM dbo.Famous_Style
ORDER BY NAMEINVC
