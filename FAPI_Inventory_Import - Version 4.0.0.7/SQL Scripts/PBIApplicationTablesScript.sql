USE [PBIApplicationTables]
GO
/****** Object:  User [AppSettingsUser]    Script Date: 01/03/2013 11:31:16 ******/
CREATE USER [AppSettingsUser] FOR LOGIN [AppSettingsUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Region_ID_Codes]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Region_ID_Codes](
	[Region_Description] [nvarchar](60) NOT NULL,
	[Region_Code] [nvarchar](16) NOT NULL,
	[Other] [nchar](10) NULL,
	[Region_Key] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_Region_ID_Codes] PRIMARY KEY CLUSTERED 
(
	[Region_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Method_ID_Codes]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Method_ID_Codes](
	[Method_Description] [nvarchar](60) NOT NULL,
	[Method_Code] [nvarchar](16) NOT NULL,
	[Other] [nchar](10) NULL,
	[Method_Key] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LastReceiptNumber]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LastReceiptNumber](
	[LastReceiptNumber] [int] NOT NULL,
	[GUID_Key] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_LastReceiptNumber] PRIMARY KEY CLUSTERED 
(
	[GUID_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventory_Warehouse_Codes]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventory_Warehouse_Codes](
	[Name] [nvarchar](60) NOT NULL,
	[Code] [nvarchar](40) NOT NULL,
	[Other] [nchar](10) NULL,
	[Warehouse_ID] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_Inventory_Warehouse_Codes] PRIMARY KEY CLUSTERED 
(
	[Warehouse_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GrowerBlockData]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrowerBlockData](
	[GABLOCKIDX] [varchar](50) NULL,
	[ID] [varchar](50) NULL,
	[NAME] [varchar](50) NULL,
	[BLOCKTYPE] [varchar](50) NULL,
	[GROWERNAMEIDX] [varchar](50) NULL,
	[GROWERLOCATIONSEQ] [varchar](50) NULL,
	[GACLASSIDX] [varchar](50) NULL,
	[DEPTIDX] [varchar](50) NULL,
	[COSTCENTERIDX] [varchar](50) NULL,
	[GASETLGRPIDX] [varchar](50) NULL,
	[CMTYIDX] [varchar](50) NULL,
	[VARIETYIDX] [varchar](50) NULL,
	[CHARGETAGSFLAG] [varchar](50) NULL,
	[ACRES] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL,
	[NOTESCOUNT] [varchar](50) NULL,
	[POOLREQUIREDFLAG] [varchar](50) NULL,
	[CTDESTTYPE] [varchar](50) NULL,
	[PRICENAMEIDX] [varchar](50) NULL,
	[GASETLREPACKTYPE] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grower_Name]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grower_Name](
	[Grower_Name] [varchar](100) NOT NULL,
	[Grower_Name_ID] [int] NOT NULL,
	[Grower_Key] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Grower_Name] PRIMARY KEY CLUSTERED 
(
	[Grower_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grower_Block_ID_Codes]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Grower_Block_ID_Codes](
	[Grower_Block_ID_Description] [nvarchar](50) NOT NULL,
	[Grower_Block_Code] [nvarchar](15) NOT NULL,
	[Other] [nchar](10) NULL,
	[Grower_Block_Key] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAPI_Import_Templates_Backup]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAPI_Import_Templates_Backup](
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
	[AddStyleSizeColumns] [int] NOT NULL,
	[AddGradeColumn] [int] NOT NULL,
	[AddPalletTypeColumn] [int] NOT NULL,
	[AddMemoColumn] [int] NOT NULL,
	[AddHatchDeckColumn] [int] NOT NULL,
	[PackCodeColumn] [int] NOT NULL,
	[Custom_1] [int] NOT NULL,
	[Other] [int] NOT NULL,
	[Data_Sheet] [nvarchar](50) NOT NULL,
	[Data_Range] [nvarchar](50) NOT NULL,
	[Special_Processing] [nvarchar](50) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAPI_Import_Templates]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAPI_Import_Templates](
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
	[AddStyleSizeColumns] [int] NOT NULL,
	[AddGradeColumn] [int] NOT NULL,
	[AddPalletTypeColumn] [int] NOT NULL,
	[AddMemoColumn] [int] NOT NULL,
	[AddHatchDeckColumn] [int] NOT NULL,
	[PackCodeColumn] [int] NOT NULL,
	[Custom_1] [int] NOT NULL,
	[Other] [int] NOT NULL,
	[Data_Sheet] [nvarchar](50) NOT NULL,
	[Data_Range] [nvarchar](50) NOT NULL,
	[Special_Processing] [nvarchar](50) NOT NULL,
	[CommodityRow] [int] NOT NULL,
	[CommodityColumn] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Famous_Warehouse_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Warehouse_Data](
	[Description] [varchar](100) NOT NULL,
	[WarehouseIDX] [int] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Variety_Group_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Variety_Group_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Variety_Data_Test]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Variety_Data_Test](
	[VARIETYIDX] [varchar](50) NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[CMTYIDX] [varchar](50) NULL,
	[VARIETYGROUPIDX] [varchar](50) NULL,
	[PRODUCTGROUPTWOIDX] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Variety_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Variety_Data](
	[VARIETYIDX] [varchar](50) NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[CMTYIDX] [varchar](50) NULL,
	[VARIETYGROUPIDX] [varchar](50) NULL,
	[PRODUCTGROUPTWOIDX] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Style_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Style_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Storage_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Storage_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Size_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Size_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Region_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Region_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Name_Role_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Name_Role_Data](
	[NAMEIDX] [varchar](50) NULL,
	[NAMETYPE] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Name_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Name_Data](
	[NAMEIDX] [varchar](50) NULL,
	[LASTCONAME] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Method_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Method_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Label_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Label_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Grower_Block_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Grower_Block_Data](
	[ID] [varchar](50) NULL,
	[NAME] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL,
	[GROWERNAMEIDX] [int] NULL,
	[VARIETYIDX] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Grade_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Grade_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Commodity_Data_OLD]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Commodity_Data_OLD](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Commodity_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Commodity_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[CMTYIDX] [int] NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Color_Data]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Color_Data](
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_BlockID]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_BlockID](
	[ID] [varchar](50) NULL,
	[NAME] [varchar](50) NULL,
	[BLOCKTYPE] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Commodity_Codes]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commodity_Codes](
	[Commodity_Code] [nvarchar](50) NOT NULL,
	[Commodity_Description] [nvarchar](50) NOT NULL,
	[Commodity_Index] [int] NOT NULL,
	[Other] [nchar](10) NULL,
	[Commodity_Key] [uniqueidentifier] ROWGUIDCOL  NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Adams_Values]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Adams_Values](
	[Data_Column_Name] [varchar](50) NOT NULL,
	[Value] [varchar](50) NOT NULL,
	[Adams_Value] [varchar](50) NOT NULL,
	[Adams_Key] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_Adams_Values] PRIMARY KEY CLUSTERED 
