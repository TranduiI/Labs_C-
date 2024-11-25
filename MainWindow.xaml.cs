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
using System.Threading;
using System.ComponentModel;

namespace Lab5B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Elevator elevator;

        public MainWindow()
        {
            InitializeComponent();
            elevator = new Elevator();
            UpdateElevatorInfo();
            UpdateListFloors();

        }

        private void TextBoxCountFloors_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9) return;
            if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) return;
            if (e.Key >= Key.Back) return;
            e.Handled = true;
        }

        private void ButtonUpdateBuilding_Click(object sender, RoutedEventArgs e)
        {
            elevator = new Elevator(int.Parse(textBoxCountFloors.Text));
            UpdateElevatorInfo();
            UpdateListFloors();
            listBoxHistory.Items.Clear();
        }

        private void TextBoxCountFloors_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxCountFloors.Text == "")
            {
                buttonUpdateBuilding.IsEnabled = false;
            }
            else
            {
                buttonUpdateBuilding.IsEnabled = true;
            }
        }

        private void UpdateElevatorInfo()
        {
            labelCountFloors.Content = elevator.GetMaxFloor();
            labelNowFloor.Content = elevator.GetFloor();
            labelStatusElevator.Content = elevator.GetStatus();
        }

        private void UpdateListFloors()
        {
            listBoxSelectedFloor.Items.Clear();
            for (int i = 1; i <= elevator.MaxFloor; i++)
            {
                if (i == elevator.Floor) continue;
                listBoxSelectedFloor.Items.Add(i);
            }
            CheckStatusFloor();
        }

        private void CheckStatusFloor()
        {
            if (listBoxSelectedFloor.SelectedIndex != -1 && elevator.Status == Action.Closed)
            {
                buttonGoTo.IsEnabled = true;
            }
            else
            {
                buttonGoTo.IsEnabled = false;
            }
            if (elevator.Status == Action.Down || elevator.Status == Action.Up)
            {
                buttonCloseDoor.IsEnabled = false;
                buttonOpenDoor.IsEnabled = false;
            }
            else
            {
                buttonCloseDoor.IsEnabled = true;
                buttonOpenDoor.IsEnabled = true;
            }
        }

        private void ButtonGoTo_Click(object sender, RoutedEventArgs e)
        {
            int neededFloor = (int)listBoxSelectedFloor.SelectedItem;
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChange;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
            worker.RunWorkerAsync(neededFloor);
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string result = elevator.End();
            listBoxHistory.Items.Add(result);
            CheckStatusFloor();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs args)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            int neededFloor = (int)args.Argument;
            string result = "";
            while (elevator.Floor != neededFloor)
            {
                result = "";
                if (elevator.Floor > neededFloor)
                {
                    result = elevator.Down();
                }
                else
                {
                    result = elevator.Up();
                }
                worker.ReportProgress(0, result);
                Thread.Sleep(500);
            }
        }

        private void Worker_ProgressChange(object obj, ProgressChangedEventArgs args)
        {
            string res = (string)args.UserState;
            listBoxHistory.Items.Add(res);
            UpdateListFloors();
            UpdateElevatorInfo();
        }

        private void ButtonOpenDoor_Click(object sender, RoutedEventArgs e)
        {
            string result = elevator.Open();
            listBoxHistory.Items.Add(result);
            UpdateElevatorInfo();
            CheckStatusFloor();
        }

        private void ButtonCloseDoor_Click(object sender, RoutedEventArgs e)
        {
            string result = elevator.Close();
            listBoxHistory.Items.Add(result);
            UpdateElevatorInfo();
            CheckStatusFloor();
        }

        private void ListBoxSelectedFloor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CheckStatusFloor();
        }
    }
}
