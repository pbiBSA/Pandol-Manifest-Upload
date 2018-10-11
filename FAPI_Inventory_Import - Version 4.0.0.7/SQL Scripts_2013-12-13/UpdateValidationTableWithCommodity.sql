

UPDATE Translation_Validation_Table TVT
SET Custom_Value = 
SELECT    DISTINCT Famous_Commodity_Data.NAME
FROM         Famous_Commodity_Data INNER JOIN
                      Famous_Variety_Data ON Famous_Commodity_Data.CMTYIDX = Famous_Variety_Data.CMTYIDX 
                      WHERE Famous_Variety_Data.NAME = TVT.Value
                      
                      