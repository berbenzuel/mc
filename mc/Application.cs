using System.Drawing;
using mc.Dialogs;
using mc.Enums;
using mc.Interfaces;
using mc.Objects;
using mc.services;
using mc.services.FSListServices;
using mc.Windows;
using mc.Windows.def;
namespace mc
{
    internal class Application : Signal
    {
        public Signal signal = new Signal();
        public Window activewindow {  get; set; }
        public Dialog? activedialog { get; set; } //z tohodle udelat list - kdyz dialog prez okno
        public MainWindow mainwindow { get; set; }
        public DataService dataservice { get; set; }

        private Dictionary<ConsoleKey, Action> keyValuePairs = new Dictionary<ConsoleKey, Action>();
        




        private bool terminate { get; set; } = false;

        public Application()
        {
            Console.Title = "moon commander";
            SetWindow();
            SetKeyValuePairs();

            dataservice = new DataService();
            mainwindow = new MainWindow(dataservice, signal);

            

            ChangeToMainWindow();
            

            signal.QuitApplication += Signal_QuitApplication; ;
            signal.ChangeToViewWindow += ChangeToViewWindow;
            signal.ChangeToMainWindow += ChangeToMainWindow;

            Control();

            Draw();
        }

        public void Draw()
        {
            activewindow.Draw();
            activedialog.Draw();
            
        }

        private void ChangeToMainWindow()
        {
            activewindow = mainwindow;
            activewindow.Draw();
        }

        private void SetKeyValuePairs()
        {
            //func keys
            keyValuePairs.Add(ConsoleKey.F1, () => ShowDialog(new HelpDialog(signal)));
            keyValuePairs.Add(ConsoleKey.F2, () => ShowDialog(new ErrorMessageDialog(new NotImplementedException(),signal)));
            keyValuePairs.Add(ConsoleKey.F3, () => ShowDialog(new ErrorMessageDialog(new NotImplementedException(),signal)));
            keyValuePairs.Add(ConsoleKey.F4, () => ShowDialog(new ErrorMessageDialog(new NotImplementedException(), signal)));
            keyValuePairs.Add(ConsoleKey.F5, () => ShowDialog(new ErrorMessageDialog(new NotImplementedException(), signal)));
            keyValuePairs.Add(ConsoleKey.F6, () => ShowDialog(new HelpDialog(signal)));
            keyValuePairs.Add(ConsoleKey.F7, () => ShowDialog(new HelpDialog(signal)));
            keyValuePairs.Add(ConsoleKey.F8, () => ShowDialog(new HelpDialog(signal)));
            keyValuePairs.Add(ConsoleKey.F9, () => ShowDialog(new HelpDialog(signal)));
            keyValuePairs.Add(ConsoleKey.F10, () => ShowDialog(new QuitDialog(signal)));

            //arrows
            keyValuePairs.Add(ConsoleKey.LeftArrow, () => ArrowPressed(Arrows.LeftArrow));
            keyValuePairs.Add(ConsoleKey.RightArrow, () => ArrowPressed(Arrows.RightArrow));
            keyValuePairs.Add(ConsoleKey.UpArrow, () => ArrowPressed(Arrows.UpArrow));
            keyValuePairs.Add(ConsoleKey.DownArrow, () => ArrowPressed(Arrows.DownArrow));

            //enter
            keyValuePairs.Add(ConsoleKey.Enter, () => EnterPressed());
        }

        private void ShowDialog(Dialog dialog)
        {
            activedialog = dialog;
            activedialog.killdialog += OnKillDialog;
            dialog.Draw();
        }
        

        private void ChangeToViewWindow(FileInfo file)
        {
            activewindow = new ViewWindow(file, signal);
            activewindow.Draw();
            
        }

        private void SetWindow()
        {
            Console.SetWindowSize(150, 40);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetBufferSize(Console.WindowWidth,Console.WindowHeight);
        }


        public virtual void Control()
        {
            while (true)
            {
                if(terminate)
                {
                    break;
                }
                if (Console.KeyAvailable)
                {  
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    if(keyValuePairs.TryGetValue(info.Key, out var keyValue))
                    {
                        keyValuePairs[info.Key].Invoke();
                    }
                    else
                    {
                        mainwindow.OtherKeyPressed(info);
                    }
                }

                if (activewindow.Size != new Size(Console.WindowWidth, Console.WindowHeight))
                {
                    
                    if (Console.WindowWidth < 150 || Console.WindowHeight < 40)
                    {
                        Console.SetWindowSize(150, 40);
                        Console.SetBufferSize(150, 40);
                    }
                    try
                    {
                        Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
                        signal.OnSizeChanged(new Size(Console.WindowWidth, Console.WindowHeight));
                        activewindow.Size = new Size(Console.WindowWidth, Console.WindowHeight);
                    }
                    catch{}

                    
                }
            }
        }

        private void Signal_QuitApplication()
        {
            terminate = true;
        }

        private void ArrowPressed(Arrows arrow)
        {
            if (activedialog != null)
            {
                activedialog.ArrowPressed(arrow);
            }
            else
            {
                mainwindow.ArrowPressed(arrow);
            }
        }
        private void EnterPressed()
        {
            if(activedialog != null)
            {
                activedialog.EnterPressed();
            }
            else
            {
                mainwindow.EnterPressed();
            }
        }

        private void OnKillDialog(Dialog dialog, bool needtorefresh)
        {
            activedialog = null;
            activewindow.Draw();
            
            
        }

    }


}


