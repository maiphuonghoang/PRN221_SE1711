using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Interaction logic for WindowLogin.xaml
    /// </summary>
    public partial class WindowLogin : Window
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;

        public WindowLogin(IProductRepository productRepository, IMemberRepository memberRepository, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _productRepository = productRepository;
            _memberRepository = memberRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            InitializeComponent();
        }
        private bool isAdmin;
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;
            var admin = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("admin");

            if (email != null && password != null)
            {
                if (email.Equals(admin["email"]) && password.Equals(admin["password"]))
                {
                    GlobalValues.IsAdmin = true;
                    WindowProducts windowProducts = new WindowProducts(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
                    windowProducts.Show();
                    this.Close();
                }
                else
                {
                    GlobalValues.IsAdmin = false;
                    Member member = _memberRepository.GetMemberByEmail(email, password);
                    if (member != null)
                    {
                        WindowMembers windowMembers = new WindowMembers(_productRepository, _memberRepository, _orderRepository, _orderDetailRepository);
                        windowMembers.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Wrong Email or Password");
                    }
                }
            }
            else
            {
                MessageBox.Show("Empty Email or Password");
            }
        }
    }
}
