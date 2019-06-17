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

namespace Diary.Views
{
    /// <summary>
    /// Logique d'interaction pour AddBroker.xaml
    /// </summary>
    public partial class AddBroker : Page
    {
        private Models.Diary db = new Models.Diary();
                
        public AddBroker()
        {
            InitializeComponent();
        }

        // regexs
        private string nameRegex = @"^[A-Za-zéàèêëïîç\- ]+";
        private string mailRegex = @"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$";
        private string phoneNumberRegex = @"^0[0-9]{9}$";

        // bool vérifs
        private bool lastNameIsValid = false;
        private bool firstNameIsValid = false;
        private bool mailIsValid = false;
        private bool phoneNumberIsValid = false;

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

        //méthode de validation du mail
        private void MailValidation()
        {
            // si mail n'est pas null, vérif regex, sinon return false
            if (!string.IsNullOrEmpty(mailTextBox.Text))
            {
                // si il passe la regex return true
                if (Regex.IsMatch(mailTextBox.Text, mailRegex))
                {
                    // si le mail n'est pas déjà pris, return true, sinon return false
                    if (db.brokers.Any(x => x.mail == mailTextBox.Text))
                    {
                        mailErrorMessage.Text = "L'adresse mail est déjà utilisée.";
                        mailIsValid = false;
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

        //méthode de validation du phoneNumber
        private void PhoneNumberValidation()
        {
            // si phoneNumber n'est pas vide, vérif regex, sinon return false
            if (!string.IsNullOrEmpty(phoneNumberTextBox.Text))
            {
                // si il passe la regex, return true, sinon return false
                if (Regex.IsMatch(phoneNumberTextBox.Text, phoneNumberRegex))
                {
                    phoneNumberErrorMessage.Text = "";
                    phoneNumberIsValid = true;
                }
                else
                {
                    phoneNumberIsValid = false;
                    phoneNumberErrorMessage.Text = "Le numéro de téléphone n'est pas valide.";
                }
            }
            else
            {
                phoneNumberIsValid = false;
                phoneNumberErrorMessage.Text = "Ce champ est requis.";
            }
        }

        // méthode qui permettant de vérifier le lastName quand le champ perds le focus
        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            LastNameValidation();
        }

        // méthode de vérification du prénom quand le champ perds le focus
        private void FirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            FirstNameValidation();
        }

        // méthode de vérification du mail quand le champ perds le focus
        private void MailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            MailValidation();
        }

        // méthode de vérification phoneNumber lors de la perte de focus
        private void PhoneNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PhoneNumberValidation();
        }

        private void Button_ClickAddBroker(object sender, RoutedEventArgs e)
        {
            // validation (pour le cas ou on essaye d'enregistrer sans toucher aux champs
            FirstNameValidation();
            LastNameValidation();
            MailValidation();
            PhoneNumberValidation();
            if (lastNameIsValid && firstNameIsValid && mailIsValid && phoneNumberIsValid)
            {
                // nouvelle instance d'un objet broker
                Models.broker newBroker = new Models.broker()
                {
                    lastName = lastNameTextBox.Text,
                    firstName = firstNameTextBox.Text,
                    mail = mailTextBox.Text,
                    phoneNumber = phoneNumberTextBox.Text
                };
                db.brokers.Add(newBroker);
                db.SaveChanges();
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            // récupère le navigationService de la page
            NavigationService nav = NavigationService.GetNavigationService(this);
            // redirection depuis cette page vers ListCustomer
            nav.Navigate(new Uri("Views/ListBroker.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}