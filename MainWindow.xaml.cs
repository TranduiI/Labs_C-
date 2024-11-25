using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

namespace Laba18_Server
{
    public partial class MainWindow : Window
    {
        private TcpListener listener;
        private bool serverStatus;
        private readonly int port = 1111;
        Thread acceptThread;
        Thread clientThread;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartServer(object sender, RoutedEventArgs e)
        {
            if (!serverStatus)
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();
                serverStatus = true;

                acceptThread = new Thread(AcceptClients);
                acceptThread.Start();

                ServerLog.Text += $"{DateTime.Now}: Server started! Port: {port} \n";
            }
        }

        private void StopServer(object sender, RoutedEventArgs e)
        {
            if (serverStatus)
            {
                listener.Stop();
                serverStatus = false;
                ServerLog.Text += $"{DateTime.Now}: Server stoped! \n";

            }
        }

        private void AcceptClients()
        {
            while (serverStatus)
            {
                try
                {
                    TcpClient client = listener.AcceptTcpClient();
                    clientThread = new Thread(HandleClient);
                    clientThread.Start(client);
                    client.SendTimeout = 100;
                    Dispatcher.Invoke(() => ServerLog.Text += $"{DateTime.Now}: New client connected from IP: {IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString())} \n");
                }
                catch (Exception)
                {
                    serverStatus = false;
                    if (clientThread != null)
                    {
                        clientThread.Abort();
                    }
                    acceptThread.Abort();
                }
            }
        }

        private void HandleClient(object tcpClient)
        {
            TcpClient client = (TcpClient)tcpClient;
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int clientData;

            while ((clientData = stream.Read(buffer, 0, buffer.Length)) != 0)
            {
                string data = Encoding.ASCII.GetString(buffer, 0, clientData);

                byte[] responseData = Encoding.ASCII.GetBytes(data);
                stream.Write(responseData, 0, responseData.Length);
            }

            stream.Dispose();
            client.Close();
        }
    }
}