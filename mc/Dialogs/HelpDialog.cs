using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Dialogs
{
    public class HelpDialog : OkDialog
    {
        public HelpDialog(Signal signalin) : base(signalin)
        {
            SetSize(new System.Drawing.Size(30, 5));
            SetLocation();

            foregroundcolor = ConsoleColor.Black;
            backgroundcolor = ConsoleColor.Gray;

            SetButtonsPosition();

            Draw();
        }

        public override void Draw()
        {
            base.Draw();

            Console.SetCursorPosition(Location.X + 2, Location.Y + 2);
            Console.Write("There is no help for you:(");

        }
    }
}
