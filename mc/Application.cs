using System.Drawing;
using mc.Windows;

namespace mc
{
    internal class Application : Signal
    {
        public Signal Signal = new Signal();
        public MainWindow mainwindow { get; set; }

        private bool terminate { get; set; } = false;

        public Application()
        {
            SetWindow();

            mainwindow = new MainWindow(Signal);

            Signal.F10Pressed += Signal_F10Pressed;

            Control();

        }

        private void SetWindow()
        {
            Console.SetWindowSize(150, 40);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "moon_commander:3";
            Console.SetBufferSize(Console.WindowWidth,Console.WindowHeight);
        }

        public virtual void Control()
        {
            while (true)
            {
                if(terminate)
                {
                    break;
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKey k = Console.ReadKey(true).Key;

                    Signal.OnKeyPressed(k);
                }

                if (mainwindow.Size != new Size(Console.WindowWidth, Console.WindowHeight))
                {
                    Console.Clear();
                    if (Console.WindowWidth < 150 || Console.WindowHeight < 40)
                    {

                        Console.SetWindowSize(150, 40);
                        Console.SetBufferSize(150, 40);
                    }
                    try
                    {
                        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
                        Signal.OnSizeChanged(new Size(Console.WindowWidth, Console.WindowHeight));
                        mainwindow.Size = new Size(Console.WindowWidth, Console.WindowHeight);
                    }
                    catch
                    {
                        throw new Exception("Window sized incorrectly");

                    }

                }
            }
        }

        private void Signal_F10Pressed()
        {
            terminate = true;
        }
    }


}


