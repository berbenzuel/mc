using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;
using mc.Objects.DirViewerServices;

namespace mc.Objects
{
    public class Viewer : ConsoleGraphicsObject.ConsoleGraphicsObject
    {
        private DataService dataservice = new DataService();
        private DirList dirlist { get; set; } = new DirList();



        public Viewer(Signal signal) // potreba predavat paletu nebo tak
        { 
            Connect(signal);


            dirlist.dataservice = this.dataservice;



            BackgroundColor = ConsoleColor.DarkBlue;
            ForegroundColor = ConsoleColor.White;
            
        }

        public override void SetUp(Point location, Size size)
        {
            base.SetUp(location, size);

            dirlist.SetUp(new Point(Location.X + 1, Location.Y + 2), new Size(Size.Width - 2, Size.Height - 4));
        }



        public override void Draw()
        {
            base.Draw();
            StringBuilder sb = new StringBuilder();
            sb.Append("┌<─");
            sb.Append(dirlist.dataservice.parentdirectoryinfo.FullName.ToString());
            sb.Append('─', Size.Width - dirlist.dataservice.parentdirectoryinfo.FullName.Length - 8);            
            sb.Append(".[☻]┐\n");

            for (int i = 0; i < Size.Height - 3; i++)
            {
                sb.Append('│');
                sb.Append(' ', Size.Width - 2);
                sb.Append('│');
                sb.Append('\n');
            }

            sb.Append('├');
            sb.Append('─', Size.Width - 2);
            sb.Append('┤');


            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(sb.ToString());

            dirlist.Draw();
        
        }


        #region signalsection

        private void Connect(Signal signal)
        {
            signal.KeyPressed += Signal_KeyPressed;
        }

        

        private void Signal_KeyPressed(object? sender, ConsoleKey e)
        {
            if (IsActive)
            {
                if (e == ConsoleKey.Enter)
                {
                    dirlist.Select();
                }
                else if (e == ConsoleKey.DownArrow)
                {
                    dirlist.MoveDown();
                }
                else if (e == ConsoleKey.UpArrow)
                {
                    dirlist.MoveUp();
                }
            }


        }
        #endregion 
    }
}
