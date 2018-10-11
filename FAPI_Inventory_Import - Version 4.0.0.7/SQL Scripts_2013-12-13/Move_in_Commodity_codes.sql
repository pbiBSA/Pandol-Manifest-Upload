USE [ApplicationSettings]
GO

/*Used to move data from the imported famous Commodities into
the Commondy Codes table. */

DELETE FROM dbo.Commodity_Codes

insert dbo.Commodity_Codes
Select [NAME], [NAMEINVC], NULL
FROM dbo.Famous_Commodities
ORDER BY [NAMEINVC]
