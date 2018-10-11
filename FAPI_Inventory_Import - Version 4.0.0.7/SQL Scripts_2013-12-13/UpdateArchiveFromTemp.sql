
USE ImportDataWarehouse
GO

IF ((SELECT TOP 1 [Vessel_Name] + [Vessel_Number] FROM FAPI_Import_Data_Archive_Temp)
	in (Select [Vessel_Name] + [Vessel_Number] FROM FAPI_Import_Data_Archive)
BEGIN
	UPDATE FAPI_Import_Data_Archive
	SET [Receipt_Number],
	[Exporter],
	[Exporter_Name],
	[Departure_Date],
	[Vessel_Number],
	[Vessel_Name],
	[Destination],
	[Pallet_Prefix],
	[Warehouse],
	[Grower_Block],
	[Commodity_ID],
	[Transaction_Type],
	[Receiving_Date],
	[Method_Id],
	[Storage_ID],
	[Import_Template],
	[Pallet_Number],
	[Variety_Code],
	[Variety_Name],
	[Label_Code],
	[Style_Code],
	[Size_Code],
	[Pack_Code],
	[Grade_Code],
	[Pack_Date],
	[Grower_Number],
	[Boxes_Count],
	[Hatch],
	[Deck],
	[Fumigated],
	[Bill_of_Lading],
	[Pallet_Type],
	[Memo],
	[Other],
	[Test_Data],
	[Archive_Key]
SELECT [Receipt_Number],
	[Exporter],
	[Exporter_Name],
	[Departure_Date],
	[Vessel_Number],
	[Vessel_Name],
	[Destination],
	[Pallet_Prefix],
	[Warehouse],
	[Grower_Block],
	[Commodity_ID],
	[Transaction_Type],
	[Receiving_Date],
	[Method_Id],
	[Storage_ID],
	[Import_Template],
	[Pallet_Number],
	[Variety_Code],
	[Variety_Name],
	[Label_Code],
	[Style_Code],
	[Size_Code],
	[Pack_Code],
	[Grade_Code],
	[Pack_Date],
	[Grower_Number],
	[Boxes_Count],
	[Hatch],
	[Deck],
	[Fumigated],
	[Bill_of_Lading],
	[Pallet_Type],
	[Memo],
	[Other],
	[Test_Data],
	[Archive_Key]
	FROM FAPI_Import_Data_Archive_Temp
	WHERE ([FAPI_Import_Data_Archive].[Vessel_Name] + [FAPI_Import_Data_Archive].[Vessel_Number]) =
			([FAPI_Import_Data_Archive_Temp].[Vessel_Name] + [FAPI_Import_Data_Archive_Temp].[Vessel_Number])
	
	
END
	
ELSE
	
BEGIN
	
END
	
GO
	
	