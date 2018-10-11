-- ================================================
-- 
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: 4/6/2014
-- Description:	Clears and repopulates the 
-- list of tag numbers from Famous
-- =============================================
ALTER PROCEDURE RebuildTagNumberTable 
	-- Add the parameters for the stored procedure here


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   TRUNCATE TABLE FamousTagNumbers

  INSERT INTO FamousTagNumbers

  SELECT TAGIDX, TagNumber
  FROM
	OPENQUERY(FAMOUS, 
		'SELECT TAGIDX, ID AS TagNumber FROM IC_TAG'
		)

 
END
GO
