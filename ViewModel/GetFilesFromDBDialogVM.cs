using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;

namespace DataArt
{
    class GetFilesFromDBDialogVM : BindableBase
    {
        #region Properties
        public FileInDB selectedFile { get { return _selectedFile; } set { _selectedFile = value; OnPropertyChanged(nameof(selectedFile)); } }
        public ObservableCollection<FileInDB> items { get; set; }
        #endregion

        #region Fields
        GetFilesFromDBDialogM getFilesFromDBM;
        FileInDB _selectedFile;
        ICommand removeElement;
        ICommand renameElement;
        ICommand downloadElement;
        #endregion

        #region Methods
        public GetFilesFromDBDialogVM()
        {
            getFilesFromDBM = new GetFilesFromDBDialogM();
            items = new ObservableCollection<FileInDB>(getFilesFromDBM.AllFiles());
        }

        void OnRemoveElement(object o)
        {
            if (selectedFile != null)
            {
                getFilesFromDBM.RemoveElement(selectedFile);
                items.Remove(selectedFile);
            }
        }

        void OnDownloadElement(object o)
        {
            getFilesFromDBM.DownloadElement(selectedFile);
        }
        #endregion

        #region Commands
        public ICommand DownloadElement { get { if (downloadElement == null) downloadElement = new RelayCommand(OnDownloadElement); return downloadElement; } }
        public ICommand RemoveElement { get { if (removeElement == null) removeElement = new RelayCommand(OnRemoveElement); return removeElement; } }
        #endregion
    }
}
