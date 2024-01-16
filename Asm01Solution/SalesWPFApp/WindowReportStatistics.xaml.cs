using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
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
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowReportStatistics.xaml
    /// </summary>
    public partial class WindowReportStatistics : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public WindowReportStatistics(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {   
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            InitializeComponent();
        }

        private void btnGenerateReportButton_Click(object sender, RoutedEventArgs e)
        {
            DateTime startDate = StartDatePicker.SelectedDate ?? DateTime.MinValue;
            DateTime endDate = EndDatePicker.SelectedDate ?? DateTime.MaxValue;
            var salesData = GetSalesData(startDate, endDate);
            var sortedSalesData = salesData.OrderByDescending(item => item.TotalSales).ToList();

            DataGrid.ItemsSource = sortedSalesData;
            decimal sum = 0;
            sum = sortedSalesData.Sum(item => item.TotalSales);

        }
        private List<SaleDataDTO> GetSalesData(DateTime startDate, DateTime endDate)
        {
            var salesData = new PRN221_Assignment01Context().Orders
                .Where(order => order.OrderDate >= startDate && order.OrderDate <= endDate)
                .SelectMany(order => order.OrderDetails)
                .Select(detail => new SaleDataDTO
                {
                    ProductName = detail.Product.ProductName,
                    UnitPrice = detail.UnitPrice,
                    Quantity = detail.Quantity,
                    Discount = detail.Discount,
                    OrderDate = detail.Order.OrderDate,
                    TotalSales = detail.UnitPrice * detail.Quantity * (1 - (decimal)detail.Discount)
                })
                .ToList();

            return salesData;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            WindowOrders wo = new WindowOrders(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
            wo.Show();
            this.Close();
        }
    }


}
