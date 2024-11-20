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

namespace mc.Windows
{
    internal class MainWindow : Window
    {

        private List<ConsoleObject> consoleobjects = new List<ConsoleObject>();

        private ViewerManager viewerManager;
        private CommandSidebar commandSidebar;
        private MenuBar menuBar;
        private Signal signal;

        private IFSItem activeitem => viewerManager.viewers[viewerManager.activeviewerindex].fslist.activeitem;

        public MainWindow(Signal Signal)
        {
            signal = Signal;
            signal.SizeChanged += S_SizeChanged;
            signal.F8Pressed += Signal_F8Pressed;
            signal.F5Pressed += Signal_F5Pressed;
            signal.F7Pressed += Signal_F7Pressed1;
            

            

            commandSidebar = new CommandSidebar();
            consoleobjects.Add(commandSidebar);

            menuBar = new MenuBar();
            consoleobjects.Add(menuBar);

            viewerManager = new ViewerManager(Signal);
            consoleobjects.Add(viewerManager);


            ElementsSetUp();
            DrawAllElements();

        }

        

        private void DrawAllElements()
        {
            foreach (var graphicsObject in consoleobjects)
            {
                graphicsObject.Draw();
            }
        }

        private void ElementsSetUp()
        {
            commandSidebar.SetUp(new Point(0, Size.Height - 1), new Size(Size.Width, 1));
            menuBar.SetUp(new Point(0, 0), new Size(Size.Width, 1));
            viewerManager.SetUp(new Point(0, 1), new Size(Size.Width, Size.Height- 3));
            
        }


        //events
        private void S_SizeChanged(object? sender, Size e)
        {
            Size = e;
            ElementsSetUp();
            DrawAllElements();

        }

        private void Signal_F8Pressed()
        {
            DeleteDialog msg = new DeleteDialog(activeitem, signal);
            //DataService.Delete(activeitem);
            //viewerManager.viewers[viewerManager.activeviewerindex].fslist.Refresh();
        }

        private void Signal_F5Pressed()
        {
            DataService.Copy(activeitem, viewerManager.viewers[viewerManager.activeviewerindex == 0?1:0].fslist.actualdirectory.FullName);
            viewerManager.viewers[viewerManager.activeviewerindex].fslist.Refresh();
        }
        private void Signal_F7Pressed1()
        {
            DataService.CreateDirectory(viewerManager.viewers[viewerManager.activeviewerindex].fslist.actualdirectory.FullName + @$"\newfoo");
            viewerManager.viewers[viewerManager.activeviewerindex].fslist.Refresh();
        }
        

    }
}
