using ClientPhone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
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

namespace ClientPhone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PRN221_SE1711_Assignment2Context _context = new PRN221_SE1711_Assignment2Context();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
        {
            List<TblPhoneDTO> phones = _context.TblPhones.ToList()
               .Select(item => new TblPhoneDTO()
               {
                   Id = item.Id,
                   Name = item.Name,
                   DateofManufacture = item.DateofManufacture,
                   Branch = item.Branch,
                   StopManufacture = item.StopManufacture,
                   StopManufactureString = item.StopManufacture == true ? "Yes" : "No",
               }).ToList();

            lsPhone.ItemsSource = phones;
            tempPhoneList = phones;
        }

        private void btnLoadData_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
        public TblPhone GetTblPhoneObject()
        {
            try
            {
                return new TblPhone
                {
                    Id = string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text),
                    Name = txtName.Text,
                    Branch = txtBranch.Text,
                    DateofManufacture = dpDateofManufacture.SelectedDate,
                    StopManufacture = cbStopManufacture.IsChecked == true ? true : false,
                };

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot get TblPhone", "Get TblPhone");
            }
            return null;
        }
        private void btnAddToList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var phone = GetTblPhoneObject();
                if (phone != null)
                {
                    phone.Id = 0;
                    _context.TblPhones.Add(phone);
                    _context.SaveChanges();
                    LoadData();
                    MessageBox.Show("Insert TblPhone success " + phone.Id + " " + phone.Name, "Add TblPhone");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Insert TblPhone failed", "Add TblPhone");
            }
        }
        private List<TblPhoneDTO> tempPhoneList = new List<TblPhoneDTO>();

        private void btnSendToServer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var phoneInfo = tempPhoneList;
                string jsonData = JsonSerializer.Serialize(phoneInfo, new JsonSerializerOptions { WriteIndented = true });
                string host = "127.0.0.1";
                int port = 5000;
                try
                {
                    TcpClient tcpClient = new TcpClient(host, port);
                    NetworkStream stream = null;
                    Byte[] data = Encoding.ASCII.GetBytes($"{jsonData}");

                    while (true)
                    {
                        stream = tcpClient.GetStream();
                        stream.Write(data, 0, data.Length);
                        break;

                    }
                    tcpClient.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("{0}", ex.Message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listView_Click(object sender, MouseButtonEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                cbStopManufacture.IsChecked = ((TblPhoneDTO)item).StopManufacture == true ? true : false;
            }
        }
    }
}
