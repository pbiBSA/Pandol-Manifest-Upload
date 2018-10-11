USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Commodity_Codes]    Script Date: 10/03/2012 08:19:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Commodity_Codes]
CREATE TABLE [dbo].[Commodity_Codes](
	[Commodity_Description] [nvarchar](50) NOT NULL,
	[Commody_Code] [nvarchar](50) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


