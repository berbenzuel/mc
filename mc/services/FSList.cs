using System.Drawing;
using System.Net.Http.Headers;
using mc.Interfaces;
using mc.Objects;
using mc.services.FSListServices;
namespace mc.services
{
    public class FSList
    {

        public List<IFSItem> fsitems { get; set; }
        public DirectoryInfo usingdirectory { get; set; } = new DirectoryInfo($@"C:Users/{Environment.UserName}");
        public IFSItem activeitem { get; set; }
        
        private DataService dataservice { get; set; }
        


        private FSRow fsrow { get; set; }

        public FSList(DataService servicein)
        {
            dataservice = servicein;
            fsitems = new List<IFSItem>();
        }

        public void SetActiveItem(int index)
        {
            activeitem = fsitems[index];
        }

        public void ItemSelect()
        {
            if (activeitem is FileItem)
            {
                dataservice.FileSelected(activeitem);
            }
            else
            {
                dataservice.DirectorySelected(this, activeitem);
            }


        }
    }
}


