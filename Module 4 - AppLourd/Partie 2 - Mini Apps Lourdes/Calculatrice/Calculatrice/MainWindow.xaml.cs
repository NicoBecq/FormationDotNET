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

namespace Calculatrice
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string operation = "";
        long nbr1 = 0;
        long nbr2 = 0;
        long ResultToDisplay = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button0_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "0";
            } 
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "0";
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "1";
            }
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "1";
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "2";
            }
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "2";
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "3";
            }
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "3";
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "4";
            }
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "4";
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "5";
            }
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "5";
            }
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "6";
            }
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "6";
            }
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "7";
            }
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "7";
            }
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "8";
            }
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "8";
            }
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            if (TextBlockResult.Text == "0")
            {
                TextBlockResult.Text = "9";
            }
            else
            {
                TextBlockResult.Text = TextBlockResult.Text + "9";
            }
        }

        private void ButtonPlus_Click(object sender, RoutedEventArgs e)
        {
            if (nbr1 == 0)
            {
                nbr1 = long.Parse(TextBlockResult.Text);
            }
            else if (nbr1 != 0)
            {
                nbr2 = long.Parse(TextBlockResult.Text);
            }
            operation = "+";
            TextBlockResult.Text = "0";
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            if (nbr1 == 0)
            {
                nbr1 = long.Parse(TextBlockResult.Text);
            }
            else if (nbr1 != 0)
            {
                nbr2 = long.Parse(TextBlockResult.Text);
            }
            operation = "-";
            TextBlockResult.Text = "0";
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            if (nbr1 == 0)
            {
                nbr1 = long.Parse(TextBlockResult.Text);
            }
            else if (nbr1 != 0)
            {
                nbr2 = long.Parse(TextBlockResult.Text);
            }
            operation = "*";
            TextBlockResult.Text = "0";
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            if (nbr1 == 0)
            {
                nbr1 = long.Parse(TextBlockResult.Text);
            }
            else if (nbr1 != 0)
            {
                nbr2 = long.Parse(TextBlockResult.Text);
            }
            operation = "/";
            TextBlockResult.Text = "0";
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            if (nbr1 != 0)
            {
                nbr2 = long.Parse(TextBlockResult.Text);
                if (nbr2 != 0)
                {
                    switch (operation)
                    {
                        case "+":
                            ResultToDisplay = nbr1 + nbr2;
                            nbr1 = ResultToDisplay;
                            TextBlockResult.Text = ResultToDisplay.ToString();
                            break;
                        case "-":
                            ResultToDisplay = nbr1 - nbr2;
                            nbr1 = ResultToDisplay;
                            TextBlockResult.Text = ResultToDisplay.ToString();
                            break;
                        case "*":
                            ResultToDisplay = nbr1 * nbr2;
                            nbr1 = ResultToDisplay;
                            TextBlockResult.Text = ResultToDisplay.ToString();
                            break;
                        case "/":
                            ResultToDisplay = nbr1 / nbr2;
                            nbr1 = ResultToDisplay;
                            TextBlockResult.Text = ResultToDisplay.ToString();
                            break;
                    }
                }
            }
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            TextBlockResult.Text = "";
            nbr1 = 0;
            nbr2 = 0;
            ResultToDisplay = 0;
            TextBlockResult.Text = "0";
        }
    }
}