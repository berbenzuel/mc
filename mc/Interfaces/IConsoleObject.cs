using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc.Interfaces
{
    public interface IConsoleObject
    {
        Point Location { get; set; }
        Size Size { get; set; }
        bool IsActive { get; set; }
    }
}
