using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Répertoire.Helper_Code;
using Répertoire.Models;
using Répertoire.Views;

namespace Répertoire
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // regexs
        private string nameRegex = @"^[A-Za-zéàèêëïîç\- ]+$";
        private string mailRegex = @"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$";

        // bool vérifs
        private bool lastNameIsValid = false;
        private bool firstNameIsValid = false;
        private bool userNameIsValid = false;
        private bool mailIsValid = false;
        private bool passwordIsValid = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        // méthodes de validation 
        //méthode de validation du lastname
        public void LastNameValidation()
        {
            // si lastNameToValidate n'est pas vide, vérif regex, sinon, return faux
            if (!string.IsNullOrEmpty(lastNameTextBox.Text))
            {
                // si il passe la regex, return true
                if (Regex.IsMatch(lastNameTextBox.Text, nameRegex))
                {
                    lastNameErrorMessage.Text = "";
                    lastNameIsValid = true;
                }
                else
                {
                    lastNameIsValid = false;
                    lastNameErrorMessage.Text = "Le nom de famille n'est pas valide";
                }
            }
            else
            {
                lastNameIsValid = false;
                lastNameErrorMessage.Text = "Ce champ est requis";
            }
        }

        //méthode de validation de firstName
        private void FirstNameValidation()
        {
            // si firstNameToValidate n'est pas null, vérif regex, sinon return false
            if (!string.IsNullOrEmpty(firstNameTextBox.Text))
            {
                // si il passe la regex, return true
                if (Regex.IsMatch(firstNameTextBox.Text, nameRegex))
                {
                    firstNameErrorMessage.Text = "";
                    firstNameIsValid = true;
                }
                else
                {
                    firstNameIsValid = false;
                    firstNameErrorMessage.Text = "Le prénom n'est pas valide.";
                }
            }
            else
            {
                firstNameIsValid = false;
                firstNameErrorMessage.Text = "Ce champ est requis.";
            }
        }

        //méthode de validation de userName
        private void UserNameValidation()
        {
            // si firstNameToValidate n'est pas null, vérif regex, sinon return false
            if (!string.IsNullOrEmpty(userNameTextBox.Text))
            {
                // si il passe la regex, return true
                if (Regex.IsMatch(userNameTextBox.Text, nameRegex))
                {
                    userNameErrorMessage.Text = "";
                    userNameIsValid = true;
                }
                else
                {
                    userNameIsValid = false;
                    userNameErrorMessage.Text = "Le prénom n'est pas valide.";
                }
            }
            else
            {
                userNameIsValid = false;
                userNameErrorMessage.Text = "Ce champ est requis.";
            }
        }

        //méthode de validation du mail
        private void MailValidation()
        {
            // si mail n'est pas null, vérif regex, sinon return false
            if (!string.IsNullOrEmpty(mailTextBox.Text))
            {
                // si il passe la regex return true
                if (Regex.IsMatch(mailTextBox.Text, mailRegex))
                {
                    if (Logic.SearchForMail(mailTextBox.Text) != null)
                    {
                        mailIsValid = false;
                        mailErrorMessage.Text = "Ce mail est déjà présent dans la base de données.";
                    }
                    else
                    {
                        mailErrorMessage.Text = "";
                        mailIsValid = true;
                    }
                }
                else
                {
                    mailIsValid = false;
                    mailErrorMessage.Text = "L'adresse mail n'est pas valide.";
                }
            }
            else
            {
                mailIsValid = false;
                mailErrorMessage.Text = "Ce champ est requis.";
            }
        }

        //méthode de validation du password
        private void PasswordValidation()
        {
            // si le mdp n'est pas null, vérifs, sinon return false
            if (!string.IsNullOrEmpty(passwordTextBox.Password))
            {
                passwordIsValid = true;
            }
            else
            {
                passwordIsValid = false;
                passwordErrorMessage.Text = "Champ requis.";
            }
        }

        // vérifs sur la perte de focus
        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            LastNameValidation();
        }

        private void FirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            FirstNameValidation();
        }

        private void UserNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            UserNameValidation();
        }

        private void MailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            MailValidation();
        }

        private void PasswordTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PasswordValidation();
        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            LastNameValidation();
            FirstNameValidation();
            UserNameValidation();
            MailValidation();
            PasswordValidation();

            if (lastNameIsValid && firstNameIsValid && userNameIsValid && mailIsValid && passwordIsValid)
            {
                // si password et confirmPassword sont égaux, try add, sinon message d'erreur
                if (confirmPasswordTextBox.Password == passwordTextBox.Password)
                {
                    try
                    {
                        Logic.SaveUserInfo(lastNameTextBox.Text, firstNameTextBox.Text, userNameTextBox.Text, mailTextBox.Text, passwordTextBox.Password);
                        lastNameTextBox.Text = "";
                        firstNameTextBox.Text = "";
                        userNameTextBox.Text = "";
                        mailTextBox.Text = "";
                        passwordTextBox.Password = "";
                        confirmPasswordTextBox.Password = "";
                        MessageBox.Show("Compte crée avec succès.", "Inscription réussie", MessageBoxButton.OK);
                    }
                    catch 
                    {
                        MessageBox.Show("Une erreur est survenue, veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    confirmPasswordErrorMessage.Text = "Les mots de passe ne sont pas identiques.";
                }
            }
        }

        // méthode permettant d'afficher une nouvelle fenêtre
        private void ButtonLogIn_Click(object sender, RoutedEventArgs e)
        {
            LogInWindow logInWindow = new LogInWindow(); // nouvelle instance d'un objet logInWindow 
            logInWindow.Show(); // ouverture de ce nouvel objet
            this.Close(); // fermeture de la mainWindow
        }
    }
}
