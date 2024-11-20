using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Objects
{
    public class Label : ConsoleGraphicsObject.ConsoleObject
    {
        public string Text { get; set; }

        private bool leftaligned {  get; set; } = true;
        private bool rightaligned {  get; set; } = false;

        public Label(string textin, ConsoleColor foregroundin, ConsoleColor backgroundin)
        {
            Text = textin;
            
            SetBackgroundColor(backgroundin);
            SetForegroundColor(foregroundin);
        }

        public Label(ConsoleColor foregroundin, ConsoleColor backgroundin)
        {
            SetBackgroundColor(backgroundin);
            SetForegroundColor(foregroundin);
        }
        public Label(string textin, Point locationin,Size sizein, ConsoleColor foregroundin, ConsoleColor backgroundin)
        {
            Text = textin;
            Location = locationin;
            Size = sizein;
            
            SetBackgroundColor(backgroundin);
            SetForegroundColor(foregroundin);

        }

        

        public override void Draw()
        {
            base.Draw();    
            Console.SetCursorPosition(Location.X, Location.Y);
            if (leftaligned)
            {
                Console.Write(Text.PadRight(Size.Width, ' '));
            }
            else if (rightaligned)
            {
                Console.Write(Text.PadLeft(Size.Width, ' '));
            }
            else
            {
                int padsize = (Size.Width - Text.Length) / 2;
                Console.Write(Text.PadRight(padsize,' ').PadLeft(padsize,' '));
            }
            ConsoleResetColor();
        }

        public void SetText(string text)
        {
            Text = text;
        }

        public void SetLeftAligned()
        {
            leftaligned = true;
            rightaligned = false;
        }
        public void SetRightAligned()
        {
            rightaligned = true;
            leftaligned = false;
        }
        public void SetMiddleAligned()
        {
            leftaligned = false;
            rightaligned = false;
        }
            


    }
}
