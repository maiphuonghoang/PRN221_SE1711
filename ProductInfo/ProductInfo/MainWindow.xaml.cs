using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace ProductInfo
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //tự động cập nhật UI khi list data thay đổi 
        private ObservableCollection<Product> products;
        public MainWindow()
        {
            InitializeComponent();
            products = new ObservableCollection<Product>();
            lsProducts.ItemsSource = products;
        }

        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            //validate information
            var product = new Product
            {
                ID = txtID.Text,
                Name = txtName.Text,
            };
            double.TryParse(txtPrice.Text, out double result);//default 0
            product.Price = result;
            products.Add(product);
        }

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json|All files (*.*)|*.*)";
            if(saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                try
                {
                    string jsonContent = JsonSerializer.Serialize(products);
                    File.WriteAllText(filePath, jsonContent);

                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void validateTextPrice(object sender, TextCompositionEventArgs e)
        {
            var number = new Regex("[^0-9.-]+");
            e.Handled = number.IsMatch(txtPrice.Text);
        }
    }
}
