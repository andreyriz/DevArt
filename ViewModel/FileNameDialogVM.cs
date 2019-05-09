using System;

namespace DataArt
{
    public class FileNameDialogVM : BindableBase
    {
        FileNameDialogM dialogModel;

        String originalName;
        String _fileName;
        public String FileName { get { return _fileName; } set { _fileName = value; OnPropertyChanged(nameof(FileName)); } }

        public FileNameDialogVM(FileNameDialogM dialogModel,String fileName)
        {
            this.dialogModel = dialogModel;
            this.FileName = fileName;
            originalName = fileName;
        }
        public void PushMessage()
        {
            if (!String.IsNullOrWhiteSpace(FileName))
            {
                dialogModel.UploadFile(FileName);
            }
            else
            {
                dialogModel.UploadFile(originalName);
            }
        }
    }
}
