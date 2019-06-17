--CREATE DATABASE propertyAgency
--GO
--USE [propertyAgency]
--GO

--/*------------------------------------------------------------
--*        Script SQLSERVER 
--------------------------------------------------------------*/


--/*------------------------------------------------------------
---- Table: propertyTypes
--------------------------------------------------------------*/
--CREATE TABLE propertyTypes(
--	idPropertyType   INT IDENTITY (1,1) NOT NULL ,
--	propertyType     VARCHAR (50) NOT NULL  ,
--	CONSTRAINT propertyTypes_PK PRIMARY KEY (idPropertyType)
--);


--/*------------------------------------------------------------
---- Table: users
--------------------------------------------------------------*/
--CREATE TABLE users(
--	idUser           INT IDENTITY (1,1) NOT NULL ,
--	userLastName     VARCHAR (100) NOT NULL ,
--	userFirstName    VARCHAR (100) NOT NULL ,
--	userBirthDate    DATETIME NOT NULL ,
--	userMail         VARCHAR (100) NOT NULL ,
--	userBudget       INT  NOT NULL ,
--	idPropertyType   INT  NOT NULL  ,
--	CONSTRAINT users_PK PRIMARY KEY (idUser)

--	,CONSTRAINT users_propertyTypes_FK FOREIGN KEY (idPropertyType) REFERENCES propertyTypes(idPropertyType)
--);


--/*------------------------------------------------------------
---- Table: propertys
--------------------------------------------------------------*/
--CREATE TABLE propertys(
--	idProperty       INT IDENTITY (1,1) NOT NULL ,
--	propertyName     VARCHAR (100) NOT NULL ,
--	propertyZip      INT  NOT NULL ,
--	propertyPrice    INT  NOT NULL ,
--	idPropertyType   INT  NOT NULL  ,
--	CONSTRAINT propertys_PK PRIMARY KEY (idProperty)

--	,CONSTRAINT propertys_propertyTypes_FK FOREIGN KEY (idPropertyType) REFERENCES propertyTypes(idPropertyType)
--);


--/*------------------------------------------------------------
---- Table: timeSlots
--------------------------------------------------------------*/
--CREATE TABLE timeSlots(
--	idTimeSlot   INT IDENTITY (1,1) NOT NULL ,
--	timeSlot     TIME (2) NOT NULL  ,
--	CONSTRAINT timeSlots_PK PRIMARY KEY (idTimeSlot)
--);


--/*------------------------------------------------------------
---- Table: rdvs
--------------------------------------------------------------*/
--CREATE TABLE rdvs(
--	idRdv        INT IDENTITY (1,1) NOT NULL ,
--	rdvDate      DATETIME NOT NULL ,
--	idUser       INT  NOT NULL ,
--	idProperty   INT  NOT NULL ,
--	idTimeSlot   INT  NOT NULL  ,
--	CONSTRAINT rdvs_PK PRIMARY KEY (idRdv)

--	,CONSTRAINT rdvs_users_FK FOREIGN KEY (idUser) REFERENCES users(idUser)
--	,CONSTRAINT rdvs_propertys0_FK FOREIGN KEY (idProperty) REFERENCES propertys(idProperty)
--	,CONSTRAINT rdvs_timeSlots1_FK FOREIGN KEY (idTimeSlot) REFERENCES timeSlots(idTimeSlot)
--);

--insertion timeSlots (6)
--INSERT INTO [dbo].[timeSlots]([timeSlot])
--	VALUES	('09:00:00'),
--			('10:00:00'),
--			('11:00:00'),
--			('13:00:00'),
--			('14:00:00'),
--			('15:00:00')
--GO

--insertions propertyTypes
--INSERT INTO [dbo].[propertyTypes]([propertyType])
--	VALUES	('Maison'),
--			('Appartement'),
--			('Terrain')
--GO

--insertion propertys
--INSERT INTO [dbo].[propertys]([propertyName], [propertyZip], [propertyPrice], [idPropertyType])
--	VALUES	('Pontoise', 95300, 140500, 2),
--			('Cergy', 95800, 210000, 1),
--			('Saint Leu La Foret', 95320, 138000, 2),
--			('Ermont', 95120, 154000, 2),
--			('Groslay', 95410, 382000, 1),
--			('Viarmes', 95270, 219000, 1),
--			('Arronville', 95810, 117000, 3),
--			('Saint Clair sur Epte', 95770, 42000, 3),
--			('Osny', 95520, 219450, 2),
--			('Marly la Ville', 95670, 186000, 3),
--			('Franconville', 95130, 107000, 2),
--			('Belloy en France', 95270, 298000, 1),
--			('Magny en Vexin', 95420, 40680, 3),
--			('Cergy', 95800, 180000, 2),
--			('Saint Leu la Foret', 95320, 195000, 2),
--			('Bellefontaine', 95270, 328000, 1),
--			('Marines', 95640, 50000, 3),
--			('Cergy', 95800, 279000, 1),
--			('Persan', 95340, 59000, 2),
--			('Berthemont la Foret', 95840, 60000, 3),
--			('Bouffemont', 95570, 211000, 2),
--			('Cergy', 95800, 61715, 2),
--			('Herblay', 95220, 484950, 1),
--			('Magny en Vexin', 95420, 213000, 1),
--			('La Roche sur Guyon', 95780, 50000, 2),
--			('Viarmes', 95270, 199000, 1),
--			('Andilly', 95580, 401000, 1),
--			('Goussainville', 95190, 364000, 1),
--			('Compiègne', 60200, 91000, 2),
--			('Gouvieux', 60270, 1248000, 1)
--GO

