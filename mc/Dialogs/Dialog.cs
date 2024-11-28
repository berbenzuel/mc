using mc.Enums;
using mc.Interfaces;
using mc.Objects;
using mc.Objects.ConsoleGraphicsObject;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Dialogs
{
    public class Dialog : IDrawable
    {
        public int activebutton { get; set; } = 0;
        public List<Button> buttons {get; set;} = new List<Button>();
        public List<ConsoleObject> consoleobjects {get; set;} = new List<ConsoleObject> ();
        
        public event Action<Dialog, bool> killdialog;


        protected Size Size { get; set; }
        protected Point Location { get; set; }
        protected bool IsActive { get; set; } = true;
        protected ConsoleColor foregroundcolor { get; set; } = ConsoleColor.Gray;
        protected ConsoleColor backgroundcolor { get; set; } = ConsoleColor.White;
        protected static Size btnsize = new Size(6, 1);

        protected bool changeinrepository { get; set; } = false;

        protected Dictionary<Arrows, Action?> arrowdictionary {  get; set; }

        protected Dialog(Signal signalin) 
        {
            

            arrowdictionary = new Dictionary<Arrows, Action>();
            arrowdictionary.Add(Arrows.LeftArrow, () => LeftArrowPressed());
            arrowdictionary.Add(Arrows.RightArrow, () => RightArrowPressed());
            arrowdictionary.Add(Arrows.UpArrow, null);
            arrowdictionary.Add(Arrows.DownArrow, null);


        }

        public virtual void Draw()
        {
            
            Console.ForegroundColor = foregroundcolor;
            Console.BackgroundColor = backgroundcolor;
            
            for (int y = 0; y < Size.Height; y++)
            {
                Console.SetCursorPosition(Location.X, Location.Y + y);
                for (int x = 0; x < Size.Width; x++)
                {
                    Console.Write(' ');
                }
            }
            DrawButtons();

            Console.ForegroundColor = foregroundcolor;
            Console.BackgroundColor = backgroundcolor;
        }

        public virtual void EnterPressed() 
        {
            buttons[activebutton].Select();
        }

        public void RightArrowPressed() //prepsat na delegata
        {
            if (activebutton < buttons.Count-1)
            {
                activebutton++;
                DrawButtons();
            }
        }
        public void LeftArrowPressed() 
        {
            if (activebutton > 0)
            {
                activebutton--;
                DrawButtons();
            }
        }

        public virtual void ArrowPressed(Arrows arrow)
        {

        }

        protected virtual void SetButtonsPosition() { }


        protected void DrawButtons()
        {
            for (int counter = 0; counter < buttons.Count; counter++)
            {
                buttons[counter].SetActive(counter==activebutton);
                buttons[counter].Draw();
            }
        }
        
        protected void SetSize(Size size)
        {
            this.Size = size;
        }
        protected void SetLocation()
        {
            Location = new Point(Console.WindowWidth / 2 - Size.Width / 2, Console.WindowHeight / 2 - Size.Height / 2);
        }
        protected virtual void KillDialog()
        {
            killdialog.Invoke(this, changeinrepository);
        }
     

    }

    
}
