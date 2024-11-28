using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;

namespace mc.Windows.def
{
    public class Window : IWindow
    {
        public Size Size { get; set; } = new Size(Console.WindowWidth, Console.WindowHeight);
        public bool IsActive { get; set; } = true;

        protected Signal signal {  get; set; }

        public Window(Signal signalin) 
        {
            signal = signalin;
        }
        
        public virtual void Draw()
        {

        }
        public void SetActive(bool active)
        {
            IsActive = active;
        }
        public void SetSize(int width, int height)
        {

            Size = new Size(width, height); 
        }


        public virtual void EnterPressed(){}

    }
    
}
