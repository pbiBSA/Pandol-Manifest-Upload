USE [ImportDataWarehouse]
GO
/****** Object:  User [AppSettingsUser]    Script Date: 01/03/2013 11:50:27 ******/
CREATE USER [AppSettingsUser] FOR LOGIN [AppSettingsUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [Report_User]    Script Date: 01/03/2013 11:50:27 ******/
CREATE USER [Report_User] FOR LOGIN [Report_User] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [ReportUser]    Script Date: 01/03/2013 11:50:27 ******/
CREATE USER [ReportUser] FOR LOGIN [ReportUser] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[ReceiptNumberLotIDGrowerBlock]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ReceiptNumberLotIDGrowerBlock](
	[ReceiptNumber] [int] NOT NULL,
	[GrowerLotIDX] [int] NULL,
	[GrowerBlockIDX] [int] NULL,
	[ReceiveDate] [date] NULL,
	[DeleteFlag] [varchar](1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LotNumberDescription]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LotNumberDescription](
	[LOTIDX] [int] NOT NULL,
	[LOTID] [nvarchar](20) NOT NULL,
	[Description] [varchar](50) NULL,
	[ClosedFlag] [char](1) NULL,
	[CloseDate] [date] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GrowerNames]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GrowerNames](
	[NameIdx] [int] NOT NULL,
	[GrowerName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_GrowerNames] PRIMARY KEY CLUSTERED 
(
	[NameIdx] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Grower_Block_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Grower_Block_Data](
	[GROWERBLOCKIDX] [int] NOT NULL,
	[ID] [varchar](50) NULL,
	[NAME] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL,
	[GROWERNAMEIDX] [int] NULL,
	[VARIETYIDX] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FAPI_Import_Data_Archive_Test_Bk]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FAPI_Import_Data_Archive_Test_Bk](
	[Receipt_Number] [int] NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Exporter_Name] [varchar](50) NULL,
	[Departure_Date] [varchar](50) NULL,
	[Vessel_Number] [varchar](50) NULL,
	[Vessel_Name] [varchar](50) NULL,
	[Destination] [varchar](50) NULL,
	[Pallet_Prefix] [varchar](10) NOT NULL,
	[Warehouse] [varchar](50) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[Grower_Block] [varchar](50) NOT NULL,
	[Commodity_ID] [varchar](50) NOT NULL,
	[Transaction_Type] [varchar](10) NOT NULL,
	[Receiving_Date] [varchar](50) NOT NULL,
	[Method_Id] [varchar](50) NOT NULL,
	[Storage_ID] [varchar](50) NOT NULL,
	[Import_Template] [varchar](50) NOT NULL,
	[Pallet_Number] [varchar](50) NOT NULL,
	[Variety_Code] [varchar](50) NOT NULL,
	[Variety_Name] [varchar](50) NULL,
	[Label_Code] [varchar](50) NOT NULL,
	[Style_Code] [varchar](50) NULL,
	[Size_Code] [varchar](50) NULL,
	[Pack_Code] [varchar](50) NULL,
	[Grade_Code] [varchar](50) NOT NULL,
	[Pack_Date] [varchar](50) NOT NULL,
	[Grower_Number] [varchar](50) NOT NULL,
	[Boxes_Count] [int] NOT NULL,
	[Hatch] [varchar](50) NULL,
	[Deck] [varchar](50) NULL,
	[Fumigated] [int] NULL,
	[Bill_of_Lading] [varchar](50) NULL,
	[Pallet_Type] [varchar](50) NULL,
	[Memo] [varchar](max) NULL,
	[Other] [varchar](50) NULL,
	[Test_Data] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FAPI_Import_Data_Archive_Test]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FAPI_Import_Data_Archive_Test](
	[Receipt_Number] [int] NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Exporter_Name] [varchar](50) NULL,
	[Departure_Date] [varchar](50) NULL,
	[Vessel_Number] [varchar](50) NULL,
	[Vessel_Name] [varchar](50) NULL,
	[Destination] [varchar](50) NULL,
	[Pallet_Prefix] [varchar](10) NOT NULL,
	[Warehouse] [varchar](50) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[Grower_Block] [varchar](50) NOT NULL,
	[Commodity_ID] [varchar](50) NOT NULL,
	[Transaction_Type] [varchar](10) NOT NULL,
	[Receiving_Date] [varchar](50) NOT NULL,
	[Method_Id] [varchar](50) NOT NULL,
	[Storage_ID] [varchar](50) NOT NULL,
	[Import_Template] [varchar](50) NOT NULL,
	[Pallet_Number] [varchar](50) NOT NULL,
	[Variety_Code] [varchar](50) NOT NULL,
	[Variety_Name] [varchar](50) NULL,
	[Label_Code] [varchar](50) NOT NULL,
	[Style_Code] [varchar](50) NULL,
	[Size_Code] [varchar](50) NULL,
	[Pack_Code] [varchar](50) NULL,
	[Grade_Code] [varchar](50) NOT NULL,
	[Pack_Date] [varchar](50) NOT NULL,
	[Grower_Number] [varchar](50) NOT NULL,
	[Boxes_Count] [int] NOT NULL,
	[Hatch] [varchar](50) NULL,
	[Deck] [varchar](50) NULL,
	[Fumigated] [int] NULL,
	[Bill_of_Lading] [varchar](50) NULL,
	[Pallet_Type] [varchar](50) NULL,
	[Memo] [varchar](max) NULL,
	[Other] [varchar](50) NULL,
	[Test_Data] [varchar](50) NULL,
	[Archive_Key] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_Archive_Test_Table] PRIMARY KEY CLUSTERED 
