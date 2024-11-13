using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Interfaces;
using mc.Objects;
using mc.Objects.ConsoleGraphicsObject;
using mc.Windows.def;

namespace mc.Windows
{
    internal class MainWindow : Window
    {
        private const int NUMBEROFVIEWERS = 2;

        private List<ConsoleGraphicsObject> graphicsObjects = new List<ConsoleGraphicsObject>();

        private ViewerManager viewerManager;
        private CommandSidebar commandSidebar;
        private MenuBar menuBar;

        public MainWindow()
        {

            Signal.SizeChanged += S_SizeChanged;


            viewerManager = new ViewerManager(Signal);
            graphicsObjects.Add(viewerManager);

            commandSidebar = new CommandSidebar(Signal);
            graphicsObjects.Add(commandSidebar);

            menuBar = new MenuBar();
            graphicsObjects.Add(menuBar);


            ElementsSetUp();
            DrawAllElements();
            

            Control();

        }


        private void DrawAllElements()
        {
            foreach (var graphicsObject in graphicsObjects)
            {
                graphicsObject.Draw();
            }
        }

        private void ElementsSetUp()
        {
            viewerManager.SetUp(new Point(0, 1), new Size(Size.Width, Size.Height- 3));
            commandSidebar.SetUp(new Point(0, Size.Height-1), new Size(Size.Width, 1));
            menuBar.SetUp(new Point(0,0), new Size(Size.Width, 1));
        }


        //events
        private void S_SizeChanged(object? sender, Size e)
        {
            Size = e;
            ElementsSetUp();
            DrawAllElements();

        }


    }
}
