using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Laba13_A
{
    class DateMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string dateFormat = "d-M-yyyy";
            
            string parsedDate = (string)values[0]+"-"+(string)values[1]+"-"+(string)values[2];
            DateTime dateTime;
            if(DateTime.TryParseExact(parsedDate, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return dateTime.ToString("dd.MM.yyyy");
            }
            else
            {
                return "Некорректная дата";
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            DateTime date;
            string dateFormat = "dd.MM.yyyy";
            if (DateTime.TryParseExact((string)value,dateFormat, CultureInfo.InvariantCulture,DateTimeStyles.None, out date))
            {
                string day = date.Day.ToString();
                string month = date.Month.ToString();
                string year = date.Year.ToString();
                return new object[] { day, month, year };
            }
            else
            {
                return new object[] { "", "", "" };
            }
        }
    }
}
