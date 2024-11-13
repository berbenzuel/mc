using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;

namespace mc.services.DirListServices
{
    //diroctory item - information about directory
    public class DirectoryItem : IFSItem
    {
        public DirectoryInfo DirectoryInfo { get; set; }

        public DirectoryItem(DirectoryInfo directoryinfoin)
        {
            DirectoryInfo = directoryinfoin;
        }
    }
}
