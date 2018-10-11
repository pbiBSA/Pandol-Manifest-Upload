USE [ApplicationSettings]
GO

/*Used to move data from the imported famous Color table into
the Color Codes table. */

DELETE FROM dbo.Color_Codes

insert dbo.Color_Codes
Select NAMEINVC, NAME, NULL
FROM dbo.Famous_Color
ORDER BY NAMEINVC
