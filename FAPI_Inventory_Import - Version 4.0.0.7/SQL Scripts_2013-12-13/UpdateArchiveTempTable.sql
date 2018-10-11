--Update the exporter name
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].[Exporter_Name] = (SELECT [Description] 
  FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Prefix' AND [Exporter] = [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].Exporter)

 --Update the variety name 
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].[Variety_Name] = 
  ISNULL((SELECT TOP 1 [Description] 
  FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].Variety_Code), (SELECT TOP 1 [Description] 
  FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Adams_Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].Variety_Code))