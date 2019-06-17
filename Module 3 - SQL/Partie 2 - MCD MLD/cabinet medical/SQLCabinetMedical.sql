--CREATE DATABASE medical
--GO
--USE [medical]
--GO
--/*------------------------------------------------------------
--*        Script SQLSERVER 
--------------------------------------------------------------*/


--/*------------------------------------------------------------
---- Table: timeSlots
--------------------------------------------------------------*/
--CREATE TABLE timeSlots(
--	idTimeSlot   INT IDENTITY (1,1) NOT NULL ,
--	timeSlot     TIME (2) NOT NULL  ,
--	CONSTRAINT timeSlots_PK PRIMARY KEY (idTimeSlot)
--);


--/*------------------------------------------------------------
---- Table: specialitys
--------------------------------------------------------------*/
--CREATE TABLE specialitys(
--	idSpeciality   INT IDENTITY (1,1) NOT NULL ,
--	speciality     VARCHAR (50) NOT NULL  ,
--	CONSTRAINT specialitys_PK PRIMARY KEY (idSpeciality)
--);


--/*------------------------------------------------------------
---- Table: doctor
--------------------------------------------------------------*/
--CREATE TABLE doctor(
--	id                INT IDENTITY (1,1) NOT NULL ,
--	doctorLastName    VARCHAR (100) NOT NULL ,
--	doctorFirstName   VARCHAR (100) NOT NULL ,
--	mail              VARCHAR (100) NOT NULL ,
--	idSpeciality      INT  NOT NULL  ,
--	CONSTRAINT doctor_PK PRIMARY KEY (id)

--	,CONSTRAINT doctor_specialitys_FK FOREIGN KEY (idSpeciality) REFERENCES specialitys(idSpeciality)
--);


--/*------------------------------------------------------------
---- Table: users
--------------------------------------------------------------*/
--CREATE TABLE users(
--	id              INT IDENTITY (1,1) NOT NULL ,
--	userLastName    VARCHAR (100) NOT NULL ,
--	userFirstName   VARCHAR (100) NOT NULL ,
--	birthDate       DATE NOT NULL ,
--	id_doctor       INT  NOT NULL  ,
--	CONSTRAINT users_PK PRIMARY KEY (id)

--	,CONSTRAINT users_doctor_FK FOREIGN KEY (id_doctor) REFERENCES doctor(id)
--);


--/*------------------------------------------------------------
---- Table: rdvs
--------------------------------------------------------------*/
--CREATE TABLE rdvs(
--	id           INT IDENTITY (1,1) NOT NULL ,
--	dateRdv      DATE NOT NULL ,
--	id_users     INT  NOT NULL ,
--	id_doctor    INT  NOT NULL ,
--	idTimeSlot   INT  NOT NULL  ,
--	CONSTRAINT rdvs_PK PRIMARY KEY (id)

--	,CONSTRAINT rdvs_users_FK FOREIGN KEY (id_users) REFERENCES users(id)
--	,CONSTRAINT rdvs_doctor0_FK FOREIGN KEY (id_doctor) REFERENCES doctor(id)
--	,CONSTRAINT rdvs_timeSlots1_FK FOREIGN KEY (idTimeSlot) REFERENCES timeSlots(idTimeSlot)
--);

--insertion speciality
--INSERT INTO [dbo].[specialitys]([speciality])
--	VALUES	('Généraliste'),
--			('Neurologue'),
--			('Oncologue')
--GO

--insertion timeSlots
--INSERT INTO [dbo].[timeSlots]([timeSlot])
--	VALUES	('08:00:00'),
--			('09:00:00'),
--			('10:00:00'),
--			('11:00:00'),
--			('13:00:00'),
--			('14:00:00'),
--			('15:00:00'),
--			('16:00:00')
--GO

--insertion table doctors	
--INSERT INTO [dbo].[doctor]([doctorLastName], [doctorFirstName], [mail], [idSpeciality])
--	VALUES	('Lagarde', 'Charles', 'lagarde.charles@gmail.com', 1),
--			('Julien-Bouvet', 'Bertrand', 'julienbouvet.bertrand@gmail.com', 1),
--			('Humbert', 'Madeleine-Constance', 'humbert.constance@gmail.com', 1),
--			('Lemoine', 'Laurent', 'lemoine.laurent@gmail.com', 2), 
--			('Hernandez-Jacquot', 'Dominique', 'hernandez-jacquot.dominique@gmail.com', 3)
--GO

