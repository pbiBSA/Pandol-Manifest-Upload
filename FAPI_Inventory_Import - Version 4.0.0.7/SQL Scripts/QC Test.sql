/****** Script for SelectTopNRows command from SSMS  ******/

  DELETE
  FROM QC_Temp

  INSERT INTO QC_Temp

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
  --INTO QC_Temp
  FROM [ImportDataWarehouse].[dbo].[FAPI_QC_Pallet_Selection]
  WHERE Boxes_Count >= 50 --Only use pallets with more than 50 boxes
  GROUP BY Exporter, [Pallet_Prefix], Variety_Code, Label_Code, [Style_Code] + [Size_Code], Grower_Number, [Grade_Code]
    ORDER BY 
    Exporter, Variety_Code, Label_Code, [Style_Code] + [Size_Code], Grower_Number