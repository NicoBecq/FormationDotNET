using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Répertoire.Models;

namespace Répertoire.Helper_Code
{
    class DAL
    {
        public static int executeQuery(string query)
        {
            // chaine de connexion
            string strConn = "data source=dotnet3\\SQLEXPRESS; initial catalog=repertory; integrated security=True; multipleactiveresultsets=True; database=repertory; integrated security=SSPI;";

            // variable permettant de retourner le nombre de lignes afféctées
            int rowCount = 0;
            // instanciation des objets de type sqlConnection et sqlCommand
            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            // attribution de valeurs aux attributs de l'objet sqlCommand
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandTimeout = 2 * 3600;

            // connection à la bdd
            sqlConnection.Open();

            // nombre de lignes afféctées
            rowCount = sqlCommand.ExecuteNonQuery();

            // fermeture de la connexion à la bdd
            sqlConnection.Close();

            return rowCount;
        }

        // méthode permettant d'executer une requete scalaire
        public static string executeScalarQuery(string query)
        {
            // déclaration d'une variable a laquelle on va attribuer l'id de l'utilisateur 
            object selectedId = null;
            string selectedIdString = null;


            string strConn = "data source=dotnet3\\SQLEXPRESS; initial catalog=repertory; integrated security=True; multipleactiveresultsets=True; database=repertory; integrated security=SSPI;";

            SqlConnection sqlConnection = new SqlConnection(strConn);
            SqlCommand sqlCommand = new SqlCommand();

            sqlCommand.CommandText = query;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandTimeout = 2 * 3600;

            try
            {
                // connection à la bdd
                sqlConnection.Open();

                // execute scalar, qui permet de retrouver la première colonne de la première ligne de la query select               
                selectedId = sqlCommand.ExecuteScalar();

                if (selectedId != null)
                {
                    selectedIdString = selectedId.ToString();
                }

                // fermeture de connexion 
                sqlConnection.Close();
            }
            catch (Exception e)
            {                
                sqlConnection.Close();
                throw e;
            }

            return selectedIdString;
        }

        public static DataSet ExecuteDataSetQuery(string query)
        {
            string strConn = "data source=dotnet3\\SQLEXPRESS; initial catalog=repertory; integrated security=True; multipleactiveresultsets=True; database=repertory; integrated security=SSPI;";

            // instanciation d'un objet de type sqlConnection
            SqlConnection sqlConnection = new SqlConnection(strConn);

            // ouverture de la connexion
            sqlConnection.Open();

            // id de l'utilisateur actuellement connécté
            string idConnectedUser = Logic.idConnectedUser;
            //query
            SqlCommand sqlCommand = new SqlCommand();

            // attribution de valeurs aux attributs de l'objet sqlCommand
            sqlCommand.CommandText = query;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandTimeout = 2 * 3600;

            // instanciation d'un objet adapter de la classe SqlDataAdaptateur
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = sqlCommand;
            // instanciation d'un objet dataSet de la classe DataSet
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet); // remplis l'objet adapter avec l'objet dataSet 

            // fermeture de la connexion
            sqlConnection.Close();

            return dataSet;
        }
    }
}