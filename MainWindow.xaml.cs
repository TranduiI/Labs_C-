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

namespace Laba13_A
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
        private bool IsNumber(string enteredText)
        {
            if (!enteredText.All(c => Char.IsNumber(c)))
            {
                return false;
            }
            return true;
        }

        private void TextBoxNumberOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNumber(e.Text);
            base.OnPreviewTextInput(e);
        }
    }
}
