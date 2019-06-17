---- Création de la table ide
--CREATE TABLE [dbo].[ide](
--  [id] SMALLINT IDENTITY (1,1) NOT NULL PRIMARY KEY,
--  [name] VARCHAR (50) NOT NULL,
--	[version] VARCHAR (50) NOT NULL,
--	[date] DATE NOT NULL,
--)
--GO

---- Insertion des données dans la table ide
--INSERT INTO [dbo].[ide] ([name], [version], [date]) VALUES 
--  ('Eclipse', '3.3', '2007-06-01'),
--  ('Eclipse', '3.5', '2009-06-01'),
--  ('Eclipse', '3.6', '2010-06-01'),
--  ('Eclipse', '3.7', '2011-06-01'),
--  ('Eclipse', '4.3', '2013-06-13'),
--  ('NetBeans', '7', '2011-04-01'),
--  ('NetBeans', '8.2', '2016-10-03');

--exo1
--SELECT [id], [framework], [version] FROM [webDevelopment].[dbo].[frameworks] WHERE [version] LIKE '2._'
--GO

--exo2
--SELECT [id], [framework], [version] FROM [webDevelopment].[dbo].[frameworks] WHERE [id] = 1 OR [id] = 3
--GO

--exo3
--SELECT [id], [name], [version], [date] FROM [webDevelopment].[dbo].[ide] WHERE [date] BETWEEN '2010-01-01' AND '2011-12-31'
--GO
