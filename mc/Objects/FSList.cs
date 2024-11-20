using System.Drawing;
using System.Net.Http.Headers;
using mc.Interfaces;
using mc.services;
using mc.services.FSListServices;
namespace mc.Objects
{
    public class FSList : ConsoleGraphicsObject.ConsoleObject
    {
        
        public List<IFSItem> fsitems { get; set; }
        public IFSItem activeitem => fsitems[selectorposition + offset];
        public DirectoryInfo actualdirectory { get; set; }


        private int selectorposition { get; set; } = 0; // this is a index of the current position in the list
        private int offset = 0; // this is a index of the first displayed item in the list
        

        private FSRow fsrow {  get; set; }

        public FSList() 
        {
            fsitems = new List<IFSItem>();
            
            
            
            ForegroundColor = ConsoleColor.White;
            BackgroundColor= ConsoleColor.DarkBlue;

            fsitems = DataService.FSItemsListMaker();
            actualdirectory = DataService.MainDirectroryInfoRefresh();

            
        }
        public override void Draw()
        {
            
            for (int i = offset; i < Size.Height+offset  && i < fsitems.Count(); i++)
            {
                fsrow = new FSRow(fsitems[i],i==0?true:false);
                fsrow.SetUp(new Point(Location.X, Location.Y + i-offset), new Size(Size.Width, 1));
                if (selectorposition + offset == i && IsActive)
                { 

                    fsrow.SetTextColor(ConsoleColor.DarkCyan, ConsoleColor.Black);
                }

            fsrow.Draw();

            fsrow.SetTextColor(BackgroundColor, ForegroundColor);
            }
        }


        public void ChangeDirectory()
        {
            actualdirectory = DataService.MainDirectroryInfoRefresh(fsitems[selectorposition+ offset].fullname);
            fsitems = DataService.RefreshList(fsitems, fsitems[selectorposition + offset].fullname);

        }

        public void Refresh()
        {
            fsitems = DataService.RefreshList(fsitems, actualdirectory.FullName);
            Update();
        }

        

        public void MoveUp()
        {
            if (selectorposition > 0)
            {
                selectorposition--;
                Draw();
            }
            else if (selectorposition == 0 && offset > 0 )
            {
                offset--;
                Draw();
            }
            
        }
        
        public void MoveDown()
        {
            
                if (selectorposition < Size.Height -1&& selectorposition+offset < fsitems.Count-1)
                {
                    selectorposition++;
                    Draw();
                }
                else if (selectorposition + offset< fsitems.Count-1) 
                {
                    offset++;
                    Draw();
                }
            
            
        }

        public void Select()
        {
            if(fsitems[selectorposition + offset] is DirectoryItem)
            {
                ChangeDirectory();
                selectorposition = 0;
                offset = 0;
                Update();

            }
            else if (fsitems[selectorposition + offset] is FileItem)
            {
                
                DataService.FileSelected(fsitems[selectorposition + offset]);
            }
        }

    }
}


