using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataArt
{
    class TextEditorM
    {
        #region Fields
        OpenFileDialog openFileDialog;
        SaveFileDialog saveFileDialog;
        StreamReader streamReader;
        BinaryReader binaryReader;
        Sql sql;
        public static String filter = "Text (*.txt)| *.txt|Json files (*.json)|*.json|C plus plus (*.cpp)|*cpp| CSharp (*.cs)| *.cs";
        const String messageBoxText = "Do you want to rename file?";
        const String caption = "DevArt";
        const MessageBoxButton button = MessageBoxButton.YesNoCancel;
        const MessageBoxImage icon = MessageBoxImage.Warning;
        #endregion
        
        #region Methods
        public TextEditorM()
        {
            Init();
        }

        private void Init()
        {

            openFileDialog = new OpenFileDialog() { Filter = filter };
            saveFileDialog = new SaveFileDialog() { Filter = filter };
            sql = new Sql();
        }

        public String OpenFileFromDisc()
        {
            if (openFileDialog.ShowDialog() == true)
            {
                streamReader = new StreamReader(openFileDialog.FileName, System.Text.Encoding.GetEncoding(1251));
                return streamReader.ReadToEnd();
            }
            return String.Empty;
        }

        public void SaveFileOnDisc(String text)
        {
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(Path.GetFileNameWithoutExtension(saveFileDialog.FileName), text);
            }
        }

        public void PushFileToServer()
        {
            if (openFileDialog.ShowDialog() == true)
            {

                switch (RenameDialog())
                {
                    case MessageBoxResult.Yes:
                        {
                            FileNameDialog dialog = new FileNameDialog(new FileNameDialogM(GetCompressedFileInByteArray()), Path.GetFileNameWithoutExtension(openFileDialog.FileName));
                            dialog.Show();
                        }
                        break;
                    case MessageBoxResult.No:
                        UploadFile();
                        break;
                }


            }

            void UploadFile()
            {
                Task.Run(() => sql.UploadFile(Path.GetFileNameWithoutExtension(openFileDialog.FileName), GetCompressedFileInByteArray()));
            }

            MessageBoxResult RenameDialog()
            {
                return MessageBox.Show(messageBoxText, caption, button, icon);
            }

            Byte[] GetCompressedFileInByteArray()
            {
                using (streamReader = new StreamReader(openFileDialog.FileName, System.Text.Encoding.GetEncoding(1251)))
                {
                    using (binaryReader = new BinaryReader(streamReader.BaseStream))
                    {
                        return SevenZipHelper.Compress(binaryReader.ReadBytes((int)streamReader.BaseStream.Length));
                    }
                }
            }
        }

        public void GetFileFromServer()
        {
            GetFilesFromDBDialog fileFromDbDialog = new GetFilesFromDBDialog();
            fileFromDbDialog.Show();
        }
        #endregion
    }
}