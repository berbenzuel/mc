using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using mc.Interfaces;
using mc.services.FSListServices;

namespace mc.services
{
    //DataService is for working with repository, in progam it is access point into repository 
    public static class DataService
    {
        public static string defaultpath = $@"C:Users/{Environment.UserName}";

        //creates list of FSItems based on default path - C:/Users/activeuser
        public static List<IFSItem> FSItemsListMaker()
        {
            List<IFSItem> list = new List<IFSItem>();
            list = RefreshList(list, defaultpath);

            return list;
        }

        //Refreshing list of IFSItems, returs actual list based on actual list parent directory
        public static List<IFSItem> RefreshList(List<IFSItem> fsitems,  string path)
        {
            DirectoryInfo directoryinfoin = new DirectoryInfo(path);
            fsitems.Clear();


            DirectoryItem updir = new DirectoryItem(directoryinfoin.Parent); //parent directory, in FSItem name builder replaced by ".."  
            fsitems.Add(updir);


            //adding subdirectoriesdirectories into the list of FSItems
            foreach (DirectoryInfo directoryinfo in directoryinfoin.GetDirectories())
            {
                DirectoryItem directoryitem = new DirectoryItem(directoryinfo);
                fsitems.Add(directoryitem);
            }


            //adding files into the list of FSItems
            foreach (FileInfo fileinfo in directoryinfoin.GetFiles())
            {
                FileItem fileitem = new FileItem(fileinfo);
                fsitems.Add(fileitem);
            }

            return fsitems;
        }

        public static void FileSelected(IFSItem item)
        {
            throw new NotImplementedException("executing or opening file");
        }

        public static DirectoryInfo MainDirectroryInfoRefresh(string path = null)
        {
            DirectoryInfo output;
            if (path == null)
            {
                output = new DirectoryInfo(defaultpath);
            }
            else
            {
                output = new DirectoryInfo(path);
            }
            return output;
            
        }

        public static void CreateDirectory(string destinationpath)
        {
            Debug.Write(destinationpath);
            Directory.CreateDirectory(destinationpath);
        }
        public static void Delete(IFSItem item)
        {
            if(item is DirectoryItem)
            {
                DirectoryInfo directoryinfo = new DirectoryInfo(@item.fullname);
                directoryinfo.Delete(true);
                
            }
            else
            {
                FileInfo fileinfo = new FileInfo(item.fullname);
                fileinfo.Delete();
            }
        }
        public static void Copy(IFSItem sourceitem, string destinationpath)
        {
            if (sourceitem is DirectoryItem)
            {
                DirectoryInfo directoryinfo = new DirectoryInfo(@sourceitem.fullname);
                Debug.WriteLine("destination: " +destinationpath + " source: " + directoryinfo.FullName);
                RecursiveCopyDirectory(directoryinfo, destinationpath);

            }
            else
            {
                FileInfo fileinfo = new FileInfo(@sourceitem.fullname);
                CopyFile(fileinfo, destinationpath);
            }
        }

        private static void CopyFile(FileInfo sourcefile, string destinationpath)
        {
            Debug.Write(destinationpath+sourcefile.Name);
            sourcefile.CopyTo(Path.Combine(destinationpath, sourcefile.Name));
            
        }
        
        private static void RecursiveCopyDirectory(DirectoryInfo sourcedirectory, string destinationuppath)
        {
            string destinationpath = destinationuppath + @$"\{sourcedirectory.Name}\";
            CreateDirectory(destinationpath);
            foreach (FileInfo info in sourcedirectory.GetFiles())
            {
                CopyFile(info, destinationpath);
            }

            foreach(DirectoryInfo info in sourcedirectory.GetDirectories())
            {
                RecursiveCopyDirectory(info,destinationpath);
            }


        }
        


    }
}
