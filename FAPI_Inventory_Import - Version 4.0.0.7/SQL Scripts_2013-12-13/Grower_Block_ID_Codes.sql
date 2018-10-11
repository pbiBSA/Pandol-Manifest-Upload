USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Grower_Block_ID_Codes]    Script Date: 10/03/2012 08:23:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*DROP TABLE [dbo].[Grower_Block_ID_Codes] */
CREATE TABLE [dbo].[Grower_Block_ID_Codes](
	[Grower_Block_ID_Description] [nvarchar](50) NOT NULL,
	[Grower_Block_Code] [nvarchar](15) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO

