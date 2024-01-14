using BusinessObject.Models;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly PRN221_Assignment01Context _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new PRN221_Assignment01Context();
            //this.Visibility = Visibility.Hidden;
        }
        //public MainWindow(PRN221_Assignment01Context context)
        //{
        //    InitializeComponent();
        //    _context = context;
        //}
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //Trước khi đăng nhập thì phải kiểm tra người dùng có nhập đủ các thông tin cần thiết (email & password)
            if (!ValidateLogin())
                return;
            //lấy dữ liệu trong bảng Member để so sánh dữ liệu người dùng 
            Member m = _context.Members.FirstOrDefault(i => i.Email.ToLower() == txtEmail.Text.ToLower());
            if (m != null)
            {
                if (txtPassword.Text == m.Password)
                {
                    MessageBox.Show("Login successfully " + m.Email + " " + m.Password);
                }
                else
                {
                    MessageBox.Show("Invalid password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid email", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            ;
        }
        private bool ValidateLogin()
        {
            if (txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Enter email", "Input Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtEmail.Focus();
                return false;//nếu chưa nhập thông tin thì thoát ở đây 
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Enter password", "Input Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                txtPassword.Focus();
                return false;//nếu chưa nhập thông tin thì thoát ở đây 
            }

            return true;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
