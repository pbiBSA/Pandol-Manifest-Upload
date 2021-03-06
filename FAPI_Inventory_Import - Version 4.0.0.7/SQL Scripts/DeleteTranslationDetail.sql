USE [PBIApplicationTables]
GO
/****** Object:  StoredProcedure [dbo].[DeleteTranslationDetail]    Script Date: 01/25/2014 08:56:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: January 12, 2014
-- Description:	Deletes translation Details entry 
-- from release table.
-- Undate to remove unused GCV data
-- =============================================
ALTER PROCEDURE [dbo].[DeleteTranslationDetail]

	@DetailRowID Int 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	DECLARE @GCV_Code VARCHAR(50)
	SET @GCV_Code = (SELECT GCV_Code    -- Get the GCV_Code from details data to delete
					FROM Translation_Details
					WHERE Translation_Details_ID = @DetailRowID)

    Delete
    From Translation_Details
    Where [Translation_Details_ID] = @DetailRowID
    
    -- Removed unused GCV Data
    EXEC DeleteUnusedGCVData @GCV_CODE
    
END
