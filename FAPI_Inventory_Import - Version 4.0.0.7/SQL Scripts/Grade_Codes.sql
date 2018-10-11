USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Grade_Codes]    Script Date: 10/03/2012 08:20:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Grade_Codes] 
CREATE TABLE [dbo].[Grade_Codes](
	[Grade_Description] [nvarchar](50) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


