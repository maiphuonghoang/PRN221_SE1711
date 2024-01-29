using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
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

namespace TCPService_SE1711
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
                while(true)
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
            }catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessClient(object p)
        {
            string data; int count;
            try
            {
                TcpClient client = p as TcpClient;
                Byte[] bytes = new Byte[1024];
                NetworkStream stream = client.GetStream();
                while ((count = stream.Read(bytes, 0, bytes.Length)) > 0)
                {
                    data = Encoding.ASCII.GetString(bytes, 0, count);
                    Dispatcher.Invoke(() =>
                    {
                        txtContent.Text = txtContent.Text + "\r\n" + data;
                    });
                }
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

 


    }
}
