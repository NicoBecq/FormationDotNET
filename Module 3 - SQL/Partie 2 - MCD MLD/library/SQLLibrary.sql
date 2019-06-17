--CREATE DATABASE library
--GO
--USE [library]
--GO

--/*------------------------------------------------------------
--*        Script SQLSERVER 
--------------------------------------------------------------*/


--/*------------------------------------------------------------
---- Table: booksTypes
--------------------------------------------------------------*/
--CREATE TABLE booksTypes(
--	idBookType   INT IDENTITY (1,1) NOT NULL ,
--	bookType     VARCHAR (50) NOT NULL  ,
--	CONSTRAINT booksTypes_PK PRIMARY KEY (idBookType)
--);


--/*------------------------------------------------------------
---- Table: users
--------------------------------------------------------------*/
--CREATE TABLE users(
--	idUser          INT IDENTITY (1,1) NOT NULL ,
--	userLastName    VARCHAR (100) NOT NULL ,
--	userFirstName   VARCHAR (100) NOT NULL ,
--	birthDate       DATETIME NOT NULL ,
--	mail            VARCHAR (100) NOT NULL ,
--	idBookType      INT  NOT NULL  ,
--	CONSTRAINT users_PK PRIMARY KEY (idUser)

--	,CONSTRAINT users_booksTypes_FK FOREIGN KEY (idBookType) REFERENCES booksTypes(idBookType)
--);


--/*------------------------------------------------------------
---- Table: authors
--------------------------------------------------------------*/
--CREATE TABLE authors(
--	idAuthor          INT IDENTITY (1,1) NOT NULL ,
--	authorLastName    VARCHAR (100) NOT NULL ,
--	authorFirstName   VARCHAR (100) NOT NULL  ,
--	CONSTRAINT authors_PK PRIMARY KEY (idAuthor)
--);


--/*------------------------------------------------------------
---- Table: books
--------------------------------------------------------------*/
--CREATE TABLE books(
--	idBook       INT IDENTITY (1,1) NOT NULL ,
--	title        VARCHAR (100) NOT NULL ,
--	idBookType   INT  NOT NULL ,
--	idAuthor     INT  NOT NULL  ,
--	CONSTRAINT books_PK PRIMARY KEY (idBook)

--	,CONSTRAINT books_booksTypes_FK FOREIGN KEY (idBookType) REFERENCES booksTypes(idBookType)
--	,CONSTRAINT books_authors0_FK FOREIGN KEY (idAuthor) REFERENCES authors(idAuthor)
--);


--/*------------------------------------------------------------
---- Table: borrowRecords
--------------------------------------------------------------*/
--CREATE TABLE borrowRecords(
--	idRecord     INT IDENTITY (1,1) NOT NULL ,
--	borrowDate   DATETIME NOT NULL ,
--	returnDate   DATETIME NOT NULL ,
--	idUser       INT  NOT NULL ,
--	idBook       INT  NOT NULL  ,
--	CONSTRAINT borrowRecords_PK PRIMARY KEY (idRecord)

--	,CONSTRAINT borrowRecords_users_FK FOREIGN KEY (idUser) REFERENCES users(idUser)
--	,CONSTRAINT borrowRecords_books0_FK FOREIGN KEY (idBook) REFERENCES books(idBook)
--);



--insertion bookTypes
--INSERT INTO [dbo].[booksTypes]([bookType])
--	VALUES	('Horreur'),
--			('Science Fiction'),
--			('Roman'),
--			('Jeunesse')
--GO

