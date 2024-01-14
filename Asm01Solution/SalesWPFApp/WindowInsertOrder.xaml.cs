using BusinessObject.Models;
using DataAccess.Repository;
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

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowInsertOrder.xaml
    /// </summary>
    public partial class WindowInsertOrder : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public WindowInsertOrder(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
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
            cbMember.ItemsSource = (_memberRepository.GetAllMembers()).ToList();
            dynamicCheckBoxProduct();
        }

        private void dynamicCheckBoxProduct()
        {
            PRN221_Assignment01Context context = new PRN221_Assignment01Context();
            var product = context.Products.ToList();
            foreach (var item in product)
            {
                CheckBox chk = new CheckBox();
                chk.Content = item.ProductName.ToString();
                //chk.Tag = item.ProductId;
                chk.Tag = item;
                chk.Checked += CheckBox_Checked;
                chk.Unchecked += CheckBox_Unchecked;

                stProduct.Children.Add(chk);
            }
        }
        ICollection<Product> lsProduct = new List<Product>();
        private Dictionary<CheckBox, Grid> checkBoxToGridMap = new Dictionary<CheckBox, Grid>();
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            Product selectedProduct = (Product)chk.Tag;
            lsProduct.Add(selectedProduct);
            //MessageBox.Show(lsProduct.Count()+"");
            // Create a new horizontal container (Grid) for each product
            Grid productGrid = new Grid();
            productGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80) });
            productGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80) });
            productGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
            productGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80) });
            productGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
            productGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(80) });
            productGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });

            // Create a Label for the product name
            Label lbProduct = new Label();
            lbProduct.Content = selectedProduct.ProductName;
            lbProduct.Margin = new Thickness(5);
            productGrid.Children.Add(lbProduct);
            Label lbUnitPrice = new Label();
            lbUnitPrice.Content = "UnitPrice";
            lbUnitPrice.Margin = new Thickness(5);
            Label lbQuantity = new Label();
            lbQuantity.Content = "Quantity";
            lbQuantity.Margin = new Thickness(5);
            Label lbDiscount = new Label();
            lbDiscount.Content = "Discount";
            lbDiscount.Margin = new Thickness(5);

            // Create TextBox controls for unitPrice, quantity, and discount
            TextBox txtUnitPrice = new TextBox();
            TextBox txtQuantity = new TextBox();
            TextBox txtDiscount = new TextBox();
            txtUnitPrice.Margin = new Thickness(5);
            txtQuantity.Margin = new Thickness(5);
            txtDiscount.Margin = new Thickness(5);
            txtUnitPrice.Tag = "txtUnitPrice" + selectedProduct.ProductId;
            txtQuantity.Tag = "txtQuantity" + selectedProduct.ProductId;
            txtDiscount.Tag = "txtDiscount" + selectedProduct.ProductId;

            // Add TextBox controls to the Grid
            Grid.SetColumn(lbUnitPrice, 1);
            Grid.SetColumn(txtUnitPrice, 2);
            Grid.SetColumn(lbQuantity, 3);
            Grid.SetColumn(txtQuantity, 4);
            Grid.SetColumn(lbDiscount, 5);
            Grid.SetColumn(txtDiscount, 6);

            productGrid.Children.Add(txtUnitPrice);
            productGrid.Children.Add(txtQuantity);
            productGrid.Children.Add(txtDiscount);
            productGrid.Children.Add(lbUnitPrice);
            productGrid.Children.Add(lbQuantity);
            productGrid.Children.Add(lbDiscount);

            checkBoxToGridMap.Add(chk, productGrid);

            // Add the Grid to the StackPanel
            stProduct.Children.Add(productGrid);
        }
        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            Product selectedProduct = (Product)chk.Tag;
            lsProduct.Remove(selectedProduct);
            //MessageBox.Show(lsProduct.Count()+"");
            // Check if the CheckBox is in the mapping
            if (checkBoxToGridMap.TryGetValue(chk, out Grid productGrid))
            {
                // Remove the Grid from the StackPanel
                stProduct.Children.Remove(productGrid);

                // Remove the mapping
                checkBoxToGridMap.Remove(chk);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = GetOrderObject();
                if (order != null)
                {
                    order.OrderId = 0;
                    _orderRepository.AddOrder(order);
                    MessageBox.Show("Create Order + OrderDetail success", "Create Order");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Create Order failed " + ex.Message, "Create Order");
            }
        }

        List<OrderDetail> getOrderDetails()
        {
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var product in lsProduct)
            {
                TextBox txtUnitPrice = FindTextBoxByProductId(product.ProductId, "txtUnitPrice");
                TextBox txtQuantity = FindTextBoxByProductId(product.ProductId, "txtQuantity");
                TextBox txtDiscount = FindTextBoxByProductId(product.ProductId, "txtDiscount");

                // Create OrderDetail using the values from TextBox controls
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = 0,
                    ProductId = product.ProductId,
                    UnitPrice = string.IsNullOrEmpty(txtUnitPrice.Text) ? 0 : decimal.Parse(txtUnitPrice.Text),
                    Quantity = string.IsNullOrEmpty(txtQuantity.Text) ? 1 : int.Parse(txtQuantity.Text),
                    Discount = string.IsNullOrEmpty(txtDiscount.Text) ? 0 : float.Parse(txtDiscount.Text),
                };
                orderDetails.Add(orderDetail);
            }

            return orderDetails;
        }
        private Order GetOrderObject()
        {
            try
            {
                int selectedMemberId = 0;
                if (cbMember.SelectedItem != null)
                {
                    Member selectedMember = (Member)cbMember.SelectedItem;
                    selectedMemberId = selectedMember.MemberId;
                }
                else
                {
                    MessageBox.Show("input email");
                    return null;
                }
                List<OrderDetail> orderDetails = getOrderDetails();

                Order o = new Order()
                {
                    OrderId = string.IsNullOrEmpty(txtOrderId.Text) ? 0 : int.Parse(txtOrderId.Text),
                    OrderDate = (DateTime)dpOrderDate.SelectedDate,
                    RequiredDate = dpRequiredDate.SelectedDate,
                    ShippedDate = dpShippedDate.SelectedDate,
                    Freight = string.IsNullOrEmpty(txtFreight.Text) ? 0 : decimal.Parse(txtFreight.Text),
                    MemberId = selectedMemberId,
                    OrderDetails = orderDetails
                };
                //MessageBox.Show(o.Freight+ "");
                return o;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private TextBox FindTextBoxByProductId(int productId, string textBoxType)
        {
            foreach (var child in stProduct.Children)
            {
                if (child is Grid productGrid)
                {
                    var txtBox = productGrid.Children.OfType<TextBox>().FirstOrDefault(txt => txt.Tag != null && txt.Tag.ToString() == textBoxType + productId);
                    if (txtBox != null)
                    {
                        return txtBox;
                    }
                }
            }

            return null;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            clearAllCheckbox();
            txtFreight.Text = string.Empty;
            cbMember.SelectedItem = null;
            dpOrderDate.SelectedDate = null;
            dpRequiredDate.SelectedDate = null;
            dpShippedDate.SelectedDate = null;
        }
        void clearAllCheckbox()
        {
            lsProduct.Clear();

            List<CheckBox> checkedCheckBoxes = stProduct.Children.OfType<CheckBox>().Where(chk => chk.IsChecked == true).ToList();

            foreach (var chk in checkedCheckBoxes)
            {
                if (checkBoxToGridMap.TryGetValue(chk, out Grid productGrid))
                {
                    // Remove the Grid from the StackPanel
                    stProduct.Children.Remove(productGrid);

                    // Remove the mapping
                    checkBoxToGridMap.Remove(chk);
                }
            }
            stProduct.Children.OfType<CheckBox>().ToList().ForEach(chk => chk.IsChecked = false);
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            WindowOrders wo = new WindowOrders(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
            wo.Show();
            this.Close();
        }
    }
}
