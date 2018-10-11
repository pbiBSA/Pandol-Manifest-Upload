-- ================================================
-- Run this stored procedure to clear out old data
-- from the archive by entering the first few characters 
-- of the Vessel_Number to be removed.
-- It will first store all to be removed in the 
-- Archived_Data_Archive table then delete only those
-- that match the pattern entered and have been archived.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: April 4, 2014
-- Description:	Clears old data from archive
-- =============================================
ALTER PROCEDURE [ClearDataFromArchive] 
	-- Add the parameters for the stored procedure here
	 @PartOfVesselNumber  AS VARCHAR(50)


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;



	--SET @PartOfVesselNumber = '14'

	SET	@PartOfVesselNumber = @PartOfVesselNumber + '%'

INSERT INTO Archived_Data_Archive
(
[Receipt_Number]
      ,[Exporter]
      ,[Exporter_Name]
      ,[Departure_Date]
      ,[Vessel_Number]
      ,[Vessel_Name]
      ,[Destination]
      ,[Pallet_Prefix]
      ,[Warehouse]
      ,[Region]
      ,[Grower_Block]
      ,[Commodity_ID]
      ,[Transaction_Type]
      ,[Receiving_Date]
      ,[Method_Id]
      ,[Storage_ID]
      ,[Import_Template]
      ,[Pallet_Number]
      ,[Variety_Code]
      ,[Variety_Name]
      ,[Label_Code]
      ,[Style_Code]
      ,[Size_Code]
      ,[Pack_Code]
      ,[Grade_Code]
      ,[Pack_Date]
      ,[Grower_Number]
      ,[Boxes_Count]
      ,[Hatch]
      ,[Deck]
      ,[Fumigated]
      ,[Bill_of_Lading]
      ,[Pallet_Type]
      ,[Memo]
      ,[Other]
      ,[Test_Data]
      )

Select 
[Receipt_Number]
      ,[Exporter]
      ,[Exporter_Name]
      ,[Departure_Date]
      ,[Vessel_Number]
      ,[Vessel_Name]
      ,[Destination]
      ,[Pallet_Prefix]
      ,[Warehouse]
      ,[Region]
      ,[Grower_Block]
      ,[Commodity_ID]
      ,[Transaction_Type]
      ,[Receiving_Date]
      ,[Method_Id]
      ,[Storage_ID]
      ,[Import_Template]
      ,[Pallet_Number]
      ,[Variety_Code]
      ,[Variety_Name]
      ,[Label_Code]
      ,[Style_Code]
      ,[Size_Code]
      ,[Pack_Code]
      ,[Grade_Code]
      ,[Pack_Date]
      ,[Grower_Number]
      ,[Boxes_Count]
      ,[Hatch]
      ,[Deck]
      ,[Fumigated]
      ,[Bill_of_Lading]
      ,[Pallet_Type]
      ,[Memo]
      ,[Other]
      ,[Test_Data]
FROM FAPI_Import_Data_Archive
WHERE Vessel_Number LIKE @PartOfVesselNumber

  DELETE
  --SELECT *  --for testing
  FROM  FAPI_Import_Data_Archive  --Archived_Data_Archive
  WHERE FAPI_Import_Data_Archive.Vessel_Number In (Select Vessel_Number from Archived_Data_Archive)
	AND Vessel_Number LIKE @PartOfVesselNumber

END
GO
