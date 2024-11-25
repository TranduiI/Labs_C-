using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Laba15_A
{
    public class OrderData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private static int num = 0;
        private string count;
        private string price;
        public OrderData()
        {
            num++;
            Num = num.ToString();
        }
        public string Num { get; private set; }
        public string Product { get; set; }

        private void Calculate()
        {
            if (double.TryParse(price, out double p) && double.TryParse(count, out double c))
            {
                Summ = Math.Round(p * c, 2).ToString();
                OnPropertyChanged("Summ");
            }
        }

        public string Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
                Calculate();
            }
        }
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                Calculate();
            }
        }
        public string Summ { get; private set; }
        
    }
}