/****** Script for SelectTopNRows command from SSMS  ******/
SELECT     GCV_Information.Grower_ID, GCV_Information.Grower_Name, GCV_Information.Commodity_Code, GCV_Information.Commodity, GCV_Information.Variety_Code, 
                      GCV_Information.Variety, GCV_Information.Produce_Type, GCV_Information.GCV_Code, Translation_Details.Grower_Style_Code, 
                      Translation_Details.Famous_Style_Code, Translation_Details.Grower_Size_Code, Translation_Details.Famoust_Size_Code, Translation_Details.Grower_Pack_Code, 
                      Translation_Details.Famoust_Pack_Code, Translation_Details.Adams_Pack_Code, Translation_Details.Grower_Label_Code, Translation_Details.Famous_Label_Code, 
                      Translation_Details.Adams_Label_Code, Translation_Details.Grower_Grade_Code, Translation_Details.Famous_Grade_Code, 
                      Translation_Details.Adams_Grade_Code, Translation_Details.Grower_Pallet_Type, Translation_Details.Famous_Pallet_Type, 
                      Translation_Details.Adams_Pallet_Type
FROM         GCV_Information INNER JOIN
                      Translation_Details ON GCV_Information.GCV_Code = Translation_Details.GCV_Code