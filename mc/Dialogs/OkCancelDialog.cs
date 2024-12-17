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
    public class OkCancelDialog : Dialog
    {
        

        public Button okbtn {  get; set; } = new Button("Ok", Point.Empty, btnsize);
        public Button cancelbtn { get; set; } = new Button("Cancel", Point.Empty, btnsize);


        public OkCancelDialog(Signal signalin) : base(signalin)
        {
            buttons.Add(okbtn);
            buttons.Add(cancelbtn);
            consoleobjects.Add(okbtn);
            consoleobjects.Add(cancelbtn);

            okbtn.selected += Okbtn_selected;
            cancelbtn.selected += Cancelbtn_selected;

        }

        protected virtual void Okbtn_selected()
        {
            //Do something
        }
        private void Cancelbtn_selected()
        {
            KillDialog();
        }
    }
}
