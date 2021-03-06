USE [PBIApplicationTables]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCreateTemplateTest]    Script Date: 02/01/2014 17:51:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: January 19, 2014
-- Description:	Creates a template or updates existing
-- Template.
-- =============================================
ALTER PROCEDURE [dbo].[UpdateCreateTemplateTest] 
	-- parameters for the stored procedure
	@Template_Name varchar(50),
	@ExporterRow [int],
	@ExporterColumn [int],
	@DepartureDateRow [int],
	@DepartureDateColumn [int],
	@VesselNumberRow [int],
	@VesselNumberColumn [int],
	@VesselNameRow [int],
	@VesselNameColumn [int],
	@DestinationRow [int],
	@DestinationColumn [int],
	@PrefixRow [int],
	@Prefix [int],
	@TagNumberRow [int],
	@TagNumberColumn [int],
	@CommodityRow [int],
	@CommodityColumn [int],
	@VarietyRow [int],
	@VarietyColumn [int],
	@StyleRow [int],
	@StyleColumn [int],
	@SizeRow [int],
	@SizeColumn [int],
	@GradeRow [int],
	@GradeColumn [int],
	@LabelRow [int],
	@LabelColumn [int],
	@PalletTypeRow [int],
	@PalletTypeColumn [int],
	@InventoryQuantityRow [int],
	@InventoryQuantityColumn [int],
	@FirstPackDateRow [int],
	@FirstPackDateColumn [int],
	@GrowerNumberRow [int],
	@GrowerNumberColumn [int],
	@HatchRow [int],
	@HatchColumn [int],
	@DeckRow [int],
	@DeckColumn [int],
	@FumigatedRow [int],
	@FumigatedColumn [int],
	@BillOfLadingRow [int],
	@BillOfLadingColumn [int],
	@MemoRow [int],
	@MemoColumn [int],
	@PackCodeRow [int],
	@PackCodeColumn [int],
	@Custom_Columns [int],
	@Other [int],
	@Data_Sheet [nvarchar](50),
	@Data_Range [nvarchar](50),
	@Special_Processing [nvarchar](50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

if(@Template_Name NOT IN (SELECT [Template_Name] FROM [Spreadsheet_Import_Templates_Test]))
	BEGIN
  INSERT INTO [Spreadsheet_Import_Templates_Test]
	(
	  [Template_Name]
      ,[ExporterRow]
      ,[ExporterColumn]
      ,[DepartureDateRow]
      ,[DepartureDateColumn]
      ,[VesselNumberRow]
      ,[VesselNumberColumn]
      ,[VesselNameRow]
      ,[VesselNameColumn]
      ,[DestinationRow]
      ,[DestinationColumn]
      ,[PrefixRow]
      ,[Prefix]
      ,[TagNumberRow]
      ,[TagNumberColumn]
      ,[CommodityRow]
      ,[CommodityColumn]
      ,[VarietyRow]
      ,[VarietyColumn]
      ,[StyleRow]
      ,[StyleColumn]
      ,[SizeRow]
      ,[SizeColumn]
      ,[GradeRow]
      ,[GradeColumn]
      ,[LabelRow]
      ,[LabelColumn]
      ,[PalletTypeRow]
      ,[PalletTypeColumn]
      ,[InventoryQuantityRow]
      ,[InventoryQuantityColumn]
      ,[FirstPackDateRow]
      ,[FirstPackDateColumn]
      ,[GrowerNumberRow]
      ,[GrowerNumberColumn]
      ,[HatchRow]
      ,[HatchColumn]
      ,[DeckRow]
      ,[DeckColumn]
      ,[FumigatedRow]
      ,[FumigatedColumn]
      ,[BillOfLadingRow]
      ,[BillOfLadingColumn]
      ,[MemoRow]
      ,[MemoColumn]
      ,[PackCodeRow]
      ,[PackCodeColumn]
      ,[Custom_Columns]
      ,[Other]
      ,[Data_Sheet]
      ,[Data_Range]
      ,[Special_Processing]
      )
  VALUES 
	(
		@Template_Name,
		@ExporterRow,
		@ExporterColumn,
		@DepartureDateRow,
		@DepartureDateColumn,
		@VesselNumberRow,
		@VesselNumberColumn,
		@VesselNameRow,
		@VesselNameColumn,
		@DestinationRow,
		@DestinationColumn,
		@PrefixRow,
		@Prefix,
		@TagNumberRow,
		@TagNumberColumn,
		@CommodityRow,
		@CommodityColumn,
		@VarietyRow,
		@VarietyColumn,
		@StyleRow,
		@StyleColumn,
		@SizeRow,
		@SizeColumn,
		@GradeRow,
		@GradeColumn,
		@LabelRow,
		@LabelColumn,
		@PalletTypeRow,
		@PalletTypeColumn,
		@InventoryQuantityRow,
		@InventoryQuantityColumn,
		@FirstPackDateRow,
		@FirstPackDateColumn,
		@GrowerNumberRow,
		@GrowerNumberColumn,
		@HatchRow,
		@HatchColumn,
		@DeckRow,
		@DeckColumn,
		@FumigatedRow,
		@FumigatedColumn,
		@BillOfLadingRow,
		@BillOfLadingColumn,
		@MemoRow,
		@MemoColumn,
		@PackCodeRow,
		@PackCodeColumn,
		@Custom_Columns,
		@Other,
		@Data_Sheet,
		@Data_Range,
		@Special_Processing	
    )
    END
    
  ELSE
    UPDATE [Spreadsheet_Import_Templates_Test]
    SET
		[Template_Name] = @Template_Name
      ,[ExporterRow] = @ExporterRow
      ,[ExporterColumn] = @ExporterColumn
      ,[DepartureDateRow] = @DepartureDateRow
      ,[DepartureDateColumn] = @DepartureDateColumn
      ,[VesselNumberRow] = @VesselNumberRow
      ,[VesselNumberColumn] = @VesselNumberColumn
      ,[VesselNameRow] = @VesselNameRow
      ,[VesselNameColumn] = @VesselNameColumn
      ,[DestinationRow] = @DestinationRow
      ,[DestinationColumn] = @DestinationColumn
      ,[PrefixRow] = @PrefixRow
      ,[Prefix] = @Prefix
      ,[TagNumberRow] = @TagNumberRow
      ,[TagNumberColumn] = @TagNumberColumn
      ,[VarietyRow] = @VarietyRow
      ,[VarietyColumn] = @VarietyColumn
      ,[StyleRow] = @StyleRow
      ,[StyleColumn] = @StyleColumn
      ,[SizeRow] = @SizeRow
      ,[SizeColumn] = @SizeColumn
      ,[GradeRow] = @GradeRow
      ,[GradeColumn] = @GradeColumn
      ,[LabelRow] = @LabelRow
      ,[LabelColumn] = @LabelColumn
      ,[PalletTypeRow] = @PalletTypeRow
      ,[PalletTypeColumn] = @PalletTypeColumn
      ,[InventoryQuantityRow] = @InventoryQuantityRow
      ,[InventoryQuantityColumn] = @InventoryQuantityColumn
      ,[FirstPackDateRow] = @FirstPackDateRow
      ,[FirstPackDateColumn] = @FirstPackDateColumn
      ,[GrowerNumberRow] = @GrowerNumberRow
      ,[GrowerNumberColumn] = @GrowerNumberColumn
      ,[HatchRow] = @HatchRow
      ,[HatchColumn] = @HatchColumn
      ,[DeckRow] = @DeckRow
      ,[DeckColumn] = @DeckColumn
      ,[FumigatedRow] = @FumigatedRow
      ,[FumigatedColumn] = @FumigatedColumn 
      ,[BillOfLadingRow] = @BillOfLadingRow
      ,[BillOfLadingColumn] = @BillOfLadingColumn
      ,[MemoRow] = @MemoRow
      ,[MemoColumn] = @MemoColumn
      ,[PackCodeRow] = @PackCodeRow
      ,[PackCodeColumn] = @PackCodeColumn
      ,[Custom_Columns] = @Custom_Columns
      ,[Other] = @Other
      ,[Data_Sheet] = @Data_Sheet
      ,[Data_Range] = @Data_Range
      ,[Special_Processing] = @Special_Processing
      ,[CommodityRow] = @CommodityRow
      ,[CommodityColumn] = @CommodityColumn
   WHERE [Template_Name] = @Template_Name
	
      

END
