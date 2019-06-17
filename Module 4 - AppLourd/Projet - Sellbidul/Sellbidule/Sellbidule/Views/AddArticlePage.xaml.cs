using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Sellbidule.Views
{
    /// <summary>
    /// Logique d'interaction pour AddArticlePage.xaml
    /// </summary>
    public partial class AddArticlePage : Page
    {
        public AddArticlePage()
        {
            InitializeComponent();
        }

        Models.SellbidulModel db = new Models.SellbidulModel();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Models.Category> categories = db.Category.ToList();
            categoryComboBox.DataContext = categories;
            categoryComboBox.SelectedValuePath = "id";
            categoryComboBox.DisplayMemberPath = "name";
        }

        // bool de validation du formulaire
        public bool isValid = true;

        /// <summary>
        /// méthode de validation du champ name
        /// </summary>
        public string NameValidation()
        {
            string name = nameTextBox.Text;
            nameErrorTextBlock.Text = "";
            if (!string.IsNullOrEmpty(name))
            {
                if (name.Length > 100)
                {
                    isValid = false;
                    nameErrorTextBlock.Text = "La nom de l'article ne doit pas dépasser 100 caractères.";
                }
            }
            else
            {
                isValid = false;
                nameErrorTextBlock.Text = "Champ requis.";
            }
            return name;
        }

        /// <summary>
        /// méthode de validation du champ prix
        /// </summary>
        public float PriceValidation()
        {
            string priceInput = priceTextBox.Text;
            priceErrorTextBlock.Text = "";
            float price = 0;
            if (!string.IsNullOrEmpty(priceInput))
            {
                if (!float.TryParse(priceInput, out price))
                {
                    isValid = false;
                    priceErrorTextBlock.Text = "Veuillez saisir un prix valide.";
                }
            }
            else
            {
                isValid = false;
                priceErrorTextBlock.Text = "Champ requis.";
            }
            return price;
        }

        /// <summary>
        /// méthode de validation du champ description
        /// </summary>
        public string DescriptionValidation()
        {
            string description = descriptionTextBox.Text;
            descriptionErrorTextBlock.Text = "";
            if (string.IsNullOrEmpty(description))
            {
                isValid = false;
                descriptionErrorTextBlock.Text = "Champ requis.";
            }
            return description;
        }

        /// <summary>
        /// méthode de validation du champ quantité
        /// </summary>
        public int QuantityValidation()
        {
            string quantityInput = quantityTextBox.Text;
            quantityErrorTextBlock.Text = "";
            int quantity = 0;
            if (!string.IsNullOrEmpty(quantityInput))
            {
                if (!int.TryParse(quantityInput, out quantity))
                {
                    isValid = false;
                    quantityErrorTextBlock.Text = "Veuillez saisir un nombre.";
                }
            }
            else
            {
                isValid = false;
                quantityErrorTextBlock.Text = "Champ requis";
            }
            return quantity;
        }

        public string RefValidation()
        {
            string reference = refTextBox.Text;
            refErrorTextBlock.Text = "";
            if (!string.IsNullOrEmpty(reference))
            {
                if (reference.Length > 10)
                {
                    isValid = false;
                    refErrorTextBlock.Text = "La référence de l'article ne doit pas dépasser 10 caractères.";
                }
            }
            else
            {
                isValid = false;
                refErrorTextBlock.Text = "Champ requis.";
            }
            return reference;
        }

        /// <summary>
        /// a la perte de focus de chaque champ, validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            NameValidation();
        }

        private void PriceTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            PriceValidation();
        }

        private void DescriptionTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            DescriptionValidation();
        }

        private void QuantityTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            QuantityValidation();
        }

        private void RefTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            RefValidation();
        }

        private void AddArticleButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameValidation();
            float price = PriceValidation();
            string description = DescriptionValidation();
            int quantity = QuantityValidation();
            string reference = RefValidation();

            if (!string.IsNullOrEmpty(imageTextBox.Text))
            {
                // déclaration d'une variable path afin de le passer en paramètre de la méthode Copy
                string path = "C:\\www\\Module 4 - AppLourd\\Projet - Sellbidul\\Sellbidule\\Sellbidule\\Pictures";
                // déclaration d'une variable fileName afin de la passer en paramètre de la méthode Copy
                string fileName = fileDialog.FileName.Substring(fileDialog.FileName.LastIndexOf('\\') + 1);
                // copie le fichier sélectionné dans le répertoire path, avec pour nom du fichier fileName
                File.Copy(fileDialog.FileName, System.IO.Path.Combine(path, fileName));
            }
            else
            {
                isValid = false;
            }

            categoryErrorTextBlock.Text = "";
            // validation de la combobox
            if (categoryComboBox.SelectedValue == null)
            {
                isValid = false;
                categoryErrorTextBlock.Text = "Veuillez sélectionner une catégorie.";
            }

            if (isValid)
            {
                Models.Article articleToAdd = new Models.Article()
                {
                    name = name,
                    price = price,
                    description = description,
                    quantity = quantity,
                    reference = reference,
                    id_Category = int.Parse(categoryComboBox.SelectedValue.ToString()),
                    picture = imageTextBox.Text
                };
                try
                {
                    db.Article.Add(articleToAdd);
                    db.SaveChanges();
                    MessageBox.Show("Article ajouté avec succès", "Ajout d'article", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Une erreur est survenue, veuillez réessayer.");
                }
            }
        }

        // nouvel objet fileDialog de la classe OpenFileDialog
        private OpenFileDialog fileDialog = new OpenFileDialog();

        private void ImageTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            // attribution de valeur à l'attribut defaultExt de l'objet fileDialog
            fileDialog.DefaultExt = "jpg";
            // ouverture de la boite de dialog pour sélectionner un fichier
            fileDialog.ShowDialog();
            // remplis la textBox image avec le nom du fichier sélectionné
            imageTextBox.Text = fileDialog.FileName.Substring(fileDialog.FileName.LastIndexOf('\\') + 1);
        }
    }
}