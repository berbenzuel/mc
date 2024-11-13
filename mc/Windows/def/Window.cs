using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;

namespace mc.Windows.def
{
    public class Window
    {
        public Size Size { get; set; } = new Size(Console.WindowWidth, Console.WindowHeight);
        public Signal Signal = new Signal();

        public virtual  void Control()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey k = Console.ReadKey(true).Key;
                    Signal.OnKeyPressed(k);
                }

                if (Size != new Size(Console.WindowWidth, Console.WindowHeight))
                {
                    Console.Clear();
                    if(Console.WindowWidth < 150 || Console.WindowHeight < 40)
                    {
                        
                        Console.SetWindowSize(150, 40);
                        Console.SetBufferSize(150, 40);
                    }
                    try
                    {
                        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
                        Signal.OnSizeChanged(new Size(Console.WindowWidth, Console.WindowHeight));
                        Size = new Size(Console.WindowWidth, Console.WindowHeight);
                    }
                    catch
                    {
                        throw new Exception("Window sized incorrectly");
                        
                    }
                    
                }
            }
        }
    }
    
}
