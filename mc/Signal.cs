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

        public void OnKeyPressed(ConsoleKey key)
        {
            KeyPressed?.Invoke(this, key);
        }

        public void OnSizeChanged(Size size)
        {
            SizeChanged?.Invoke(this, size);
        }

    }
}
