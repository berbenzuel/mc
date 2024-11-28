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
        private Label text { get; set; }

        public event Action selected;

        public Button(string textin, Point locationin, Size sizein) 
        {
            ForegroundColor = ConsoleColor.Black;
            BackgroundColor = ConsoleColor.Yellow;
            Location = locationin;
            Size = sizein;
            text = new Label(textin, Location, Size, ForegroundColor, BackgroundColor);
        }

        public override void Draw()
        {
            base.Draw();
            text.Location = Location;
            text.SetActive(IsActive);
            text.Draw();
            
        }
        public void Select()
        {
            selected.Invoke();  
        }
    }
}
