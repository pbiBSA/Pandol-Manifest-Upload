USE [ImportDataWarehouse]
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateExporter_Name_with_Exporter]    Script Date: 01/02/2013 08:38:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: December 18, 2012
-- Description:	Updates null Exporter_Name with Exporter
-- =============================================

ALTER PROCEDURE [dbo].[sp_UpdateExporter_Name_with_Exporter] 

AS
BEGIN

	SET NOCOUNT ON;
	
  UPDATE [ImportDataWarehouse].[dbo].[FAPI_Import_Data_Archive]
  SET [Exporter_Name] = [Exporter]
  WHERE [Exporter_Name] IS NULL
  


END
