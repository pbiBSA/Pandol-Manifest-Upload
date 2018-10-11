


--Update Name Role data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Name_Role_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Name_Role_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAMEIDX, NAMETYPE, INACTIVEFLAG FROM FC_NAME_ROLE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Name data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Name_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Name_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAMEIDX, LASTCONAME FROM FC_NAME')
	

--Update Variety Group data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Variety_Group_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Variety_Group_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC FROM IC_PS_VARIETY_GROUP')

	
--Update Style data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Style_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Style_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_STYLE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Storage data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Storage_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Storage_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_Storage')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Size data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Size_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Size_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_SIZE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Region data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Region_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Region_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_REGION')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Method data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Method_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Method_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_METHOD')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Label data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Label_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Label_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_LABEL')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Grade data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Grade_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Grade_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_GRADE')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Commodity data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Commodity_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Commodity_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_COMMODITY')
	WHERE [INACTIVEFLAG] = 'N'
	

--Update Grower Block data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Grower_Block_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Grower_Block_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT ID, NAME, INACTIVEFLAG, GROWERNAMEIDX, VARIETYIDX FROM GA_BLOCK')
	WHERE [INACTIVEFLAG] = 'N'

--Update Pallet Type data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Color_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Color_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT NAME, NAMEINVC, INACTIVEFLAG FROM IC_PS_COLOR')
	WHERE [INACTIVEFLAG] = 'N'
	
  
  --Update Variety data
 DELETE
 FROM [ApplicationSettings].[dbo].[Famous_Variety_Data]
 
 INSERT INTO [ApplicationSettings].[dbo].[Famous_Variety_Data]
SELECT *
FROM         
	OPENQUERY(FAMOUS, 'SELECT * FROM IC_PS_VARIETY')
	WHERE [INACTIVEFLAG] = 'N'
	
	
--Update the dropdown and translation-validation tables
EXEC [ApplicationSettings].[dbo].[sp_Manifest_Upload_App_Tables_Update]
	
	