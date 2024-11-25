using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Word = Microsoft.Office.Interop.Word;

namespace Laba15_A
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<OrderData> orderDatas = new ObservableCollection<OrderData>();

        public ObservableCollection<OrderData> OrderDatas
        {
            get
            {
                return orderDatas;
            }
            set
            {
                orderDatas = value;
                OnPropertyChanged("OrderDatas");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            labelNum.Content = $"Заказ № {Properties.Settings.Default.OrdersCount}";
            labelDate.Content = $"{DateTime.Now.ToShortDateString()}";
            CheckButton();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void CreateDocBtn_Click(object sender, RoutedEventArgs e)
        {
            Word.Application app = new Word.Application();
            Word.Document document = app.Documents.Add($@"{Environment.CurrentDirectory}\Template.docx");
            document.Range().Find.Execute(FindText: "<#>", ReplaceWith: $"{Properties.Settings.Default.OrdersCount}");
            document.Range().Find.Execute(FindText: "<Дата>", ReplaceWith: $"{DateTime.Now.ToShortDateString()}");
            document.Range().Find.Execute(FindText: "<Поставщик>", ReplaceWith: $"{textBoxProvider.Text}");
            document.Range().Find.Execute(FindText: "<Покупатель>", ReplaceWith: $"{textBoxClient.Text}");
            document.Range().Find.Execute(FindText: "<Сумма>", ReplaceWith: $"{CalculateSum()}");
            Word.Table table = document.Tables[1];
            for (int i = 1; i < orderDatas.Count; i++)
            {
                table.Rows.Add(table.Rows[2]);
            }
            for (int i = 0; i < orderDatas.Count; i++)
            {
                table.Rows[2 + i].Cells[1].Range.Text = orderDatas[i].Num;
                table.Rows[2 + i].Cells[2].Range.Text = orderDatas[i].Product;
                table.Rows[2 + i].Cells[3].Range.Text = orderDatas[i].Count + " шт.";
                table.Rows[2 + i].Cells[4].Range.Text = orderDatas[i].Price + " руб.";
                table.Rows[2 + i].Cells[5].Range.Text = orderDatas[i].Summ + " руб.";
            }
            string fileName = $@"{Environment.CurrentDirectory}\Расходная накладная №{Properties.Settings.Default.OrdersCount} от {DateTime.Now.ToShortDateString()}.docx";
            document.SaveAs(FileName: fileName);
            document.Close();
            Properties.Settings.Default.OrdersCount++;
            Properties.Settings.Default.Save();
            MessageBox.Show($"Сформирован документ: {fileName}");
            Close();
        }

        private double CalculateSum()
        {
            double allSum = 0;
            for (int i = 0; i < orderDatas.Count; i++)
            {
                double sum = 0;
                if (double.TryParse(orderDatas[i].Summ, out sum))
                {
                    allSum += sum;
                }
            }
            return allSum;
        }

        private void CellEditEnd(object sender, EventArgs e)
        {
            labelSum.Content = $"{CalculateSum()} руб.";
            CheckButton();
        }

        private void CheckButton()
        {
            if (textBoxClient.Text.Length > 0 &&
                textBoxProvider.Text.Length > 0 &&
                orderDatas.Count > 0)
            {
                createDocBtn.IsEnabled = true;
            }
            else
            {
                createDocBtn.IsEnabled = false;
            }
        }

        private void TextBoxClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckButton();
        }

        private void TextBoxProvider_TextChanged(object sender, TextChangedEventArgs e)
        {
            CheckButton();
        }
    }
}