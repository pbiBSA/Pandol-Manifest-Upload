USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Style_Codes]    Script Date: 10/03/2012 08:27:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Style_Codes]
CREATE TABLE [dbo].[Style_Codes](
	[Style_Description] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


