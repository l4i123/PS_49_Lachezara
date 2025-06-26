using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Globalization;
using System.Windows.Data;
namespace UI.Converters
{
    public class PasswordHiderConverter : IValueConverter
    {
        public object Convert(object  value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string password)
            {
                return password.Length > 0 ? new string('*', password.Length) : string.Empty;
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
              return Binding.DoNothing;
        }
    
    }
}
