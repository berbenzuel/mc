using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;

namespace mc
{

    public class Signal : ISignal
    {

        public event EventHandler<ConsoleKey> KeyPressed;
        public event EventHandler<Size> SizeChanged;
        public event Action F8Pressed;
        public event Action F5Pressed;
        public event Action F7Pressed;
        public event Action F10Pressed;

        public void OnKeyPressed(ConsoleKey key)
        {
            if (key == ConsoleKey.F8)
            {
                F8Pressed.Invoke();
            }
            else if (key == ConsoleKey.F5)
            {
                F5Pressed.Invoke();
            }
            else if (key == ConsoleKey.F7)
            {
                F7Pressed.Invoke();
            }
            else if (key == ConsoleKey.F10)
            {
                F10Pressed.Invoke();
            }
            else
            {
                KeyPressed?.Invoke(this, key);
            }   
        }


        public void OnSizeChanged(Size size)
        {
            SizeChanged?.Invoke(this, size);
        }


    }
}
