using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;
using mc.Dialogs;
using mc.Objects;
using mc.Objects.ConsoleGraphicsObject;
using mc.services;
using mc.Windows.def;
using mc.services.FSListServices;
using mc.Enums;

namespace mc.Windows
{
    internal class MainWindow : Window
    {

        public Viewer activeviewer { get; set; }
        public Viewer inactiveviewer { get; set; }

        private List<Viewer> viewerlist;

        private List<IDrawable> drawables = new List<IDrawable>();
        private CommandSidebar commandSidebar;
        private MenuBar menuBar;
        private DataService dataservice { get; set; }
        private Dictionary<Arrows, Action> arrowpressed = new Dictionary<Arrows, Action>();

        private Viewer leftviewer;
        private Viewer rightviewer;

        private delegate void setactiveviewer(Viewer toactive, Viewer toinactive);



        public MainWindow(DataService servicein,Signal signalin) : base(signalin)
        {
            Size = new Size(Console.WindowWidth, Console.WindowHeight);
            Console.WriteLine("pls something");
            dataservice = servicein;      
            signal = signalin;
            
            viewerlist = new List<Viewer>();

            leftviewer = new Viewer(dataservice);
            activeviewer = leftviewer;
            drawables.Add(leftviewer);
            viewerlist.Add(leftviewer);

            rightviewer = new Viewer(dataservice);
            inactiveviewer = rightviewer;
            drawables.Add(rightviewer);
            viewerlist.Add(rightviewer);

            commandSidebar = new CommandSidebar();
            drawables.Add(commandSidebar);


            //menuBar = new MenuBar();
            //drawables.Add(menuBar);

            ElementsSetUp();

            setactiveviewer setactiveviewer = new setactiveviewer(SetActiveViewer);

            setactiveviewer(leftviewer, rightviewer);

            arrowpressed.Add(Arrows.LeftArrow, () => setactiveviewer.Invoke(leftviewer, rightviewer));
            arrowpressed.Add(Arrows.RightArrow, () => setactiveviewer.Invoke(rightviewer, leftviewer));
            arrowpressed.Add(Arrows.UpArrow, () => activeviewer.UpArrowPressed());
            arrowpressed.Add(Arrows.DownArrow, () => activeviewer.DownArrowPressed());
        }

        

        

        public override void Draw()
        {
            ElementsSetUp();

            
            foreach (var drawable in drawables)
            {
                drawable.Draw();
            }
        }

        private void ElementsSetUp() // daji se nastavit neco jako funkce(bude to pouze delegat) a ten bude vsechno nastavovat vyvolanim
        {
            commandSidebar.SetUp(new Point(0, Size.Height - 1), new Size(Size.Width, 1));
            //menuBar.SetUp(new Point(0, 0), new Size(Size.Width, 1));
            leftviewer.SetUp(new Point(0,1), new Size(Size.Width/2,Size.Height-4));
            rightviewer.SetUp(new Point(Size.Width/2,1), new Size(Size.Width/2,Size.Height-4));
        }

        public void ArrowPressed(Arrows arrow)
        {
            arrowpressed[arrow].Invoke();
        }


        public override void EnterPressed()
        {
            activeviewer.EnterPressed();
        }

        public void OtherKeyPressed(ConsoleKeyInfo keyinfo)
        {

        }

        private void SetActiveViewer(Viewer toactive, Viewer toinactive)
        {
            activeviewer = toactive;
            toactive.SetActive(true);

            inactiveviewer = toinactive;
            toinactive.SetActive(false);

            foreach(Viewer viewer in viewerlist)
            {
                viewer.Draw();
            }
        }



    }
}
