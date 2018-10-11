USE [ImportDataWarehouse]
GO

/****** Object:  Table [dbo].[FAPI_Import_Data_Archive_Temp_Test]    Script Date: 01/03/2013 11:15:29 ******/
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

ALTER TABLE [dbo].[FAPI_Import_Data_Archive_Temp_Test] ADD  CONSTRAINT [DF_Archive_Temp_Table_Archive__Test_Key]  DEFAULT (newid()) FOR [Archive_Key]
GO


