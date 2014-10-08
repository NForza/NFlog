using System.Collections.ObjectModel;
using Caliburn.Micro;
using Microsoft.Win32;
using NFlog.Core;
using System.Collections.Generic;
using System.IO;
using NFlog.Viewer.WebApi;

namespace NFlog.Viewer
{
    public class ShellViewModel : PropertyChangedBase, IShell, IHandle<MessageReceivedEvent>
    {
        private readonly IEventAggregator eventAggregator;
        private string fileName;

        public ShellViewModel(INFlogWebApi webapi, IEventAggregator eventAggregator)
        {
            eventAggregator.Subscribe(this);
            Messages = new ObservableCollection<NFlogMessage>();
        }

        public void LoadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "NFlog log (*.nflog)|*.nflog|All files(*.*)|*.*" };
            if (openFileDialog.ShowDialog() == true)
            {
                fileName = openFileDialog.FileName;
                RefreshFile();
            }
        }

        public void RefreshFile()
        {
            NFlogDeserializer deserializer = new NFlogDeserializer();
            Messages = new ObservableCollection<NFlogMessage>( deserializer.Deserialize(File.ReadAllText(fileName)));
        }

        public NFlogMessage SelectedMessage { get; set; }

        private ObservableCollection<NFlogMessage> messages;
        public ObservableCollection<NFlogMessage> Messages
        {
            get
            {
                return messages;
            }
            set
            {
                messages = value;
                NotifyOfPropertyChange();
            }
        }

        public void Handle(MessageReceivedEvent msg)
        {
           Messages.Add( msg.Message );           
        }
    }
}