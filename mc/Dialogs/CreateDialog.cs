using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;
using mc.Objects;
using mc.services;
using mc.services.FSListServices;

namespace mc.Dialogs
{
    public class CreateDialog : OkCancelDialog
    {
        private SingleLineTextEdit textedit {  get; set; }
        private DirectoryInfo directoryinfo {  get; set; }

        public CreateDialog(DirectoryInfo directoryin, Signal signalin) : base(signalin) 
        {
            directoryinfo = directoryin;

            SetSize(new Size(60, 10));
            SetLocation();

            foregroundcolor = ConsoleColor.Black;
            backgroundcolor = ConsoleColor.Gray;

            textedit = new SingleLineTextEdit(new Point(Location.X +2, Location.Y +3), new Size(54,1));
            textedit.Draw();

            okbtn.SetLocation(Location.X +2 , Location.Y + Size.Height-2);
            cancelbtn.SetLocation(okbtn.Location.X + 20, okbtn.Location.Y);
            consoleobjects.Add(textedit);



            Draw();
        }

        public override void Draw()
        {
            base.Draw();
            StringBuilder sb = new StringBuilder();
            sb.Append('┌');
            sb.Append('─',(Size.Width - 26)/2);
            sb.Append(" Create a new Directory ");
            sb.Append('─', (Size.Width - 26) / 2);
            sb.Append('┐');
            Console.SetCursorPosition(Location.X, Location.Y+1);
            Console.Write(sb.ToString());
            sb.Clear();

            for(int i = 2; i<4; i++)
            {
                Console.SetCursorPosition(Location.X, Location.Y+i);
                Console.Write('│');
                Console.SetCursorPosition(Location.X + Size.Width-1, Location.Y + i);
                Console.Write('│');
            }

            sb.Append('├');
            sb.Append('─', Size.Width - 2);
            sb.Append('┤');
            Console.SetCursorPosition(Location.X, Location.Y + 4);
            Console.Write(sb.ToString());
            sb.Clear();

            textedit.Draw();
        }

        protected override void Okbtn_selected()
        {
            if (textedit.text != null)
            {
                string finalpath = directoryinfo.FullName+ '/' + textedit.text;
                //DataService.CreateDirectory(finalpath);
                KillDialog();
            } 
        }
    }
}
