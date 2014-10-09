using System.Collections.ObjectModel;
using System.IO;
using Caliburn.Micro;
using Microsoft.Win32;
using NFlog.Core;
using NFlog.Viewer.Events;
using NFlog.Viewer.WebApi;

namespace NFlog.Viewer
{
    public class ShellViewModel : PropertyChangedBase, IShell, IHandle<MessageReceivedEvent>
    {
        private readonly IEventAggregator eventAggregator;
        private string fileName;

        public ShellViewModel(INFlogWebApi webapi, IEventAggregator eventAggregator)
        {
            //webapi is injected as a reference to make sure it gets created
            this.eventAggregator = eventAggregator;
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
            Messages = new ObservableCollection<NFlogMessage>(deserializer.Deserialize(File.ReadAllText(fileName)));
        }

        private NFlogMessage selectedMessage;
        public NFlogMessage SelectedMessage
        {
            get { return selectedMessage; }
            set
            {
                selectedMessage = value;
                NotifyOfPropertyChange(() => SelectedMessage);
                eventAggregator.PublishOnUIThreadAsync(new SelectedMessageChangedEvent() { Message = selectedMessage });
            }
        }

        private string _searchString;
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                NotifyOfPropertyChange(() => SearchString);
            }
        }

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
            Messages.Add(msg.Message);
        }
    }
}