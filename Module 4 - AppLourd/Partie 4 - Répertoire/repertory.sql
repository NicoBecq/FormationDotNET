--CREATE DATABASE repertory
--GO
--USE [repertory]
--GO

--/*------------------------------------------------------------
--*        Script SQLSERVER 
----------------------------------------------------------*/


--/*------------------------------------------------------------
-- Table: users
----------------------------------------------------------*/
--CREATE TABLE users(
--	idUser      INT IDENTITY (1,1) NOT NULL ,
--	lastName    NVARCHAR (50) NOT NULL ,
--	firstName   NVARCHAR (50) NOT NULL ,
--	userName    NVARCHAR (50) NOT NULL ,
--	mail        VARCHAR (100) NOT NULL ,
--	password    VARCHAR (255) NOT NULL  ,
--	CONSTRAINT users_PK PRIMARY KEY (idUser)
--);


--/*------------------------------------------------------------
-- Table: contacts
----------------------------------------------------------*/
--CREATE TABLE contacts(
--	idContact     INT IDENTITY (1,1) NOT NULL ,
--	lastName      NVARCHAR (50) NOT NULL ,
--	firstName     NVARCHAR (50) NOT NULL ,
--	mail          VARCHAR (100) NOT NULL ,
--	phoneNumber   VARCHAR (255) NOT NULL ,
--	address       VARCHAR (255) NOT NULL ,
--	photo         VARCHAR (255) NOT NULL ,
--	idUser        INT  NOT NULL  ,
--	CONSTRAINT contacts_PK PRIMARY KEY (idContact)

--	,CONSTRAINT contacts_users_FK FOREIGN KEY (idUser) REFERENCES users(idUser)
--);