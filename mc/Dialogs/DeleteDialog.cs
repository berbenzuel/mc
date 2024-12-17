using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Objects;
using mc.Interfaces;
using mc.services;
using System.Diagnostics;

namespace mc.Dialogs
{
    public class DeleteDialog : OkCancelDialog
    {

        private string datatype { get; set; }
        private string suffix { get; set; }
        private string itemname { get; set; }
        
        
        private IFSItem item { get; set; }



        public DeleteDialog(IFSItem itemin, Signal signalin) : base(signalin) 
        {
            this.item = itemin;
            //datatype = DataService.GetTypeName(item);
            //suffix = DataService.GetPrefix(item);
            itemname = $"\"{suffix}{item.name}\"";


            foregroundcolor = ConsoleColor.White;
            backgroundcolor = ConsoleColor.Red;

            SetSize(new Size(22, 8));
            SetLocation();

            okbtn.SetLocation(Location.X + 3, Location.Y + Size.Height - 2);
            cancelbtn.SetLocation(Location.X + 12, Location.Y + Size.Height - 2);

            

            Draw();
        }

        protected override void Okbtn_selected()
        {
            //DataService.Delete(item);
            KillDialog();
        }


        public override void Draw() //Draw the dialog
        {
            base.Draw();
            Console.SetCursorPosition(Location.X+1, Location.Y+1);
            Console.Write("┌───── ");
            Console.Write("Delete");
            Console.Write(" ─────┐");


            Console.SetCursorPosition(Location.X+1, Location.Y+2);
            Console.Write("│");
            Console.SetCursorPosition(Location.X + Size.Width / 2 - 4 - datatype.Length/2, Location.Y + 2);
            Console.Write("Delete " + datatype);
            Console.SetCursorPosition(Location.X + Size.Width-2, Location.Y + 2);
            Console.Write("│");


            Console.SetCursorPosition(Location.X+1, Location.Y + 3);
            Console.Write("│");
            Console.SetCursorPosition(Location.X + Size.Width / 2 - itemname.Length/2, Location.Y + 3);
            Console.Write(itemname);
            Console.SetCursorPosition(Location.X + Size.Width - 2, Location.Y + 3);
            Console.Write("│");

            Console.SetCursorPosition(Location.X + 1, Location.Y + 4);
            Console.Write("├──────────────────┤");

            Console.SetCursorPosition(Location.X+1, Location.Y + 4);
            Console.Write("│");
            Console.SetCursorPosition(Location.X + Size.Width - 2, Location.Y + 4);
            Console.Write("│");

            Console.SetCursorPosition(Location.X + 1, Location.Y + 4);
            Console.Write("└──────────────────┘");






        }






    }
}
