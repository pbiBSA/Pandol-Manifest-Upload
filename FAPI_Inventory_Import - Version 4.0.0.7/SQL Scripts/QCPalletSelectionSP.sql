/****** Script for SelectTopNRows command from SSMS  ******/

DECLARE @RowNum INT
DECLARE @MaxRows INT
DECLARE @NumberToPull INT
SET @RowNum = 1
SET @MaxRows = (SELECT COUNT([Exporter]) FROM [#QC_Temp])
SET @NumberToPull = 1



WHILE @RowNum <= @MaxRows  --Step through all rows of the QC_Temp table

BEGIN

SET @NumberToPull = (SELECT							--Get the number of pallet to pull
						[Number Pallets to check] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = @RowNum)


INSERT INTO QC_Archive_Test

SELECT TOP (@NumberToPull) [Selection_Date]
      ,[Receipt_Number]
      ,[Exporter]
      ,[Vessel_Number]
      ,[Pallet_Prefix]
      ,[Warehouse]
      ,[Region]
      ,[Grower_Block]
      ,[Commodity_ID]
      ,[Receiving_Date]
      ,[Pallet_Number]
      ,[Variety_Code]
      ,[Label_Code]
      ,[Style_Code]
      ,[Size_Code]
      ,[Pack_Code]
      ,[Grade_Code]
      ,[Grower_Number]
      ,[Boxes_Count]
      ,'QC' AS Memo
      ,[QC_Key]
     
  FROM [ImportDataWarehouse].[dbo].[FAPI_QC_Pallet_Selection]
  WHERE [Boxes_Count] >= 50
	
		AND Exporter = (SELECT
						[Exporter] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = 1
					)
		AND [Pallet_Prefix] = (SELECT
						[Pallet_Prefix] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = 1
					)
		AND [Variety_Code] = (SELECT
						[Variety_Code] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = 1
					)
		AND [Label_Code] = (SELECT
						[Label_Code] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = 1
					)
		AND [Variety_Code] = (SELECT
						[Variety_Code] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = 1
					)
		AND [Style_Code] + [Size_Code] = (SELECT
						[StyleSize] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = 1
					)
			AND [Grade_Code] = (SELECT
						[Grade_Code] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = 1
					)
					
		AND [Grower_Number] = (SELECT
						[Grower_Number] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = 1
					)
	
	
	--Verify not already QC'd
	
		AND NOT Exporter IN (SELECT
						[Exporter] 
					FROM [QC_Archive_Test]
					)
		AND NOT [Pallet_Prefix] IN (SELECT
						[Pallet_Prefix] 
					FROM [QC_Archive_Test]
					)
		AND NOT [Variety_Code] IN (SELECT
						[Variety_Code] 
					FROM [QC_Archive_Test]
					)
		AND NOT [Label_Code] IN (SELECT
						[Label_Code] 
					FROM [QC_Archive_Test]
					)
		AND NOT [Variety_Code] IN (SELECT
						[Variety_Code] 
					FROM [QC_Archive_Test]
					)			
		AND NOT [Style_Code] + [Size_Code] IN (SELECT
						[Style_Code] + [Size_Code] 
					FROM [QC_Archive_Test]
					)
			AND NOT [Grade_Code] IN (SELECT
						[Grade_Code] 
					FROM [QC_Archive_Test]
					)
					
		AND NOT [Grower_Number] IN (SELECT
						[Grower_Number] 
					FROM [QC_Archive_Test]
					)
		AND NOT [Receipt_Number] IN (SELECT
						[Receipt_Number] 
					FROM [QC_Archive_Test]
					)			
		
		
  ORDER BY QC_Key
  
  SET @RowNum = @RowNum + 1
  
  END