(
	[Archive_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FAPI_Import_Data_Archive_Temp_Test]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FAPI_Import_Data_Archive_Temp_Test](
	[Receipt_Number] [int] NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Exporter_Name] [varchar](50) NULL,
	[Departure_Date] [varchar](50) NULL,
	[Vessel_Number] [varchar](50) NULL,
	[Vessel_Name] [varchar](50) NULL,
	[Destination] [varchar](50) NULL,
	[Pallet_Prefix] [varchar](10) NOT NULL,
	[Warehouse] [varchar](50) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[Grower_Block] [varchar](50) NOT NULL,
	[Commodity_ID] [varchar](50) NOT NULL,
	[Transaction_Type] [varchar](10) NOT NULL,
	[Receiving_Date] [varchar](50) NOT NULL,
	[Method_Id] [varchar](50) NOT NULL,
	[Storage_ID] [varchar](50) NOT NULL,
	[Import_Template] [varchar](50) NOT NULL,
	[Pallet_Number] [varchar](50) NOT NULL,
	[Variety_Code] [varchar](50) NOT NULL,
	[Variety_Name] [varchar](50) NULL,
	[Label_Code] [varchar](50) NOT NULL,
	[Style_Code] [varchar](50) NULL,
	[Size_Code] [varchar](50) NULL,
	[Pack_Code] [varchar](50) NULL,
	[Grade_Code] [varchar](50) NOT NULL,
	[Pack_Date] [varchar](50) NOT NULL,
	[Grower_Number] [varchar](50) NOT NULL,
	[Boxes_Count] [int] NOT NULL,
	[Hatch] [varchar](50) NULL,
	[Deck] [varchar](50) NULL,
	[Fumigated] [int] NULL,
	[Bill_of_Lading] [varchar](50) NULL,
	[Pallet_Type] [varchar](50) NULL,
	[Memo] [varchar](max) NULL,
	[Other] [varchar](50) NULL,
	[Test_Data] [varchar](50) NULL,
	[Archive_Key] [uniqueidentifier] ROWGUIDCOL  NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FAPI_Import_Data_Archive_Temp_Archive]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FAPI_Import_Data_Archive_Temp_Archive](
	[Receipt_Number] [int] NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Exporter_Name] [varchar](50) NULL,
	[Departure_Date] [varchar](50) NULL,
	[Vessel_Number] [varchar](50) NULL,
	[Vessel_Name] [varchar](50) NULL,
	[Destination] [varchar](50) NULL,
	[Pallet_Prefix] [varchar](10) NOT NULL,
	[Warehouse] [varchar](50) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[Grower_Block] [varchar](50) NOT NULL,
	[Commodity_ID] [varchar](50) NOT NULL,
	[Transaction_Type] [varchar](10) NOT NULL,
	[Receiving_Date] [varchar](50) NOT NULL,
	[Method_Id] [varchar](50) NOT NULL,
	[Storage_ID] [varchar](50) NOT NULL,
	[Import_Template] [varchar](50) NOT NULL,
	[Pallet_Number] [varchar](50) NOT NULL,
	[Variety_Code] [varchar](50) NOT NULL,
	[Variety_Name] [varchar](50) NULL,
	[Label_Code] [varchar](50) NOT NULL,
	[Style_Code] [varchar](50) NULL,
	[Size_Code] [varchar](50) NULL,
	[Pack_Code] [varchar](50) NULL,
	[Grade_Code] [varchar](50) NOT NULL,
	[Pack_Date] [varchar](50) NOT NULL,
	[Grower_Number] [varchar](50) NOT NULL,
	[Boxes_Count] [int] NOT NULL,
	[Hatch] [varchar](50) NULL,
	[Deck] [varchar](50) NULL,
	[Fumigated] [int] NULL,
	[Bill_of_Lading] [varchar](50) NULL,
	[Pallet_Type] [varchar](50) NULL,
	[Memo] [varchar](max) NULL,
	[Other] [varchar](50) NULL,
	[Test_Data] [varchar](50) NULL,
	[Archive_Key] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FAPI_Import_Data_Archive_Temp]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FAPI_Import_Data_Archive_Temp](
	[Receipt_Number] [int] NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Exporter_Name] [varchar](50) NULL,
	[Departure_Date] [varchar](50) NULL,
	[Vessel_Number] [varchar](50) NULL,
	[Vessel_Name] [varchar](50) NULL,
	[Destination] [varchar](50) NULL,
	[Pallet_Prefix] [varchar](10) NOT NULL,
	[Warehouse] [varchar](50) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[Grower_Block] [varchar](50) NOT NULL,
	[Commodity_ID] [varchar](50) NOT NULL,
	[Transaction_Type] [varchar](10) NOT NULL,
	[Receiving_Date] [varchar](50) NOT NULL,
	[Method_Id] [varchar](50) NOT NULL,
	[Storage_ID] [varchar](50) NOT NULL,
	[Import_Template] [varchar](50) NOT NULL,
	[Pallet_Number] [varchar](50) NOT NULL,
	[Variety_Code] [varchar](50) NOT NULL,
	[Variety_Name] [varchar](50) NULL,
	[Label_Code] [varchar](50) NOT NULL,
	[Style_Code] [varchar](50) NULL,
	[Size_Code] [varchar](50) NULL,
	[Pack_Code] [varchar](50) NULL,
	[Grade_Code] [varchar](50) NOT NULL,
	[Pack_Date] [varchar](50) NOT NULL,
	[Grower_Number] [varchar](50) NOT NULL,
	[Boxes_Count] [int] NOT NULL,
	[Hatch] [varchar](50) NULL,
	[Deck] [varchar](50) NULL,
	[Fumigated] [int] NULL,
	[Bill_of_Lading] [varchar](50) NULL,
	[Pallet_Type] [varchar](50) NULL,
	[Memo] [varchar](max) NULL,
	[Other] [varchar](50) NULL,
	[Test_Data] [varchar](50) NULL,
	[Archive_Key] [uniqueidentifier] ROWGUIDCOL  NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FAPI_Import_Data_Archive_Bk]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FAPI_Import_Data_Archive_Bk](
	[Receipt_Number] [int] NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Exporter_Name] [varchar](50) NULL,
	[Departure_Date] [varchar](50) NULL,
	[Vessel_Number] [varchar](50) NULL,
	[Vessel_Name] [varchar](50) NULL,
	[Destination] [varchar](50) NULL,
	[Pallet_Prefix] [varchar](10) NOT NULL,
	[Warehouse] [varchar](50) NOT NULL,
	[Grower_Block] [varchar](50) NOT NULL,
	[Commodity_ID] [varchar](50) NOT NULL,
	[Transaction_Type] [varchar](10) NOT NULL,
	[Receiving_Date] [varchar](50) NOT NULL,
	[Method_Id] [varchar](50) NOT NULL,
	[Storage_ID] [varchar](50) NOT NULL,
	[Import_Template] [varchar](50) NOT NULL,
	[Pallet_Number] [varchar](50) NOT NULL,
	[Variety_Code] [varchar](50) NOT NULL,
	[Variety_Name] [varchar](50) NULL,
	[Label_Code] [varchar](50) NOT NULL,
	[Style_Code] [varchar](50) NULL,
	[Size_Code] [varchar](50) NULL,
	[Pack_Code] [varchar](50) NULL,
	[Grade_Code] [varchar](50) NOT NULL,
	[Pack_Date] [varchar](50) NOT NULL,
	[Grower_Number] [varchar](50) NOT NULL,
	[Boxes_Count] [int] NOT NULL,
	[Hatch] [varchar](50) NULL,
	[Deck] [varchar](50) NULL,
	[Fumigated] [int] NULL,
	[Bill_of_Lading] [varchar](50) NULL,
	[Pallet_Type] [varchar](50) NULL,
	[Memo] [varchar](max) NULL,
	[Other] [varchar](50) NULL,
	[Test_Data] [nchar](10) NULL,
	[Archive_Key] [uniqueidentifier] ROWGUIDCOL  NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FAPI_Import_Data_Archive]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FAPI_Import_Data_Archive](
	[Receipt_Number] [int] NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Exporter_Name] [varchar](50) NULL,
	[Departure_Date] [varchar](50) NULL,
	[Vessel_Number] [varchar](50) NULL,
	[Vessel_Name] [varchar](50) NULL,
	[Destination] [varchar](50) NULL,
	[Pallet_Prefix] [varchar](10) NOT NULL,
	[Warehouse] [varchar](50) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[Grower_Block] [varchar](50) NOT NULL,
	[Commodity_ID] [varchar](50) NOT NULL,
	[Transaction_Type] [varchar](10) NOT NULL,
	[Receiving_Date] [varchar](50) NOT NULL,
	[Method_Id] [varchar](50) NOT NULL,
	[Storage_ID] [varchar](50) NOT NULL,
	[Import_Template] [varchar](50) NOT NULL,
	[Pallet_Number] [varchar](50) NOT NULL,
	[Variety_Code] [varchar](50) NOT NULL,
	[Variety_Name] [varchar](50) NULL,
	[Label_Code] [varchar](50) NOT NULL,
	[Style_Code] [varchar](50) NULL,
	[Size_Code] [varchar](50) NULL,
	[Pack_Code] [varchar](50) NULL,
	[Grade_Code] [varchar](50) NOT NULL,
	[Pack_Date] [varchar](50) NOT NULL,
	[Grower_Number] [varchar](50) NOT NULL,
	[Boxes_Count] [int] NOT NULL,
	[Hatch] [varchar](50) NULL,
	[Deck] [varchar](50) NULL,
	[Fumigated] [int] NULL,
	[Bill_of_Lading] [varchar](50) NULL,
	[Pallet_Type] [varchar](50) NULL,
	[Memo] [varchar](max) NULL,
	[Other] [varchar](50) NULL,
	[Test_Data] [varchar](50) NULL,
	[Archive_Key] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_Archive_Table] PRIMARY KEY CLUSTERED 
