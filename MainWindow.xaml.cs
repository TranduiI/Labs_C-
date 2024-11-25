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

namespace Laba13_C
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Department> Deps { get; set; }
        private Department depItem;

        public Department DepItem
        {
            get => depItem;
            set
            {
                depItem = value;
                OnPropertyChanged("DepItem");
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Deps = new ObservableCollection<Department>() { new Department("IT"), new Department("Marketing"), new Department("Finance") };
            Deps[0].Employees = new ObservableCollection<Employee>() { new Employee("John Moralez"), new Employee("Michael Jackson") };
            Deps[1].Employees = new ObservableCollection<Employee>() { new Employee("Steve Jobs"), new Employee("Tim Cook"), new Employee("Jordan Belfort") };
            Deps[2].Employees = new ObservableCollection<Employee>() { new Employee("Steve Wonder"), new Employee("Tom Robinson") };
            //DepItem = Deps[0];
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
