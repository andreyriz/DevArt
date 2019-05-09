using Microsoft.Win32;
using System.IO;
using System.Linq;
using System.Text;

namespace DataArt
{
    class GetFilesFromDBDialogM
    {
        #region Fields
        SaveFileDialog saveFileDialog;
        Sql sql;
        #endregion

        #region Methods
        public GetFilesFromDBDialogM()
        {
            sql = new Sql();
            saveFileDialog = new SaveFileDialog() { Filter = TextEditorM.filter };
        }

        public IQueryable<FileInDB> AllFiles()
        {
            return sql.AllFiles();
        }

        public async void RemoveElement(FileInDB selectedFile)
        {
            await sql.DeleteFile(selectedFile.Id);
        }

        public void DownloadElement(FileInDB selectedFile)
        {
            saveFileDialog.FileName = selectedFile.FileName;
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, Encoding.UTF8.GetString(SevenZipHelper.Decompress(selectedFile.BinaryData)));
            }
        }
        #endregion
    }
}
