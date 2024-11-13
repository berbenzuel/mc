using mc.Objects;
using mc.Objects.ConsoleGraphicsObject;
using mc.Windows.def;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc
{
    public class ViewerManager : ConsoleGraphicsObject
    {

        private const int NUMBEROFVIEWERS = 1;
        private Size baseviewersize {  get; set; }

        private Viewer[] Viewers = new Viewer[NUMBEROFVIEWERS];

        public ViewerManager(Signal signal)
        {
            Signal = signal;
            Maker();
        }

        public override void SetUp(Point location, Size size)
        {
            base.SetUp(location, size);
            baseviewersize = new Size(Size.Width / 2, Size.Height);

            for (int i = 0; i < NUMBEROFVIEWERS; i++) 
            {
                Viewers[i].SetUp(new Point(0 + i * baseviewersize.Width, 1), baseviewersize);
            }
        }
        private void Maker()
        {
            for (int i = 0; i < NUMBEROFVIEWERS; i++)
            {
                Viewers[i] = new Viewer(Signal);
            }   
        }

        public override void Draw()
        {  
            for (int i = 0; i < NUMBEROFVIEWERS; i++)
            {
                Viewers[i].Draw();
            }
        }




    }
}
