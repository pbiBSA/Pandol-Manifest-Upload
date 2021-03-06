/****** Script for SelectTopNRows command from SSMS  ******/


TRUNCATE TABLE [GCV_Information_Test]

INSERT INTO [GCV_Information_Test]

SELECT TOP 1000 [Grower_ID]
      ,[Grower_Name]
      ,[Commodity_Code]
      ,[Commodity]
      ,[Grower_Commodity_Code]
      ,[Variety_Code]
      ,[Variety]
      ,[Grower_Variety_Code]
      ,[Stone_Fruit]
      ,[GCV_Code]
  FROM [PBIApplicationTables].[dbo].[GCV_Information]