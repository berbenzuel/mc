using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using mc.Interfaces;
using mc.services.FSListServices;

namespace mc.services
{
    //DataService is for working with repository, in progam it is access point into repository 
    public class DataService
    {

        public DataService()
        {
            
        }
        


        //Refreshing list of IFSItems, returs actual list based on actual list parent directory
        public FSList RefreshList(FSList fslist)
        {  
                
                fslist.fsitems.Clear();


                DirectoryItem updir = new DirectoryItem(fslist.usingdirectory.Parent); //parent directory, in FSItem name builder replaced by ".."  
                fslist.fsitems.Add(updir);


                //adding subdirectoriesdirectories into the list of FSItems
                foreach (DirectoryInfo directoryinfo in fslist.usingdirectory.GetDirectories())
                {
                    DirectoryItem directoryitem = new DirectoryItem(directoryinfo);
                    fslist.fsitems.Add(directoryitem);
                }


                //adding files into the list of FSItems
                foreach (FileInfo fileinfo in fslist.usingdirectory.GetFiles())
                {
                    FileItem fileitem = new FileItem(fileinfo);
                    fslist.fsitems.Add(fileitem);
                }

            return fslist;
                //using FileSystemWatcher watcher = new FileSystemWatcher(path);
                //watcher.EnableRaisingEvents = true;
                //watcher.IncludeSubdirectories = true;
        }


        public void DirectorySelected(FSList fslist, IFSItem item)
        {
            if ( fslist.activeitem is  DirectoryItem )
            {
                try
                {
                    fslist.usingdirectory = new DirectoryInfo(item.fullname);
                } 
                catch (UnauthorizedAccessException)
                {
                    
                }
                
            }
        }
        public void FileSelected(IFSItem item)
        {
            throw new NotImplementedException("executing or opening file");
        }

        public List<string> ReadFile(FileInfo filein)
        {
            List<string> outlist = new List<string>();
            using StreamReader stream = new StreamReader(filein.FullName);
            {
                while (!stream.EndOfStream)
                {
                    outlist.Add(stream.ReadLine());
                }
            }
            return outlist;
        }

        public string GetPrefix(IFSItem fsitem)
        {
            if (fsitem is DirectoryItem)
            {
                return "/";
            }
            else
            {
                return ".";
            }
        }
        public string GetTypeName(IFSItem fsitem)
        {
            if (fsitem is DirectoryItem)
            {
                return "directory";
            }
            else
            {
                return "file";
            }
        }
        
        
        
        
        public void CreateDirectory(string destinationpath)
        {
            try
            {
                Directory.CreateDirectory(destinationpath);
                
                
            }
            catch(IOException) { }
        }
        public void Delete(IFSItem item)
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
        public void Copy(IFSItem sourceitem, string destinationpath)
        {
            if (sourceitem is DirectoryItem)
            {
                DirectoryInfo directoryinfo = new DirectoryInfo(@sourceitem.fullname);
                RecursiveCopyDirectory(directoryinfo, destinationpath);

            }
            else
            {
                FileInfo fileinfo = new FileInfo(@sourceitem.fullname);
                CopyFile(fileinfo, destinationpath);
            }
        }
        
        

        public void Move(IFSItem sourceitem, string destinationpath)
        {
            if (sourceitem is DirectoryItem)
            { 
                Directory.Move(sourceitem.fullname, Path.Exists(destinationpath) ? destinationpath + sourceitem.name:destinationpath);
            }
            else
            {
                File.Move(sourceitem.fullname, Path.Exists(destinationpath) ? destinationpath + sourceitem.name : destinationpath);
            }
        
        }

        private void CopyFile(FileInfo sourcefile, string destinationpath)
        {
            Debug.Write(destinationpath+sourcefile.Name);
            sourcefile.CopyTo(Path.Combine(destinationpath, sourcefile.Name));
            
        }
        
        private void RecursiveCopyDirectory(DirectoryInfo sourcedirectory, string destinationuppath)
        {
            string destinationpath = destinationuppath + sourcedirectory.Name;
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
