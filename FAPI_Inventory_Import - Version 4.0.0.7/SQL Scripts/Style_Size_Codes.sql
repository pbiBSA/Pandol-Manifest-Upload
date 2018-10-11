USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[Style_Size_Codes]    Script Date: 10/03/2012 08:28:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Style_Size_Codes] 
CREATE TABLE [dbo].[Style_Size_Codes](
	[Style_Size_Description] [nvarchar](60) NOT NULL,
	[Style_Size_Code] [nvarchar](50) NOT NULL,
	[Other] [nchar](10) NULL
) ON [PRIMARY]

GO


