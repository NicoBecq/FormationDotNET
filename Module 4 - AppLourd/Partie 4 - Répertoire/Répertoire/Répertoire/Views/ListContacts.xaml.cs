using System;
using System.Collections.Generic;
using System.Data;
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
using Répertoire.Models;

namespace Répertoire.Views
{
    /// <summary>
    /// Logique d'interaction pour ListContacts.xaml
    /// </summary>
    public partial class ListContacts : Window
    {
        public ListContacts()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet dataSet = Logic.SearchForContacts();
                contactDataGrid.DataContext = dataSet.Tables[0];
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue, veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonReturnToProfil_Click(object sender, RoutedEventArgs e)
        {
            Profil profilWindow = new Profil();
            profilWindow.Show();
            this.Close();
        }
    }
}
