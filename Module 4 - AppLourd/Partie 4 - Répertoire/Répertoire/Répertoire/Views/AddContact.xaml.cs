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
using System.Windows.Shapes;
using Répertoire.Models;

namespace Répertoire.Views
{
    /// <summary>
    /// Logique d'interaction pour AddContact.xaml
    /// </summary>
    public partial class AddContact : Window
    {
        public AddContact()
        {
            InitializeComponent();
        }

        // regexs
        private string nameRegex = @"^[A-Za-zéàèêëïîç\- ]+$";
        private string mailRegex = @"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$";
        private string phoneRegex = @"^((\+)33|0)[1-9](\d{2}){4}$";

        // bool vérifs
        private bool nameAreValid = false;
        private bool mailIsValid = false;
        private bool phoneNumberIsValid = false;
        private bool addressIsValid = false;

        // méthode de validation lastName ou firstName
        private string NameValidation(string name)
        {
            string errorMessage = "";
            // si name n'est pas null, continuer vérifs, sinon message d'erreur
            if (!string.IsNullOrEmpty(name))
            {
                // si name passe la regex, 
                if(Regex.IsMatch(name, nameRegex))
                {
                    nameAreValid = true;
                    return errorMessage = "";
                }
                else
                {
                    nameAreValid = false;
                    return errorMessage = "Ce champ n'est pas valide.";
                }
            }
            else
            {
                nameAreValid = false;
                return errorMessage = "Ce champ est requis.";
            }
        }

        // validation du mail
        private void MailValidation()
        {
            string mail = mailTextBox.Text;
            // si le textbox n'est pas null, continuer vérifs, sinon message d'erreur
            if (!string.IsNullOrEmpty(mail))
            {
                // si mail passe la regex, il est valide, sinon message d'erreur
                if (Regex.IsMatch(mail, mailRegex))
                {
                    mailIsValid = true;
                    mailErrorMessage.Text = "";
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

        // validation du téléphone
        private void PhoneNumberValidation()
        {
            string phone = phoneNumberTextBox.Text;
            // si phone n'est pas null, continuer vérifs, sinon message d'erreur
            if (!string.IsNullOrEmpty(phone))
            {
                // si il passe la regex, il est valide, sinon message d'erreur
                if (Regex.IsMatch(phone, phoneRegex))
                {
                    phoneNumberIsValid = true;
                    phoneNumberErrorMessage.Text = "";
                }
                else
                {
                    phoneNumberIsValid = false;
                    phoneNumberErrorMessage.Text = "Numéro de téléphone n'est pas valide.";
                }
            }
            else
            {
                phoneNumberIsValid = false;
                phoneNumberErrorMessage.Text = "Ce champ est requis.";
            }
        }

        // validation adresse
        private void AddressValidation()
        {
            string address = addressTextBox.Text;
            // si address n'est pas vide, il est valide, sinon il n'est pas vailde
            if (!string.IsNullOrEmpty(address))
            {
                addressIsValid = true;
                addressErrorMessage.Text = "";
            }
            else
            {
                addressIsValid = false;
                addressErrorMessage.Text = "Ce champs est requis";
            }
        }

        /// <summary>
        /// méthodes qui vont valider les champs lors de la perte de focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            lastNameErrorMessage.Text = NameValidation(lastNameTextBox.Text);
        }

        private void FirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            firstNameErrorMessage.Text = NameValidation(firstNameTextBox.Text);
        }

        private void MailTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            MailValidation();
        }

        private void PhoneNumberTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PhoneNumberValidation();
        }

        private void AddressTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            AddressValidation();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            // validation des champs du formulaire
            lastNameErrorMessage.Text = NameValidation(lastNameTextBox.Text);
            firstNameErrorMessage.Text = NameValidation(firstNameTextBox.Text);
            MailValidation();
            PhoneNumberValidation();
            AddressValidation();
            // si tous mes champs sont valides, ajouter
            if (nameAreValid && mailIsValid && phoneNumberIsValid && addressIsValid)
            {
                try
                {
                    if (Logic.SaveContactInfo(lastNameTextBox.Text, firstNameTextBox.Text, mailTextBox.Text, phoneNumberTextBox.Text, addressTextBox.Text) == 1)
                    {
                        MessageBox.Show("Le contact a bien été ajouté.", "Ajout", MessageBoxButton.OK);
                    }
                }
                catch
                {
                    MessageBox.Show("Une erreur est survenue, veuillez réessayer.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ButtonReturnProfil_Click(object sender, RoutedEventArgs e)
        {
            Profil profilWindow = new Profil();
            profilWindow.Show();
            this.Close();
        }
    }
}