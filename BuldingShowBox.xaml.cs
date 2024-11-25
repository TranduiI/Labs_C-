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
using System.Windows.Shapes;

namespace Lab5B
{
    /// <summary>
    /// Логика взаимодействия для BuldingShowBox.xaml
    /// </summary>
    public partial class BuldingShowBox : Window
    {
        public string floors;
        public BuldingShowBox()
        {
            InitializeComponent();
        }

        private void labelCountFloorsButton_Click(object sender, RoutedEventArgs e)
        {
            if(labelCountFloorsText.Text != "")
            {
                floors = labelCountFloorsText.Text;
            }
        }
    }
}