--insertion users
--INSERT INTO [dbo].[users]([userLastName], [userFirstName], [userBirthDate], [userMail], [userBudget], [idPropertyType])
--	VALUES	('Dupre', 'André', '1983-05-09', 'dupre.andre@gmail.com', 500000, 1),
--			('Hebert-Dijoux', 'Éléonore', '1983-07-23', 'herbert.eleonore@gmail.com', 50000, 2),
--			('Lombard', 'Josette', '1965-07-11', 'lombard.josette@gmail.com', 70000, 2),
--			('Lemaire', 'Hugues', '1996-09-03', 'lemaire.hugues@gmail.com', 100000, 3),
--			('de la Gomez', 'Lucie', '1999-05-28', 'gomez.lucie@gmail.com', 200000, 1),
--			('Thierry-Cousin', 'Anne', '1988-04-15', 'cousin.anne@gmail.com', 60000, 3),
--			('Jean', 'Roger', '1980-02-14', 'jean.roger@gmail.com', 1000000, 1),
--			('Becker', 'Alexandrie-Julie', '1957-05-27', 'becker.alexandrie@gmail.com', 300000, 1),
--			('Valette', 'Anouk', '1974-07-27', 'valette.anouk@gmail.com', 150000, 2),
--			('Schneider', 'Adèle', '1981-01-05', 'schneider.adele@gmail.com', 350000, 1),
--			('Ferrand', 'Jérôme', '1968-09-27', 'ferrand.jerome@gmail.com', 500000, 3),
--			('Pichon', 'Georges', '1963-12-06', 'pichon.georges@gmail.com', 75000, 2),
--			('Bernier', 'Valérie', '1965-07-28', 'bernier.valerie@gmail.com', 99999, 3),
--			('Blanchet-Hamon', 'Olivier', '1998-06-21', 'blanchet.olivier@gmail.com', 250000, 1),
--			('Tessier', 'Céline', '1955-11-27', 'tessier.celine@gmail.com', 950000, 1),
--			('Vincent', 'Frédérique', '1986-11-04', 'vincent.frederique@gmail.com', 25000, 3),
--			('Texier', 'Martin', '1993-10-13', 'texier.martin@gmail.com', 600000, 2),
--			('Leger', 'Théophile', '1968-04-10', 'leger.theophile@gmail.com', 350000, 1),
--			('Seguin', 'Odette-Josette', '1955-11-15', 'seguin.odette@gmail.com', 500000, 1),
--			('Schmitt', 'Marcel', '1982-10-05', 'schmitt.marcel@gmail.com', 152350, 2)
--GO

--inesrtions rdvs (idUser commence à 5)
--INSERT INTO [dbo].[rdvs]([rdvDate], [idUser], [idProperty], [idTimeSlot])
--	VALUES	('2019-05-10', 5, 1, 1),
--			('2019-05-10', 6, 2, 2),
--			('2019-05-10', 7, 3, 3),
--			('2019-05-10', 8, 4, 4),
--			('2019-05-10', 9, 5, 6),
--			('2019-05-13', 10, 6, 2),
--			('2019-05-13', 11, 7, 3),
--			('2019-05-13', 12, 8, 5),
--			('2019-05-14', 13, 9, 1),
--			('2019-05-14', 14, 10, 3)
--GO

--fonctionnalité 1 afficher tous les biens par prix (nom, zip, type, prix)
--SELECT [propertyName], [propertyZip], [propertyType], [propertyPrice]
--	FROM [dbo].[propertys]
--	INNER JOIN [dbo].[propertyTypes] ON [dbo].[propertys].[idPropertyType] = [dbo].[propertyTypes].[idPropertyType]
--	ORDER BY [propertyPrice]
--GO

--fonctionnalité 2 afficher les rdvs par odre chro. (date, timeSlot, nom(bien), type, zip, nom(client)
--SELECT [rdvDate], [timeSlot], [propertyName], [propertyType], [propertyZip], [userLastName], [userFirstName]
--	FROM [dbo].[rdvs]
--	INNER JOIN [dbo].[propertys] ON [dbo].[rdvs].[idProperty] = [dbo].[propertys].[idProperty]
--	INNER JOIN [dbo].[propertyTypes] ON [dbo].[propertys].[idPropertyType] = [dbo].[propertyTypes].[idPropertyType]
--	INNER JOIN [dbo].[users] ON [dbo].[rdvs].[idUser] = [dbo].[users].[idUser]
--	INNER JOIN [dbo].[timeSlots] ON [dbo].[rdvs].[idTimeSlot] = [dbo].[timeSlots].[idTimeSlot]
--	ORDER BY [rdvDate], [timeSlot]
--GO

--fonctionnalité 3 afficher les clients par type de biens (nom(client), type, budget)
SELECT [userLastName], [userFirstName], [propertyType], [userBudget]
	FROM [dbo].[users]
	INNER JOIN [dbo].[propertyTypes] ON [dbo].[users].[idPropertyType] = [dbo].[propertyTypes].[idPropertyType]
	WHERE [dbo].[propertyTypes].[idPropertyType] = 3
	ORDER BY [propertyType]
GO