(
	[Archive_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Warehouse_Data]    Script Date: 01/03/2013 11:50:25 ******/
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
/****** Object:  Table [dbo].[Famous_Variety_Group_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Variety_Group_Data](
	[VARIETYGROUPIDX] [int] NULL,
	[CMTYIDX] [int] NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Variety_Data]    Script Date: 01/03/2013 11:50:25 ******/
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
/****** Object:  Table [dbo].[Famous_Style_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Style_Data](
	[STYLEIDX] [int] NULL,
	[CMTYIDX] [int] NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Storage_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Storage_Data](
	[STORAGEIDX] [int] NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Size_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Size_Data](
	[SIZEIDX] [int] NULL,
	[CMTYIDX] [int] NULL,
	[STYLEIDX] [int] NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[UNITSPEWRPALLET] [int] NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Region_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Region_Data](
	[REGIONIDX] [int] NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Produce_Inventory_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Produce_Inventory_Data](
	[INVENTORYIDX] [int] NULL,
	[TAGIDX] [int] NULL,
	[WAREHOUSEIDX] [int] NULL,
	[PRODUCTIDX] [int] NULL,
	[GROWERBLOCKIDX] [int] NULL,
	[GROWERLOTIDX] [int] NULL,
	[RECEIVEDATE] [date] NULL,
	[RECEIVEQUANTITY] [int] NULL,
	[RECEIVECOST] [money] NULL,
	[ISSUEQUANTITY] [int] NULL,
	[ISSUECOST] [money] NULL,
	[QUALITYIDX] [int] NULL,
	[AVALIABLE] [nchar](10) NULL,
	[SALEAMOUNT] [money] NULL,
	[RECEIPTAMOUNT] [money] NULL,
	[RECEIPTDATE] [date] NULL,
	[REGIONIDX] [int] NULL,
	[METHODIDX] [int] NULL,
	[CMTYIDX] [int] NULL,
	[STYLEIDX] [int] NULL,
	[SIZEIDX] [int] NULL,
	[VARIETYIDX] [int] NULL,
	[LABELIDX] [int] NULL,
	[STORAGEIDX] [int] NULL,
	[COLORIDX] [int] NULL,
	[ProductProduceNameINC] [varchar](120) NULL,
	[ProductNameGrower] [varchar](120) NULL,
	[TagNumber] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Name_Role_Data]    Script Date: 01/03/2013 11:50:25 ******/
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
/****** Object:  Table [dbo].[Famous_Name_Data]    Script Date: 01/03/2013 11:50:25 ******/
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
/****** Object:  Table [dbo].[Famous_Method_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Method_Data](
	[METHODIDX] [int] NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Label_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Label_Data](
	[LABELIDX] [int] NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Grade_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Grade_Data](
	[GRADEIDX] [int] NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Famous_Commodity_Data]    Script Date: 01/03/2013 11:50:25 ******/
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
/****** Object:  Table [dbo].[Famous_Color_Data]    Script Date: 01/03/2013 11:50:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Famous_Color_Data](
	[COLORIDX] [int] NULL,
	[NAME] [varchar](50) NULL,
	[NAMEINVC] [varchar](50) NULL,
	[INACTIVEFLAG] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateManifestUploadArchiveInfo]    Script Date: 01/03/2013 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: 11/12/2012
-- Description:	Updates the exporter and variety name from translation table data
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateManifestUploadArchiveInfo] 
	
AS
BEGIN
	
	SET NOCOUNT ON;
--Update the exporter name
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].[Exporter_Name] = (SELECT [Description] 
  FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Prefix' AND [Exporter] = [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].Exporter)

 --Update the variety name 
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].[Variety_Name] = 
  ISNULL((SELECT TOP 1 [Description] 
  FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].Variety_Code), (SELECT TOP 1 [Description] 
  FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Adams_Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive].Variety_Code))
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateExporter_Name_with_Exporter]    Script Date: 01/03/2013 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: December 18, 2012
-- Description:	Updates null Exporter_Name with Exporter
-- =============================================

CREATE PROCEDURE [dbo].[sp_UpdateExporter_Name_with_Exporter] 

AS
BEGIN

	SET NOCOUNT ON;
	
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]
  SET [Exporter_Name] = [Exporter]
  WHERE [Exporter_Name] IS NULL
  


END
GO
/****** Object:  StoredProcedure [dbo].[sp_update_Inventory_Table]    Script Date: 01/03/2013 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: December 31, 2012
-- Description:	Updates the Product Inventory Table
-- =============================================
CREATE PROCEDURE [dbo].[sp_update_Inventory_Table]
	
AS
BEGIN
DELETE 
FROM Famous_Produce_Inventory_Data
INSERT INTO Famous_Produce_Inventory_Data
SELECT INVENTORYIDX, INC.TAGIDX, WAREHOUSEIDX, INC.PRODUCTIDX, GABLOCKIDX,
	GALOTIDX, RECEIVEDATE, RECVQNT, RECVCOST, ISSUEQNT, ISSUECOST, QUALITYIDX, 
    AVAILABLEFLAG, SALEAMOUNT, RECEIPTAMOUNT, RECEIPTDATE, 
	REGIONIDX, METHODIDX, CMTYIDX,
      STYLEIDX, SIZEIDX, VARIETYIDX, LABELIDX, STORAGEIDX,
      COLORIDX, NAMEINVC, NAMEGROWER, TID.ID
FROM         
	OPENQUERY(FAMOUS, 'SELECT INVENTORYIDX, TAGIDX, WAREHOUSEIDX, PRODUCTIDX, GABLOCKIDX,
	GALOTIDX, RECEIVEDATE, RECVQNT, RECVCOST, ISSUEQNT, ISSUECOST, QUALITYIDX, 
    AVAILABLEFLAG, SALEAMOUNT, RECEIPTAMOUNT, RECEIPTDATE 
	FROM  IC_INVENTORY WHERE TAGIDX  > 60000') INC
	
	INNER JOIN
	OPENQUERY(FAMOUS, 'SELECT PRODUCTIDX, REGIONIDX, METHODIDX, CMTYIDX,
      STYLEIDX, SIZEIDX, VARIETYIDX, LABELIDX, STORAGEIDX,
      COLORIDX, NAMEINVC, NAMEGROWER
      FROM IC_PRODUCT_PRODUCE')  PP
      ON INC.PRODUCTIDX = PP.PRODUCTIDX
      INNER JOIN 
    OPENQUERY(FAMOUS, 'SELECT TAGIDX, ID FROM IC_TAG') TID
      ON INC.TAGIDX = TID.TAGIDX
	
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Import_Archive_From_Temp_Version2]    Script Date: 01/03/2013 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: December 7, 2012
-- Description:	Updates the archive table from the temp table
-- then clears the temp table.
-- Updated December 31, 2012
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_Import_Archive_From_Temp_Version2] 


AS

BEGIN

  
 	
 	UPDATE FAPI_Import_Data_Archive 
	SET [Receipt_Number] = AT.[Receipt_Number],
	[Exporter] = AT.[Exporter],
	[Exporter_Name] = AT.[Exporter_Name],
	[Departure_Date] = AT.[Departure_Date],
	[Vessel_Number] = AT.[Vessel_Number],
	[Vessel_Name] = AT.[Vessel_Name],
	[Destination] = AT.[Destination],
	[Pallet_Prefix] = AT.[Pallet_Prefix],
	[Warehouse] = AT.[Warehouse],
	[Region] = AT.[Region],
	[Grower_Block] = AT.[Grower_Block],
	[Commodity_ID] = AT.[Commodity_ID],
	[Transaction_Type] = AT.[Transaction_Type],
	[Receiving_Date] = AT.[Receiving_Date],
	[Method_Id] = AT.[Method_Id],
	[Storage_ID] = AT.[Storage_ID],
	[Import_Template] = AT.[IMport_Template],
	[Pallet_Number] = AT.[Pallet_Number],
	[Variety_Code] = AT.[Variety_Code],
	[Variety_Name] = AT.[Variety_Name],
	[Label_Code] = AT.[Label_Code],
	[Style_Code] = AT.[Style_Code],
	[Size_Code] = AT.[Size_Code],
	[Pack_Code] = AT.[Pack_Code],
	[Grade_Code] = AT.[Grade_Code],
	[Grower_Number] = AT.[Grower_Number],
	[Boxes_Count] = AT.[Boxes_Count],
	[Hatch] = AT.[Hatch],
	[Deck] = AT.[Deck],
	[Fumigated] = AT.[Fumigated],
	[Bill_of_Lading] = AT.[Bill_of_Lading],
	[Pallet_Type] = AT.[Pallet_Type],
	[Memo] = AT.[Memo],
	[Other] = AT.[Other],
	[Test_Data] = AT.[Test_Data]
	
	FROM FAPI_Import_Data_Archive_Temp AT
	WHERE ([FAPI_Import_Data_Archive].[Commodity_ID] + [FAPI_Import_Data_Archive].[Exporter] + 
		[FAPI_Import_Data_Archive].[Vessel_Number] + [FAPI_Import_Data_Archive].[Pallet_Number] +
		Convert(varchar,[FAPI_Import_Data_Archive].[Boxes_Count])) =
			(AT.[Commodity_ID] + AT.[Exporter] + AT.[Vessel_Number] + AT.[Pallet_Number]+ Convert(varchar, AT.[Boxes_Count])) 

			
  INSERT INTO [FAPI_Import_Data_Archive_Temp_Archive]
  SELECT *
  FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]

			
	Delete
	FROM FAPI_Import_Data_Archive_Temp
	WHERE ([Commodity_ID] + [Exporter] + [Vessel_Number] + [Pallet_Number]+ Convert(varchar,[Boxes_Count])) IN ( SELECT [Commodity_ID] 
		+ [Exporter] + [Vessel_Number] + [Pallet_Number] + Convert(varchar,[Boxes_Count]) 
		FROM [FAPI_Import_Data_Archive])

			
	

	INSERT INTO FAPI_Import_Data_Archive 
	SELECT *
	FROM FAPI_Import_Data_Archive_Temp DAT
	WHERE (NOT([Commodity_ID] + [Exporter] + [Vessel_Number] + [Pallet_Number]+ Convert(varchar,[Boxes_Count])) IN ( SELECT [Commodity_ID] 
		+ [Exporter] + [Vessel_Number] + [Pallet_Number] + Convert(varchar,[Boxes_Count]) 
		FROM [FAPI_Import_Data_Archive]))

	
	Delete
	FROM FAPI_Import_Data_Archive_Temp
	
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Import_Archive_From_Temp_Test]    Script Date: 01/03/2013 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: December 7, 2012
-- Description:	Updates the archive table from the temp table
-- then clears the temp table.
-- used in test mode
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_Import_Archive_From_Temp_Test] 


AS

BEGIN

 	UPDATE FAPI_Import_Data_Archive_Test 
	SET [Receipt_Number] = AT.[Receipt_Number],
	[Exporter] = AT.[Exporter],
	[Exporter_Name] = AT.[Exporter_Name],
	[Departure_Date] = AT.[Departure_Date],
	[Vessel_Number] = AT.[Vessel_Number],
	[Vessel_Name] = AT.[Vessel_Name],
	[Destination] = AT.[Destination],
	[Pallet_Prefix] = AT.[Pallet_Prefix],
	[Warehouse] = AT.[Warehouse],
	[Region] = AT.[Region],
	[Grower_Block] = AT.[Grower_Block],
	[Commodity_ID] = AT.[Commodity_ID],
	[Transaction_Type] = AT.[Transaction_Type],
	[Receiving_Date] = AT.[Receiving_Date],
	[Method_Id] = AT.[Method_Id],
	[Storage_ID] = AT.[Storage_ID],
	[Import_Template] = AT.[IMport_Template],
	[Pallet_Number] = AT.[Pallet_Number],
	[Variety_Code] = AT.[Variety_Code],
	[Variety_Name] = AT.[Variety_Name],
	[Label_Code] = AT.[Label_Code],
	[Style_Code] = AT.[Style_Code],
	[Size_Code] = AT.[Size_Code],
	[Pack_Code] = AT.[Pack_Code],
	[Grade_Code] = AT.[Grade_Code],
	[Grower_Number] = AT.[Grower_Number],
	[Boxes_Count] = AT.[Boxes_Count],
	[Hatch] = AT.[Hatch],
	[Deck] = AT.[Deck],
	[Fumigated] = AT.[Fumigated],
	[Bill_of_Lading] = AT.[Bill_of_Lading],
	[Pallet_Type] = AT.[Pallet_Type],
	[Memo] = AT.[Memo],
	[Other] = AT.[Other],
	[Test_Data] = AT.[Test_Data]
	
	FROM FAPI_Import_Data_Archive_Temp_Test AT
	WHERE ([FAPI_Import_Data_Archive_Test].[Commodity_ID] + [FAPI_Import_Data_Archive_Test].[Exporter] + 
		[FAPI_Import_Data_Archive_Test].[Vessel_Number] + [FAPI_Import_Data_Archive_Test].[Pallet_Number] +
		Convert(varchar,[FAPI_Import_Data_Archive_Test].[Boxes_Count])) =
			(AT.[Commodity_ID] + AT.[Exporter] + AT.[Vessel_Number] + AT.[Pallet_Number]+ Convert(varchar, AT.[Boxes_Count])) 

			
	Delete
	FROM FAPI_Import_Data_Archive_Temp_Test
	WHERE ([Commodity_ID] + [Exporter] + [Vessel_Number] + [Pallet_Number]+ Convert(varchar,[Boxes_Count])) IN ( SELECT [Commodity_ID] 
		+ [Exporter] + [Vessel_Number] + [Pallet_Number] + Convert(varchar,[Boxes_Count]) 
		FROM [FAPI_Import_Data_Archive_Test])

			
	

	INSERT INTO FAPI_Import_Data_Archive_Test 
	SELECT *
	FROM FAPI_Import_Data_Archive_Temp_Test DAT
	WHERE (NOT([Commodity_ID] + [Exporter] + [Vessel_Number] + [Pallet_Number]+ Convert(varchar,[Boxes_Count])) IN ( SELECT [Commodity_ID] 
		+ [Exporter] + [Vessel_Number] + [Pallet_Number] + Convert(varchar,[Boxes_Count]) 
		FROM [FAPI_Import_Data_Archive_Test]))

	
	Delete
	FROM FAPI_Import_Data_Archive_Temp_Test
	
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Update_Import_Archive_From_Temp]    Script Date: 01/03/2013 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: December 7, 2012
-- Description:	Updates the archive table from the temp table
-- then clears the temp table.
-- =============================================
CREATE PROCEDURE [dbo].[sp_Update_Import_Archive_From_Temp] 


AS

BEGIN

 	UPDATE FAPI_Import_Data_Archive 
	SET [Receipt_Number] = AT.[Receipt_Number],
	[Exporter] = AT.[Exporter],
	[Exporter_Name] = AT.[Exporter_Name],
	[Departure_Date] = AT.[Departure_Date],
	[Vessel_Number] = AT.[Vessel_Number],
	[Vessel_Name] = AT.[Vessel_Name],
	[Destination] = AT.[Destination],
	[Pallet_Prefix] = AT.[Pallet_Prefix],
	[Warehouse] = AT.[Warehouse],
	[Region] = AT.[Region],
	[Grower_Block] = AT.[Grower_Block],
	[Commodity_ID] = AT.[Commodity_ID],
	[Transaction_Type] = AT.[Transaction_Type],
	[Receiving_Date] = AT.[Receiving_Date],
	[Method_Id] = AT.[Method_Id],
	[Storage_ID] = AT.[Storage_ID],
	[Import_Template] = AT.[IMport_Template],
	[Pallet_Number] = AT.[Pallet_Number],
	[Variety_Code] = AT.[Variety_Code],
	[Variety_Name] = AT.[Variety_Name],
	[Label_Code] = AT.[Label_Code],
	[Style_Code] = AT.[Style_Code],
	[Size_Code] = AT.[Size_Code],
	[Pack_Code] = AT.[Pack_Code],
	[Grade_Code] = AT.[Grade_Code],
	[Grower_Number] = AT.[Grower_Number],
	[Boxes_Count] = AT.[Boxes_Count],
	[Hatch] = AT.[Hatch],
	[Deck] = AT.[Deck],
	[Fumigated] = AT.[Fumigated],
	[Bill_of_Lading] = AT.[Bill_of_Lading],
	[Pallet_Type] = AT.[Pallet_Type],
	[Memo] = AT.[Memo],
	[Other] = AT.[Other],
	[Test_Data] = AT.[Test_Data]
	
	FROM FAPI_Import_Data_Archive_Temp AT
	WHERE ([FAPI_Import_Data_Archive].[Commodity_ID] + [FAPI_Import_Data_Archive].[Exporter] + 
		[FAPI_Import_Data_Archive].[Vessel_Number] + [FAPI_Import_Data_Archive].[Pallet_Number] +
		Convert(varchar,[FAPI_Import_Data_Archive].[Boxes_Count])) =
			(AT.[Commodity_ID] + AT.[Exporter] + AT.[Vessel_Number] + AT.[Pallet_Number]+ Convert(varchar, AT.[Boxes_Count])) 

			
	Delete
	FROM FAPI_Import_Data_Archive_Temp
	WHERE ([Commodity_ID] + [Exporter] + [Vessel_Number] + [Pallet_Number]+ Convert(varchar,[Boxes_Count])) IN ( SELECT [Commodity_ID] 
		+ [Exporter] + [Vessel_Number] + [Pallet_Number] + Convert(varchar,[Boxes_Count]) 
		FROM [FAPI_Import_Data_Archive])

			
	

	INSERT INTO FAPI_Import_Data_Archive 
	SELECT *
	FROM FAPI_Import_Data_Archive_Temp DAT
	WHERE (NOT([Commodity_ID] + [Exporter] + [Vessel_Number] + [Pallet_Number]+ Convert(varchar,[Boxes_Count])) IN ( SELECT [Commodity_ID] 
		+ [Exporter] + [Vessel_Number] + [Pallet_Number] + Convert(varchar,[Boxes_Count]) 
		FROM [FAPI_Import_Data_Archive]))

	
	Delete
	FROM FAPI_Import_Data_Archive
	
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_Back_Up_Archive_Table]    Script Date: 01/03/2013 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: January 3, 2013
-- Description:	Backups the Archive table to 
-- the archive_Bk table.
-- =============================================
CREATE PROCEDURE [dbo].[sp_Back_Up_Archive_Table] 


AS
BEGIN
  DELETE
  FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Bk]
  
  INSERT INTO [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Bk]
  SELECT [Receipt_Number]
      ,[Exporter]
      ,[Exporter_Name]
      ,[Departure_Date]
      ,[Vessel_Number]
      ,[Vessel_Name]
      ,[Destination]
      ,[Pallet_Prefix]
      ,[Warehouse]
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
      ,(newid())
  FROM [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateTablesFromFamous]    Script Date: 01/03/2013 11:50:27 ******/
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
CREATE PROCEDURE [dbo].[UpdateTablesFromFamous] 
	
	
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
SELECT ICT.ICTRXHDRIDX, GALOTIDX, GABLOCKIDX, RECEIVEDATE, DELETEFLAG
FROM         
	OPENQUERY(FAMOUS, 'SELECT DISTINCT ICTRXHDRIDX, GALOTIDX, GABLOCKIDX, RECEIVEDATE
FROM IC_INVENTORY
WHERE ICTRXHDRIDX > 3300000 AND ICTRXHDRIDX < 9000000') ICT
INNER JOIN
OPENQUERY (FAMOUS, 'SELECT ICTRXHDRIDX, DELETEFLAG FROM IC_TRX_LINE') ITL
ON ICT.ICTRXHDRIDX = ITL.ICTRXHDRIDX

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
SELECT INVENTORYIDX, INC.TAGIDX, WAREHOUSEIDX, INC.PRODUCTIDX, GABLOCKIDX,
	GALOTIDX, RECEIVEDATE, RECVQNT, RECVCOST, ISSUEQNT, ISSUECOST, QUALITYIDX, 
    AVAILABLEFLAG, SALEAMOUNT, RECEIPTAMOUNT, RECEIPTDATE, 
	REGIONIDX, METHODIDX, CMTYIDX,
      STYLEIDX, SIZEIDX, VARIETYIDX, LABELIDX, STORAGEIDX,
      COLORIDX, NAMEINVC, NAMEGROWER, TID.ID
FROM         
	OPENQUERY(FAMOUS, 'SELECT INVENTORYIDX, TAGIDX, WAREHOUSEIDX, PRODUCTIDX, GABLOCKIDX,
	GALOTIDX, RECEIVEDATE, RECVQNT, RECVCOST, ISSUEQNT, ISSUECOST, QUALITYIDX, 
    AVAILABLEFLAG, SALEAMOUNT, RECEIPTAMOUNT, RECEIPTDATE 
	FROM  IC_INVENTORY WHERE TAGIDX  > 60000') INC
	
	INNER JOIN
	OPENQUERY(FAMOUS, 'SELECT PRODUCTIDX, REGIONIDX, METHODIDX, CMTYIDX,
      STYLEIDX, SIZEIDX, VARIETYIDX, LABELIDX, STORAGEIDX,
      COLORIDX, NAMEINVC, NAMEGROWER
      FROM IC_PRODUCT_PRODUCE')  PP
      ON INC.PRODUCTIDX = PP.PRODUCTIDX
      INNER JOIN 
    OPENQUERY(FAMOUS, 'SELECT TAGIDX, ID FROM IC_TAG') TID
      ON INC.TAGIDX = TID.TAGIDX
	
	
	



END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateManifestUploadArchiveInfoVersion2]    Script Date: 01/03/2013 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: 12/10/2012
-- Description:	Updates the exporter and variety name from translation table data
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateManifestUploadArchiveInfoVersion2] 
	
AS
BEGIN
	
	SET NOCOUNT ON;
--Update the exporter name from prefix
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].[Exporter_Name] = (SELECT [Description] 
  FROM [PBIApplicationTables].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Prefix' AND [Value] = [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].[Pallet_Prefix])

--Update missing Exporter names
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]
  SET [Exporter_Name] = [Exporter]
  WHERE [Exporter_Name] IS NULL
 
 --Update the variety name 
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].[Variety_Name] = 
  ISNULL((SELECT TOP 1 [Description] 
  FROM [PBIApplicationTables].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].Variety_Code), (SELECT TOP 1 [Description] 
  FROM [PBIApplicationTables].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Adams_Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp].Variety_Code))
  
  EXEC sp_Update_Import_Archive_From_Temp_Version2
  
  
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateManifestUploadArchiveInfoTest]    Script Date: 01/03/2013 11:50:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: 12/7/2012
-- Description:	Updates the exporter and variety name from translation table data
-- this script is used in test mode
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateManifestUploadArchiveInfoTest] 
	
