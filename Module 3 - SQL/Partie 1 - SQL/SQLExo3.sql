--exercice 1
--ALTER TABLE [dbo].[languages] ADD versions NVARCHAR;  

--exercice3
--USE webDevelopment;
--EXEC sp_rename 'languages.versions', 'version'; --sp_rename est une procédure stockée plutot conseillé de suppr et recréer plutot que de remane.

--exercice 5
--ALTER TABLE [dbo].[frameworks]
--ALTER COLUMN [version] NVARCHAR(10);

-- TP
--USE [codex];
--ALTER TABLE [dbo].[clients]
--	DROP COLUMN [secondPhoneNumber];
--GO
--EXEC sp_rename 'clients.firstPhoneNumber', 'phoneNumber', 'COLUMN';
--GO
--ALTER TABLE [dbo].[clients]
--	ALTER COLUMN [phoneNumber] NVARCHAR;
--GO
--ALTER TABLE [dbo].[clients]
--	ADD zipCode NVARCHAR,
--		city NVARCHAR;
--GO
