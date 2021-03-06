USE [ImportDataWarehouse]
GO
/****** Object:  StoredProcedure [dbo].[UpdateQCArchiveTable_Test]    Script Date: 11/29/2014 11:44:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =========================================================
-- Author:		Mikhael Brown
-- Create date: October 26, 2014
-- Description:	Updates the list of pallets and the data
-- that are selected for QC and marked QC in the memo column
-- =========================================================
ALTER PROCEDURE [dbo].[UpdateQCArchiveTable_Test2]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;




--Create a temp table to hold the signature of pallets to QC and the number of to QC
  --DROP TABLE [#QC_Temp]
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
	
--Fill temp table with criteria for QC selection
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
      ,((
			CASE
				COUNT(DISTINCT Pallet_Number) When 1 THEN 2  --Should at least have one pallet
			    ELSE COUNT(DISTINCT Pallet_Number) END)/2) 
	  AS [Number Pallets to check]  
  
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
    
    
  --Update memo field in archive table for Pallets to QC
  Update [FAPI_Import_Data_Archive_Test]
  SET Memo = (Select [Memo] FROM QC_Archive_Test
			WHERE Pallet_Number = 
				FAPI_Import_Data_Archive_Test.Pallet_Number)
			
  

END
