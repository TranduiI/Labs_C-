using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Lab5_WPF
{
    class Coffee
    {
        private string type;
        private bool isMilk;
        private bool isSugar;
        private int price;
        private BitmapImage image;

        public Coffee()
        {
            type = "Американо";
            image = new BitmapImage(new Uri("pack://siteoforigin:,,,/Images/americano.png")); //
            isMilk = true;
            isSugar = true;
            price = 300;
        }

        public Coffee(string type, bool isMilk, bool isSugar, int price)
        {
            switch (type)
            {
                case "Americano":
                    image = new BitmapImage(new Uri("pack://siteoforigin:,,,/Images/americano.png"));
                    this.type = "Американо";
                    break;
                case "Cappuchino":
                    image = new BitmapImage(new Uri("pack://siteoforigin:,,,/Images/capuchino.png"));
                    this.type = "Капучино";
                    break;
                case "Espresso":
                    image = new BitmapImage(new Uri("pack://siteoforigin:,,,/Images/espresso.png"));
                    this.type = "Эспрессо";
                    break;
                case "Cocoa":
                    image = new BitmapImage(new Uri("pack://siteoforigin:,,,/Images/cocoa.png"));
                    this.type = "Какао";
                    break;
            }
            this.isMilk = isMilk;
            this.isSugar = isSugar;
            this.price = price;
        }

        public override string ToString()
        {
            string result = "Вы купили ";
            result += $"кофе \"{type}\" ";
            if (IsMilk == true) result += "с молоком ";
            if (IsSugar == true) result += "с сахаром ";
            result += "!";
            return result;
        }

        public bool IsMilk
        {
            get
            {
                return isMilk;
            }
            set
            {
                isMilk = value;
            }
        }

        public bool IsSugar
        {
            get
            {
                return isSugar;
            }
            set
            {
                isSugar = value;
            }
        }

        public int Price
        {
            get
            {
                return price + ((isSugar == true) ? 10 : 0) + ((isMilk == true) ? 20 : 0);
            }
        }

        public BitmapImage Image
        {
            get
            {
                return image;
            }
        }
    }
}

