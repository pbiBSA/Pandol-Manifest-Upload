USE [ImportDataWarehouse]
GO
/****** Object:  StoredProcedure [dbo].[UpdateTablesFromFamous]    Script Date: 01/02/2013 08:35:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: December 18, 2012
-- Description:	Gets data for reporting from Famous
-- Added famous tables from application settings.
-- December 27, 2012 add inventory table export
-- =============================================
ALTER PROCEDURE [dbo].[UpdateTablesFromFamous] 
	
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   --Get and update grower table
   DELETE 
FROM [ImportDataWarehouse].[dbo].[GrowerNames]

INSERT INTO [ImportDataWarehouse].[dbo].[GrowerNames]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAMEIDX, LastCONAME
FROM fc_name
join ga_grower 
on ga_grower.growernameidx = fc_name.nameidx')

  --Lot Number and Description 
DELETE
FROM [ImportDataWarehouse].[dbo].[LotNumberDescription]

INSERT INTO [ImportDataWarehouse].[dbo].[LotNumberDescription]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT GALOTIDX, ID, DESCR, ICCLOSEDFLAG, CLOSEDATE
FROM GA_LOT
WHERE DESCR IS NOT NULL')

--Reciept Number, Grower Block, Lot ID
DELETE 
FROM [ImportDataWarehouse].[dbo].[ReceiptNumberLotIDGrowerBlock]

INSERT INTO [ImportDataWarehouse].[dbo].[ReceiptNumberLotIDGrowerBlock]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT DISTINCT ICTRXHDRIDX, GALOTIDX, GABLOCKIDX, RECEIVEDATE
FROM IC_INVENTORY
WHERE ICTRXHDRIDX > 3300000 AND ICTRXHDRIDX < 9000000
ORDER BY ICTRXHDRIDX')

  --Update Name Role data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Name_Role_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Name_Role_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAMEIDX, NAMETYPE, INACTIVEFLAG FROM FC_NAME_ROLE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Name data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Name_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Name_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAMEIDX, LASTCONAME FROM FC_NAME')
	

--Update Variety Group data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Variety_Group_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Variety_Group_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT VARIETYGROUPIDX, CMTYIDX, NAME, NAMEINVC FROM IC_PS_VARIETY_GROUP')

	
--Update Style data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Style_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Style_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT STYLEIDX, CMTYIDX, NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_STYLE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Storage data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Storage_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Storage_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT STORAGEIDX, NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_Storage')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Size data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Size_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Size_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT SIZEIDX, CMTYIDX, STYLEIDX, NAME, NAMEINVC, UNITSPERPALLET, INACTIVEFLAG FROM IC_PS_SIZE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Region data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Region_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Region_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT REGIONIDX, NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_REGION')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Method data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Method_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Method_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT METHODIDX, NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_METHOD')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Label data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Label_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Label_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT LABELIDX, NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_LABEL')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Grade data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Grade_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Grade_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT GRADEIDX, NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_GRADE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Commodity data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Commodity_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Commodity_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, CMTYIDX, INACTIVEFLAG FROM IC_PS_COMMODITY')
	WHERE [INACTIVEFLAG] = 'N'
	


--Update Pallet Type data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Color_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Color_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT COLORIDX, NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_COLOR')
	WHERE [INACTIVEFLAG] = 'N'
	
  
  --Update Variety data
 DELETE
 FROM [ImportDataWarehouse].[dbo].[Famous_Variety_Data]
 
 INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Variety_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT * FROM IC_PS_VARIETY')
	WHERE [INACTIVEFLAG] = 'N'
	
	--Update Warehouse Data
DELETE 
FROM [ImportDataWarehouse].[dbo].[Famous_Warehouse_Data]
INSERT INTO [ImportDataWarehouse].[dbo].[Famous_Warehouse_Data]
SELECT     
	NL.DESCR, 
	WH.WAREHOUSEIDX
FROM         
	OPENQUERY(FAMOUS, 'SELECT * FROM IC_WAREHOUSE') WH
	inner join
	OPENQUERY(FAMOUS, 'SELECT * FROM  FC_NAME_LOCATION') nl
	on wh.nameidx = nl.nameidx
	AND Wh.NAMELOCATIONSEQ = NL.NAMELOCATIONSEQ 
	WHERE Wh.INVENTORYFLAG = 'Y' AND Wh.ICDEPTIDX is null
	Order by NL.DESCR
	
	--Update Inventory Data
DELETE 
FROM Famous_Produce_Inventory_Data
INSERT INTO Famous_Produce_Inventory_Data
SELECT INVENTORYIDX, TAGIDX, WAREHOUSEIDX, INC.PRODUCTIDX, GABLOCKIDX,
	GALOTIDX, RECEIVEDATE, RECVQNT, RECVCOST, ISSUEQNT, ISSUECOST, QUALITYIDX, 
    AVAILABLEFLAG, SALEAMOUNT, RECEIPTAMOUNT, RECEIPTDATE, 
	REGIONIDX, METHODIDX, CMTYIDX,
      STYLEIDX, SIZEIDX, VARIETYIDX, LABELIDX, STORAGEIDX,
      COLORIDX, NAMEINVC, NAMEGROWER, NULL
FROM         
	OPENQUERY(FAMOUS, 'SELECT INVENTORYIDX, TAGIDX, WAREHOUSEIDX, PRODUCTIDX, GABLOCKIDX,
	GALOTIDX, RECEIVEDATE, RECVQNT, RECVCOST, ISSUEQNT, ISSUECOST, QUALITYIDX, 
    AVAILABLEFLAG, SALEAMOUNT, RECEIPTAMOUNT, RECEIPTDATE 
	FROM  IC_INVENTORY') INC
	INNER JOIN
	OPENQUERY(FAMOUS, 'SELECT PRODUCTIDX, REGIONIDX, METHODIDX, CMTYIDX,
      STYLEIDX, SIZEIDX, VARIETYIDX, LABELIDX, STORAGEIDX,
      COLORIDX, NAMEINVC, NAMEGROWER
      FROM IC_PRODUCT_PRODUCE')  PP
      ON INC.PRODUCTIDX = PP.PRODUCTIDX
	
	 --     INNER JOIN 
--    OPENQUERY(FAMOUS, 'SELECT TAGIDX, ID FROM IC_TAG') TID
 --     ON INC.TAGIDX = TID.TAGIDX
	
	



END
