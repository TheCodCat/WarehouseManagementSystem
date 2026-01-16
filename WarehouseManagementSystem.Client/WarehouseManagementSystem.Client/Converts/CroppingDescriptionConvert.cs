using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WarehouseManagementSystem.Client.Converts
{
    public class CroppingDescriptionConvert : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            int charCount = 200;
            if (value is string strValue)
            {
                StringBuilder stringBuilder = new StringBuilder();
                var str = strValue.Length >= charCount ? stringBuilder.Append(strValue[..charCount]) : stringBuilder.Append(strValue[..strValue.Length]);
                stringBuilder.Append(str);

                if(strValue.Length > charCount)
                    stringBuilder.Append("...");

                return stringBuilder.ToString();
            }
            else
                return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return default;
        }
    }
}
