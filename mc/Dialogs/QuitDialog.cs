using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace mc.Dialogs
{
    public class QuitDialog : OkCancelDialog
    {

        public QuitDialog(Signal signalin) : base(signalin) 
        {
            SetSize(new Size(30, 15));
            SetLocation();

            foregroundcolor = ConsoleColor.White;
            backgroundcolor = ConsoleColor.Red;

            okbtn.SetLocation(new Point(Location.X + 2, Location.Y + 14));
            cancelbtn.SetLocation(new Point(Location.X + 12, Location.Y + 14));

            Draw();
        }

        public override void Draw()
        {
            base.Draw();

            Console.SetCursorPosition(Location.X + 1, Location.Y+2);
            Console.Write("Do ju wont tu kvit?");
        }

        protected override void Okbtn_selected()
        {
            
        }
    }
}
