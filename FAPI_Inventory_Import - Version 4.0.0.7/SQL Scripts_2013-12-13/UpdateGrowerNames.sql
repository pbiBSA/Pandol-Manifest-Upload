USE [ApplicationSettings]
GO


DELETE
FROM [ApplicationSettings].dbo.Grower_Name
INSERT INTO [ApplicationSettings].dbo.Grower_Name
SELECT [ApplicationSettings].dbo.FC_Name.LASTCONAME, [ApplicationSettings].dbo.FC_Name.NAMEIDX, (newid())
FROM [ApplicationSettings].dbo.FC_Name, [ApplicationSettings].dbo.FC_Name_Role
WHERE  [ApplicationSettings].dbo.FC_Name.NAMEIDX = [ApplicationSettings].dbo.FC_Name_Role.NAMEIDX
AND [ApplicationSettings].dbo.FC_Name_Role.NAMETYPE = 9 AND 
[ApplicationSettings].dbo.FC_Name_Role.INACTIVEFLAG = 'N'