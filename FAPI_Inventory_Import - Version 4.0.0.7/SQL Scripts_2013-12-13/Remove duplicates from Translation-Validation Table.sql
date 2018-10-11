--Remove duplicates from the Translation-Validation table

DELETE
FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
WHERE [ApplicationSettings].[dbo].[Translation_Validation_Table].[id] IN

-- List 1 - all rows that have duplicates
(SELECT F.ID
FROM [ApplicationSettings].[dbo].[Translation_Validation_Table] AS F
WHERE Exists (SELECT [Description], [Value], Count([id])
FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
WHERE [ApplicationSettings].[dbo].[Translation_Validation_Table].[Description] = F.[Description]
   AND [ApplicationSettings].[dbo].[Translation_Validation_Table].[Value] = F.[Value]
GROUP BY [ApplicationSettings].[dbo].[Translation_Validation_Table].[Description], [ApplicationSettings].[dbo].[Translation_Validation_Table].[Value]
HAVING Count([ApplicationSettings].[dbo].[Translation_Validation_Table].[id]) > 1))
AND [ApplicationSettings].[dbo].[Translation_Validation_Table].[id] NOT IN

-- List 2 - one row from each set of duplicate
(SELECT Min([id])
FROM [ApplicationSettings].[dbo].[Translation_Validation_Table] AS F
WHERE Exists (SELECT [Description], [Value], Count([id])
FROM [ApplicationSettings].[dbo].[Translation_Validation_Table]
WHERE [ApplicationSettings].[dbo].[Translation_Validation_Table].[Description] = F.[Description]
   AND [ApplicationSettings].[dbo].[Translation_Validation_Table].[Value] = F.[Value]
GROUP BY [ApplicationSettings].[dbo].[Translation_Validation_Table].[Description], [ApplicationSettings].[dbo].[Translation_Validation_Table].[Value]
HAVING Count([ApplicationSettings].[dbo].[Translation_Validation_Table].[id]) > 1)
GROUP BY [Description], [Value]);