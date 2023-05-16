using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ООО__Товары_для_животных_.Tools;

internal class ProductBackgroundConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var count = (int)value;

        return count == 0 ? Brushes.Gray : Brushes.Transparent;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}