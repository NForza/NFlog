using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
            Messages = new ObservableCollection<NFlogViewerMessage>();
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
            Messages = new ObservableCollection<NFlogViewerMessage>(deserializer.Deserialize(File.ReadAllText(fileName)).Cast<NFlogViewerMessage>());
        }

        private NFlogViewerMessage selectedShownMessage;
        public NFlogViewerMessage SelectedShownMessage
        {
            get { return selectedShownMessage; }
            set
            {
                selectedShownMessage = value;
                NotifyOfPropertyChange(() => SelectedShownMessage);
                eventAggregator.PublishOnUIThreadAsync(new SelectedMessageChangedEvent() { Message = selectedShownMessage });
            }
        }

        private string searchString;
        public string SearchString
        {
            get { return searchString; }
            set
            {
                searchString = value;
                NotifyOfPropertyChange(() => SearchString);
                BuildShowMessages();
            }
        }

        private ObservableCollection<NFlogViewerMessage> messages;
        public ObservableCollection<NFlogViewerMessage> Messages
        {
            get
            {
                return messages;
            }
            set
            {
                messages = value;
                NotifyOfPropertyChange();
                BuildShowMessages();
            }
        }

        private void BuildShowMessages()
        {
            ShownMessages = 
                new ObservableCollection<NFlogViewerMessage>(
                    messages.Where(m => m.MatchesSearchString(searchString)));            
        }

        private ObservableCollection<NFlogViewerMessage> shownMessages;
        public ObservableCollection<NFlogViewerMessage> ShownMessages
        {
            get
            {
                return shownMessages;
            }
            set
            {
                shownMessages = value;
                NotifyOfPropertyChange();
            }
        }

        public void Handle(MessageReceivedEvent msg)
        {
            Messages.Add(msg.Message);
            if (msg.Message.MatchesSearchString(SearchString))
                ShownMessages.Add(msg.Message);
        }
    }
}