AS
BEGIN
	
	SET NOCOUNT ON;
--Update the exporter name
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp_Test]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp_Test].[Exporter_Name] = (SELECT [Description] 
  FROM [PBIApplicationTables].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Prefix' AND [Value] = [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp_Test].[Pallet_Prefix])
  

--Update missing Exporter names
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp_Test]
  SET [Exporter_Name] = [Exporter]
  WHERE [Exporter_Name] IS NULL


 --Update the variety name 
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp_Test]
  SET [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp_Test].[Variety_Name] = 
  ISNULL((SELECT TOP 1 [Description] 
  FROM [PBIApplicationTables].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp_Test].Variety_Code), (SELECT TOP 1 [Description] 
  FROM [PBIApplicationTables].[dbo].[Translation_Validation_Table]
  WHERE Data_Column_Name = 'Variety' AND [Adams_Value] = 
  [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive_Temp_Test].Variety_Code))
  
  EXEC sp_Update_Import_Archive_From_Temp_Test
  
  
END
GO
/****** Object:  Default [DF_Archive_Table_Archive_Key]    Script Date: 01/03/2013 11:50:25 ******/
ALTER TABLE [dbo].[FAPI_Import_Data_Archive] ADD  CONSTRAINT [DF_Archive_Table_Archive_Key]  DEFAULT (newid()) FOR [Archive_Key]
GO
/****** Object:  Default [DF_Archive_Table_Archive_Bk_Key]    Script Date: 01/03/2013 11:50:25 ******/
ALTER TABLE [dbo].[FAPI_Import_Data_Archive_Bk] ADD  CONSTRAINT [DF_Archive_Table_Archive_Bk_Key]  DEFAULT (newid()) FOR [Archive_Key]
GO
/****** Object:  Default [DF_Archive_Temp_Table_Archive_Key]    Script Date: 01/03/2013 11:50:25 ******/
ALTER TABLE [dbo].[FAPI_Import_Data_Archive_Temp] ADD  CONSTRAINT [DF_Archive_Temp_Table_Archive_Key]  DEFAULT (newid()) FOR [Archive_Key]
GO
/****** Object:  Default [DF_Archive_Temp_Table_Archive__Test_Key]    Script Date: 01/03/2013 11:50:25 ******/
ALTER TABLE [dbo].[FAPI_Import_Data_Archive_Temp_Test] ADD  CONSTRAINT [DF_Archive_Temp_Table_Archive__Test_Key]  DEFAULT (newid()) FOR [Archive_Key]
GO
/****** Object:  Default [DF_Archive_Test_Table_Archive_Key]    Script Date: 01/03/2013 11:50:25 ******/
ALTER TABLE [dbo].[FAPI_Import_Data_Archive_Test] ADD  CONSTRAINT [DF_Archive_Test_Table_Archive_Key]  DEFAULT (newid()) FOR [Archive_Key]
GO
/****** Object:  Default [DF_LotNumberDescription_ClosedFlag]    Script Date: 01/03/2013 11:50:25 ******/
ALTER TABLE [dbo].[LotNumberDescription] ADD  CONSTRAINT [DF_LotNumberDescription_ClosedFlag]  DEFAULT ('N') FOR [ClosedFlag]
GO
