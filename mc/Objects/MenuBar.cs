using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Objects
{
    internal class MenuBar : ConsoleGraphicsObject.ConsoleGraphicsObject
    {
        public MenuBar()
        { 
            SetLocation(new Point(0,0));
            SetSize(new Size(Console.WindowWidth, 1));
        }
    }
}
