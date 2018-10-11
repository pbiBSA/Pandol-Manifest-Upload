USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Inventory_Warehouse_Codes]    Script Date: 10/03/2012 08:26:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*DROP TABLE [dbo].[Inventory_Warehouse_Codes] */
CREATE TABLE [dbo].[Inventory_Warehouse_Codes](
	[Name] [nvarchar](60) NOT NULL,
	[Code] [nvarchar](40) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


