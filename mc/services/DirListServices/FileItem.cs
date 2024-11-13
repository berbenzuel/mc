using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;

namespace mc.services.DirListServices
{
    //File info - file information like name, modified time...
    public class FileItem : IFSItem
    {
        public FileInfo FileInfo { get; set; }

        public string name {  get; set; }
        public string size { get; set; }

    }
}
