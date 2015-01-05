﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace NFlog.WebViewer
{
    public class AzureMessage : TableEntity
    {
        public AzureMessage(string appName)
        {
            PartitionKey = appName;
            RowKey = Guid.NewGuid().ToString();
        }

        public int MessageType { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public string AppName { get; set; }
        public int ThreadID { get; set; }
        public string Data { get; set; }
    }
}