--insertion patients
--INSERT INTO [dbo].[users]([userLastName], [userFirstName], [birthDate], [id_doctor])
--	VALUES	('Adélaïde-Célina', 'Vaillant', '1986-06-13', 2),
--			('Nathalie', 'Durand', '1980-12-24', 2),
--			('Marcelle', 'Rocher', '1975-08-02', 2),
--			('Alexandrie-Audrey', 'Grenier', '1992-05-05', 3),
--			('Grégoire', 'Blin', '1990-02-16', 2),
--			('Antoine', 'Seguin-Bonnin', '1983-10-15', 3),
--			('Agathe', 'de Poirier', '1995-08-06', 3),
--			('Audrey', 'Pottier', '1988-02-28', 3),
--			('Stéphanie', 'Julien', '1998-06-06', 3),
--			('William', 'Diaz', '1919-12-12', 3),
--			('Colette', 'Colas', '1970-12-14', 4),
--			('François', 'Monnier', '1988-07-22', 4),
--			('Nathalie', 'Weber', '1995-05-31', 4),
--			('Marianne', 'Gay-Martins', '1979-03-19', 4),
--			('Virginie', 'Carre', '1960-02-07', 4),
--			('Yves', 'Boucher', '1956-07-21', 5),
--			('Grégoire', 'Charles', '1972-11-16', 5),
--			('Vincent-Benjamin', 'Bouvet', '2000-09-13', 5),
--			('Gabrielle', 'Schneider', '1992-02-06', 5),
--			('Nathalie', 'Guillou', '2000-09-28', 5),
--			('Éric', 'Remy', '1994-07-27', 6),
--			('Margaud', 'Barre', '1954-09-04', 6),
--			('Timothée', 'Maillot', '1981-12-15', 6),
--			('Antoinette', 'Coste', '1974-09-02', 6),
--			('Thibaut', 'Lambert', '1983-04-05', 6)
--GO


--insertion rdvs
--INSERT INTO [dbo].[rdvs]([dateRdv], [idTimeSlot], [id_doctor], [id_users])
--	VALUES	('2019-05-06', 1, 2, 1),
--			('2019-05-06', 2, 2, 2),
--			('2019-05-06', 3, 2, 3),
--			('2019-05-06', 4, 2, 4),
--			('2019-05-06', 6, 2, 5),
--			('2019-05-06', 1, 3, 6),
--			('2019-05-06', 3, 3, 7),
--			('2019-05-06', 4, 3, 8),
--			('2019-05-06', 5, 3, 9),
--			('2019-05-06', 6, 3, 10),
--			('2019-05-06', 2, 4, 11),
--			('2019-05-06', 3, 4, 12),
--			('2019-05-06', 4, 4, 13),
--			('2019-05-06', 5, 4, 14),
--			('2019-05-06', 7, 4, 15),
--			('2019-05-06', 2, 5, 16),
--			('2019-05-06', 3, 5, 17),
--			('2019-05-06', 4, 5, 18),
--			('2019-05-06', 5, 5, 19),
--			('2019-05-06', 8, 5, 20),
--			('2019-05-06', 1, 6, 21),
--			('2019-05-06', 2, 6, 22),
--			('2019-05-06', 4, 6, 23),
--			('2019-05-06', 6, 6, 24),
--			('2019-05-06', 7, 6, 25),
--			('2019-07-02', 4, 2, 1),
--			('2019-07-02', 6, 3, 5),
--			('2019-07-02', 8, 4, 15),
--			('2019-07-02', 7, 5, 20),
--			('2019-07-02', 1, 6, 25)
--GO


--fonctionnalité 1 afficher tous les rdvs (date, heure, nom (patient), nom(medecin), spécialité)
--SELECT [dateRdv], [timeSlot], [userLastName], [userFirstName], [doctorLastName], [speciality]
--	FROM [dbo].[rdvs]
--	INNER JOIN [dbo].[users] ON [dbo].[rdvs].[id_users] = [dbo].[users].[id]
--	INNER JOIN [dbo].[doctor] ON [dbo].[rdvs].[id_doctor] = [dbo].[doctor].[id]
--	INNER JOIN [dbo].[specialitys] ON [dbo].[doctor].[idSpeciality] = [dbo].[specialitys].[idSpeciality]
--	INNER JOIN [dbo].[timeSlots] ON [dbo].[rdvs].[idTimeSlot] = [dbo].[timeSlots].[idTimeSlot]
--	ORDER BY [doctorLastName]
--GO

--fonctionnalité 2 afficher les rdvs d'un médecin (nom(medecin), date, crénaux, nom prénom(patient))
--SELECT [doctorLastName], [dateRdv], [timeSlot], [userFirstName], [userLastName]
--	FROM [dbo].[rdvs]
--	INNER JOIN [dbo].[doctor] ON [dbo].[rdvs].[id_doctor] = [dbo].[doctor].[id]
--	INNER JOIN [dbo].[timeSlots] ON [dbo].[rdvs].[idTimeSlot] = [dbo].[timeSlots].[idTimeSlot]
--	INNER JOIN [dbo].[users] ON [dbo].[rdvs].[id_users] = [dbo].[users].[id]
--	WHERE [dbo].[doctor].[id] = 2
--GO

--fonctionnalité 3 afficher le rdv d'un patient(nom, prénom(patient), spé, nom, prénom(médecin), date, crénaux)
--SELECT [userLastName], [userFirstName], [speciality], [doctorLastName], [doctorFirstName], [dateRdv], [timeSlot]
--	FROM [dbo].[rdvs]
--	INNER JOIN [dbo].[users] ON [dbo].[rdvs].[id_users] = [dbo].[users].[id]
--	INNER JOIN 	[dbo].[doctor] ON [dbo].[rdvs].[id_doctor] = [dbo].[doctor].[id]
--	INNER JOIN [dbo].[specialitys] ON [dbo].[doctor].[idSpeciality] = [dbo].[specialitys].[idSpeciality]
--	INNER JOIN [dbo].[timeSlots] ON [dbo].[rdvs].[idTimeSlot] = [dbo].[timeSlots].[idTimeSlot]
--	WHERE [dbo].[users].[id] = 5
--GO