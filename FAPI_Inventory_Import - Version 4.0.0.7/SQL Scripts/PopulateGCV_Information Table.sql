/****** Script for SelectTopNRows command from SSMS  ******/
TRUNCATE TABLE [PBIApplicationTables].[dbo].[GCV_Information]


INSERT INTO [PBIApplicationTables].[dbo].[GCV_Information]
	(
	  [Grower_ID]
      ,[Grower_Name]
      ,[Commodity_Code]
      ,[Commodity]
      ,[Variety_Code]
      ,[Variety]
      ,[Produce_Type]
      ,[GCV_Code]
    )
      
     SELECT     GrowerBlockData.GROWERNAMEIDX, 
				Grower_Name.Grower_Name, 
				Famous_Commodity_Data.NAME AS CommodityCode, 
				Famous_Commodity_Data.NAMEINVC AS Commodity, 
                VarietyData.NAME AS VarietyCode,
                VarietyData.NAMEINVC AS Variety, 
                'Soft',
                (CAST(GrowerBlockData.GROWERNAMEIDX AS VARChar(50)) + '-'
                + Famous_Commodity_Data.NAME + '-'
                + VarietyData.NAME) AS GCV_Code
                
FROM         GrowerBlockData INNER JOIN
                      Grower_Name ON GrowerBlockData.GROWERNAMEIDX = Grower_Name.Grower_Name_ID INNER JOIN
                      VarietyData ON GrowerBlockData.VARIETYIDX = VarietyData.VARIETYIDX INNER JOIN
                      Famous_Commodity_Data ON GrowerBlockData.CMTYIDX = Famous_Commodity_Data.CMTYIDX
