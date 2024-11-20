using mc.Objects.ConsoleGraphicsObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Dialogs
{
    public class DialogDef : Objects.ConsoleGraphicsObject.ConsoleObject
    {
        public int activeobjectindex {get; set;}
        public List<IConsoleObject> objects;

        public override void Draw()
        {
            base.Draw();
            for (int y = 0; y < Size.Height; y++)
            {
                Console.SetCursorPosition(Location.X, Location.Y + y);
                for (int x = 0; x < Size.Width; x++)
                {
                    Console.Write(' ');
                }
            }
        }

    }

    
}
