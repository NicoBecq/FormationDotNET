using System;
using System.Collections.Generic;
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
using Répertoire.Views;

namespace Répertoire.Views
{
    /// <summary>
    /// Logique d'interaction pour LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LogInWindow()
        {
            InitializeComponent();
        }

        //méthode permettant d'afficher la fenêtre d'inscription
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow(); // nouvelle instance d'un objet mainWindow 
            mainWindow.Show(); // ouverture de ce nouvel objet
            this.Close(); // fermeture de la window actuelle
        }

        /// <summary>
        /// méthode de permettant de connecter l'utilisateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            // booléens de validation
            bool formIsValid = true;

            // si le champ mail est vide, message d'erreur
            if (string.IsNullOrEmpty(mailTextBox.Text))
            {
                formIsValid = false;
                mailErrorMessage.Text = "Champ requis.";
            }

            // si le champ password est vide, message d'erreur
            if (string.IsNullOrEmpty(passwordTextBox.Password))
            {
                formIsValid = false;
                passwordErrorMessage.Text = "Champ requis";
            }

            if (formIsValid)
            {
                // si la requete select retourne un id, l'utilisateur est connécté, sinon message d'erreur
                if (string.IsNullOrEmpty(Logic.SearchForUser(mailTextBox.Text, passwordTextBox.Password)))
                {
                    logInErrorMessage.Text = "Mail ou mot de passe incorrect.";
                }
                else
                {
                    MessageBox.Show("Vous êtes connécté!", "Connexion", MessageBoxButton.OK);
                    // instanciation et affichage d'une nouvelle fenêtre Profil et fermeture de LogInWindow
                    Profil profilWindow = new Profil();
                    profilWindow.Show();
                    this.Close();
                }
            }
        }
    }
}
