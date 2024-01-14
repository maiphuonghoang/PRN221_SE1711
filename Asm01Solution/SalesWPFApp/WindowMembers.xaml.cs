using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Text;
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
    /// Interaction logic for WindowMembers.xaml
    /// </summary>
    public partial class WindowMembers : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        public WindowMembers(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _orderDetailRepository = orderDetailRepository;
            InitializeComponent();
            LoadData();

        }

        private void LoadData()
        {
            ListView.ItemsSource = _memberRepository.GetAllMembers();
        }

        private void btnLoadMember_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        private Member GetMemberObject()
        {
            try
            {
                Member m = new Member()
                {
                    MemberId = string.IsNullOrEmpty(txtMemberId.Text) ? 0 : int.Parse(txtMemberId.Text),
                    Email = txtEmail.Text,
                    City = txtCity.Text,
                    CompanyName = txtCompanyName.Text,
                    Country = txtCountry.Text,
                    Password = txtPassword.Text,
                };
                return m;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        void validateSaveMember()
        {
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Enter email", "Input Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEmail.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Enter password", "Input Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return;
            }
        }
        private void btnInsertMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                validateSaveMember();
                var member = GetMemberObject();
                if (member != null)
                {
                    member.MemberId = 0;
                    _memberRepository.AddMember(member);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert member failed " + ex.Message, "Add member");
            }
        }

        private void btnUpdateMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                validateSaveMember();
                var member = GetMemberObject();
                if (member != null)
                {
                    _memberRepository.UpdateMember(member);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update member failed " + ex.Message, "Update member");
            }
        }

        private void btnDeleteMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var member = GetMemberObject();
                if (member != null)
                {
                    var lsOrder = _orderRepository.GetOrdersByUser(member.Email);
                    if (lsOrder.Count() > 0)
                    {
                        MessageBox.Show("Cannot delete Member, is being attached with Orders");
                        return;
                    }
                    _memberRepository.DeleteMember(member);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete Member failed " + ex.Message, "Member Product");
            }

        }

        private void btnResetMember_Click(object sender, RoutedEventArgs e)
        {
            txtMemberId.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void btnProductManagement_Click(object sender, RoutedEventArgs e)
        {
            WindowProducts wp = new WindowProducts(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
            wp.Show();
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
