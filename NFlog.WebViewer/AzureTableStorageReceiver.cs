using System;
using Microsoft.WindowsAzure.Storage.Table;
using NFlog.Core;
using NFlog.WebApi;

namespace NFlog.WebViewer
{
    class AzureTableStorageReceiver : AzureTableStorage, IMessageReceiver
    {
        public void MessageReceived(NFlogMessage message)
        {
            if (message != null)            
                AddMessageToAzureStorage(message);            
        }

        private void AddMessageToAzureStorage(NFlogMessage message)
        {
            var table = GetCloudTable();

            AzureMessage amsg = new AzureMessage(message.AppName);

            amsg.AppName = message.AppName;
            amsg.Data = message.Data == null ? String.Empty : message.Data.ToString();
            amsg.DateTime = message.DateTime;
            amsg.Message = message.Message;
            amsg.MessageType = message.MessageType;
            amsg.ThreadID = message.ThreadID;

            TableOperation insertOperation = TableOperation.Insert(amsg);
            var result = table.Execute(insertOperation);
        }

       
    }
}