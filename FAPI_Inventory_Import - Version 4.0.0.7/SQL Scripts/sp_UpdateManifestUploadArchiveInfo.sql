-- ================================================
-- UpdateManifestUploadArchiveInfo Stored Procedure
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: 11/12/2012
-- Description:	Updates the exporter and variety name from translation table data
-- =============================================
ALTER PROCEDURE sp_UpdateManifestUploadArchiveInfo 
	
AS
BEGIN
	
	SET NOCOUNT ON;
--Update the exporter name
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].[Exporter_Name] = (SELECT [Description] 
  FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Prefix' AND [Exporter] = [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].Exporter)

 --Update the variety name 
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].[Variety_Name] = 
  ISNULL((SELECT TOP 1 [Description] 
  FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].Variety_Code), (SELECT TOP 1 [Description] 
  FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Adams_Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].Variety_Code))
END
GO
