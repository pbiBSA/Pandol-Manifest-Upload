USE [PBIApplicationTables]
GO

/****** Object:  Table [dbo].[Translation_Table]    Script Date: 01/21/2013 09:07:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Translation_Table](
	[Species] [varchar](50) NOT NULL,
	[Exporter_Pack_Code] [varchar](50) NULL,
	[Exporter_Style] [varchar](50) NULL,
	[Exporter_Size] [varchar](50) NULL,
	[Exporter_Custom] [varchar](50) NULL,
	[Famous_Style] [varchar](50) NOT NULL,
	[Famous_Size] [varchar](50) NOT NULL,
	[Famous_Custom] [varchar](50) NULL,
	[Adams_Pack_Code] [varchar](50) NULL,
	[Adams_Custom] [varchar](50) NULL,
	[Record_Key] [uniqueidentifier] ROWGUIDCOL  NOT NULL,
 CONSTRAINT [PK_Translation_Table] PRIMARY KEY CLUSTERED 
(
	[Record_Key] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Translation_Table] ADD  CONSTRAINT [DF_Translation_Table_Exporter_Custom]  DEFAULT ('0') FOR [Exporter_Custom]
GO

ALTER TABLE [dbo].[Translation_Table] ADD  CONSTRAINT [DF_Translation_Table_Famous_Custom]  DEFAULT ('0') FOR [Famous_Custom]
GO

ALTER TABLE [dbo].[Translation_Table] ADD  CONSTRAINT [DF_Translation_Table_Adams_Custom]  DEFAULT ('0') FOR [Adams_Custom]
GO

ALTER TABLE [dbo].[Translation_Table] ADD  CONSTRAINT [DF_Translation_Table_Record_Key]  DEFAULT (newid()) FOR [Record_Key]
GO


