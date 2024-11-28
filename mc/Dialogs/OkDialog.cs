using mc.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Dialogs
{
    public class OkDialog : Dialog
    {
        


        public Button okbtn { get; set; } = new Button("Ok", Point.Empty, btnsize);


        public OkDialog(Signal signalin) : base(signalin)
        {
            buttons.Add(okbtn);
            consoleobjects.Add(okbtn);

            okbtn.selected += Okbtn_selected;


        }

        protected virtual void Okbtn_selected()
        {
            KillDialog();
        }

        protected override void SetButtonsPosition()
        {
            okbtn.SetLocation(Location.X + Size.Width / 2 - btnsize.Width/2, Location.Y + Size.Height - 2);
        }

    }
}
