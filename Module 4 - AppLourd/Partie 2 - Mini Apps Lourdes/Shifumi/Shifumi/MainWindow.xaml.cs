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

namespace Shifumi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // déclaration de variables
        private int UserPlay = 0;
        private int nbrTry = 0;
        private int IARoundWon = 0;
        private int UserRoundWon = 0;
        private int EqualityRound = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            // si un des radioButton est checked, passer au vérifs suivantes
            if (RadioButtonRock.IsChecked == true || RadioButtonPaper.IsChecked == true || RadioButtonScissors.IsChecked == true)
            {
                // génération est stockage d'un nbre aléatoire compris entre 1 et 3 inclus
                int IAPlay = new Random().Next(1, 4);
                // incrémentation du nbre d'essais
                nbrTry++;

                // affichage du coup de l'ia
                switch (IAPlay)
                {
                    // 1 = pierre
                    case 1:
                        TextBlockIAPlay.Text = "L'IA choisi la pierre.";
                        ImageIAPlay.Source = new BitmapImage(new Uri("/Imgs/Pierre.png", UriKind.Relative));
                        break;
                    // 2 = feuille
                    case 2:
                        TextBlockIAPlay.Text = "L'IA choisi la feuille.";
                        ImageIAPlay.Source = new BitmapImage(new Uri("/Imgs/Feuille.png", UriKind.Relative));
                        break;
                    // 3 = ciseaux
                    case 3:
                        TextBlockIAPlay.Text = "L'IA choisi les ciseaux.";
                        ImageIAPlay.Source = new BitmapImage(new Uri("/Imgs/Ciseaux.png", UriKind.Relative));
                        break;
                }

                // affichage des images des coups par l'utilisateur joués et du texte correspondant
                // si pierre est joué par l'utilisateur, afficher les trucs correspondants
                if (RadioButtonRock.IsChecked == true)
                {
                    UserPlay = 1;
                    TextBlockUserPlay.Text = "Vous avez choisi la pierre.";
                    ImageUserPlay.Source = new BitmapImage(new Uri("/Imgs/Pierre.png", UriKind.Relative));
                }
                else if (RadioButtonPaper.IsChecked == true)
                {
                    UserPlay = 2;
                    TextBlockUserPlay.Text = "Vous avez choisi la feuille.";
                    ImageUserPlay.Source = new BitmapImage(new Uri("/Imgs/Feuille.png", UriKind.Relative));
                }
                else if (RadioButtonScissors.IsChecked == true)
                {
                    UserPlay = 3;
                    TextBlockUserPlay.Text = "Vous avez choisi les ciseaux.";
                    ImageUserPlay.Source = new BitmapImage(new Uri("/Imgs/Ciseaux.png", UriKind.Relative));
                }

                // comparaison des coups joués
                // si les coups sont différents continuer les vérifs
                if (UserPlay != IAPlay)
                {
                    // si l'utilisateur joue pierre, vérifier ce que joue l'IA
                    if (UserPlay == 1)
                    {
                        // si l'IA joue feuille, il gagne
                        if (IAPlay == 2)
                        {
                            TextBlockResultOfRound.Text = "L'IA gagne ce round.";
                            IARoundWon++;
                        }
                        // si l'IA joue ciseaux, l'utilisateur gagne
                        else if (IAPlay == 3)
                        {
                            TextBlockResultOfRound.Text = "Vous gagnez ce round.";
                            UserRoundWon++;
                        }
                    }
                    // si l'utilisateur joue feuille, vérifier ce que joue l'IA
                    else if (UserPlay == 2)
                    {
                        // si l'IA joue pierre, il perds
                        if (IAPlay == 1)
                        {
                            TextBlockResultOfRound.Text = "Vous gagnez ce round.";
                            UserRoundWon++;
                        }
                        // si l'IA joue ciseaux, il gagne
                        else if (IAPlay == 3)
                        {
                            TextBlockResultOfRound.Text = "L'IA gagne ce round.";
                            IARoundWon++;
                        }
                    }
                    // si l'utilisateur joue ciseaux, vérifier ce que joue l'IA
                    else if (UserPlay == 3)
                    {
                        // si l'IA joue piere, il gagne
                        if (IAPlay == 1)
                        {
                            TextBlockResultOfRound.Text = "L'IA gagne ce round.";
                            IARoundWon++;
                        }
                        // si l'IA joue feuille, il perds
                        else if (IAPlay == 2)
                        {
                            TextBlockResultOfRound.Text = "Vous gagnez ce round.";
                            UserRoundWon++;
                        }
                    }
                }
                // sinon, égalité
                else
                {
                    EqualityRound++;
                    TextBlockResultOfRound.Text = "Egalité.";
                }
                // afficher stats
                TextBlockUserRoundWon.Text = "Victoires : " + UserRoundWon.ToString();
                TextBlockIARoundWon.Text = "Défaites : " + IARoundWon.ToString();
                TextBlockEgalityRound.Text = "Egalitées : " + EqualityRound.ToString();
                // calcul et stockage du pourcentage de victoire utilisateur
                int UserWinPercent = 100 * UserRoundWon / nbrTry;
                TextBlockPercentUserVictory.Text = "Pourcentage de victoire : " + UserWinPercent.ToString() + " %";
            }
            // sinon, message d'erreur
            else
            {
                MessageBox.Show("Veuillez choisir un coup pour pourvoir vous mesurer au programme.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
