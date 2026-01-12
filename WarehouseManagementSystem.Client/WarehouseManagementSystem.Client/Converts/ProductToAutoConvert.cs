using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using WarehouseManagementSystem.Client.Models;

namespace WarehouseManagementSystem.Client.Converts
{
    public class ProductToAutoConvert : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
       {
            if(value is IList<ProductMaui> productMauis)
            {
                return productMauis.Select(x => $"{x.Id} {x.Name} {x.Description}");
            }
            else
                return null;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
