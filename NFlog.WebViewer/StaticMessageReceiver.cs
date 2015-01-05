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

        static CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            ConfigurationManager.ConnectionStrings["AzureStorage"].ConnectionString);

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
            var tableClient = storageAccount.CreateCloudTableClient();
            // Create the table if it doesn't exist.
            CloudTable table = tableClient.GetTableReference("nflog");
            table.CreateIfNotExists();

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

        public static IEnumerable<NFlogMessage> Messages
        {
            get { return messages; }
        }
    }
}