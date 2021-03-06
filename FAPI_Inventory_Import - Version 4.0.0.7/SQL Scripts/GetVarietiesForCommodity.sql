USE [PBIApplicationTables]
GO
/****** Object:  StoredProcedure [dbo].[GetVarietiesForCommodity]    Script Date: 10/19/2013 10:08:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: October 5, 2013
-- Description:	Returns the varities for a given
-- commodity
-- =============================================
ALTER PROCEDURE [dbo].[GetVarietiesForCommodity]
	@Commodity VarChar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  SELECT     Famous_Variety_Data.NAME AS Variety_Code, Famous_Variety_Data.NAMEINVC AS Variety_Name, Famous_Commodity_Data.NAME AS Commodity_Code, 
                      Famous_Commodity_Data.NAMEINVC AS Commodity, CASE ISNULL(Commodity, '0') WHEN '0' THEN 'N' ELSE 'Y' END AS Stone_Fruit
  FROM         Famous_Variety_Data INNER JOIN
                      Famous_Commodity_Data ON Famous_Variety_Data.CMTYIDX = Famous_Commodity_Data.CMTYIDX LEFT OUTER JOIN
                      StoneFuitCommodities ON Famous_Commodity_Data.NAME = StoneFuitCommodities.Commodity
  WHERE     (Famous_Variety_Data.INACTIVEFLAG = 'N') AND (Famous_Commodity_Data.INACTIVEFLAG = 'N')
		  AND (Famous_Commodity_Data.NAME = @Commodity)
  ORDER BY Famous_Variety_Data.NAMEINVC
END
