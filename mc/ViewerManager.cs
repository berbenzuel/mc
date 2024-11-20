using mc.Objects;
using mc.Objects.ConsoleGraphicsObject;
using mc.Windows.def;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mc
{
    public class ViewerManager : ConsoleObject
    {
        public Viewer[] viewers = new Viewer[NUMBEROFVIEWERS];
        public int activeviewerindex { get; set; } = 0;
       
        private const int NUMBEROFVIEWERS = 2;
       
        private Size baseviewersize {  get; set; } //actual viewer size

        

        public ViewerManager(Signal signal)
        {
            signal.KeyPressed += Signal_KeyPressed;
            Maker();
        }
        public override void Draw()
        {
            
            for (int i = 0; i < NUMBEROFVIEWERS; i++)
            {
                ;
                viewers[i].Draw();
            }
        }

        public override void SetUp(Point location, Size size)
        {
            base.SetUp(location, size);

            baseviewersize = new Size(Size.Width / 2, Size.Height);

            for (int i = 0; i < NUMBEROFVIEWERS; i++)
            {
                
                viewers[i].SetUp(new Point(0 + i * baseviewersize.Width, 1), baseviewersize);
            }
            
        }

        //add viewers into field
        private void Maker()
        {
            for (int i = 0; i < NUMBEROFVIEWERS; i++)
            {
                viewers[i] = new Viewer();
                viewers[i].fslist.SetActive(i == activeviewerindex ? true : false);
            }  
            
        }

        //draw all viewers

        //i need to make several events, but for examle in one list this elseifs are ridiculous
        private void Signal_KeyPressed(object? sender, ConsoleKey e)
        {
            if (IsActive)
            {
                if (e == ConsoleKey.Enter)
                {
                    viewers[activeviewerindex].EnterPressed();
                }
                else if (e == ConsoleKey.DownArrow)
                {
                    viewers[activeviewerindex].DownArrowPressed();
                }
                else if (e == ConsoleKey.UpArrow)
                {
                    viewers[activeviewerindex].UpArrowPressed();
                }
                else if (e == ConsoleKey.RightArrow)
                {
                    if (activeviewerindex < NUMBEROFVIEWERS-1)
                    {
                        viewers[activeviewerindex].fslist.SetActive(false);
                        viewers[activeviewerindex].fslist.Draw();
                        activeviewerindex++;
                        viewers[activeviewerindex].fslist.SetActive(true);
                        viewers[activeviewerindex].fslist.Draw();
                    }
                }
                else if (e == ConsoleKey.LeftArrow)
                {
                    if (activeviewerindex > 0)
                    {
                        viewers[activeviewerindex].fslist.SetActive(false); 
                        viewers[activeviewerindex].fslist.Draw();
                        activeviewerindex--;
                        viewers[activeviewerindex].fslist.SetActive(true);
                        viewers[activeviewerindex].fslist.Draw();
                    }
                }
            }

        }

    }
}
