--exo1
--USE [france];
--GO
--SELECT [id], [region], [prefecture], [nom_region] FROM [dbo].[regions];
--GO

--exo2
--SELECT * FROM [dbo].[departements]
--	ORDER BY [nom_dep];
--GO

--exo3
--SELECT * FROM [dbo].[villes]
--	WHERE [dep] = '60'
--	ORDER BY [cp];
--GO

--exo4
--SELECT TOP 3 * FROM [dbo].[villes] 
--	WHERE [cp] = 60400
--	ORDER BY [ville];

--exo5
--SELECT * FROM [dbo].[villes]
--	WHERE [ville] LIKE '%saint%';

--exo6
--SELECT [nom_dep], COUNT(*) AS 'count' FROM [france].[dbo].[departements]
--	INNER JOIN [dbo].[villes] ON [dbo].[departements].[dep] = [dbo].[villes].[dep]
--	GROUP BY [nom_dep];

--exo7
--SELECT [ville], [nom_region] FROM [dbo].[villes]
--	INNER JOIN [dbo].[regions] ON [dbo].[villes].[region] = [dbo].[regions].[region]
--	WHERE [nom_region] = 'Picardie';

--exo8
--USE [france];
--GO
--SELECT [nom_region], [nom_dep], COUNT([ville]) AS 'count'
--	FROM [dbo].[villes]
--	INNER JOIN [dbo].[regions] ON [dbo].[villes].[region] = [dbo].[regions].[region]
--	INNER JOIN [dbo].[departements] ON [dbo].[villes].[dep] = [dbo].[departements].[dep]
--	GROUP BY [nom_region], [nom_dep];
--GO

--exo8
--SELECT [nom_region], COUNT([ville]) AS 'countReg'
--	FROM [dbo].[regions]
--	INNER JOIN [dbo].[villes] ON [dbo].[regions].[region] = [dbo].[villes].[region]
--	GROUP BY [nom_region]
--UNION
--SELECT [nom_dep], COUNT([ville])
--	FROM [dbo].[departements]
--	INNER JOIN [dbo].[villes] ON [dbo].[departements].[dep] = [dbo].[villes].[dep]
--	GROUP BY [nom_dep];
--GO