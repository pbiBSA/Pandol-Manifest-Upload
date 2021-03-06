USE [PBIApplicationTables]
GO
/****** Object:  StoredProcedure [dbo].[RefreshTestTemplateTable]    Script Date: 01/26/2014 09:49:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: January 26, 2014
-- Description:	Clears and inserts the current 
-- data from the production template table
-- =============================================
ALTER PROCEDURE [dbo].[RefreshTestTemplateTable] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

TRUNCATE TABLE [Spreadsheet_Import_Templates_Test]


INSERT INTO [Spreadsheet_Import_Templates_Test]
		(
	  [Template_Name]
      ,[ExporterRow]
      ,[ExporterColumn]
      ,[DepartureDateRow]
      ,[DepartureDateColumn]
      ,[VesselNumberRow]
      ,[VesselNumberColumn]
      ,[VesselNameRow]
      ,[VesselNameColumn]
      ,[DestinationRow]
      ,[DestinationColumn]
      ,[PrefixRow]
      ,[Prefix]
      ,[TagNumberRow]
      ,[TagNumberColumn]
      ,[CommodityRow]
      ,[CommodityColumn]
      ,[VarietyRow]
      ,[VarietyColumn]
      ,[StyleRow]
      ,[StyleColumn]
      ,[SizeRow]
      ,[SizeColumn]
      ,[GradeRow]
      ,[GradeColumn]
      ,[LabelRow]
      ,[LabelColumn]
      ,[PalletTypeRow]
      ,[PalletTypeColumn]
      ,InventoryQuantityRow
      ,[InventoryQuantityColumn]
      ,[FirstPackDateRow]
      ,[FirstPackDateColumn]
      ,[GrowerNumberRow]
      ,[GrowerNumberColumn]
      ,[HatchRow]
      ,[HatchColumn]
      ,[DeckRow]
      ,[DeckColumn]
      ,[FumigatedRow]
      ,[FumigatedColumn]
      ,[BillOfLadingRow]
      ,[BillOfLadingColumn]
      ,[MemoRow]
      ,[MemoColumn]
      ,[PackCodeRow]
      ,[PackCodeColumn]
      ,[Custom_Columns]
      ,[Other]
      ,[Data_Sheet]
      ,[Data_Range]
      ,[Special_Processing]
      )
      
SELECT [Template_Name]
      ,[ExporterRow]
      ,[ExporterColumn]
      ,[DepartureDateRow]
      ,[DepartureDateColumn]
      ,[VesselNumberRow]
      ,[VesselNumberColumn]
      ,[VesselNameRow]
      ,[VesselNameColumn]
      ,[DestinationRow]
      ,[DestinationColumn]
      ,[PrefixRow]
      ,[Prefix]
      ,[TagNumberRow]
      ,[TagNumberColumn]
      ,[CommodityRow]
      ,[CommodityColumn]
      ,[VarietyRow]
      ,[VarietyColumn]
      ,[StyleRow]
      ,[StyleColumn]
      ,[SizeRow]
      ,[SizeColumn]
      ,[GradeRow]
      ,[GradeColumn]
      ,[LabelRow]
      ,[LabelColumn]
      ,[PalletTypeRow]
      ,[PalletTypeCoumn]
      ,[InventoryQuanityRow]
      ,[InventoryQuantityColumn]
      ,[FirstPackDateRow]
      ,[FirstPackDateColumn]
      ,[GrowerNumberRow]
      ,[GrowerNumberColumn]
      ,[HatchRow]
      ,[HatchColumn]
      ,[DeckRow]
      ,[DeckColumn]
      ,[FumigatedRow]
      ,[FumigatedColumn]
      ,[BillOfLadingRow]
      ,[BillOfLadingColumn]
      ,[MemoRow]
      ,[MemoColumn]
      ,[PackCodeRow]
      ,[PackCodeColumn]
      ,[Custom_Columns]
      ,[Other]
      ,[Data_Sheet]
      ,[Data_Range]
      ,[Special_Processing]

  FROM [PBIApplicationTables].[dbo].[Spreadsheet_Import_Templates]

END
