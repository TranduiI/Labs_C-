using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba13_C
{
    public class Department : INotifyPropertyChanged
    {
        private string depName;
        private ObservableCollection<Employee> employees;
        public event PropertyChangedEventHandler PropertyChanged;

        public Department(string depName)
        {
            this.depName = depName;
            employees = new ObservableCollection<Employee>();
        }
        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged("Employees");
            }
        }
        public string DepName { get => depName; }
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
