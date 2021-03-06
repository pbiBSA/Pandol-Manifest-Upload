/****** Script for SelectTopNRows command from SSMS  ******/
TRUNCATE TABLE Translation_Details_Test


INSERT INTO Translation_Details_Test


SELECT TOP 1000 [GCV_Code]
      ,[Grower_Style_Code]
      ,[Famous_Style_Code]
      ,[Grower_Size_Code]
      ,[Famous_Size_Code]
      ,[Grower_Pack_Code]
      ,[Famous_Pack_Code]
      ,[Adams_Pack_Code]
      ,[Grower_Label_Code]
      ,[Famous_Label_Code]
      ,[Adams_Label_Code]
      ,[Grower_Grade_Code]
      ,[Famous_Grade_Code]
      ,[Adams_Grade_Code]
      ,[Grower_Pallet_Type]
      ,[Famous_Pallet_Type]
      ,[Adams_Pallet_Type]

  FROM [PBIApplicationTables].[dbo].[Translation_Details]