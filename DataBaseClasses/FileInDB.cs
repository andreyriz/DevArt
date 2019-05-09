using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataArt
{
    public class FileInDB
    {
        [Key]
        public Int32 Id { get; set; }
        public String FileName { get; set; }
        public Byte[] BinaryData { get; set; }
        public DateTime DateTime { get; set; }
    }
}
