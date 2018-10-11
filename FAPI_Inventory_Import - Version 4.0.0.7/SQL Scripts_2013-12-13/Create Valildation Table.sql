USE [ApplicationSettings]
GO

/****** Object:  Table [dbo].[ValidationTable]    Script Date: 10/08/2012 10:37:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

DROP TABLE [dbo].[ValidationTable]
CREATE TABLE [dbo].[ValidationTable](
	[Data_Column_Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[Value] [varchar](50) NOT NULL,
	[Ignore] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


