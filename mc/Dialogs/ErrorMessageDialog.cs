using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Dialogs
{
    public class ErrorMessageDialog : OkDialog
    {
        private string message {  get; set; }
        public ErrorMessageDialog(Exception exeption,Signal signalin) : base(signalin)
        {
            message = exeption.Message;

            SetSize(new System.Drawing.Size(message.Length +4, 5));
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
            Console.Write(message);

        }
    }
}
