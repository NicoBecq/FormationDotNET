--USE [france];

--SELECT COUNT([ville]) AS 'ville_dep', 
--	[nom_dep] AS 'departement1', 
--	(SELECT COUNT([ville])
--	FROM [dbo].[villes]
--	INNER JOIN [dbo].[regions] ON [dbo].[villes].[region] = [dbo].[regions].[region]) AS 'ville_reg',
--	[nom_region] AS 'region1'
--		FROM [dbo].[villes]
--		INNER JOIN [dbo].[departements] ON [dbo].[villes].[dep] = [dbo].[departements].[dep]
--		INNER JOIN [dbo].[regions] ON [dbo].[villes].[region] = [dbo].[departements].[region]
--		GROUP BY [nom_dep], [nom_region]
--		ORDER BY [nom_region];

--SELECT [nom_region], COUNT([ville]) AS 'count' 
--	FROM [dbo].[villes]
--	INNER JOIN [dbo].[regions] ON [dbo].[villes].[region] = [dbo].[regions].[region]
--	GROUP BY [nom_region];



--bonus2
USE [france];
SELECT [nom_region], [nom_dep], COUNT([ville]) AS 'count'
	FROM [dbo].[regions]
	LEFT JOIN [dbo].[departements] ON [dbo].[regions].[region] = [dbo].[departements].[region]
	LEFT JOIN [dbo].[villes] ON [dbo].[regions].[region] = [dbo].[villes].[region]
	GROUP BY [nom_region], [nom_dep]
	ORDER BY [nom_region];