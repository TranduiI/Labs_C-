using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
using System.Xml;
using System.Windows.Controls.DataVisualization.Charting;

namespace Laba14_C
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Valute> valutes;
        public ObservableCollection<Valute> Valutes
        {
            get
            {
                return valutes;
            }
            set
            {
                valutes = value;
                OnPropertyChanged("Valutes");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            LoadValutes();
            AllowBtn();
        }

        private void LoadValutes()
        {
            ObservableCollection<Valute> loadedValues = new ObservableCollection<Valute>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"https://www.cbr.ru/scripts/XML_val.asp?d=0");
            XmlNodeList items = doc.SelectNodes("//Item");
            foreach (XmlNode item in items)
            {
                loadedValues.Add(new Valute { Name = item.SelectSingleNode("Name").InnerText, Code = item.Attributes["ID"].InnerText });
            }
            Valutes = loadedValues;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load($@"http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1=" + $"{calendar.SelectedDates[0].ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("en-US"))}" + $@"&date_req2=" + $@"{calendar.SelectedDates[calendar.SelectedDates.Count - 1].ToString("dd/MM/yyyy", CultureInfo.GetCultureInfo("en-US"))}" + $@"&VAL_NM_RQ=" + $@"{(listBoxValute.SelectedItem as Valute).Code}");
            XmlNodeList list = doc.SelectNodes("//Record");
            ObservableCollection<KeyValuePair<string, double>> values = new ObservableCollection<KeyValuePair<string, double>>();
            for (int i = 0; i < list.Count; i++)
            {
                values.Add(new KeyValuePair<string, double>(list[i].Attributes["Date"].Value, double.Parse(list[i].SelectSingleNode("Value").InnerText)));
            }
            chart.Title = (listBoxValute.SelectedItem as Valute).Name;
            LoadChart(values);
        }

        private void LoadChart(ObservableCollection<KeyValuePair<string, double>> values)
        {
            int value = ((radioButtonPie.IsChecked == true) ? 1 : 0) +
                ((radioButtonArea.IsChecked == true) ? 2 : 0) +
                ((radioButtonBar.IsChecked == true) ? 3 : 0) +
                ((radioButtonLine.IsChecked == true) ? 4 : 0) +
                ((radioButtonColumn.IsChecked == true) ? 5 : 0);
            Series series = null;
            switch (value)
            {
                case 1:
                    series = new PieSeries();
                    ((PieSeries)series).ItemsSource = values;
                    ((PieSeries)series).Title = "Value";
                    ((PieSeries)series).DependentValuePath = "Value";
                    ((PieSeries)series).IndependentValuePath = "Key";
                    break;
                case 2:
                    series = new AreaSeries();
                    ((AreaSeries)series).ItemsSource = values;
                    ((AreaSeries)series).Title = "Value";
                    ((AreaSeries)series).DependentValuePath = "Value";
                    ((AreaSeries)series).IndependentValuePath = "Key";
                    break;
                case 3:
                    series = new BarSeries();
                    ((BarSeries)series).ItemsSource = values;
                    ((BarSeries)series).Title = "Value";
                    ((BarSeries)series).DependentValuePath = "Value";
                    ((BarSeries)series).IndependentValuePath = "Key";
                    break;
                case 4:
                    series = new LineSeries();
                    ((LineSeries)series).ItemsSource = values;
                    ((LineSeries)series).Title = "Value";
                    ((LineSeries)series).DependentValuePath = "Value";
                    ((LineSeries)series).IndependentValuePath = "Key";
                    break;
                case 5:
                    series = new ColumnSeries();
                    ((ColumnSeries)series).ItemsSource = values;
                    ((ColumnSeries)series).Title = "Value";
                    ((ColumnSeries)series).DependentValuePath = "Value";
                    ((ColumnSeries)series).IndependentValuePath = "Key";
                    break;
            }
            chart.Series.Clear();
            chart.Series.Add(series);
        }

        private void AllowBtn()
        {
            if (listBoxValute.SelectedItem != null && calendar.SelectedDates.Count > 2)
            {
                buttonShow.IsEnabled = true;
            }
            else
            {
                buttonShow.IsEnabled = false;
            }
        }

        private void LbV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AllowBtn();
        }

        private void Calendar_ChangedDate(object sender, SelectionChangedEventArgs e)
        {
            AllowBtn();
        }
    }
}