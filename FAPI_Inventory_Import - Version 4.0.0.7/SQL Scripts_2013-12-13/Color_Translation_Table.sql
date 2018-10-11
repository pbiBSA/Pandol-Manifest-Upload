USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Color_Translation_Table]    Script Date: 10/05/2012 14:01:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Color_Translation_Table]
CREATE TABLE [dbo].[Color_Translation_Table](
	[Exporter] [nvarchar](60) NOT NULL,
	[Exporter_Color_Code] [nvarchar](60) NOT NULL,
	[Famous_Color_Code] [nvarchar](16) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


