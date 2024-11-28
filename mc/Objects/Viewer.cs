using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;
using mc.services;
using mc.services.FSListServices;


namespace mc.Objects
{
    public class Viewer : ConsoleGraphicsObject.ConsoleObject
    {

        public FSList fslist { get; set; }
        private Label maindirectorylabel { get; set; }

        private string usingdirectory => fslist.usingdirectory.FullName;
        private DataService dataservice { get; set; }
        private FSRow fsrow {  get; set; }

        private int selectorposition { get; set; } = 0; // this is a index of the current position in the list
        private int offset = 0; // this is a index of the first displayed item in the list
        private Size tablesize => new Size( this.Size.Width-2, this.Size.Height-4);



        public Viewer(DataService dataservice) // potreba predavat paletu nebo tak
        {
            
            this.dataservice = dataservice;
            BackgroundColor = ConsoleColor.DarkBlue;
            ForegroundColor = ConsoleColor.White;

            InActiveBackgroundColor = BackgroundColor;
            InActiveForegroundColor = ForegroundColor;
            fslist = new FSList(this.dataservice);
            dataservice.RefreshList(fslist);
            //maindirectorylabel = new Label(maindirectory,ForegroundColor, BackgroundColor);
        }

        public override void SetUp(Point location, Size size)
        {
            base.SetUp(location, size);
            
            
            //maindirectorylabel.SetUp(new Point(Location.X + 3, Location.Y), new Size(maindirectory.Length, 1));
        }



        public override void Draw()
        {
            base.Draw();
            GraphicsDraw();
            TableDraw();
           

            //maindirectorylabel.Update();
            //RowsDraw();
        }

        private void TableDraw()
        {
            
            for (int i = offset; i < tablesize.Height + offset && i < fslist.fsitems.Count(); i++)
            {
                
                fsrow = new FSRow(fslist.fsitems[i], i == 0 ? true : false);
                fsrow.SetUp(new Point(Location.X+1, Location.Y +2 +i - offset), new Size(tablesize.Width, 1));
                if (selectorposition + offset == i && IsActive)
                {

                    fsrow.SetTextColor(ConsoleColor.DarkCyan, ConsoleColor.Black);
                }

                fsrow.Draw();

                fsrow.SetTextColor(BackgroundColor, ForegroundColor);
            }
        }

        private void TableErease()
        {
            for (int y = 0; y < tablesize.Height; y++)
            {
                Console.SetCursorPosition(Location.X+1, Location.Y+ 2 +y);
                for (int x = 0; x < tablesize.Width; x++)
                {
                    Console.Write(' ');
                }
            }
        }

        private void GraphicsDraw()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("┌<─");
            //sb.Append(' ', maindirectory.Length);
            sb.Append('─', Size.Width - 8);
            sb.Append(".[☻]┐");

            Console.SetCursorPosition(Location.X, Location.Y);
            Console.WriteLine(sb.ToString());


            for (int i = 0; i < Size.Height - 3; i++)
            {
                sb.Clear();
                sb.Append('│');
                sb.Append(' ', Size.Width - 2);
                sb.Append('│');

                Console.SetCursorPosition(Location.X, Location.Y + 1 + i);
                Console.WriteLine(sb.ToString());
            }


            sb.Clear();
            sb.Append('├');
            sb.Append('─', Size.Width - 2);
            sb.Append('┤');

            Console.SetCursorPosition(Location.X, Location.Y + Size.Height - 2);
            Console.WriteLine(sb.ToString());
        }


        public void UpArrowPressed()
        {
            if (selectorposition > 0)
            {
                selectorposition--;
                Draw();
            }
            else if (selectorposition == 0 && offset > 0)
            {
                offset--;
                Draw();
            }

            fslist.SetActiveItem(selectorposition+offset);
        }
        public void DownArrowPressed()
        {
            if (selectorposition < tablesize.Height - 1 && selectorposition + offset < fslist.fsitems.Count - 1)
            {
                selectorposition++;
                Draw();
            }
            else if (selectorposition + offset < fslist.fsitems.Count - 1)
            {
                offset++;
                Draw();
            }
            fslist.SetActiveItem(selectorposition + offset);
        }
        public void EnterPressed()
        {
            fslist.ItemSelect();
            dataservice.RefreshList(fslist);
            TableErease();
            selectorposition = 0;
            offset = 0;
            TableDraw();
            
        }
        


    }
}
