using mc.Interfaces;
using mc.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Windows
{
    public class ViewWindow : def.Window, IWindow
    {
        private int offset { get; set; } = 0;
        private List<string> textlines = new List<string>();
        private ConsoleColor backgroundcolor { get; set; } = ConsoleColor.DarkBlue;
        private ConsoleColor foregroundcolor { get; set; } = ConsoleColor.White;

        public ViewWindow(FileInfo fileinfo, Signal signalin) : base(signalin)
        {
            Console.Clear();
            signalin.KeyPressed += Signalin_KeyPressed;

            //textlines = DataService.ReadFile(fileinfo);
            DrawLines();

        }

        private void Signalin_KeyPressed(object? sender, ConsoleKeyInfo e)
        {
            if (e.Key == ConsoleKey.Escape)
            {
                
            }
            else if (e.Key == ConsoleKey.DownArrow && offset < textlines.Count)
            {
                offset++;
            }
            else if (e.Key == ConsoleKey.DownArrow && offset > 0)
            {
                offset--;
            }
        }
        

        private void DrawLines()
        {
            Console.SetCursorPosition(0, 0);
            foreach (var line in textlines)
            {
                Console.WriteLine(line);
            }
        }
    }
}
