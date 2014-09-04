using Caliburn.Micro;
using Microsoft.Win32;
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
            Contents = File.ReadAllText(fileName);
        }

        private string _Contents;
        public string Contents
        {
            get
            {
                return _Contents;
            }
            set
            {
                _Contents = value;
                NotifyOfPropertyChange();
            }
        }
    }
}