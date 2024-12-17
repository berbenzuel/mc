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
    public class CommandSidebar : ConsoleGraphicsObject.ConsoleObject
    {

        private Size commandbuttonsize {  get; set; }
        private static string[] commands = { "Help", "Menu", "View", "Edit", "Copy", "RenMov", "Mkdir", "Delete", "PullDn", "Quit" };
        
        private CommandButton[] buttons = new CommandButton[commands.Length]; 

        public CommandSidebar() 
        {
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
                buttons[i] = new CommandButton(i + 1, commands[i]);
            }
        }

    }

}
