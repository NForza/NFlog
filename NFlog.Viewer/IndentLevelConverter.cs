using System;
using System.Windows;
using System.Windows.Data;

namespace NFlog.Viewer
{
    public class IndentLevelConverter : IValueConverter
    {
        const int defaultIndentLevel = 10;

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int val = (int)value;

            if (parameter == null)
            {
                return IntToLeftMargin(defaultIndentLevel * val);
            }
            return IntToLeftMargin(int.Parse((string)parameter) * val);
        }

        private Thickness IntToLeftMargin(int leftMargin)
        {
            return new Thickness(leftMargin, 0, 0, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
