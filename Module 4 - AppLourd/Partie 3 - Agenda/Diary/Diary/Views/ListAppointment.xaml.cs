using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diary.Views
{
    /// <summary>
    /// Logique d'interaction pour ListAppointment.xaml
    /// </summary>
    public partial class ListAppointment : Page
    {
        Models.Diary db = new Models.Diary();
        // définition d'une variable de type collectionviewsource
        private CollectionViewSource appointmentViewSource;

        // déclaration d'une liste de type broker et une autre de type customer pour bind dans les comboboxs
        public List<Models.broker> brokersList;

        public List<Models.customer> customersList;

        // déclaration de bools pour vérif form
        private bool idBrokerIsValid = false;
        private bool idCustomerIsValid = false;
        private bool dateIsValid = false;
        private bool hourIsValid = false;
        private bool minutesIsValid = false;

        public ListAppointment()
        {
            InitializeComponent();
            //définition de la viewSource (lien entre le xaml et code-behind)
            appointmentViewSource = (CollectionViewSource)FindResource("appointmentViewSource");

            BindComboBoxBroker();
            BindComboBoxCustomer();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            db.appointments.Load();
            appointmentViewSource.Source = db.appointments.Local;
        }

        // méthode permettant de transmetre la liste de tous les brokers à binder dans le xaml
        public void BindComboBoxBroker()
        {
            brokersList = db.brokers.ToList();
            BrokerComboBox.DataContext = brokersList;
            BrokerComboBox.SelectedValuePath = "idBroker";
        }

        // méthode permettant de transmetre la liste de tous les customers à binder dans le xaml
        public void BindComboBoxCustomer()
        {
            customersList = db.customers.ToList();
            CustomerComboBox.DataContext = customersList;
            CustomerComboBox.SelectedValuePath = "idCustomer";
        }

        // méthode de validation du champ date
        private void DateValidation()
        {
            // remise du message d'erreur à nulle
            datePickerErrorMessage.Text = "";
            if (DatePicker.SelectedDate != null)
            {
                //stockage de la date séléctionnée
                DateTime selectedDate = DatePicker.SelectedDate.Value;
                // si le champ retourne une valeur, continuer les vérifs, sinon message d'erreur
                // si la date est inférieure à la date actuelle, message d'erreur, sinon continuer les vérifs
                if (selectedDate.Year < DateTime.Now.Year && selectedDate.Month < DateTime.Now.Month && selectedDate.Day < DateTime.Now.Day)
                {
                    dateIsValid = false;
                    datePickerErrorMessage.Text = "La date saisie n'est pas valide car passée.";
                }
                else
                {
                    // si la date est samedi ou dimanche message d'erreur, sinon date valide
                    if (selectedDate.DayOfWeek.ToString() == "Saturday" || selectedDate.DayOfWeek.ToString() == "Sunday")
                    {
                        dateIsValid = false;
                        datePickerErrorMessage.Text = "Impossible de prendre un rendez-vous le week-end";
                    }
                    else
                    {
                        dateIsValid = true;
                    }
                }
            }
            else
            {
                datePickerErrorMessage.Text = "Champ requis.";
            }
        }

        // méthode de validation du champ heures
        private void HoursValidation()
        {
            // remise du message d'erreur à nulle
            hoursErrorMessage.Text = "";
            // si le champ n'est pas vide, continuer les vérifs, sinon message d'erreur
            if (!string.IsNullOrEmpty(HoursTextBox.Text))
            {
                // si c'est convertible en int, continuer les vérifs, sinon message d'erreur
                if (int.TryParse(HoursTextBox.Text, out int hours))
                {
                    // si l'heure est entre 8 et 18 heures, continuer vérifs, sinon message d'erreur
                    if (hours >= 8 && hours < 18)
                    {
                        hourIsValid = true;
                    }
                    else
                    {
                        hourIsValid = false;
                        hoursErrorMessage.Text = "Vous ne pouvez prendre de rendez-vous qu'entre 8 heures et 18 heures.";
                    }
                }
                else
                {
                    hourIsValid = false;
                    hoursErrorMessage.Text = "Saisie invalide.";
                }
            }
            else
            {
                hourIsValid = false;
                hoursErrorMessage.Text = "Ce champ est requis.";
            }
        }

        // méthode de validation du champ minutes
        private void MinutesValidation()
        {
            // remise du message d'erreur à nulle
            minutesErrorMessage.Text = "";
            // si le champ n'est pas vide, continuer les vérifs, sinon message d'erreur
            if (!string.IsNullOrEmpty(MinutesTextBox.Text))
            {
                // si la conversion est possible, continuer les vérifs, sinon message d'erreur
                if (int.TryParse(MinutesTextBox.Text, out int minutes))
                {
                    // si minutes sont entre 0 et 59, le champ est valide, sinon message d'erreur
                    if (minutes >= 0 && minutes < 60)
                    {
                        minutesIsValid = true;
                    }
                    else
                    {
                        minutesIsValid = false;
                        minutesErrorMessage.Text = "Saisie invalide.";
                    }
                }
                else
                {
                    minutesIsValid = false;
                    minutesErrorMessage.Text = "Saisie incorecte.";
                }
            }
            else
            {
                minutesIsValid = false;
                minutesErrorMessage.Text = "Ce champ est requis.";
            }
        }

        // méthode qui va vérifier la date sélectionnée lors d'un changement de date
        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // appel de la méthode de validation de la date
            DateValidation();
        }

        // méthode qui va vérifier l'heure sur la perte de focus de l'input
        private void HoursTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // appel de la méthode de validation de l'heure
            HoursValidation();
        }

        // méthode qui va vérifier les minutes lors de la perte de focus de l'input
        private void MinutesTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            // appel de la méthode de validation des minutes
            MinutesValidation();
        }

        private void ButtonUpdateAppointment_Click(object sender, RoutedEventArgs e)
        {
            DateValidation();
            HoursValidation();
            MinutesValidation();
            // si la combobox retroune null, message d'erreur, sinon idBrokerIsValid = true
            if (BrokerComboBox.SelectedValue == null)
            {
                idBrokerErrorMessage.Text = "Champ requis.";
            }
            else
            {
                idBrokerIsValid = true;
            }
            // si la combobox retroune null, message d'erreur, sinon idCustomerIsValid = true
            if (CustomerComboBox.SelectedValue == null)
            {
                idCustomerErrorMessage.Text = "Champ requis.";
            }
            else
            {
                idCustomerIsValid = true;
            }
            if (idBrokerIsValid && idCustomerIsValid && dateIsValid && hourIsValid && minutesIsValid)
            {
                try
                {
                    // nouvel objet qui contient les données du rdv a modifier
                    Models.appointment appointmentToModify = db.appointments.Find(int.Parse(idAppointmentTextBlock.Text));
                    // stockage de la valeur du datepicker                    
                    DateTime selectedDate = DatePicker.SelectedDate.Value;
                    string selectedDateString = selectedDate.Date.ToShortDateString() + " " + HoursTextBox.Text + ":" + MinutesTextBox.Text;
                    selectedDate = Convert.ToDateTime(selectedDateString);

                    Models.appointment appointmentModified = new Models.appointment()
                    {
                        idAppointment = int.Parse(idAppointmentTextBlock.Text),
                        idBroker = Convert.ToInt32(BrokerComboBox.SelectedValue),
                        idCustomer = Convert.ToInt32(CustomerComboBox.SelectedValue),
                        datHour = selectedDate,
                        subject = SubjectTextBox.Text
                    };

                    db.Entry(appointmentToModify).CurrentValues.SetValues(appointmentModified);
                    db.SaveChanges();

                    MessageBox.Show("Le rendez-vous a bien été modifié.", "Modification", MessageBoxButton.OK);
                }
                catch
                {
                    MessageBox.Show("Une erreure s'est produite, veuillez réessayer plus tard.", "Modification erreur", MessageBoxButton.OK);               
                }
            }
        }

        private void ButtonDeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            // demande de confirmation
            MessageBoxResult answer = MessageBox.Show("Etes-vous sûr de vouloir supprimer ce rendez-vous?\nCette opération est définitive!", "Attention | Suppression", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            // si il réponds oui, supprimer, sinon close messagebox
            if (answer == MessageBoxResult.Yes)
            {
                try
                {
                    // delete requete linq
                    db.appointments.Remove(db.appointments.Find(int.Parse(idAppointmentTextBlock.Text)));
                    db.SaveChanges();
                    MessageBox.Show("Rendez-vous supprimé avec succès", "Suppression réussie", MessageBoxButton.OK);
                }
                catch
                {
                    MessageBox.Show("Une erreur s'est produite, veuillez réessayer ultérieurement", "Erreur", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}