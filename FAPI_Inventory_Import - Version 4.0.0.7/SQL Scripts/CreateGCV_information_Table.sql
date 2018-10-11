USE [PBIApplicationTables]
GO

/****** Object:  Table [dbo].[GCV_Information]    Script Date: 10/12/2013 13:27:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[GCV_Information](
	[Grower_ID] [int] NOT NULL,
	[Grower_Name] [varchar](50) NOT NULL,
	[Commodity_Code] [varchar](50) NOT NULL,
	[Commodity] [varchar](50) NOT NULL,
	[Grower_Commodity_Code] [varchar](50) NULL,
	[Variety_Code] [varchar](50) NOT NULL,
	[Variety] [varchar](50) NOT NULL,
	[Grower_Variety_Code] [varchar](50) NULL,
	[Stone_Fruit] [varchar](10) NOT NULL,
	[GCV_Code] [varchar](50) NOT NULL,
	[GCV_IDX] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_GCV_IDX] PRIMARY KEY CLUSTERED 
(
	[GCV_IDX] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


