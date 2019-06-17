using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Répertoire.Helper_Code;

namespace Répertoire.Models
{
    class Logic
    {
        public static void SaveUserInfo(string lastName, string firstName, string userName, string mail, string password)
        {
            try
            {
                // création et stockage de la requete sql
                string query = "INSERT INTO [dbo].[users]([lastName], [firstName], [userName], [mail], [password])" +
                    "VALUES ('" + lastName + "', '" + firstName + "', '" + userName + "', '" + mail + "', '" + password + "')";

                // execute la requete
                DAL.executeQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // méthode permettant de chercher dans la base si le mail saisi pas l'utilisateur est déjà enregistré 
        public static string SearchForMail(string mail)
        {
            // requete sql
            string query = "SELECT [idUser] FROM [dbo].[users] WHERE [mail] = '" + mail + "';";

            return DAL.executeScalarQuery(query);
        }

        public static string idConnectedUser = "0";

        // méthode permettant de chercher dans la base l'utilisateur qui essaye de se connecter
        public static string SearchForUser(string mail, string password)
        {
            try
            {
                string query = "SELECT [idUser] FROM [dbo].[users] WHERE [mail] = '" + mail + "' AND [password] = '" + password + "';";

                idConnectedUser = DAL.executeScalarQuery(query);

                return idConnectedUser;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // sélectionne l'utilisateur connécté
        public static DataSet selectConnectedUserQuery()
        {
            try
            {
                string query = "SELECT [lastName], [firstName], [userName], [mail] FROM [dbo].[users] WHERE [idUser] = '" + idConnectedUser + "';";
                return DAL.ExecuteDataSetQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // saveContactInfo
        public static int SaveContactInfo(string lastName, string firstName, string mail, string phone, string address)
        {
            try
            {
                // query
                string query = "INSERT INTO [dbo].[contacts]([lastName], [firstName], [mail], [phoneNumber], [address], [idUser]) VALUES ('" + lastName + "', '" + firstName + "', '" + mail + "', '" + phone + "', '" + address + "', '" + idConnectedUser + "');";

                return DAL.executeQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // searchForContacts
        public static DataSet SearchForContacts()
        {
            try
            {
                string query = "SELECT [lastName], [firstName], [mail], [phoneNumber], [address] FROM [dbo].[contacts] WHERE [idUser] = '" + idConnectedUser + "';";
                return DAL.ExecuteDataSetQuery(query);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
