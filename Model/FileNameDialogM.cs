using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataArt
{
   public class FileNameDialogM
    {
        Byte[] fileInByteArray;
        Sql sql;
        public FileNameDialogM(Byte[] fileInByteArray)
        {
            this.fileInByteArray = fileInByteArray;
            sql = new Sql();
        }

        public void UploadFile(String fileName)
        {
            Task.Run(()=> sql.UploadFile(fileName, fileInByteArray));
        }
    }
}
