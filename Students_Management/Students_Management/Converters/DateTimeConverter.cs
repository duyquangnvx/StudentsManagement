using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Student_Manager.Converter
{
    public class DateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime date = (DateTime)value;
            string day = string.Empty, month = String.Empty;
            day = date.Day < 10 ? String.Format($"0{date.Day}") : date.Day.ToString();
            month = date.Month < 10 ? String.Format($"0{date.Month}") : date.Month.ToString();

            return String.Format($"{day}-{month}-{date.Year}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
