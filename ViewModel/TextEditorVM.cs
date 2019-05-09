using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataArt
{
    class TextEditorVM : BindableBase
    {
        #region Fields
        TextEditorM textEditor;
        String _text;
        ICommand openFileFromDisc;
        ICommand createFileOnDisc;
        ICommand pushFileToServer;
        ICommand getFileFromServer;
#endregion

        public String Text { get { return _text; } set { _text = value; OnPropertyChanged(nameof(Text)); } }
        
        #region Methods
        public TextEditorVM()
        {
            textEditor = new TextEditorM();
            Text = "";
        }

        public void EnterCommand(Int32 position)
        {
           Text= Text.Insert(position, "\n");
        }

        public void OnOpenFileFromDisc(Object o)
        {
            Text = textEditor.OpenFileFromDisc();
        }

        public void OnCreateFileOnDisc(Object o)
        {
            textEditor.SaveFileOnDisc(Text);
        }

        public void OnPushFileToServer(Object o)
        {
            textEditor.PushFileToServer();
        }

        public void OnGetFileFromServer(Object o)
        {
            textEditor.GetFileFromServer();
        }
        #endregion

        #region Commands
        public ICommand OpenFromDisc { get { if (openFileFromDisc == null) openFileFromDisc = new RelayCommand(OnOpenFileFromDisc); return openFileFromDisc; } }
        public ICommand CreateFileOnDisc { get { if (createFileOnDisc == null) createFileOnDisc = new RelayCommand(OnCreateFileOnDisc); return createFileOnDisc; } }
        public ICommand PushFileToServer { get { if (pushFileToServer == null) pushFileToServer = new RelayCommand(OnPushFileToServer); return pushFileToServer; } }
        public ICommand GetFileFromServer { get { if (getFileFromServer == null) getFileFromServer = new RelayCommand(OnGetFileFromServer); return getFileFromServer; } }
        #endregion
    }
}