(
	[Adams_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VarietyData]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VarietyData](
	[VARIETYIDX] [varchar](50) NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[CMTYIDX] [varchar](50) NULL,
	[VARIETYGROUPIDX] [varchar](50) NULL,
	[PRODUCTGROUPTWOIDX] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Translation_Validation_Table_Old]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Translation_Validation_Table_Old](
	[Data_Column_Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Value] [varchar](50) NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Adams_Value] [varchar](50) NULL,
	[Style] [varchar](50) NULL,
	[Size] [varchar](50) NULL,
	[Custom_Value] [varchar](50) NULL,
	[Ignore] [int] NULL,
	[Validation_Key] [uniqueidentifier] NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Translation_Validation_Table]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Translation_Validation_Table](
	[Data_Column_Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Value] [varchar](50) NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Adams_Value] [varchar](50) NULL,
	[Style] [varchar](50) NULL,
	[Size] [varchar](50) NULL,
	[Custom_Value] [varchar](50) NULL,
	[Ignore] [int] NULL,
	[Famous_Validate] [int] NULL,
	[Validation_Key] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_Translation_Validation_Table] PRIMARY KEY CLUSTERED 
(
	[Validation_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Storage_ID_Codes]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Storage_ID_Codes](
	[Storage_Description] [nvarchar](60) NOT NULL,
	[Storage_Code] [nvarchar](16) NOT NULL,
	[Other] [nchar](10) NULL,
	[Storage_Key] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Storage_ID_Codes] PRIMARY KEY CLUSTERED 
(
	[Storage_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Spreadsheet_Import_Templates]    Script Date: 01/03/2013 11:31:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Spreadsheet_Import_Templates](
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
 CONSTRAINT [PK_Spreadsheet_Import_Templates] PRIMARY KEY CLUSTERED 
(
	[Template_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_Manifest_Upload_App_Tables_Update]    Script Date: 01/03/2013 11:31:16 ******/
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
CREATE PROCEDURE [dbo].[sp_Manifest_Upload_App_Tables_Update] 
	
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
GO
/****** Object:  StoredProcedure [dbo].[sp_Get_Data_From_Famous_And_Update_Tables]    Script Date: 01/03/2013 11:31:16 ******/
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
CREATE PROCEDURE [dbo].[sp_Get_Data_From_Famous_And_Update_Tables] 

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
GO
/****** Object:  Default [DF_Adams_Values_Adams_Key]    Script Date: 01/03/2013 11:31:14 ******/
ALTER TABLE [dbo].[Adams_Values] ADD  CONSTRAINT [DF_Adams_Values_Adams_Key]  DEFAULT (newid()) FOR [Adams_Key]
GO
/****** Object:  Default [DF_Commodity_Codes_Commodity_Key]    Script Date: 01/03/2013 11:31:14 ******/
ALTER TABLE [dbo].[Commodity_Codes] ADD  CONSTRAINT [DF_Commodity_Codes_Commodity_Key]  DEFAULT (newid()) FOR [Commodity_Key]
GO
/****** Object:  Default [DF_Inventory_Warehouse_Codes_Warehouse_ID]    Script Date: 01/03/2013 11:31:14 ******/
ALTER TABLE [dbo].[Inventory_Warehouse_Codes] ADD  CONSTRAINT [DF_Inventory_Warehouse_Codes_Warehouse_ID]  DEFAULT (newid()) FOR [Warehouse_ID]
GO
/****** Object:  Default [DF_LastReceiptNumber_GUID_Key]    Script Date: 01/03/2013 11:31:14 ******/
ALTER TABLE [dbo].[LastReceiptNumber] ADD  CONSTRAINT [DF_LastReceiptNumber_GUID_Key]  DEFAULT (newid()) FOR [GUID_Key]
GO
/****** Object:  Default [DF_Region_ID_Codes_Region_Key]    Script Date: 01/03/2013 11:31:14 ******/
ALTER TABLE [dbo].[Region_ID_Codes] ADD  CONSTRAINT [DF_Region_ID_Codes_Region_Key]  DEFAULT (newid()) FOR [Region_Key]
GO
/****** Object:  Default [DF_Translation_Validation_Table_Validation_Key]    Script Date: 01/03/2013 11:31:14 ******/
ALTER TABLE [dbo].[Translation_Validation_Table] ADD  CONSTRAINT [DF_Translation_Validation_Table_Validation_Key]  DEFAULT (newid()) FOR [Validation_Key]
GO
