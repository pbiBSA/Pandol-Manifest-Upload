USE [PBIApplicationTables]
GO
/****** Object:  StoredProcedure [dbo].[sp_Manifest_Upload_App_Tables_Update]    Script Date: 12/31/2012 08:36:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: November 14, 2012
-- Description:	Updates the manifest upload data tables with famous data
-- from tables imported into the database
-- Added updates for Grower Names 11/29/2012
-- Added updates for commodity by variety
-- =============================================
ALTER PROCEDURE [dbo].[sp_Manifest_Upload_App_Tables_Update] 
	
AS
BEGIN
SET NOCOUNT ON;

-- Update and add new entries into Translation-Validation Table
--	Update Varieties
DELETE  --Remove old entries
FROM Translation_Validation_Table
WHERE [Translation_Validation_Table].[Famous_Validate] = 1 AND
 [Translation_Validation_Table].[Data_Column_Name] = 'Variety'
 
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Variety', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL, 1, (newid())
FROM Famous_Variety_Data
WHERE NAMEINVC NOT in (Select [Description] FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Variety')
	


--	Update Commodities
DELETE
FROM Translation_Validation_Table
WHERE [Translation_Validation_Table].[Famous_Validate] = 1 AND
 [Translation_Validation_Table].[Data_Column_Name] = 'Commodity'
 
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Commodity', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL, 1, (newid())
FROM Famous_Commodity_Data
WHERE NAMEINVC NOT in (Select [Description] FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Commodity')
	
--Update Varity Commodities
UPDATE Translation_Validation_Table
SET Custom_Value = 
 Famous_Commodity_Data.NAME
FROM Famous_Commodity_Data INNER JOIN
     Famous_Variety_Data ON Famous_Commodity_Data.CMTYIDX = Famous_Variety_Data.CMTYIDX INNER JOIN
     Translation_Validation_Table ON Famous_Variety_Data.NAME = Translation_Validation_Table.Value
 Where Translation_Validation_Table.Value = Famous_Variety_Data.NAME


--Update Labels
DELETE  --Remove old entries
FROM Translation_Validation_Table
WHERE [Translation_Validation_Table].[Famous_Validate] = 1 AND
 [Translation_Validation_Table].[Data_Column_Name] = 'Label'
 
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Label', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL, 1, (newid())
FROM Famous_Label_Data
WHERE NAMEINVC NOT in (Select [Description] FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Label')

--Update Grades
DELETE  --Remove old entries
FROM Translation_Validation_Table
WHERE [Translation_Validation_Table].[Famous_Validate] = 1 AND
 [Translation_Validation_Table].[Data_Column_Name] = 'Grade'
 
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Grade', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL, 1,(newid())
FROM Famous_Grade_Data
WHERE NAMEINVC NOT in (Select [Description] FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Grade')

--Update Pallet Types
DELETE  --Remove old entries
FROM Translation_Validation_Table
WHERE [Translation_Validation_Table].[Famous_Validate] = 1 AND
 [Translation_Validation_Table].[Data_Column_Name] = 'PalletType'
 
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'PalletType', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL, 1, (newid())
FROM Famous_Color_Data
WHERE NAMEINVC NOT in (Select [Description] FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'PalletType')

--Update Sizes
DELETE  --Remove old entries
FROM Translation_Validation_Table
WHERE [Translation_Validation_Table].[Famous_Validate] = 1 AND
 [Translation_Validation_Table].[Data_Column_Name] = 'Size'
 
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Size', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL, 1, (newid())
FROM Famous_Size_Data
WHERE NAMEINVC NOT in (Select [Description] FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Size')

--Update Styles
DELETE  --Remove old entries
FROM Translation_Validation_Table
WHERE [Translation_Validation_Table].[Famous_Validate] = 1 AND
 [Translation_Validation_Table].[Data_Column_Name] = 'Style'
 
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Style', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL, 1, (newid())
FROM Famous_Style_Data
WHERE NAMEINVC NOT in (Select [Description] FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Style')
	
--Update the Adams Values for the Translation table
UPDATE [Translation_Validation_Table]
SET [Translation_Validation_Table].[Adams_Value] =
		AT.[Adams_Value]
FROM [dbo].[Adams_Values] AT
WHERE [dbo].[Translation_Validation_Table].[Data_Column_Name] =
		AT.[Data_Column_Name] AND 
		[dbo].[Translation_Validation_Table].[Value] =
		AT.[Value] AND dbo.Translation_Validation_Table.Famous_Validate = 1


--Dropdown Updates ************************
--Add missing Grower Block
DELETE
FROM Grower_Block_ID_Codes
INSERT INTO Grower_Block_ID_Codes
SELECT DISTINCT NAME, [ID], NULL, (newid())
FROM Famous_Grower_Block_Data
WHERE [INACTIVEFLAG] = 'N'

--Add missing Commodity Codes
DELETE
FROM Commodity_Codes
INSERT INTO Commodity_Codes
SELECT DISTINCT NAME, NAMEINVC, CMTYIDX, NULL, (newid())
FROM Famous_Commodity_Data
WHERE [INACTIVEFLAG] = 'N'

--Add missing regions
DELETE
FROM Region_ID_Codes
INSERT INTO Region_ID_Codes
SELECT DISTINCT NAME, NAMEINVC, NULL, (newid())
FROM Famous_Region_Data
WHERE [INACTIVEFLAG] = 'N'
	
--Add missing MethodID Codes
DELETE
FROM Method_ID_Codes
INSERT INTO Method_ID_Codes
SELECT DISTINCT NAME, NAMEINVC, NULL, (newid())
FROM Famous_Method_Data
WHERE [INACTIVEFLAG] = 'N'

--Add missing Storage ID Codes
DELETE
FROM Storage_ID_Codes
INSERT INTO Storage_ID_Codes
SELECT DISTINCT NAME, NAMEINVC, NULL, (newid())
FROM Famous_Storage_Data
WHERE [INACTIVEFLAG] = 'N'
	
--Update Grower names
DELETE
FROM Grower_Name
INSERT INTO Grower_Name
SELECT Famous_Name_Data.LASTCONAME, Famous_Name_data.NAMEIDX, (newid())
FROM Famous_Name_Data, Famous_Name_Role_Data
WHERE  Famous_Name_Data.NAMEIDX = Famous_Name_Role_Data.NAMEIDX
AND Famous_Name_Role_Data.NAMETYPE = 9 AND 
Famous_Name_Role_Data.INACTIVEFLAG = 'N'

DELETE
FROM Inventory_Warehouse_Codes
INSERT INTO Inventory_Warehouse_Codes
SELECT DISTINCT [Description], [Description], NULL, (newid())
FROM Famous_Warehouse_Data




    
END
