using Caliburn.Micro;
using Microsoft.Win32;
using NFlog.Core;
using System.Collections.Generic;
using System.IO;

namespace NFlog.Viewer
{
    public class ShellViewModel : PropertyChangedBase, IShell
    {
        private string fileName;

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
            Messages = deserializer.Deserialize(File.ReadAllText(fileName));
        }

        private IEnumerable<NFlogMessage> messages;
        public IEnumerable<NFlogMessage> Messages
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
    }
}