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

        private void btnChangeDatabase_Click(object sender, RoutedEventArgs e)
        {
            //insert dữ liệu nếu nó chưa có trong database hoặc edit nếu đã tồn tại.
            //Xoá nếu chỉ có trường ID còn lại bị null và cập nhật 1 datagrid hoặc listview.


        }
    }
}
