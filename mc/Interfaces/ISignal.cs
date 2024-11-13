using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Interfaces
{
    public interface ISignal
    {
        event EventHandler<ConsoleKey> KeyPressed;

        event EventHandler<Size> SizeChanged;
    }
}
