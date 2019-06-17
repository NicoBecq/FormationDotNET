using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Répertoire.Views;
using Répertoire.Models;

namespace Répertoire.Views
{
    /// <summary>
    /// Logique d'interaction pour Profil.xaml
    /// </summary>
    public partial class Profil : Window
    {
        public Profil()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet dataSet = Logic.selectConnectedUserQuery();
                // si la première table du dataSet contient au moins une ligne, récupérer les informations stockée dedans, sinon message d'erreur
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    // stockage des données du tableau du dataSet dans des variables
                    string userLastName = dataSet.Tables[0].Rows[0]["lastName"].ToString();
                    string userFirstName = dataSet.Tables[0].Rows[0]["firstName"].ToString();
                    string userName = dataSet.Tables[0].Rows[0]["userName"].ToString();
                    string userMail = dataSet.Tables[0].Rows[0]["mail"].ToString();

                    // affichage des données dans leurs textBlock
                    userLastNameTextBlock.Text = userLastName;
                    userFirstNameTextBlock.Text = userFirstName;
                    userNameTextBlock.Text = userName;
                    userMailTextBlock.Text = userMail;
                    userNameArea.Text = userName;
                }
                else
                {
                    MessageBox.Show("Une erreur est survenue, veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue, veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void ButtonAddContact_Click(object sender, RoutedEventArgs e)
        {
            AddContact addContactWindow = new AddContact();
            addContactWindow.Show();
            this.Close();
        }

        private void ButtonListContact_Click(object sender, RoutedEventArgs e)
        {
            ListContacts listContactsWindow = new ListContacts();
            listContactsWindow.Show();
            this.Close();
        }

        private void ButtonDeconnect_Click(object sender, RoutedEventArgs e)
        {
            Logic.idConnectedUser = "0";
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
