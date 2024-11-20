using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;

namespace mc.services.FSListServices
{
    //File info - file information like name, modified time...
    public class FileItem : IFSItem
    {
        public string name { get; set; }
        public string size { get; set; }
        public DateTime lastmodifieddate { get; set; }
        public string fullname { get; set; }

        public FileItem(FileInfo infoin) 
        {
            
            name = infoin.Name;
            size = infoin.Length.ToString();
            lastmodifieddate = infoin.LastWriteTime;
            fullname = infoin.FullName;
        }

    }
}
