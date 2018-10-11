-- ================================================
-- sp_Back_Up_Archive_Table
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: January 3, 2013
-- Description:	Backups the Archive table to 
-- the archive_Bk table.
-- =============================================
ALTER PROCEDURE sp_Back_Up_Archive_Table 


AS
BEGIN
  DELETE
  FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Bk]
  
  INSERT INTO [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Bk]
  SELECT [Receipt_Number]
      ,[Exporter]
      ,[Exporter_Name]
      ,[Departure_Date]
      ,[Vessel_Number]
      ,[Vessel_Name]
      ,[Destination]
      ,[Pallet_Prefix]
      ,[Warehouse]
      ,[Grower_Block]
      ,[Commodity_ID]
      ,[Transaction_Type]
      ,[Receiving_Date]
      ,[Method_Id]
      ,[Storage_ID]
      ,[Import_Template]
      ,[Pallet_Number]
      ,[Variety_Code]
      ,[Variety_Name]
      ,[Label_Code]
      ,[Style_Code]
      ,[Size_Code]
      ,[Pack_Code]
      ,[Grade_Code]
      ,[Pack_Date]
      ,[Grower_Number]
      ,[Boxes_Count]
      ,[Hatch]
      ,[Deck]
      ,[Fumigated]
      ,[Bill_of_Lading]
      ,[Pallet_Type]
      ,[Memo]
      ,[Other]
      ,[Test_Data]
      ,(newid())
  FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]
END
GO
