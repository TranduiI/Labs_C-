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
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace Laba15_B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int rows, columns;
        private string path;
        private ObservableCollection<List<string>> datas;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ObservableCollection<List<string>> Datas
        {
            get
            {
                return datas;
            }
            set
            {
                datas = value;
                GenerateColumns();
                CheckRow();
                OnPropertyChanged("Datas");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            ObservableCollection<List<string>> initData = new ObservableCollection<List<string>>() { new List<string>() { "" } };
            Datas = initData;
        }

        private void GenerateColumns()
        {
            dataGrid.Columns.Clear();
            columns = datas[0].Count;
            rows = datas.Count;
            for (int i = 0; i < datas[0].Count; i++)
            {
                DataGridTextColumn column = new DataGridTextColumn();
                column.Binding = new Binding($"[{i}]");
                dataGrid.Columns.Add(column);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "Excel book (*.xlsx)| *.xlsx";
            saveFileDialog.DefaultExt = "Excel book (*.xlsx)| *.xlsx";
            if (saveFileDialog.ShowDialog() == true)
            {
                Excel.Application app = new Excel.Application();
                Excel.Workbook workbook = app.Workbooks.Add();
                Excel.Worksheet worksheet = workbook.Worksheets[1];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        worksheet.Cells[i + 1, j + 1].Value = datas[i][j];
                    }
                }
                workbook.SaveAs(saveFileDialog.FileName);
                workbook.Close();
                MessageBox.Show($"Файл сохранен как {saveFileDialog.FileName}!");
            }
        }
        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel book (*.xlsx)| *.xlsx";
            openFileDialog.DefaultExt = "Excel book (*.xlsx)| *.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                path = openFileDialog.FileName;
                Load();
            }
        }
        private void Load()
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook workbook = app.Workbooks.Open(path);
            Excel.Worksheet worksheet = workbook.Worksheets[1];
            ObservableCollection<List<string>> initData = new ObservableCollection<List<string>>();
            for (int i = 1; i <= worksheet.UsedRange.Rows.Count; i++)
            {
                List<string> row = new List<string>();
                for (int j = 1; j <= worksheet.UsedRange.Columns.Count; j++)
                {
                    row.Add((worksheet.Cells[i, j] as Excel.Range).Value.ToString());
                }
                initData.Add(row);
            }
            workbook.Close();
            Datas = initData;
        }
        private void BtnRowAdd(object sender, RoutedEventArgs e)
        {
            List<string> newRow = new List<string>();
            for (int i = 0; i < columns; i++)
            {
                newRow.Add("");
            }
            datas.Add(newRow);
            Datas = datas;
        }
        private void BtnRowDel(object sender, RoutedEventArgs e)
        {
            datas.RemoveAt(datas.Count - 1);
            Datas = datas;
        }

        private void CheckRow()
        {
            btnRowDel.IsEnabled = (rows > 1);
            btnColDel.IsEnabled = (columns > 1);
        }

        private void BtnColAdd(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < rows; i++)
            {
                datas[i].Add("");
            }
            Datas = datas;
        }

        private void BtnColDel(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < rows; i++)
            {
                datas[i].RemoveAt(datas[i].Count - 1);
            }
            Datas = datas;
        }
    }
}