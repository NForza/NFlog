using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using NFlog.Core;

namespace NFlog.Viewer
{
    class MessageTemplateSelector : DataTemplateSelector
    {
        static Dictionary<int, string> dataTemplates = new Dictionary<int, string>()
        {
            { MessageTypes.Message, "DefaultMessageTemplate" },
            { MessageTypes.Warning, "WarningTemplate" },
            { MessageTypes.Object, "ObjectTemplate" }
        };

        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var message = item as NFlogMessage;
            if (message == null)
                return null;
            string templateName;
            if (dataTemplates.TryGetValue(message.MessageType, out templateName))
            {
                return Application.Current.Resources[templateName] as DataTemplate;                
            }
            return null;
        }
    }
}
