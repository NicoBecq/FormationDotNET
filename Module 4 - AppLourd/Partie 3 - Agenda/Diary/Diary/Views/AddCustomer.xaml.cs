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
    /// Logique d'interaction pour AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Page
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void Button_ClickAddCustomer(object sender, RoutedEventArgs e)
        {
            // "conn" bdd
            Models.Diary db = new Models.Diary();

            // regexs
            string mailRegex = @"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$";
            string phoneNumberRegex = @"^0[0-9]{9}$";

            // nouvelle instance d'un objet customer
            Models.customer newCustomer = new Models.customer();
            // si la textbox lastName n'est pas vide, l'ajouter à l'objet, sinon message d'erreur
            if (!string.IsNullOrEmpty(lastNameTextBox.Text))
            {
                newCustomer.lastName = lastNameTextBox.Text;
                // si la textBox frstName n'est pas vide, l'ajouter à l'objet, sinon messsage d'erreur
                if (!string.IsNullOrEmpty(firstNameTextBox.Text))
                {
                    newCustomer.firstName = firstNameTextBox.Text;
                    // si la textbox mail n'est pas vide, vérif regex, sinon message d'erreur
                    if (!string.IsNullOrEmpty(mailTextBox.Text))
                    {
                        // si il passe la regex, je l'ajoute, sinon message d'erreur
                        if (Regex.IsMatch(mailTextBox.Text, mailRegex))
                        {
                            newCustomer.mail = mailTextBox.Text;
                            // si la textbox phoneNumber n'est pas vide, vérif regex, sinon message d'erreur
                            if (!string.IsNullOrEmpty(phoneNumberTextBox.Text))
                            {
                                // si il passe la regex, ajouter, sinon message d'erreur
                                if (Regex.IsMatch(phoneNumberTextBox.Text, phoneNumberRegex))
                                {
                                    newCustomer.phoneNumber = phoneNumberTextBox.Text;
                                    // si la textbox budget n'est pas vide, tryparse, sinon message d'erreur
                                    if (!string.IsNullOrEmpty(budgetTextBox.Text))
                                    {
                                        // si c'est convertible en int, l'ajouter, sinon message d'erreur
                                        if (int.TryParse(budgetTextBox.Text, out int budget) && budget > 0)
                                        {
                                            newCustomer.budget = budget;
                                            // si le mail existe déjà dans la bdd, message d'erreur, sinon, insérer
                                            if (db.customers.Any(x => x.mail == newCustomer.mail))
                                            {
                                                MessageBox.Show("Le client que vous essayer d'ajouter semble déjà exister.", "Client déjà présent dans la base de données.", MessageBoxButton.OK, MessageBoxImage.Error);
                                            }
                                            else
                                            {
                                                // ajout dans la bdd
                                                try
                                                {
                                                    db.customers.Add(newCustomer);
                                                    db.SaveChanges();
                                                    MessageBox.Show("Client ajouté avec succès.", "Succès!", MessageBoxButton.OK);
                                                    lastNameTextBox.Text = "";
                                                    firstNameTextBox.Text = "";
                                                    mailTextBox.Text = "";
                                                    phoneNumberTextBox.Text = "";
                                                    budgetTextBox.Text = "";                                                    
                                                }
                                                // si erreur, message d'erreur
                                                catch
                                                {
                                                    MessageBox.Show("Une erreur s'est produite.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Le budget n'est pas vailde.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Veuillez renseigner le buget.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Le numéro de télephone n'est pas vailde.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Veuillez renseigner le numéro de télephone", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }                        
                        else
                        {
                            MessageBox.Show("L'addresse mail n'est pas valide.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Veuillez renseigner l'adresse mail.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez renseigner le prénom.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Veuillez renseigner le nom de famille.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // méthode permettant de rediriger vers la page listCustomer sur le bouton annuler
        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            // redirection depuis cette page vers ListCustomer
            this.NavigationService.Navigate(new Uri("Views/ListCustomer.xaml", UriKind.RelativeOrAbsolute));
            //autre méthode
            //this.NavigationService.Navigate(new ListCustomer());
        }
    }
}