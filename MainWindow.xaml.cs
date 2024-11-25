using Lab5_WPF;
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


namespace Lab5_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int money = 0;
        private Coffee coffee;
        private int change = 0;

        public MainWindow()
        {
            InitializeComponent();
            coffee = new Coffee();
            UpdateCoffee();
        }

        private void RadioButtonAmericano_Click(object sender, RoutedEventArgs e)
        {
            coffee = new Coffee("Americano", (bool)checkBoxMilk.IsChecked, (bool)checkBoxSugar.IsChecked, 300);
            UpdateCoffee();
        }

        private void RadioButtonCappuchino_Click(object sender, RoutedEventArgs e)
        {
            coffee = new Coffee("Cappuchino", (bool)checkBoxMilk.IsChecked, (bool)checkBoxSugar.IsChecked, 450);
            UpdateCoffee();
        }

        private void RadioButtonEspresso_Click(object sender, RoutedEventArgs e)
        {
            coffee = new Coffee("Espresso", (bool)checkBoxMilk.IsChecked, (bool)checkBoxSugar.IsChecked, 200);
            UpdateCoffee();
        }

        private void RadioButtonCocoa_Click(object sender, RoutedEventArgs e)
        {
            coffee = new Coffee("Cocoa", (bool)checkBoxMilk.IsChecked, (bool)checkBoxSugar.IsChecked, 50);
            UpdateCoffee();
        }

        private void CheckBoxSugar_Click(object sender, RoutedEventArgs e)
        {
            coffee.IsSugar = (bool)checkBoxSugar.IsChecked;
            UpdateCoffee();
        }

        private void CheckBoxMilk_Click(object sender, RoutedEventArgs e)
        {
            coffee.IsMilk = (bool)checkBoxMilk.IsChecked;
            UpdateCoffee();
        }

        private void ButtonAddMoney_Click(object sender, RoutedEventArgs e)
        {
            money += int.Parse(textBoxMoney.Text);
            UpdateTextMoney();
        }

        private void TextBoxMoney_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9) return;
            if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) return;
            e.Handled = true;
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            string result = coffee.ToString() + $"\n Сдача: {change}";
            money = 0;
            UpdateTextMoney();
            MessageBox.Show(result);
        }

        private void UpdateTextMoney()
        {
            labelSum.Content = money.ToString();
            if (money < coffee.Price)
            {
                change = 0;
                buttonOK.IsEnabled = false;
            }
            else
            {
                change = money - coffee.Price;
                buttonOK.IsEnabled = true;
            }
            labelChange.Content = change.ToString();
        }

        private void UpdateCoffee()
        {
            if (coffee.IsSugar == true)
            {
                ImageSugar.Visibility = Visibility.Visible;
            }
            else
            {
                ImageSugar.Visibility = Visibility.Hidden;
            }
            if (coffee.IsMilk == true)
            {
                ImageMilk.Visibility = Visibility.Visible;
            }
            else
            {
                ImageMilk.Visibility = Visibility.Hidden;
            }
            ImageCoffee.Source = coffee.Image;
            labelPrice.Content = coffee.Price;
            UpdateTextMoney();
        }
    }

}
