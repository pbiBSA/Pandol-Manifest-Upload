-- ================================================
-- 
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mikhael Brown
-- Create date: March 6, 2014
-- Description:	Counts number of match Tag Numbers
-- =============================================
ALTER PROCEDURE TagNumberMatchesInFamous
	-- Add the parameters for the stored procedure here
	@TagNumber VARCHAR(50)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

 -- DECLARE @NumberTags INT
  --SET @NumberTags = 
  (SELECT COUNT([TagNumber])
  FROM [PBIApplicationTables].[dbo].[FamousTagNumbers]
  
  WHERE TagNumber = @TagNumber)
  
  --Return @NumberTags

END
GO
