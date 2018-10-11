USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[ValidationTable]    Script Date: 10/09/2012 15:44:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO


DROP TABLE [dbo].[TranslationTable]
CREATE TABLE [dbo].[TranslationTable](
	[Data_Column_Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Value] [varchar](50) NOT NULL,
	[Exporter] [varchar](50) NULL,
	[Ignore] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


