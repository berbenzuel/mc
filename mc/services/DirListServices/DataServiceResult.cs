using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Objects.DirViewerServices
{
    public class DataServiceResult
    {
        public string Name { get; set; }
        public string Size { get; set; }
        public DateTime Date { get; set; }
        public char Prefix { get; set; }

        public DataServiceResult(string namein, string sizein, DateTime dateint, char prefixin)
        {
            Name = namein;
            Size = sizein;
            Date = dateint;
            Prefix = prefixin;
        }


    }
}
