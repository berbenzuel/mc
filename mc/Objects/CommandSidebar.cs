using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace mc.Objects
{
    public class CommandSidebar : ConsoleGraphicsObject.ConsoleGraphicsObject
    {

        private Size commandbuttonsize {  get; set; }
        private static string[] commands = { "Help", "Menu", "View", "Edit", "Copy", "RenMov", "Mkdir", "Delete", "PullDn", "Quit" };
        
        private CommandButton[] buttons = new CommandButton[commands.Length]; 

        public CommandSidebar(Signal signal) 
        {
            signal.KeyPressed += Signal_KeyPressed;
            Maker();
        }

        

        public override void Draw()
        {
            
            foreach (var button in buttons)
            {
                button.Draw();
            }
        }

        public override void SetUp(Point location, Size size)
        {
            base.SetUp(location, size);
            commandbuttonsize = new Size(Size.Width / 10, 1);
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetUp(new Point(Location.X + i * commandbuttonsize.Width, Location.Y), commandbuttonsize);
            }
        }

        private void Maker()
        {           
            for(int i  = 0; i < buttons.Length; i++) 
            {
                buttons[i] = new CommandButton(i + 1, commands[i], Signal);
            }
        }

        private void Signal_KeyPressed(object? sender, ConsoleKey e)
        {
            switch(e)
            {
                case ConsoleKey.F1:
                    throw new NotImplementedException();

                case ConsoleKey.F2:
                    throw new NotImplementedException();

                case ConsoleKey.F3:
                    throw new NotImplementedException();

                case ConsoleKey.F4:
                    throw new NotImplementedException();

                case ConsoleKey.F5:
                    throw new NotImplementedException();

                case ConsoleKey.F6:
                    throw new NotImplementedException();

                case ConsoleKey.F7:
                    throw new NotImplementedException();

                case ConsoleKey.F8:
                    throw new NotImplementedException();

                case ConsoleKey.F9:
                    throw new NotImplementedException();

                case ConsoleKey.F10:
                    throw new NotImplementedException();


            }
        }

    }

}
