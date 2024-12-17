using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mc.Dialogs;
using mc.Interfaces;

namespace mc
{

    public class Signal : ISignal
    {

        public event EventHandler<ConsoleKeyInfo> KeyPressed;
        public event EventHandler<Size> SizeChanged;
        
        public event Action F1Pressed;
        public event Action F2Pressed;
        public event Action F3Pressed;
        public event Action F4Pressed;
        public event Action F5Pressed;
        public event Action F6Pressed;
        public event Action F7Pressed;
        public event Action F8Pressed;
        public event Action F9Pressed;
        public event Action F10Pressed;

        public event Action<Dialog, bool> KillDialog;
        public event Action QuitApplication;

        public event Action ChangeToMainWindow;
        public event Action<FileInfo> ChangeToViewWindow;
        public event Action<FileInfo> ChangeToEditWindow;
        public void OnKeyPressed(ConsoleKeyInfo key)
        {
            try
            {
                if (key.Key == ConsoleKey.F1)
                {
                    F1Pressed.Invoke();
                }
                else if (key.Key == ConsoleKey.F2)
                {
                    F2Pressed.Invoke();
                }
                else if (key.Key == ConsoleKey.F3)
                {
                    F3Pressed.Invoke();
                }
                else if (key.Key == ConsoleKey.F4)
                {
                    F4Pressed.Invoke();
                }
                else if (key.Key == ConsoleKey.F5)
                {
                    F5Pressed.Invoke();
                }
                else if (key.Key == ConsoleKey.F6)
                {
                    F6Pressed.Invoke();
                }
                else if (key.Key == ConsoleKey.F7)
                {
                    F7Pressed.Invoke();
                }
                else if (key.Key == ConsoleKey.F8)
                {
                    F8Pressed.Invoke();
                }
                else if (key.Key == ConsoleKey.F9)
                {
                    F9Pressed.Invoke();
                }
                else if (key.Key == ConsoleKey.F10)
                {
                    F10Pressed.Invoke();
                }
                else
                {
                    KeyPressed?.Invoke(this, key);
                }
            }
            catch { } 
        }


        public void OnSizeChanged(Size size)
        {
            SizeChanged?.Invoke(this, size);
        }

        public void OnKillDialog(Dialog dialog, bool needtorefresh)
        {
            KillDialog?.Invoke(dialog, needtorefresh);
        }

        public void OnQuitApplication()
        {
            QuitApplication?.Invoke();
        }

        public void OnChangeToMainWindow()
        {
            ChangeToMainWindow?.Invoke();
        }
        public void OnChangeToViewWindow(FileInfo file)
        {
            ChangeToViewWindow?.Invoke(file);
        }
        public void OnChangeToEditWindow(FileInfo file)
        {
            ChangeToEditWindow?.Invoke(file);
        }
    }
}
