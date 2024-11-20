using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Objects
{
    public class Button : ConsoleGraphicsObject.ConsoleObject
    {
        private Action clicked;
        private Label text { get; set; }

        public Button(string textin, Point locationin, Size sizein,Action action, ConsoleColor backgroundcolorin, ConsoleColor foregroundcolorin) 
        {
            Location = locationin;
            Size = sizein;
            clicked = action;
            text = new Label(textin, Location, Size, foregroundcolorin, backgroundcolorin);
        }

        public void Selected()
        {
            clicked.Invoke();
        }

        public override void Draw()
        {
            base.Draw();
            text.Draw();
        }
    }
}
