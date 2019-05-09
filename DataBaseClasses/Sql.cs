using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows;

namespace DataArt
{
    class Sql
    {
        #region Properties
        String connectionString = ConfigurationManager.ConnectionStrings["FilesOnPC"].ToString();
        SqlConnection connection;
        FileContext fc;
#endregion
        
        #region Methods
        public Sql()
        {
            Init();
        }

        void Init()
        {
            fc = new FileContext();
            connection = new SqlConnection(connectionString);
        }

        public async void UploadFile(String name, byte[] binaryData)
        {
            fc.files.Add(new FileInDB() { FileName = name, BinaryData = binaryData,DateTime=DateTime.Now });
            await fc.SaveChangesAsync();
            connection.Close();
        }

        public IQueryable<FileInDB> AllFiles()
        {
            return fc.files;
        }

        public async Task DeleteFile(int index)
        {
            if (fc.files.Find(index) != null)
            {
                fc.files.Remove(fc.files.Find(index));
                await fc.SaveChangesAsync();
            }
        }

        public async Task RenameFile(int index, String newFileName)
        {
            if (fc.files.Find(index) != null)
            {
                fc.files.Find(index).FileName = newFileName;
                await fc.SaveChangesAsync();
            }
        }
        #endregion
    }
}