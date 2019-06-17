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
    /// Logique d'interaction pour ListCustomer.xaml
    /// </summary>
    public partial class ListCustomer : Page
    {
        // "conn" bdd
        private Models.Diary db = new Models.Diary();

        // définition d'une variable de type collectionviewsource
        private CollectionViewSource custViewSource;

        public ListCustomer()
        {
            InitializeComponent();

            //définition de la viewSource (lien entre le xaml et code-behind)
            custViewSource = (CollectionViewSource)FindResource("customerViewSource");            
        }

        private void PageListCustomer_Loaded(object sender, RoutedEventArgs e)
        {
            // chargement data table customers
            db.customers.Load();

            // sctockage de la data dans la source de la collection
            custViewSource.Source = db.customers.Local;
        }

        // méthode pour mettre a jour un client
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            // déclaration des regexs
            string mailRegex = @"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$";
            string phoneNumberRegex = @"^0[0-9]{9}$";

            // si tous les champs sont remplis, continuer vérifs, sinon message d'erreur
            if (!string.IsNullOrEmpty(lastNameTextBox.Text) && !string.IsNullOrEmpty(firstNameTextBox.Text) && !string.IsNullOrEmpty(mailTextBox.Text) && !string.IsNullOrEmpty(phoneNumberTextBox.Text) && !string.IsNullOrEmpty(budgetTextBox.Text))
            {
                // test des regexs
                if (Regex.IsMatch(mailTextBox.Text, mailRegex))
                {
                    if (Regex.IsMatch(phoneNumberTextBox.Text, phoneNumberRegex))
                    {
                        // si budget est convertible en int et positif, ajouter, sinon message d'erreur
                        if (int.TryParse(budgetTextBox.Text, out int budget) && budget > 0)
                        {
                            try
                            {
                                Models.customer customerToUpdate = new Models.customer()
                                {
                                    lastName = lastNameTextBox.Text,
                                    firstName = firstNameTextBox.Text,
                                    mail = mailTextBox.Text,
                                    phoneNumber = phoneNumberTextBox.Text,
                                    budget = budget
                                };

                                db.SaveChanges();

                                MessageBox.Show("Le client a bien été modifié.", "Client modifié", MessageBoxButton.OK);
                            }
                            catch
                            {
                                MessageBox.Show("Une erreur s'est produite, veuillez réessayer ultérieurement.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Le budget n'est pas valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Le numéro de téléphone n'est pas valide");
                    }
                }
                else
                {
                    MessageBox.Show("L'adresse mail n'est pas valide", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Tous les champs sont obligatoires.", "Erreur, champs requis", MessageBoxButton.OK, MessageBoxImage.Error);
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
                    db.customers.Remove(db.customers.Find(int.Parse(idCustomerTextBlock.Text)));
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