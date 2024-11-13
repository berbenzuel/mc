using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;
using mc.services.DirListServices;

namespace mc.Objects.DirViewerServices
{
    public class DataService
    {
        public DirectoryInfo parentdirectoryinfo { get; set; }
        public DirectoryInfo[] subdirectoriesinfo { get; set; }
        public FileInfo[] filesinfo {  get; set; }

        //public List<DataServiceResult> Rows = new List<DataServiceResult>();
        public List<IFSItem> fsitemrows { get; set; }

        public int directorysize { get; set; }
        public int rootsize;


        public DataService()
        {
            parentdirectoryinfo = new DirectoryInfo(@$"C:/users/{Environment.UserName}");
            fsitemrows = new List<IFSItem>();
            GetInfo();
            RefreshList();
        }

        public void ChangeDirectory(string path)
        {
            try
            {
                parentdirectoryinfo = new DirectoryInfo(@path);
            }
            catch { }
        }

        public void RefreshList()
        {
            
            GetInfo();

            fsitemrows = new List<IFSItem>();
            DirectoryItem updir = new DirectoryItem(parentdirectoryinfo);
            fsitemrows.Add(updir);

            foreach (DirectoryInfo directoryinfo in subdirectoriesinfo)
            {
                DirectoryItem item = new DirectoryItem(directoryinfo);
                fsitemrows.Add(item);

            }
        }

        public void Select(int row)
        {
            try
            {
                if (fsitemrows[row] is DirectoryItem)
                {
                    ChangeDirectory(fsitemrows[row].path);
                }
                
                else if (fsitemrows[row] is FileItem)
                {

                }
            }
            catch { }
        }


        private void GetInfo()
        {
            subdirectoriesinfo = parentdirectoryinfo.GetDirectories();
            filesinfo = parentdirectoryinfo.GetFiles();
        }

    }
}
