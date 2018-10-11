USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Label_Codes]    Script Date: 10/03/2012 08:27:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*DROP TABLE [dbo].[Label_Codes] */
CREATE TABLE [dbo].[Label_Codes](
	[Label_Description] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