--insertion users
--INSERT INTO [dbo].[users]([userLastName], [userFirstName], [birthDate], [mail], [idBookType])
--	VALUES	('Sanchez', 'Gérard', '1964-08-20', 'sanchez.gerard@gmail.com', 3),
--			('Poulain', 'Zacharie-Xavier', '1984-04-18', 'poulain.xavier@gmail.com', 2),
--			('Simon-Vallee', 'Pierre', '1980-07-11', 'pierre.simon@gmail.com', 1),
--			('Jacquot', 'Benjamin', '1986-06-01', 'benjamin.jacquot@gmail.com', 4),
--			('Richard', 'Pauline', '1987-03-26', 'pauline.richard@gmail.com', 1),
--			('Le Lefebvre', 'William', '1971-06-06', 'william.lefebvre@gmail.com', 3),
--			('Benard', 'Stéphane', '1961-03-13', 'stephane.bernard@gmail.com', 1),
--			('Olivier', 'Lorraine', '1975-08-26', 'lorraine.olivier@gmail.com', 2),
--			('Benoit', 'Élise', '1962-12-21', 'elise.benoit@gmail.com', 4),
--			('Morin', 'Stéphane', '1958-10-02', 'stephane.morin@gmail.com', 2),
--			('Roger', 'Jeannine', '1986-10-01', 'jeannine.roger@gmail.com', 1),
--			('Le Albert', 'Christelle', '1979-02-10', 'christelle.albert@gmail.com', 4),
--			('Chauveau-Marty', 'Alix', '1984-09-24', 'alix.chauveaux@gmail.com', 2),
--			('Boulay', 'Auguste', '1973-03-22', 'auguste.boulay@gmail.com', 1),
--			('Marion', 'Thierry', '1977-02-08', 'thierry.marion@gmail.com', 4),
--			('Costa-Maillot', 'Hugues', '1968-01-09', 'hugues.costa@gmail.com', 2),
--			('Boutin', 'Jeanne', '1957-09-04', 'jeanne.boutin@gmail.com', 1),
--			('Blot', 'Martine', '1970-01-24', 'martine.blot@gmail.com', 3),
--			('Ledoux', 'Jacques', '1997-11-27', 'jacques.ledoux@gmail.com', 1),
--			('Philippe', 'Matthieu', '1967-10-30','matthieu.philippe@gmail.com', 4),
--			('Perret', 'Jacques', '1979-05-20', 'jacques.perret@gmail.com', 2), 
--			('Chartier', 'Joseph', '1958-05-29', 'joseph.chartier@gmail.com', 1),
--			('Denis', 'Margaret', '1957-08-17', 'margaret.denis@gmail.com', 3),
--			('Marin', 'Stéphanie', '1999-12-19', 'stephanie.marin@gmail.com', 4),
--			('Renaud', 'Cécile', '1993-09-23', 'cecile.renaud@gmail.com', 2)
--GO

--insertion authors
--INSERT INTO [dbo].[authors]([authorLastName], [authorFirstName])
--	VALUES	('Musso', 'Guillaume'),
--			('De Vigan', 'Delphine'),
--			('Valognes', 'Aurélie'),
--			('Dicker', 'Joel'),
--			('Foenkinos', 'David'),
--			('Martin-Lugand', 'Agnès'),
--			('Rufin', 'Jean-Christophe'),
--			('Bilal', 'Enki'),
--			('Bablet', 'Mathieu'),
--			('Spitéri', 'Léo'),
--			('Damasio', 'Alain'),
--			('Runberg', 'Sylvain'),
--			('Sobral', 'Patrick'),
--			('Neel', 'Julien'),
--			('Gazzotti', 'Bruno'),
--			('Dequier', 'Bruno'),
--			('Bravo', 'Emile'),
--			('Dugomier', 'Vincent'),
--			('Lyfung', 'Patricia'),
--			('King', 'Stephen'),
--			('Stocker', 'Bram')
--GO


--insertion livres 
--INSERT INTO [dbo].[books]([title], [idBookType], [idAuthor])
--	VALUES	('La Vie Secrète des écrivains', 3, 1),
--			('La jeune fille et la nuit', 3, 1),
--			('Les gratitudes', 3, 2),
--			('La cerise sur le gâteau', 3, 3),
--			('La disparition de Stéphanie Mailer', 3, 4),
--			('Deux soeurs', 3, 5),
--			('Une évidence', 3, 6),
--			('Les sept mariages d Edgar et Ludmilla', 3, 7),
--			('Bug Tome 1', 2, 8),
--			('Bug Tome 2', 2, 8),
--			('Shangri-la', 2, 9),
--			('Retour sur Aldébaran Tome 1', 2, 10),
--			('Retour sur Aldébaran Tome 2', 2, 10),
--			('La Horde du contrevent Tome 1', 2, 11),
--			('Les survivants Tome 5 Anomalies quantiques', 2, 10),
--			('In Mars Tome 2 Les solitaires', 2, 12),
--			('Les légendaires Tome 21', 4, 13),
--			('Les légendaires Tome 20', 4, 13),
--			('Les légendaires Tome 19', 4, 13),
--			('Les légendaires Tome 18', 4, 13),
--			('Lou Tome 8', 4, 14),
--			('Seuls Tome 11 les cloueurs de nuit', 4, 15),
--			('Louca Tome 6 Confrontations', 4, 16),
--			('Spirou L espoir malgré tout', 4, 17),
--			('Les enfants de la Résistance Tome 1', 4, 18),
--			('La Rose écarkate Tile 14', 4, 19),
--			('Shining', 1, 20),
--			('ça', 1, 20),
--			('Simetierre', 1, 20),
--			('Carrie', 1, 20),
--			('Anatomie de l horreur', 1, 20),
--			('Dracula', 1, 21),
--			('Salem', 1, 20),
--			('Le fléau', 1, 20),
--			('Sac d os', 1, 20),
--			('Desolation', 1, 20)
--GO

