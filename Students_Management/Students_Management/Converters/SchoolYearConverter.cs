using Students_Management.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Students_Management.Converters
{
    class SchoolYearConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var year = value as NamHoc;
            if (year == null)
            {
                return "Không rõ";
            }
            return String.Format($"{year.NgayBatDau?.Year}-{year.NgayKetThuc?.Year}");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
