using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Objects;
using mc.Interfaces;

namespace mc.Dialogs
{
    public class DeleteDialog : DialogDef
    {
        private Button btnyes {  get; set; }
        private Button btncancel { get; set; }

        private string datatypedelete { get; set; }
        private string suffix { get; set; }

        public DeleteDialog(IFSItem item, Signal signal) 
        {

            ForegroundColor = ConsoleColor.White;
            BackgroundColor = ConsoleColor.Red;
            SetSize(22, 8);
            SetLocation(true);
            Draw();
        }

        public override void Draw()
        {
            base.Draw();
            Console.SetCursorPosition(Location.X+1, Location.Y+1);
            Console.Write("┌───── ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Delete");
            ConsoleResetColor();
            Console.Write(" ─────┐");

            Console.Write(" │");
            Console.SetCursorPosition(Location.X + Size.Width / 2 - datatypedelete.Length, Location.Y + 2);

        }
    }
}
