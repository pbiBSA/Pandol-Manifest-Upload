USE [ImportDataWarehouse]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateManifestUploadArchiveInfoVersion2]    Script Date: 01/02/2013 08:35:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: 12/10/2012
-- Description:	Updates the exporter and variety name from translation table data
-- =============================================
ALTER PROCEDURE [dbo].[sp_UpdateManifestUploadArchiveInfoVersion2] 
	
AS
BEGIN
	
	SET NOCOUNT ON;
--Update the exporter name from prefix
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].[Exporter_Name] = (SELECT [Description] 
  FROM [PBIApplicationTables].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Prefix' AND [Value] = [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].[Pallet_Prefix])

--Update missing Exporter names
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]
  SET [Exporter_Name] = [Exporter]
  WHERE [Exporter_Name] IS NULL
 
 --Update the variety name 
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].[Variety_Name] = 
  ISNULL((SELECT TOP 1 [Description] 
  FROM [PBIApplicationTables].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].Variety_Code), (SELECT TOP 1 [Description] 
  FROM [PBIApplicationTables].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Adams_Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].Variety_Code))
  
  EXEC sp_Update_Import_Archive_From_Temp_Version2
  
  
END
