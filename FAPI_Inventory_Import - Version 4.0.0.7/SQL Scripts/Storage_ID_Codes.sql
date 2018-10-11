USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Variety_Codes]    Script Date: 10/03/2012 08:32:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*DROP TABLE [dbo].[Storage_ID_Codes] */
CREATE TABLE [dbo].[Storage_ID_Codes](
	[Storage_Description] [nvarchar](60) NOT NULL,
	[Storage_Code] [nvarchar](16) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


