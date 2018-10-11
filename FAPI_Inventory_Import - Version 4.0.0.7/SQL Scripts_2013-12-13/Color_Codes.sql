USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Style_Codes]    Script Date: 10/05/2012 14:11:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Size_Codes](
	[Size_Description] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


