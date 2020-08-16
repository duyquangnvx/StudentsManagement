using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Students_Management.Converters
{
    class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool gender = (bool)value;

            return gender == false ? "Nam" : "Nữ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string gender = value as string;

            return gender.Equals("Nam") ? false : true;
        }
    }
}
