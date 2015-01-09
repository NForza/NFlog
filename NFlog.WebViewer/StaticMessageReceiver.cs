using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using NFlog.Core;

namespace NFlog.WebViewer
{
    public class StaticMessageReceiver
    {
        static List<NFlogMessage> messages = new List<NFlogMessage>();

        private static CloudTable _table;

        public static void MessageReceived(NFlogMessage message)
        {
            if (message != null)
            {
                messages.Add(message);
                AddMessageToAzureStorage(message);
            }
        }

        private static void AddMessageToAzureStorage(NFlogMessage message)
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

        private static CloudTable GetCloudTable()
        {
            if (_table == null)
            {
                var storageAccount = CloudStorageAccount.Parse(
                    ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);

                var tableClient = storageAccount.CreateCloudTableClient();
                _table = tableClient.GetTableReference("nflog");
                _table.CreateIfNotExists();
            }
            return _table;
        }

        public static IEnumerable<NFlogMessage> Messages
        {
            get { return messages; }
        }
    }
}