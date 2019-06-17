--CREATE DATABASE [SellBidule]
--GO
--USE [SellBidule]
--GO

--/*------------------------------------------------------------
---- Table: Category
--------------------------------------------------------------*/
--CREATE TABLE Category(
--	id     INT IDENTITY (1,1) NOT NULL ,
--	name   VARCHAR (50) NOT NULL  ,
--	CONSTRAINT Category_PK PRIMARY KEY (id)
--);


--/*------------------------------------------------------------
---- Table: Article
--------------------------------------------------------------*/
--CREATE TABLE Article(
--	id            INT IDENTITY (1,1) NOT NULL ,
--	reference     VARCHAR (10) NOT NULL ,
--	name          VARCHAR (100) NOT NULL ,
--	price         REAL  NOT NULL ,
--	quantity      INT  NOT NULL ,
--	description   TEXT  NOT NULL ,
--	picture       VARCHAR (255) NOT NULL ,
--	id_Category   INT  NOT NULL  ,
--	CONSTRAINT Article_PK PRIMARY KEY (id)

--	,CONSTRAINT Article_Category_FK FOREIGN KEY (id_Category) REFERENCES Category(id)
--);

--INSERT INTO [dbo].[Category]([name])
--	VALUES	('Nature'),
--			('Maison'),
--			('Informatique')
--GO

--INSERT INTO [dbo].[Article] ([reference], [name], [price], [quantity], [description], [picture], [id_Category])
--VALUES
--  ('N0001', 'Bout de bois � l''unit�', 25, 1, 'Mor�eaux de bois provenant d''if d''argentine ', 'nature1.jpg', 1),
--  ('N0002', 'Cailloux � l''unit�', 34.40, 1, 'Cailloux cuit � tr�s haute temp�rature provenance P�rou', 'nature2.jpg', 1),
--  ('N0003', 'Poignet de terre', 15, 1, 'Poignet de terre sec et impure provenant d''un chantier sur Paris', 'nature3.jpg', 1),
--  ('N0004', 'Feuille morte � l''unit�', 70.25, 1, 'Feuille morte en d�compositon provenance Russie', 'nature4.jpg', 1),
--  ('N0005', 'Bouteille d''air pure', 105, 1, 'Air tout droit venue du sommet de l''evrest', 'nature5.jpg', 1)
--GO
 
--INSERT INTO [dbo].[Article] ([reference], [name], [price], [quantity], [description], [picture], [id_Category])
--VALUES
--  ('M0001', 'Tas de poussiere', 30, 1, 'Poussiere provenant du dessous du canap�e de Jean-Luc Reichmann', 'maison1.jpg', 2),
--  ('M0002', 'Mouchoir � l''unit�', 2, 1, 'Mouchoire de poche seul non utiliser', 'maison2.jpg', 2),
--  ('M0003', 'Toile d''araign�e', 12, 1, 'Vielle Toile d''araign�e a placer dans un coin d''une piece', 'maison3.jpg', 2),
--  ('M0004', 'Canette vide', 60, 1, 'D�coration canette vide sans marque', 'maison4.jpg', 2),
--  ('M0005', 'Mor�eaux de vieux jouet', 25, 1, 'Mor�eaux de vieux jouet a collectionn�s', 'maison5.jpg', 2)
--GO
 
--INSERT INTO [dbo].[Article] ([reference], [name], [price], [quantity], [description], [picture], [id_Category])
--VALUES
--  ('I0001', 'C�ble vid�o 1km HD', 698.92, 1, 'C�ble Vid�o Haute D�finition HR6 Acier 1km F/FTP 250Mhz .', 'informatique1.png', 3),
--  ('I0002', 'Touche de clavier chat', 32, 1, 'Touche de clavier KAWA�E en forme de pate de chat !!', 'informatique2.jpg', 3),
--  ('I0003', 'Vis Pc Gamer', 6.74, 1, 'Vis de PC sp�ciale gamer. Indispensable pour fixer vos multiples cartes graphiques RGB.', 'informatique3.jpg', 3),
--  ('I0004', 'Clef USB 5Ko', 15.36, 1, 'Cette clef usb d''une taille de 5Ko saura stocker vos projets les plus volumineux.', 'informatique4.jpg', 3),
--  ('I0005', 'Clavier M�canique', 178.23, 1, 'clavier m�canique pour gamer. Ce magnifique clavier gamer r�duira votre input lag en jeu de mani�re significative.', 'informatique5.jpg', 3)
--GO