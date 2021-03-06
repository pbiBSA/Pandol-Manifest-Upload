USE [PBIApplicationTables]
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Data_From_Famous_And_Update_Tables]    Script Date: 12/31/2012 08:36:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: December 4, 2012
-- Description:	Pulls data from the linked Famous Database to update the working
-- table to update the application settings tables
-- =============================================
ALTER PROCEDURE [dbo].[sp_Get_Data_From_Famous_And_Update_Tables] 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   --Update Name Role data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Name_Role_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Name_Role_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAMEIDX, NAMETYPE, INACTIVEFLAG FROM FC_NAME_ROLE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Name data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Name_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Name_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAMEIDX, LASTCONAME FROM FC_NAME')
	

--Update Variety Group data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Variety_Group_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Variety_Group_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC FROM IC_PS_VARIETY_GROUP')

	
--Update Style data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Style_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Style_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_STYLE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Storage data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Storage_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Storage_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_Storage')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Size data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Size_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Size_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_SIZE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Region data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Region_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Region_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_REGION')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Method data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Method_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Method_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_METHOD')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Label data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Label_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Label_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_LABEL')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Grade data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Grade_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Grade_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_GRADE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Commodity data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Commodity_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Commodity_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, CMTYIDX, INACTIVEFLAG FROM IC_PS_COMMODITY')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Grower Block data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Grower_Block_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Grower_Block_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT ID, NAME, INACTIVEFLAG, GROWERNAMEIDX, VARIETYIDX FROM GA_BLOCK')
	WHERE [INACTIVEFLAG] = 'N'

--Update Pallet Type data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Color_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Color_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_COLOR')
	WHERE [INACTIVEFLAG] = 'N'
	
  
  --Update Variety data
 DELETE
 FROM [PBIApplicationTables].[dbo].[Famous_Variety_Data]
 
 INSERT INTO [PBIApplicationTables].[dbo].[Famous_Variety_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT * FROM IC_PS_VARIETY')
	WHERE [INACTIVEFLAG] = 'N'
	
	--Update Warehouse Data
DELETE 
FROM [PBIApplicationTables].[dbo].[Famous_Warehouse_Data]
INSERT INTO [PBIApplicationTables].[dbo].[Famous_Warehouse_Data]
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
	
	
--Update the dropdown and translation-validation tables
EXEC [PBIApplicationTables].[dbo].[sp_Manifest_Upload_App_Tables_Update]
END
