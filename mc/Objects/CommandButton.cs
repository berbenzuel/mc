using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace mc.Objects
{
    public class CommandButton : ConsoleGraphicsObject.ConsoleObject
    {
        private Label numberLabel;
        private Label commandLabel;

        private int number {  get; set; }
        private string command { get; set; }

        public CommandButton(int numberin, string commandin) 
        {
            number = numberin;
            command = commandin;
            Maker();
        }

        private void Maker()
        {
            numberLabel = new Label(number.ToString(), ConsoleColor.White, ConsoleColor.Black);
            commandLabel = new Label(command, ConsoleColor.Black, ConsoleColor.DarkCyan);
        }

        public override void SetUp(Point location, Size size)
        {
            base.SetUp(location, size);
            numberLabel.SetUp(Location, new Size(2, 1));
            commandLabel.SetUp(new Point(Location.X + 2, Location.Y), new Size(Size.Width-2, 1));
        }

        public override void Draw()
        {
            numberLabel.Draw();
            commandLabel.Draw();
        }


    }
}
