--exo1
--SELECT * FROM [webDevelopment].[dbo].[languages];
--GO

--exo2
--SELECT [version] FROM [webDevelopment].[dbo].[languages] WHERE [language] = 'PHP';
--GO

--exo3
--SELECT [version] FROM [webDevelopment].[dbo].[languages] WHERE [language] = 'PHP' OR [language] = 'JavaScript';
--GO

--exo4
--SELECT * FROM [webDevelopment].[dbo].[languages] WHERE [id] = 3 OR [id] = 5 OR [id] = 7;
--SELECT * FROM [webDevelopment].[dbo].[languages] WHERE [id] IN (3, 5, 7);	 AUTRE METHODE 
--GO

--exo5
--SELECT TOP 2 * FROM [webDevelopment].[dbo].[languages] WHERE [language] = 'JavaScript';
--GO

--exo6
--SELECT * FROM [webDevelopment].[dbo].[languages] WHERE [language] != 'PHP';
																	--<> 'PHP';
																	--NOT [language];
--GO

--exo7
--SELECT * FROM [webDevelopment].[dbo].[languages] ORDER BY [language];
--GO