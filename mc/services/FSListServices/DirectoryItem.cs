using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;

namespace mc.services.FSListServices
{
    //diroctory item - information about directory
    public class DirectoryItem : IFSItem
    {
        public string name { get; set; }
        public string size { get; set; }
        public DateTime lastmodifieddate { get; set; }
        public string fullname { get; set; }
        
        public DirectoryItem(DirectoryInfo infoin)
        {
            name = infoin.Name;
            size = "4096";
            lastmodifieddate = infoin.LastWriteTime;
            fullname = infoin.FullName;
        }
    }
}
