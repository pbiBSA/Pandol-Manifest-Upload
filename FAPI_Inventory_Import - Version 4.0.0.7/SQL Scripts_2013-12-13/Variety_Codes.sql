USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Variety_Codes]    Script Date: 10/03/2012 08:29:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Variety_Codes] 
CREATE TABLE [dbo].[Variety_Codes](
	[Description] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


