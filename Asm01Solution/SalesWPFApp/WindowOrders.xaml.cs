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
using System.Windows.Shapes;
using BusinessObject.Models;
using System.Windows.Automation.Text;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for WindowOrders.xaml
    /// </summary>
    public partial class WindowOrders : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public WindowOrders(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            InitializeComponent();
            author();
            LoadData();
        }
        void author()
        {
            if (GlobalValues.IsAdmin == false)
            {
                btnProductManagement.IsEnabled = false;
            }
        }
        private void LoadData()
        {

            var orders = new List<OrderDTO>();
            var lsOrder = _orderRepository.GetAllOrders();
            foreach (var item in lsOrder)
            {
                var mb = _memberRepository.GetMemberById(item.MemberId);
                OrderDTO tmp = new OrderDTO()
                {
                    OrderId = item.OrderId,
                    MemberId = item.MemberId,
                    Email = mb != null ? mb.Email : null,
                    OrderDate = item.OrderDate,
                    RequiredDate = item.RequiredDate,
                    ShippedDate = item.ShippedDate,
                    Freight = item.Freight,
                    Member = item.Member,
                };
                orders.Add(tmp);
            }

            ListView.ItemsSource = orders;
            cbMember.ItemsSource = (_memberRepository.GetAllMembers()).ToList();
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
                Order o = new Order()
                {
                    OrderId = string.IsNullOrEmpty(txtOrderId.Text) ? 0 : int.Parse(txtOrderId.Text),
                    OrderDate = (DateTime)dpOrderDate.SelectedDate,
                    RequiredDate = dpRequiredDate.SelectedDate,
                    ShippedDate = dpShippedDate.SelectedDate,
                    Freight = string.IsNullOrEmpty(txtFreight.Text) ? 0 : decimal.Parse(txtFreight.Text),
                    MemberId = selectedMemberId,

                };
                return o;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        private void btnLoadOrder_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void btnInsertOrder_Click(object sender, RoutedEventArgs e)
        {
            WindowInsertOrder wio = new WindowInsertOrder(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
            wio.Show();
            this.Close();
        }

        private void btnUpdateOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = GetOrderObject();
                if (order != null)
                {
                    _orderRepository.UpdateOrder(order);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Order failed " + ex.Message, "Update Order");
            }
        }

        private void btnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var order = GetOrderObject();
                if (order != null)
                {
                    var lsOrderDetail = _orderDetailRepository.GetOrderDetailByOrderId(order.OrderId);
                    //var lsOrderDetail = new PRN221_Assignment01Context().Orders
                    //                    .SelectMany(order => order.OrderDetails);
                    order.OrderDetails = lsOrderDetail.ToList();
                    if (lsOrderDetail.Count() > 0)
                    {
                        _orderDetailRepository.DeleteOrderDetailByOrderId(lsOrderDetail);
                    }
                    _orderRepository.DeleteOrder(order);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Product failed " + ex.Message, "Delete Product");
            }
        }

        private void btnResetOrder_Click(object sender, RoutedEventArgs e)
        {
            txtOrderId.Text = string.Empty;
            txtFreight.Text = string.Empty;
            cbMember.SelectedItem = null;
            dpOrderDate.SelectedDate = null;
            dpRequiredDate.SelectedDate = null;
            dpShippedDate.SelectedDate = null;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listView = sender as ListView;
            var selectedItem = listView.SelectedItem as OrderDTO;

            if (selectedItem != null)
            {
                cbMember.SelectedValue = selectedItem.MemberId;
                cbMember.SelectedItem = selectedItem;
                txtOrderId.Text = selectedItem.OrderId.ToString();
                txtFreight.Text = selectedItem.Freight.ToString();
                dpShippedDate.SelectedDate = selectedItem.ShippedDate;
                dpOrderDate.SelectedDate = selectedItem.OrderDate;
                dpRequiredDate.SelectedDate = selectedItem.RequiredDate;
            }

        }

        private void btnMemberManagement_Click(object sender, RoutedEventArgs e)
        {
            WindowMembers wm = new WindowMembers(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
            wm.Show();
            this.Close();
        }

        private void btnProductManagement_Click(object sender, RoutedEventArgs e)
        {
            WindowProducts wp = new WindowProducts(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
            wp.Show();
            this.Close();
        }
        private PRN221_Assignment01Context _context = new PRN221_Assignment01Context();
        private void btnReportStatistic_Click(object sender, RoutedEventArgs e)
        {
            WindowReportStatistics wrs = new WindowReportStatistics(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
            wrs.Show();
            this.Close();

        }

    }
}