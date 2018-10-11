-- ================================================
-- 
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: October 12, 2013
-- Description:	Insert/update GDV and Translation
-- details data
-- =============================================
ALTER PROCEDURE UpdateGCV_InfoandTranslationDetails 
	-- Parameters for the stored procedure
	-- GCV Information parms
	 @GrowerName varchar(50),
	 @GrowerID Int,
	 @CommodityName Varchar(50),
	 @CommodityCode Varchar(50),
	 @GrowerCommodityCode Varchar(50),
	 @VarietyName Varchar(50),
	 @VarietyCode Varchar(50),
	 @GrowerVarietyCode Varchar(50),
	 @StoneFruit Varchar(10),
	 @GCV_ID Varchar(50),
	--Details Parms
	 @Style Varchar(50),
	 @GrowerStyle Varchar(50),
	 @Size Varchar(50),
	 @GrowerSize Varchar(50),
	 @Packcode Varchar(50),
	 @GrowerPackcode Varchar(50),
	 @Grade Varchar(50),
	 @GrowerGrade Varchar(50),
	 @Label Varchar(50),
	 @GrowerLabel Varchar(50),
	 @PalletType Varchar(50),
	 @GrowerPalletType Varchar(50)
	 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	--Update or add the GCV information to the GCV_Information table
    If(@GCV_ID IN (SELECT GCV_CODE FROM dbo.GCV_Information))
    BEGIN
    UPDATE GCV_Information
		SET
	  [Grower_ID] = @GrowerID
      ,[Grower_Name] = @GrowerName
      ,[Commodity_Code] = @CommodityCode
      ,[Commodity] = @CommodityName
      ,[Grower_Commodity_Code] = @GrowerCommodityCode
      ,[Variety_Code] = @VarietyCode
      ,[Variety] = @VarietyName
      ,[Grower_Variety_Code] = @GrowerVarietyCode
      ,[Stone_Fruit] = @StoneFruit
    WHERE GCV_Code = @GCV_ID 
    END
    
    ELSE
    BEGIN
    INSERT INTO dbo.GCV_Information
    (
      [Grower_ID]
      ,[Grower_Name]
      ,[Commodity_Code]
      ,[Commodity]
      ,[Grower_Commodity_Code]
      ,[Variety_Code]
      ,[Variety]
      ,[Grower_Variety_Code]
      ,[Stone_Fruit]
      ,[GCV_Code]
    )
    VALUES
    (
      @GrowerID
      ,@GrowerName
      ,@CommodityCode
      ,@CommodityName
      ,@GrowerCommodityCode
      ,@VarietyCode
      ,@VarietyName
      ,@GrowerVarietyCode
      ,@StoneFruit
      ,@GCV_ID 
      )
    END
    
    -- Add or update details information
    if(@GCV_ID + @Style + @Size + @Packcode + @Grade + 
		@Label + @PalletType IN 
		(SELECT GCV_Code + Famous_Style_Code + Famous_Size_Code + Famous_Grade_Code + 
				Famous_Label_Code + Famous_Pallet_Type AS SeachCode From dbo.Translation_Details))
	BEGIN
	UPDATE Translation_Details
	  SET 
		   [Grower_Style_Code] = ISNULL(@GrowerStyle,'')
		  ,[Grower_Size_Code] = ISNULL(@GrowerSize,'')
		  ,[Grower_Pack_Code] = @GrowerPackcode
		  ,[Grower_Label_Code] = @GrowerLabel
		  ,[Grower_Grade_Code] = ISNULL(@GrowerGrade,'')
		  ,[Grower_Pallet_Type] = @GrowerPalletType
		  
	  WHERE [GCV_Code] = @GCV_ID AND [Famous_Style_Code] = @Style AND [Famous_Size_Code] = @Size AND
			[Famous_Pack_Code] = @Packcode AND [Famous_Label_Code] = @Label AND 
			[Famous_Grade_Code] = @Grade AND [Famous_Pallet_Type] = @PalletType
	END
	
	ELSE
	BEGIN
	INSERT INTO dbo.Translation_Details
	(
	  [GCV_Code]
      ,[Grower_Style_Code]
      ,[Famous_Style_Code]
      ,[Grower_Size_Code]
      ,[Famous_Size_Code]
      ,[Grower_Pack_Code]
      ,[Famous_Pack_Code]
      ,[Grower_Label_Code]
      ,[Famous_Label_Code]
      ,[Grower_Grade_Code]
      ,[Famous_Grade_Code]
      ,[Grower_Pallet_Type]
      ,[Famous_Pallet_Type]
      )
      VALUES
      (
      @GCV_ID
      ,@GrowerStyle
      ,@Style
      ,@GrowerSize
      ,@Size
      ,@GrowerPackcode
      ,@Packcode
      ,@GrowerLabel
      ,@Label
      ,@GrowerGrade
      ,@Grade
      ,@GrowerPalletType
      ,@PalletType
      )
	END
END
GO
