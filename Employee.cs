using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba13_C
{
    public class Employee : INotifyPropertyChanged
    {
        private string name;
        private int depID;
        public event PropertyChangedEventHandler PropertyChanged;

        public Employee(string name)
        {
            this.name = name;
        }
        public int DepID
        {
            get => depID;
            set
            {
                depID = value;
                OnPropertyChanged("DepID");
            }
        }
        public string EmplName { get => name; }
        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}