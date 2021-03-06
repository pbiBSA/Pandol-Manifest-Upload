USE [PBIApplicationTables]
GO
/****** Object:  StoredProcedure [dbo].[DeleteUnusedGCVData]    Script Date: 01/24/2014 07:21:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: January 25, 2014
-- Description:	Deletes translation GCV Data entry 
-- if there are no linked records in the details
-- table for it.
-- =============================================
ALTER PROCEDURE [dbo].[DeleteUnusedGCVData]

	@GCV_Code VARCHAR(50) 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON
    
    if(NOT (@GCV_Code in ((SELECT GCV_Code 
					FROM Translation_Details))))
	BEGIN
	 DELETE
	 FROM GCV_Information_Test
	 WHERE GCV_Code = @GCV_Code
	END
	
    
END
