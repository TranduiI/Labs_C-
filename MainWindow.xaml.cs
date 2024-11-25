using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Laba14_A
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ToNews_Click(object sender, RoutedEventArgs e)
        {
            if((sender as Hyperlink).Tag != null)
            {
                string path = (sender as Hyperlink).Tag as string;
                Process.Start(path);
            }
            else
            {
                MessageBox.Show("Выберите новость", "Ошибка", MessageBoxButton.OK);
            }
            

        }
    }
}
