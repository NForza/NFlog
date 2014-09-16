using NFlog.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NFlog.Viewer
{
    class MessageTemplateSelector: DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var message = item as NFlogMessage;
            if (message == null)
                return null;

            return Application.Current.Resources["DefaultMessageTemplate"] as DataTemplate;
        }
    }
}
