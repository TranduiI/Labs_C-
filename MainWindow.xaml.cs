using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Laba17
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int port = 11111;
        private UdpClient userClient;
        private IPAddress chatAddres;
        private IPEndPoint endPoint;
        private bool conStatus;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                
                string username = txtUsername.Text;
                userClient = new UdpClient(new IPEndPoint(IPAddress.Any, port));
                chatAddres = IPAddress.Parse("225.0.0.0");
                endPoint = new IPEndPoint(chatAddres, port);
                userClient.JoinMulticastGroup(chatAddres);
                conStatus = true;
                StartReceive();
                string message = $"Пользователь {username} присоединился к чату.";
                byte[] data = Encoding.UTF8.GetBytes(message);
                userClient.Send(data, data.Length, endPoint);
                Dispatcher.Invoke(() => btnStart.IsEnabled = false);
                Dispatcher.Invoke(() => btnStop.IsEnabled = true);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StartReceive()
        {
            if (userClient != null)
            {
                userClient.BeginReceive(Resieve, null);
            }
        }



        private void Resieve(IAsyncResult result)
        {
            try
            {
                if (userClient != null)
                {
                    if (conStatus != false)
                    {
                        byte[] data = userClient.EndReceive(result, ref endPoint);
                        if (data != null)
                        {
                            string message = Encoding.UTF8.GetString(data);
                            Dispatcher.Invoke(() => listMessages.Items.Add(message));
                            StartReceive();
                        }
                    }
                }
            }
            catch (SocketException)
            {

            }
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (userClient != null)
                {
                    string message = $"[{DateTime.Now}] {txtUsername.Text}: {txtMessage.Text}";
                    byte[] data = Encoding.UTF8.GetBytes(message);
                    userClient.Send(data, data.Length, endPoint);
                    txtMessage.Clear();
                }
                else
                {
                    MessageBox.Show("Клиент не запущен !");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                if (userClient != null)
                {
                    conStatus = false;
                    Dispatcher.Invoke(() => listMessages.Items.Add($"Пользователь {username} покинул чат."));
                    userClient.DropMulticastGroup(chatAddres);
                    userClient.Dispose();
                    userClient.Close();
                    userClient = null;

                    Dispatcher.Invoke(() => btnStart.IsEnabled = true);
                    Dispatcher.Invoke(() => btnStop.IsEnabled = false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
