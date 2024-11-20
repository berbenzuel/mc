using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;


namespace mc.Objects
{
    public class Viewer : ConsoleGraphicsObject.ConsoleObject
    {

        public FSList fslist { get; set; }



        public Viewer() // potreba predavat paletu nebo tak
        {
            BackgroundColor = ConsoleColor.DarkBlue;
            ForegroundColor = ConsoleColor.White;
            fslist = new FSList();
        }

        public override void SetUp(Point location, Size size)
        {
            base.SetUp(location, size);

            fslist.SetUp(new Point(Location.X + 1, Location.Y + 2), new Size(Size.Width - 2, Size.Height - 4));
        }



        public override void Draw()
        {
            base.Draw();
            
            StringBuilder sb = new StringBuilder();
            sb.Append("┌<─");
            sb.Append(fslist.fsitems[0].fullname);
            sb.Append('─', Size.Width - fslist.fsitems[0].fullname.Length - 8);
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


            fslist.Draw();

        }


        public void UpArrowPressed()
        {
            fslist.MoveUp();
        }
        public void DownArrowPressed()
        {
            fslist.MoveDown();
        }
        public void EnterPressed()
        {
            fslist.Select();
        }
        


    }
}
