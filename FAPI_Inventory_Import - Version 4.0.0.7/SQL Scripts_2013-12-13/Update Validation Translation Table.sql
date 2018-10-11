USE [ApplicationSettings]
GO

--Add missing Varieties
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Variety', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL
FROM IC_PS_VARIETY_DATA_TABLE
WHERE NAME NOT in (Select Value FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Variety')

--Add missing Labels
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Label', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL
FROM IC_PS_LABEL_DATA_TABLE
WHERE NAME NOT in (Select Value FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Label')

--Add missing Grades
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Grade', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL
FROM IC_PS_GRADE_DATA_TABLE
WHERE NAME NOT in (Select Value FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Grade')

--Add missing Pallet Types
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'PalletType', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL
FROM IC_PS_COLOR_DATA_TABLE
WHERE NAME NOT in (Select Value FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'PalletType')

--Add missing Sizes
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Size', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL
FROM IC_PS_SIZE_DATA_TABLE
WHERE NAME NOT in (Select Value FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Size')

--Add missing Styles
INSERT INTO Translation_Validation_Table
SELECT DISTINCT 'Style', NAMEINVC, NAME, NULL, NULL, NULL, NULL, NULL, NULL
FROM IC_PS_Style_DATA_TABLE
WHERE NAME NOT in (Select Value FROM Translation_Validation_Table
	WHERE [Data_Column_Name] = 'Style')



--Dropdown Updates ************************
--Add missing Grower Block
INSERT INTO Grower_Block_ID_Codes
SELECT DISTINCT NAME, [ID], NULL
FROM GA_BLOCK_DATA_TABLE
WHERE [ID] NOT in (Select [Grower_Block_Code] FROM Grower_Block_ID_Codes)
	AND [INACTIVEFLAG] = 'N'

--Add missing Commodity Codes
INSERT INTO Commodity_Codes
SELECT DISTINCT NAME, NAMEINVC, NULL
FROM IC_PS_COMMODITY_DATA_TABLE
WHERE NAME NOT in (Select Commodity_Code FROM Commodity_Codes)
	AND [INACTIVEFLAG] = 'N'

--Add missing regions
INSERT INTO Region_ID_Codes
SELECT DISTINCT NAME, NAMEINVC, NULL
FROM IC_PS_REGION_DATA_TABLE
WHERE NAME NOT in (Select Region_Description FROM Region_ID_Codes)
	AND [INACTIVEFLAG] = 'N'

