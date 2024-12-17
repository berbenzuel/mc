using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Interfaces
{
    //file system base Interface - for Items in direcrories
    public interface IFSItem 
    {
        public string name { get; set; }
        public string size { get; set; }
        public DateTime lastmodifieddate { get; set; }
        public string fullname { get; set; }
    }
}
