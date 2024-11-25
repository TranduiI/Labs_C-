using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laba13_B
{
    class TrolleyBusRule : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int count = 0;
            try
            {
                if (((string)value).Length > 0)
                {
                    count = int.Parse((string)value);
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, $"Только цифры: Входная строка имела неверный формат.");
            }
            if (count < Min || count > Max)
            {
                return new ValidationResult(false, $"Введите колчиество троллейбусов от {Min} до {Max}");
            }
            return ValidationResult.ValidResult;
        }
    }
}

