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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Le_juste_prix
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // initialisation d'un nbre random entre 1 et 50
        public int NbrToGuess = new Random().Next(1, 51);
        public int NbrTry = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // stockage de la saisie utilisateur
            string UserInput = TextBoxUserInput.Text;
            // si la saisie utilisateur peut être convertie en nbre, continuer les tests
            if (int.TryParse(UserInput, out int UserNumber))
            {
                // si la saisie est inférieure à 1 ou supérieure à 50, afficher message d'erreur
                if (UserNumber < 1 || UserNumber > 50)
                {
                    MessageBox.Show("La valeur saisie n'est pas dans les limites", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                // sinon comparer nbre avec le nbre random
                else
                {
                    // si userNumber est plus grand que nbrToGuess, incrémenter nbre d'essais, afficher c'est plus petit
                    if (UserNumber > NbrToGuess)
                    {
                        NbrTry++;
                        MessageBox.Show("C'est plus petit", "Faux", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    // sinon si userNumber est plus petit que nbrToGuess, incrémenter nbre d'essais, afficher c'est plus grand
                    else if (UserNumber < NbrToGuess)
                    {
                        NbrTry++;
                        MessageBox.Show("C'est plus grand", "Faux", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    // sinon si userNumber est égal à nbrToGuess, afficher c'est gagné
                    else if (UserNumber == NbrToGuess)
                    {
                        MessageBox.Show("Bravo, vous avez gagné!!\nLe prix a deviner était " + NbrToGuess + ".\nVous avez trouvé en " + NbrTry + " essais.", "Bravo");
                        // afficher le bouton pour jouer, et cache les différents élements du jeu
                        ButtonPlay.Visibility = Visibility.Visible;
                        TextBlockObjectToGuess.Visibility = Visibility.Hidden;
                        TextBoxUserInput.Visibility = Visibility.Hidden;
                        ButtonTryNbr.Visibility = Visibility.Hidden;
                        LabelForUserInput.Visibility = Visibility.Hidden;
                    }
                }
            }
            // sinon, afficher message d'erreur
            else
            {
                MessageBox.Show("La valeur saisie n'est pas un nombre", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Méthode permettant de jouer/rejouer
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // affiche | cache les différents élements
            ButtonPlay.Visibility = Visibility.Hidden;
            TextBlockObjectToGuess.Visibility = Visibility.Visible;
            TextBoxUserInput.Visibility = Visibility.Visible;
            ButtonTryNbr.Visibility = Visibility.Visible;
            LabelForUserInput.Visibility = Visibility.Visible;
            // remet l'attribut text de textBoxUserInput par défaut
            TextBoxUserInput.Text = ""; // TextBoxUserInput.Clear();
            //remet le compteur de try à 0 et génère un nouveau random 
            NbrTry = 0;
            NbrToGuess = new Random().Next(1, 51);
        }
    }
}