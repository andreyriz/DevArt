using System.Configuration;
using System.Data.Entity;

namespace DataArt
{
    class FileContext : DbContext
    {
        public FileContext():base(ConfigurationManager.ConnectionStrings["FilesOnPC"].ToString())
        {
        }

        public DbSet<FileInDB> files { get; set; }
    }
}
