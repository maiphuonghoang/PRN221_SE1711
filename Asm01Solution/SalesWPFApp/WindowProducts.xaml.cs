using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowProducts.xaml
    /// </summary>
    public partial class WindowProducts : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public WindowProducts(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            ListView.ItemsSource = _productRepository.GetAllProducts();
        }
        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void btnLoadProduct_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        public Product GetProductObject()
        {
            try
            {
                Product p = new Product()
                {
                    ProductId = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
                    ProductName = txtName.Text,
                    CategoryId = int.Parse(txtCategory.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtPrice.Text),
                    UnitsInStock = int.Parse(txtUnit.Text),
                };
                return p;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void btnInsertProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = GetProductObject();
                if (product != null)
                {
                    product.ProductId = 0;
                    _productRepository.AddProduct(product);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert Product failed " + ex.Message, "Add Product");
            }
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = GetProductObject();
                if (product != null)
                {
                    _productRepository.UpdateProduct(product);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Product failed " + ex.Message , "Update Product");
            }
        }

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = GetProductObject();
                if (product != null)
                {
                    var lsOrderDetail = _orderDetailRepository.GetOrderDetailByProductId(product.ProductId);
                    if (lsOrderDetail.Count() > 0)
                    {
                        MessageBox.Show("Cannot delete Produduct, is being attached with OrderDetails");
                        return;
                    }
                    _productRepository.DeleteProduct(product);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Product failed " + ex.Message, "Delete Product");
            }
        }

        private void btnResetProduct_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = string.Empty;
            txtCategory.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtWeight.Text = string.Empty;
        }

        private void btnSearchById_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtId.Text.Trim() == "")
                {
                    MessageBox.Show("Enter id", "Input Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtId.Focus();
                    return;
                }
                int id = int.Parse(txtId.Text);
                if (id > 0)
                {
                    var product =  _productRepository.GetProductById(id);
                    ListView.ItemsSource = new List<Product> { product };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnSearchByPrice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtPrice.Text.Trim() == "")
                {
                    MessageBox.Show("Enter price", "Input Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtPrice.Focus();
                    return;
                }
                decimal price = decimal.Parse(txtPrice.Text);
                if (price > 0)
                {
                    ListView.ItemsSource = _productRepository.GetProductsByPrice(price);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnSearchByUnit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtUnit.Text.Trim() == "")
                {
                    MessageBox.Show("Enter unit", "Input Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    txtId.Focus();
                    return;
                }
                int unit = int.Parse(txtUnit.Text);
                if (unit > 0)
                {
                    ListView.ItemsSource = _productRepository.GetProductsByUnitInStock(unit);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void btnMemberManagement_Click(object sender, RoutedEventArgs e)
        {
            WindowMembers wm = new WindowMembers(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
            wm.Show();
            this.Close();
        }

        private void btnOrderManagement_Click(object sender, RoutedEventArgs e)
        {
            WindowOrders wo = new WindowOrders(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
            wo.Show();
            this.Close();
        }
    }
}
