using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Laba16
{
    class SqrRootsMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (double.TryParse((string)values[0], out double a) &&
                double.TryParse((string)values[1], out double b) &&
                double.TryParse((string)values[2], out double c))
            {
                KeyValuePair<double, double> result = RootsCalc.GetRoots(a, b, c);
                if (result.Equals(default(KeyValuePair<double, double>)) == true)
                {
                    return "Нет корней";
                }
                return $"X1: {result.Key}\nX2: {result.Value}";
            }
            else
            {
                return "Не является числом";
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[3] { 0, 0, 0 };
        }
    }
}
