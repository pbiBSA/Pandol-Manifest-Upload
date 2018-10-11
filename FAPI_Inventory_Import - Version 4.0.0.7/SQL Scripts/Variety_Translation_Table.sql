USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Variety_Translation_Table]    Script Date: 10/05/2012 14:01:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Variety_Translation_Table]
CREATE TABLE [dbo].[Variety_Translation_Table](
	[Exporter] [nvarchar](60) NOT NULL,
	[Exporter_Variety_Code] [nvarchar](60) NOT NULL,
	[Famous_Variety_Code] [nvarchar](16) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


