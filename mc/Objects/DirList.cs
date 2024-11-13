using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Objects.DirViewerServices;

namespace mc.Objects
{
    public class DirList : ConsoleGraphicsObject.ConsoleGraphicsObject
    {
        public DataService dataservice { get; set; }

        
        private int SelectorPosition { get; set; } = 0; // this is a index of the current position in the list
        private int Offset = 2; // this is a index of the first displaed item in thge list

        private DirListRow[] dirListRow {  get; set; }

        
        public DirList() 
        {
            
            ForegroundColor = ConsoleColor.White;
            BackgroundColor= ConsoleColor.DarkBlue;

            
        }
        public override void Draw()
        {
            
            for (int i = 0; i < Size.Height  && i < dirListRow.Length; i++)
            {
                
                if (SelectorPosition == i)
                {
                    dirListRow[i].SetTextColor(ConsoleColor.DarkCyan, ConsoleColor.Black);
                }
                
                dirListRow[i].Draw();

                dirListRow[i].SetTextColor(BackgroundColor, ForegroundColor);
            }
        }

        public override void SetUp(Point location, Size size)
        {
            base.SetUp(location, size);
            Refresh();
        }

        public override void Erease()
        {
            for (int i = 0; i < Size.Height && i < dirListRow.Length; i++)
            {
                dirListRow[i].Erease();

            }
        }

        private void Refresh()
        {
            dataservice.RefreshList();
            dirListRow = new DirListRow[dataservice.fsitemrows.Count()];
          
            DirListRowSetUp();
        }
        private void DirListRowSetUp()
        {

            for(int i = 0; i < dirListRow.Length ; i++)
            {
                dirListRow[i].SetUp(new Point(Location.X, Location.Y + i), new Size(Size.Width, 1));
            }
        }

        

        public void MoveUp()
        {
            //if (SelectorPosition >= 0)
            //{

            //    if (SelectorPosition > 0)
            //    {
            //        Offset--;
            //    }
            //    SelectorPosition--;

            //    DirListRowSetUp();


            //    Update();
            //}
            if (SelectorPosition > 0)
            {
                --SelectorPosition;
                // todo calc offset
            }
        }
        
        public void MoveDown()
        {
            
            //if (SelectorPosition + Offset  < dataService.Rows.Count() +1 )
            //{
            //    SelectorPosition++;
            //    if (SelectorPosition > Size.Height -1)
            //    {
            //        Offset++;
            //        DirListRowSetUp();

            //    }
                

            //    Update();
            //}
           
            if (SelectorPosition < dirListRow.Length)
            {
                ++SelectorPosition;
                // todo calc if you need increment the offset
                // Offset += SelectorPosition * rowHeight > Size.height ? 1 : 0;
            }
            ListDraw();
        }

        public void Select()
        {
            Erease();
            dataservice.Select(SelectorPosition);
            Refresh();

            Offset = 0;
            SelectorPosition = 0;
            Draw();

        }


        private void ListDraw()
        {
            int height = 0;
            int rowHeight = 20; // make it constant in the class.
            for(int i = Offset; i < dirListRow.Length; ++i)
            {
                drawRow(i, height);
                height += rowHeight;
                if (height > Size.Height)
                {
                    break;
                }
            }
        }

        private void drawRow(int index, int y)
        {
            // bla bla
        }
    }
}
