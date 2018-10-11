USE [PBIApplicationTables]
GO

/****** Object:  Table [dbo].[Spreadsheet_Import_Templates]    Script Date: 01/26/2014 09:48:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Spreadsheet_Import_Templates_Test](
	[Template_Name] [nvarchar](50) NOT NULL,
	[ExporterRow] [int] NOT NULL,
	[ExporterColumn] [int] NOT NULL,
	[DepartureDateRow] [int] NOT NULL,
	[DepartureDateColumn] [int] NOT NULL,
	[VesselNumberRow] [int] NOT NULL,
	[VesselNumberColumn] [int] NOT NULL,
	[VesselNameRow] [int] NOT NULL,
	[VesselNameColumn] [int] NOT NULL,
	[DestinationRow] [int] NOT NULL,
	[DestinationColumn] [int] NOT NULL,
	[PrefixRow] [int] NOT NULL,
	[Prefix] [int] NOT NULL,
	[TagNumberRow] [int] NOT NULL,
	[TagNumberColumn] [int] NOT NULL,
	[CommodityRow] [int] NOT NULL,
	[CommodityColumn] [int] NOT NULL,
	[VarietyRow] [int] NOT NULL,
	[VarietyColumn] [int] NOT NULL,
	[StyleRow] [int] NOT NULL,
	[StyleColumn] [int] NOT NULL,
	[SizeRow] [int] NOT NULL,
	[SizeColumn] [int] NOT NULL,
	[GradeRow] [int] NOT NULL,
	[GradeColumn] [int] NOT NULL,
	[LabelRow] [int] NOT NULL,
	[LabelColumn] [int] NOT NULL,
	[PalletTypeRow] [int] NOT NULL,
	[PalletTypeCoumn] [int] NOT NULL,
	[InventoryQuanityRow] [int] NOT NULL,
	[InventoryQuantityColumn] [int] NOT NULL,
	[FirstPackDateRow] [int] NOT NULL,
	[FirstPackDateColumn] [int] NOT NULL,
	[GrowerNumberRow] [int] NOT NULL,
	[GrowerNumberColumn] [int] NOT NULL,
	[HatchRow] [int] NOT NULL,
	[HatchColumn] [int] NOT NULL,
	[DeckRow] [int] NOT NULL,
	[DeckColumn] [int] NOT NULL,
	[FumigatedRow] [int] NOT NULL,
	[FumigatedColumn] [int] NOT NULL,
	[BillOfLadingRow] [int] NOT NULL,
	[BillOfLadingColumn] [int] NOT NULL,
	[MemoRow] [int] NOT NULL,
	[MemoColumn] [int] NOT NULL,
	[PackCodeRow] [int] NOT NULL,
	[PackCodeColumn] [int] NOT NULL,
	[Custom_Columns] [int] NOT NULL,
	[Other] [int] NOT NULL,
	[Data_Sheet] [nvarchar](50) NOT NULL,
	[Data_Range] [nvarchar](50) NOT NULL,
	[Special_Processing] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Spreadsheet_Import_Templates_Test] PRIMARY KEY CLUSTERED 
(
	[Template_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


