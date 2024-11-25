using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Laba13_B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<TrolleyBus> buses;
        public MainWindow()
        {
            InitializeComponent();
            textBoxCount.Text = "1";
        }
        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            buses = TrolleyBus.GetTrolleyBuses();
            GenerateAll();
        }

        private void GenerateAll()
        {
            gridBuses.Children.Clear();
            richTextBoxLog.Document.Blocks.Clear();
            for (int i = 0; i < buses.Count; i++)
            {
                Button button = new Button();
                button.Content = "№"+buses[i].TrNum;
                button.Background = new SolidColorBrush(Color.FromRgb(17, 197, 17));
                button.Click += Button_Click;
                button.Margin = new Thickness(3);
                gridBuses.Children.Add(button);
                Grid.SetColumn(button, i % 15);
                Grid.SetRow(button, i / 15);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            int id = Int32.Parse(button.Content.ToString().Trim('№')) - 1;
            if (buses[id].HasLeft == false)
            {
                string result = buses[id].Drive();
                richTextBoxLog.AppendText(result);
                button.Background = new SolidColorBrush(Color.FromRgb(236, 80, 80));
            }
        }
    }
}
