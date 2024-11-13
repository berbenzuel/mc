using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;

namespace mc.Objects.ConsoleGraphicsObject
{


    public abstract class ConsoleGraphicsObject : IConsoleGraphicsObject, IDrawable 
    {
        public Point Location { get; set; }
        public Size Size { get; set; }
        public bool IsActive { get; set; } = true;



        protected ConsoleColor ForegroundColor { get; set; } = ConsoleColor.White;
        protected ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Black;
        protected Signal Signal { get; set; }


        public virtual void Draw() // predelat vsechny draw na base.draw - nastaveni barvicek
        {
            Console.SetCursorPosition(Location.X, Location.Y);
            Console.ForegroundColor = ForegroundColor;
            Console.BackgroundColor = BackgroundColor;
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

        public void SetActive()
        {
            IsActive = true;
        }
        public void SetInActive()
        {
            IsActive= false;
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
