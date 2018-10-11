

--Create a temp table to hold the signature of pallets to QC and the number of to QC
DROP TABLE [#QC_Temp]
  CREATE TABLE [#QC_Temp](
	[RowNumber] [bigint] NULL,
	[Exporter] [varchar](50) NULL,
	[Pallet_Prefix] [varchar](10) NOT NULL,
	[Variety_Code] [varchar](50) NOT NULL,
	[Label_Code] [varchar](50) NOT NULL,
	[StyleSize] [varchar](100) NULL,
	[Grade_Code] [varchar](50) NOT NULL,
	[Grower_Number] [varchar](50) NOT NULL,
	[Number Pallets to check] [int] NOT NULL
	)
	
--Fill temp table
INSERT INTO #QC_Temp

  SELECT
	  ROW_NUMBER() OVER(ORDER BY Exporter) AS [RowNumber]
	  ,[Exporter]
      ,[Pallet_Prefix] 
      ,[Variety_Code]
      ,[Label_Code]
      ,[Style_Code] + [Size_Code] AS [StyleSize]
      ,ISNULL([Grade_Code], '') AS 'Grade_Code'
      ,[Grower_Number]
      ,CASE 
		WHEN SUM([Boxes_Count]) * 0.004 <= 36 THEN 1
        WHEN SUM([Boxes_Count]) * 0.004 <= 46 THEN 2
        WHEN SUM([Boxes_Count]) * 0.004 <= 56 THEN 3
        WHEN SUM([Boxes_Count]) * 0.004 <= 66 THEN 4
        WHEN SUM([Boxes_Count]) * 0.004 <= 76 THEN 5
        ELSE 6
        END AS [Number Pallets to check]  
  --INTO #QC_Temp
  FROM [ImportDataWarehouse].[dbo].[FAPI_QC_Pallet_Selection_Test]
  WHERE Boxes_Count >= 50 --Only use pallets with more than 50 boxes
  GROUP BY Exporter, [Pallet_Prefix], Variety_Code, Label_Code, [Style_Code] + [Size_Code], Grower_Number, [Grade_Code]
    ORDER BY 
    Exporter, Variety_Code, Label_Code, [Style_Code] + [Size_Code], Grower_Number
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
     
  FROM [ImportDataWarehouse].[dbo].[FAPI_QC_Pallet_Selection_Test]
  WHERE [Boxes_Count] >= 50
	
		AND Exporter = (SELECT
						[Exporter] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = @RowNum
					)
		AND [Pallet_Prefix] = (SELECT
						[Pallet_Prefix] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = @RowNum
					)
		AND [Variety_Code] = (SELECT
						[Variety_Code] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = @RowNum
					)
		AND [Label_Code] = (SELECT
						[Label_Code] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = @RowNum
					)
		AND [Variety_Code] = (SELECT
						[Variety_Code] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = @RowNum
					)
		AND [Style_Code] + [Size_Code] = (SELECT
						[StyleSize] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = @RowNum
					)
			AND [Grade_Code] = (SELECT
						[Grade_Code] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = @RowNum
					)
					
		AND [Grower_Number] = (SELECT
						[Grower_Number] 
					FROM [#QC_Temp]
					WHERE [RowNumber] = @RowNum
					)
	
	
	--Verify not already QC'd
	
		AND NOT (
				(Exporter + [Pallet_Prefix] + [Variety_Code]
				+  [Label_Code]  + [Variety_Code] + [Style_Code] + [Size_Code]
				+ [Grade_Code] + [Grower_Number] + CAST([Receipt_Number] AS VARCHAR(50)))   IN (SELECT
						(Exporter + [Pallet_Prefix] + [Variety_Code]
				+  [Label_Code]  + [Variety_Code] + [Style_Code] + [Size_Code]
				+ [Grade_Code] + [Grower_Number] + CAST([Receipt_Number] AS VARCHAR(50))) 
					FROM [QC_Archive_Test]
				)
		
	
			
		)--Should not have this combination
		
  ORDER BY QC_Key
  
  SET @RowNum = @RowNum + 1
  
  END
    
  