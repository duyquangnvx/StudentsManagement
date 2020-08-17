using Students_Management.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Students_Management.Converters
{
    public class FinalScoreConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int studentId = (int)parameter;
            MonHoc subject = value as MonHoc;
            double score = subject.BangDiems.Where(t => t.IdHocSinh == studentId).Average(t => t.Diem).Value;
            return score.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