--insertions records (id_users commence à 2, tous les autres à 1)
--INSERT INTO [dbo].[borrowRecords]([borrowDate], [returnDate], [idUser], [idBook])
--	VALUES	('2019-04-22', '2019-04-29', 3, 1),
--			('2019-04-22', '2019-04-29', 4, 2),
--			('2019-04-22', '2019-04-29', 5, 3),
--			('2019-04-22', '2019-04-29', 6, 4),
--			('2019-04-22', '2019-04-29', 7, 5),
--			('2019-04-22', '2019-04-29', 8, 6),
--			('2019-04-22', '2019-04-29', 9, 7),
--			('2019-04-22', '2019-04-29', 10, 8),
--			('2019-04-22', '2019-04-29', 11, 9),
--			('2019-04-22', '2019-04-29', 12, 10),
--			('2019-04-22', '2019-04-29', 13, 11),
--			('2019-04-22', '2019-04-29', 14, 12),
--			('2019-04-22', '2019-04-29', 15, 13),
--			('2019-04-22', '2019-04-29', 16, 14),
--			('2019-04-22', '2019-04-29', 17, 15),
--			('2019-04-22', '2019-04-29', 18, 16),
--			('2019-05-06', '2019-05-13', 19,17),
--			('2019-05-06', '2019-05-13', 20, 18),
--			('2019-05-06', '2019-05-13', 21, 19),
--			('2019-05-06', '2019-05-13', 22, 20),
--			('2019-05-06', '2019-05-13', 23, 21),
--			('2019-05-06', '2019-05-13', 24, 22),
--			('2019-05-06', '2019-05-13', 25, 23),
--			('2019-05-06', '2019-05-13', 26, 24),
--			('2019-05-06', '2019-05-13', 27, 25),
--			('2019-05-06', '2019-05-13', 3, 26),
--			('2019-05-06', '2019-05-13', 4, 27),
--			('2019-05-06', '2019-05-13', 5, 28),
--			('2019-05-06', '2019-05-13', 6, 29),
--			('2019-05-06', '2019-05-13', 7, 30)
--GO

--fonctionnalité 1 afficher records (titre, user, borrowDate, returnDate)
--SELECT [title], [userLastName], [userFirstName], [borrowDate], [returnDate]
--	FROM [dbo].[borrowRecords]
--	INNER JOIN [dbo].[books] ON [dbo].[borrowRecords].[idBook] = [dbo].[books].[idBook]
--	INNER JOIN [dbo].[users] ON [dbo].[borrowRecords].[idUser] = [dbo].[users].[idUser]
--	ORDER BY [borrowDate]
--GO

--fonctionnalité 2 afficher tous les livres (titre, genre, author, select ceux qui sont dispo)
--DECLARE @actualDate datetimeoffset = CONVERT(DATE, GETDATE());
--SELECT [title], [bookType], [authorLastName], [authorFirstName],
--	CASE 
--		WHEN @actualDate > [dbo].[borrowRecords].[borrowDate] AND @actualDate <  [dbo].[borrowRecords].[returnDate]
--			THEN 'non dispo' -- si la date actuelle est comprise entre les dates d'emprunts et de retrour d'un livre, il n'est pas dispo
--		WHEN @actualDate >  [dbo].[borrowRecords].[returnDate]
--			THEN 'dispo' --si la date actuelle est supérieure à la date de retour d'un livre, il est dispo
--	END AS 'disponibilité'
--	FROM [dbo].[books]
--	INNER JOIN [dbo].[authors] ON [dbo].[books].[idAuthor] = [dbo].[authors].[idAuthor]
--	INNER JOIN [dbo].[booksTypes] ON [dbo].[books].[idBookType] = [dbo].[booksTypes].[idBookType]
--	INNER JOIN [dbo].[borrowRecords] ON [dbo].[books].[idBook] = [dbo].[borrowRecords].[idBook]	
--	ORDER BY [title]
--GO

--fonctionnalité 3 afficher le nbre total de livre par genre (genre, total de livre correspondant)
----SELECT [bookType], COUNT([title]) AS 'nbre de livres'
----	FROM [dbo].[booksTypes]
----	LEFT JOIN [dbo].[books] ON [dbo].[booksTypes].[idBookType] = [dbo].[books].[idBookType]
----	GROUP BY [bookType]
----GO