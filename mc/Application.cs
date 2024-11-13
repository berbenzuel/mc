using System.Drawing;
using mc.Windows;

namespace mc
{
    internal class Application : Signal
    {
        public Application()
        {
            SetWindow();



            MainWindow mainWindow = new MainWindow();

        }
        private void SetWindow()
        {
            Console.SetWindowSize(150, 40);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Title = "midnight commander";
            Console.SetBufferSize(Console.WindowWidth,Console.WindowHeight);
        }




    }
}
