USE [ImportDataWarehouse]
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Import_Archive_From_Temp_Version2]    Script Date: 01/02/2013 08:35:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: December 7, 2012
-- Description:	Updates the archive table from the temp table
-- then clears the temp table.
-- Updated December 31, 2012
-- =============================================
ALTER PROCEDURE [dbo].[sp_Update_Import_Archive_From_Temp_Version2] 


AS

BEGIN

  
 	
 	UPDATE FAPI_Import_Data_Archive 
	SET [Receipt_Number] = AT.[Receipt_Number],
	[Exporter] = AT.[Exporter],
	[Exporter_Name] = AT.[Exporter_Name],
	[Departure_Date] = AT.[Departure_Date],
	[Vessel_Number] = AT.[Vessel_Number],
	[Vessel_Name] = AT.[Vessel_Name],
	[Destination] = AT.[Destination],
	[Pallet_Prefix] = AT.[Pallet_Prefix],
	[Warehouse] = AT.[Warehouse],
	[Region] = AT.[Region],
	[Grower_Block] = AT.[Grower_Block],
	[Commodity_ID] = AT.[Commodity_ID],
	[Transaction_Type] = AT.[Transaction_Type],
	[Receiving_Date] = AT.[Receiving_Date],
	[Method_Id] = AT.[Method_Id],
	[Storage_ID] = AT.[Storage_ID],
	[Import_Template] = AT.[IMport_Template],
	[Pallet_Number] = AT.[Pallet_Number],
	[Variety_Code] = AT.[Variety_Code],
	[Variety_Name] = AT.[Variety_Name],
	[Label_Code] = AT.[Label_Code],
	[Style_Code] = AT.[Style_Code],
	[Size_Code] = AT.[Size_Code],
	[Pack_Code] = AT.[Pack_Code],
	[Grade_Code] = AT.[Grade_Code],
	[Grower_Number] = AT.[Grower_Number],
	[Boxes_Count] = AT.[Boxes_Count],
	[Hatch] = AT.[Hatch],
	[Deck] = AT.[Deck],
	[Fumigated] = AT.[Fumigated],
	[Bill_of_Lading] = AT.[Bill_of_Lading],
	[Pallet_Type] = AT.[Pallet_Type],
	[Memo] = AT.[Memo],
	[Other] = AT.[Other],
	[Test_Data] = AT.[Test_Data]
	
	FROM FAPI_Import_Data_Archive_Temp AT
	WHERE ([FAPI_Import_Data_Archive].[Commodity_ID] + [FAPI_Import_Data_Archive].[Exporter] + 
		[FAPI_Import_Data_Archive].[Vessel_Number] + [FAPI_Import_Data_Archive].[Pallet_Number] +
		Convert(varchar,[FAPI_Import_Data_Archive].[Boxes_Count])) =
			(AT.[Commodity_ID] + AT.[Exporter] + AT.[Vessel_Number] + AT.[Pallet_Number]+ Convert(varchar, AT.[Boxes_Count])) 

			
  INSERT INTO [FAPI_Import_Data_Archive_Temp_Archive]
  SELECT *
  FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]

			
	Delete
	FROM FAPI_Import_Data_Archive_Temp
	WHERE ([Commodity_ID] + [Exporter] + [Vessel_Number] + [Pallet_Number]+ Convert(varchar,[Boxes_Count])) IN ( SELECT [Commodity_ID] 
		+ [Exporter] + [Vessel_Number] + [Pallet_Number] + Convert(varchar,[Boxes_Count]) 
		FROM [FAPI_Import_Data_Archive])

			
	

	INSERT INTO FAPI_Import_Data_Archive 
	SELECT *
	FROM FAPI_Import_Data_Archive_Temp DAT
	WHERE (NOT([Commodity_ID] + [Exporter] + [Vessel_Number] + [Pallet_Number]+ Convert(varchar,[Boxes_Count])) IN ( SELECT [Commodity_ID] 
		+ [Exporter] + [Vessel_Number] + [Pallet_Number] + Convert(varchar,[Boxes_Count]) 
		FROM [FAPI_Import_Data_Archive]))

	
	Delete
	FROM FAPI_Import_Data_Archive_Temp
	
END;


	
