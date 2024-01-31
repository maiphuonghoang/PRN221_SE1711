using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
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
using ClientPhone.Models;
using System.IO;
using System.Text.Json;

namespace ServerPhone
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
        }

        private void btnListen_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Listen);
            thread.Start();
        }
        //update delete khởi dựng delegate
        public void Listen()
        {
            string host = "127.0.0.1";
            int port = 5000;
            int count = 0; //đếm số lượng client kết nối với server 
            TcpListener server = null;
            try
            {
                IPAddress localAddress = IPAddress.Parse(host);
                server = new TcpListener(localAddress, port);
                server.Start();
                Dispatcher.Invoke(() =>
                {
                    txtContent.Text = $"waiting for client connection ... ";

                });
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Dispatcher.Invoke(() =>
                    {
                        txtContent.Text = $"Number of client connected ..." + ++count;

                    });
                    //thread lắng nghe client gửi nhận dữ liệu 
                    Thread newThread = new Thread(new ParameterizedThreadStart(ProcessClient));
                    newThread.Start(client);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        List<TblPhone> phones = new List<TblPhone>();
        private void ProcessClient(object p)
        {
            string data; int count;
            try
            {
                /*
                TcpClient client = p as TcpClient;
                Byte[] bytes = new Byte[1024];
                NetworkStream stream = client.GetStream();
                while ((count = stream.Read(bytes, 0, bytes.Length)) > 0)
                {
                    data = Encoding.ASCII.GetString(bytes);
                    string t = data.ToString();
                    // Process the data sent by the client.
                    List<TblPhone> phones = JsonSerializer.Deserialize<List<TblPhone>>(data);

                    Dispatcher.Invoke(() =>
                    {
                        //txtContent.Text = $"{DateTime.Now:t}" + txtContent.Text + "\r\n" + data;
                        lsPhone.ItemsSource = phones;
                    });
                }
                */
                TcpClient client = p as TcpClient;
                NetworkStream stream = client.GetStream();
                List<byte> receivedBytes = new List<byte>();
                byte[] buffer = new byte[1024];

                int bytesRead;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    for (int i = 0; i < bytesRead; i++)
                    {
                        receivedBytes.Add(buffer[i]);
                    }
                }

                data = Encoding.ASCII.GetString(receivedBytes.ToArray());

                // Process the data sent by the client.
                phones = JsonSerializer.Deserialize<List<TblPhone>>(data);
                processDataToDB();

                Dispatcher.Invoke(() =>
                {
                    lsPhone.ItemsSource = phones;
                });
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void processDataToDB()
        {
            //insert dữ liệu nếu nó chưa có trong database hoặc edit nếu đã tồn tại.
            //Xoá nếu chỉ có trường ID còn lại bị null 
            foreach (var phone in phones)
            {
                var existingPhone = _context.TblPhones.FirstOrDefault(p => p.Id == phone.Id);
                if (existingPhone != null)
                {
                    if (phone.Name.Trim() == "" && phone.Branch.Trim() == "" && phone.DateofManufacture == null && phone.StopManufacture == false)
                    {
                        //delete 
                        _context.Remove(existingPhone);
                        _context.SaveChanges();
                    }
                    else
                    {
                        //update 
                        existingPhone.Id = existingPhone.Id;
                        existingPhone.Branch = phone.Branch;
                        existingPhone.Name = phone.Name;
                        existingPhone.DateofManufacture = phone.DateofManufacture;
                        existingPhone.StopManufacture = phone.StopManufacture;
                        _context.Update(existingPhone);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    //insert 
                    if (!(phone.Name.Trim() == "" && phone.Branch.Trim() == "" && phone.DateofManufacture == null && phone.StopManufacture == false))
                    {
                        phone.Id = 0;
                        _context.Add(phone);
                        _context.SaveChanges();
                    }
                }

            }
            phones = _context.TblPhones.ToList();

        }
    }
}
