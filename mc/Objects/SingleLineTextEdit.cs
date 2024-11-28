using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Text.Json;

namespace mc.Objects
{
    public class SingleLineTextEdit : ConsoleGraphicsObject.ConsoleObject
    {


        public string text => GetText();


        private List<char> textchars { get; set; }
        private Signal signal { get; set; }
        private int cursorposition { get; set; } = 0;

        public SingleLineTextEdit(Point locationin, Size sizein)
        {
            
            Location = locationin;
            Size = sizein;

            textchars = new List<char>();

           

            signal.KeyPressed += Signal_KeyPressed;
        }

        private void Signal_KeyPressed(object? sender, ConsoleKeyInfo e)
        {
            if (IsActive)
            {
                try
                {
                    if (e.Key == ConsoleKey.Backspace && cursorposition > 0)
                    {
                        textchars.RemoveAt(cursorposition-1);
                        cursorposition--;
                    }
                    else
                    {
                        char input = e.KeyChar;
                        textchars.Add(input);
                        cursorposition++;
                    }

                    Draw();
                }  catch { }


            }
        }


        public override void Draw()
        {
            base.Draw();
            Console.SetCursorPosition(Location.X, Location.Y);
            for (int counter = 0; counter < Size.Width; counter++)
            {
                
                Console.Write(' ');
            }
            
            Console.SetCursorPosition(Location.X, Location.Y);
            foreach (char letter in textchars)
            {

                Console.Write(letter);
            }
        }
        public void SetText(string textin)
        {
            textchars.Clear();
            foreach (char c in textin)
            {
                textchars.Add(c);
                cursorposition++;
            }
        }

        private string GetText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char input in textchars)
            {

                sb.Append(input);
                
            }
            return sb.ToString();
        }

        
    }
}
