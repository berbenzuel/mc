using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;

namespace mc.Objects.ConsoleGraphicsObject
{


    public abstract class ConsoleObject : IConsoleObject, IDrawable
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public bool IsActive { get; set; } = true;



        protected ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;
        protected ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;

        protected ConsoleColor InActiveForegroundColor { get; set; } = ConsoleColor.Gray;
        protected ConsoleColor InActiveBackgroundColor {  get; set; } = ConsoleColor.DarkGray;

        


        public virtual void Draw() // predelat vsechny draw na base.draw - nastaveni barvicek
        {
            if (IsActive)
            {
                Console.ForegroundColor = ForegroundColor;
                Console.BackgroundColor = BackgroundColor;
            }
            else
            {
                Console.ForegroundColor = InActiveForegroundColor;
                Console.BackgroundColor = InActiveBackgroundColor;
            }


        }


        public virtual void Erease()
        {
            ConsoleResetColor();
            for (int i = 0; i < Size.Height; i++)
            {
                Console.SetCursorPosition(Location.X, Location.Y + i);
                for (int j = 0; j < Size.Width; j++)
                {
                    Console.Write(' ');
                }
            }
        }

        public virtual void SetUp(Point location, Size size)
        {
            SetLocation(location);
            SetSize(size);
        }

        public void ConsoleResetColor()
        {
            Console.ForegroundColor= ForegroundColor;
            Console.BackgroundColor= BackgroundColor;
        }

        public void Update()
        {
            Erease();
            Draw();
        }

        #region sizedef
        public void SetSize(int x, int y)
        {
            Size = new Size(x, y);
        }
        public void SetSize(Size newSize)
        {
            Size = newSize;
        }
        #endregion

        #region locationdef
        public void SetLocation(Point newlocation)
        {
            Location = newlocation;

        }
        public void SetLocation(int x, int y)
        {
            Location = new Point(x, y);
        }
        public void SetLocation(bool middleOfWindow)
        {
            Location = new Point(Console.WindowWidth / 2 - Size.Width / 2, Console.WindowHeight / 2 - Size.Height / 2);
        }
        #endregion

        public void SetActive(bool active)
        {
            IsActive = active;
        }

        public void SetBackgroundColor(ConsoleColor color)
        { 
            BackgroundColor = color;
        }

        public void SetForegroundColor(ConsoleColor color)
        {
            ForegroundColor = color;
        }

    }
}
