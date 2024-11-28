using mc.Interfaces;
using mc.Objects;
using mc.services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Dialogs
{
    public class RenMovDialog : OkCancelDialog
    {

        private IFSItem sourceitem { get; set; }
        private DirectoryInfo destinationinfo { get; set; }
        private SingleLineTextEdit textedit { get; set; }

        private string prefix = "##";

        public RenMovDialog(IFSItem sourceitemin, DirectoryInfo destinationdirectoryin, Signal signalin) : base(signalin)
        {
            sourceitem = sourceitemin;
            destinationinfo = destinationdirectoryin;

            SetSize(new Size(60, 10));
            SetLocation();

            foregroundcolor = ConsoleColor.Black;
            backgroundcolor = ConsoleColor.Gray;

            okbtn.SetLocation(Location.X + 2, Location.Y + Size.Height - 2);
            cancelbtn.SetLocation(okbtn.Location.X + 20, okbtn.Location.Y);

            textedit = new SingleLineTextEdit(new Point(Location.X + 3, Location.Y + 5), new Size(Size.Width - 6, 1));
            textedit.SetText(destinationinfo.FullName);
            consoleobjects.Add(textedit);


            Draw();
        }

        public override void Draw()
        {
            base.Draw();

            Console.SetCursorPosition(Location.X + 1, Location.Y + 2);
            Console.Write("Move " + prefix + sourceitem.name + " into:");

            textedit.Draw();
        }

        //protected override void Okbtn_selected()
        //{
        //    DataService.Move(sourceitem, textedit.text + @"/");
        //    KillDialog(true);
        //}
    }
}
