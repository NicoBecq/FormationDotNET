using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Logique d'interaction pour ListBroker.xaml
    /// </summary>
    public partial class ListBroker : Page
    {
        Models.Diary db = new Models.Diary();

        // regexs
        private string nameRegex = @"^[A-Za-zéàèêëïîç\- ]+";
        private string mailRegex = @"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$";
        private string phoneNumberRegex = @"^0[0-9]{9}$";

        // bool vérifs
        private bool lastNameIsValid = false;
        private bool firstNameIsValid = false;
        private bool mailIsValid = false;
        private bool phoneNumberIsValid = false;

        // définition d'une variable de type collectionviewsource
        private CollectionViewSource brokerViewSource;

        public ListBroker()
        {
            InitializeComponent();

            //définition de la viewSource (lien entre le xaml et code-behind)
            brokerViewSource = (CollectionViewSource)FindResource("brokerViewSource");
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            // chargement data table customers
            db.brokers.Load();

            // sctockage de la data dans la source de la collection
            brokerViewSource.Source = db.brokers.Local;
        }

        // méthode de vérif lastName
        private void LastNameValidation()
        {
            if (!string.IsNullOrEmpty(lastNameTextBox.Text))
            {
                if (Regex.IsMatch(lastNameTextBox.Text, nameRegex))
                {
                    lastNameIsValid = true;
                }
                else
                {
                    LastNameErrorMessage.Text = "Le nom n'est pas valide.";
                }
            }
            else
            {
                LastNameErrorMessage.Text = "Ce champ est requis.";
            }
        }

        // méthode de vérif firstName
        private void FirstNameValidation()
        {
            if (!string.IsNullOrEmpty(firstNameTextBox.Text))
            {
                if (Regex.IsMatch(firstNameTextBox.Text, nameRegex))
                {
                    firstNameIsValid = true;
                }
                else
                {
                    FirstNameErrorMessage.Text = "Le prénom n'est pas valide.";
                }
            }
            else
            {
                FirstNameErrorMessage.Text = "Ce champ est requis.";
            }
        }

        // méthode de vérif mail
        private void MailValidation()
        {
            int idSelectedBroker = int.Parse(idBrokerTextBlock.Text);
            if (!string.IsNullOrEmpty(mailTextBox.Text))
            {
                if (Regex.IsMatch(mailTextBox.Text, mailRegex))
                {
                    if (db.brokers.Any(x => x.mail == mailTextBox.Text & x.idBroker != idSelectedBroker))
                    {
                        MailErrorMessage.Text = "Email déjà utilisé.";
                    }
                    else
                    {
                        mailIsValid = true;
                    }
                }
                else
                {
                    MailErrorMessage.Text = "L'adresse mail n'est pas valide.";
                }
            }
            else
            {
                MailErrorMessage.Text = "Ce champ est requis.";
            }
        }

        // méthode de vérif phoneNumber
        private void PhoneNumberValidation()
        {
            if (!string.IsNullOrEmpty(phoneNumberTextBox.Text))
            {
                if (Regex.IsMatch(phoneNumberTextBox.Text, phoneNumberRegex))
                {
                    phoneNumberIsValid = true;
                }
                else
                {
                    PhoneNumberErrorMessage.Text = "Le numéro de téléphone n'est pas valide.";
                }
            }
            else
            {
                PhoneNumberErrorMessage.Text = "Ce champ est requis.";
            }
        }

        //méthode pour vérif lors de la perte de focus de la textBox
        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            LastNameValidation();
        }

        //méthode pour vérif lors de la perte de focus de la textBox
        private void FirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            FirstNameValidation();
        }

        //méthode pour vérif lors de la perte de focus de la textBox
        private void MailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            MailValidation();
        }

        //méthode pour vérif lors de la perte de focus de la textBox
        private void PhoneNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PhoneNumberValidation();
        }

        private void ButtonUpdateBroker_Click(object sender, RoutedEventArgs e)
        {
            LastNameValidation();
            FirstNameValidation();
            MailValidation();
            PhoneNumberValidation();
            if (lastNameIsValid && firstNameIsValid && mailIsValid && phoneNumberIsValid)
            {
                try
                {
                    Models.broker brokerModified = new Models.broker()
                    {
                        lastName = lastNameTextBox.Text,
                        firstName = firstNameTextBox.Text,
                        mail = mailTextBox.Text,
                        phoneNumber = phoneNumberTextBox.Text
                    };

                    db.SaveChanges();

                    MessageBox.Show("Le courtier à bien été modifié.", "Modification", MessageBoxButton.OK);
                }
                catch
                {
                    MessageBox.Show("Une erreure s'est produite, veuillez réessayer plus tard.", "Modification erreur", MessageBoxButton.OK);
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            // demande de confirmation
            MessageBoxResult answer = MessageBox.Show("Etes-vous sûr de vouloir supprimer " + firstNameTextBox.Text + " " + lastNameTextBox.Text + "?\nCette opération est définitive", "Attention | Suppression", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            // si il réponds oui, supprimer, sinon close messagebox
            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    // delete requete linq
                    db.brokers.Remove(db.brokers.Find(int.Parse(idBrokerTextBlock.Text)));
                    db.SaveChanges();
                    MessageBox.Show("Client supprimé avec succès", "Suppression réussie", MessageBoxButton.OK);
                }
                catch
                {
                    MessageBox.Show("Une erreur s'est produite, veuillez réessayer ultérieurement", "Erreur", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}