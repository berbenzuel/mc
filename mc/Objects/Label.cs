using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Objects
{
    public class Label : ConsoleGraphicsObject.ConsoleGraphicsObject
    {
        public string Text { get; set; }



        public Label(string textin, ConsoleColor foregroundin, ConsoleColor backgroundin)
        {
            Text = textin;
            
            BackgroundColor = backgroundin;
            ForegroundColor = foregroundin;
        }

        public Label(ConsoleColor foregroundin, ConsoleColor backgroundin)
        { 
            ForegroundColor = foregroundin;
            BackgroundColor = backgroundin;
        }

        

        public override void Draw()
        {
            base.Draw();    
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.Write(Text.PadRight(Size.Width));
            ConsoleResetColor();
        }

        public void SetText(string text)
        {
            Text = text;
        }
    }
}
