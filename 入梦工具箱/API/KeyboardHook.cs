using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyHook
{
   class KeyboardHook
    {


        #region 常数和结构

        public const int WM_KEYDOWN = 0x100;

        public const int WM_KEYUP = 0x101;

        public const int WM_SYSKEYDOWN = 0x104;

        public const int WM_SYSKEYUP = 0x105;

        public const int WH_KEYBOARD_LL = 13;



        [StructLayout(LayoutKind.Sequential)] //声明键盘钩子的封送结构类型 

        public class KeyboardHookStruct

        {

            public int vkCode; //表示一个在1到254间的虚似键盘码 

            public int scanCode; //表示硬件扫描码 

            public int flags;

            public int time;

            public int dwExtraInfo;

        }

        #endregion

        #region Api

        public delegate int HookProc(int nCode, Int32 wParam, IntPtr lParam);

        //安装钩子的函数 

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);



        //卸下钩子的函数 

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern bool UnhookWindowsHookEx(int idHook);



        //下一个钩挂的函数 

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern int CallNextHookEx(int idHook, int nCode, Int32 wParam, IntPtr lParam);



        [DllImport("user32")]

        public static extern int ToAscii(int uVirtKey, int uScanCode, byte[] lpbKeyState, byte[] lpwTransKey, int fuState);



        [DllImport("user32")]

        public static extern int GetKeyboardState(byte[] pbKeyState);



        [DllImport("kernel32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        public static extern IntPtr GetModuleHandle(string lpModuleName);

        #endregion

        int hHook;

        HookProc KeyboardHookDelegate;

        public event KeyEventHandler KeyDownEvent;

        public event KeyEventHandler KeyUpEvent;

        public event KeyPressEventHandler KeyPressEvent;

        //public KeyboardHook() { }

        public void Start()

        {

            KeyboardHookDelegate = new HookProc(KeyboardHookProc);

            Process cProcess = Process.GetCurrentProcess();

            ProcessModule cModule = cProcess.MainModule;

            var mh = GetModuleHandle(cModule.ModuleName);

            hHook = SetWindowsHookEx(WH_KEYBOARD_LL, KeyboardHookDelegate, mh, 0);

        }

        public void Stop()

        {

            UnhookWindowsHookEx(hHook);

        }

        private List<Keys> preKeysList = new List<Keys>();//存放被按下的控制键，用来生成具体的键

        private int KeyboardHookProc(int nCode, Int32 wParam, IntPtr lParam)

        {

            //如果该消息被丢弃（nCode<0）或者没有事件绑定处理程序则不会触发事件

            if ((nCode >= 0) && (KeyDownEvent != null || KeyUpEvent != null || KeyPressEvent != null))

            {

                KeyboardHookStruct KeyDataFromHook = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

                Keys keyData = (Keys)KeyDataFromHook.vkCode;

                //按下控制键

                if ((KeyDownEvent != null || KeyPressEvent != null) && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))

                {

                    if (IsCtrlAltShiftKeys(keyData) && preKeysList.IndexOf(keyData) == -1)

                    {

                        preKeysList.Add(keyData);

                    }

                }

                //WM_KEYDOWN和WM_SYSKEYDOWN消息，将会引发OnKeyDownEvent事件

                if (KeyDownEvent != null && (wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN))

                {

                    KeyEventArgs e = new KeyEventArgs(GetDownKeys(keyData));



                    KeyDownEvent(this, e);

                }

                //WM_KEYDOWN消息将引发OnKeyPressEvent 

                if (KeyPressEvent != null && wParam == WM_KEYDOWN)

                {

                    byte[] keyState = new byte[256];

                    GetKeyboardState(keyState);



                    byte[] inBuffer = new byte[2];

                    if (ToAscii(KeyDataFromHook.vkCode, KeyDataFromHook.scanCode, keyState, inBuffer, KeyDataFromHook.flags) == 1)

                    {

                        KeyPressEventArgs e = new KeyPressEventArgs((char)inBuffer[0]);

                        KeyPressEvent(this, e);

                    }

                }

                //松开控制键

                if ((KeyDownEvent != null || KeyPressEvent != null) && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))

                {

                    if (IsCtrlAltShiftKeys(keyData))

                    {

                        for (int i = preKeysList.Count - 1; i >= 0; i--)

                        {

                            if (preKeysList[i] == keyData) { preKeysList.RemoveAt(i); }

                        }

                    }

                }

                //WM_KEYUP和WM_SYSKEYUP消息，将引发OnKeyUpEvent事件 

                if (KeyUpEvent != null && (wParam == WM_KEYUP || wParam == WM_SYSKEYUP))

                {

                    KeyEventArgs e = new KeyEventArgs(GetDownKeys(keyData));

                    KeyUpEvent(this, e);

                }

            }

            return CallNextHookEx(hHook, nCode, wParam, lParam);

        }

        //根据已经按下的控制键生成key

        private Keys GetDownKeys(Keys key)

        {

            Keys rtnKey = Keys.None;

            foreach (Keys i in preKeysList)

            {

                if (i == Keys.LControlKey || i == Keys.RControlKey) { rtnKey = rtnKey | Keys.Control; }

                if (i == Keys.LMenu || i == Keys.RMenu) { rtnKey = rtnKey | Keys.Alt; }

                if (i == Keys.LShiftKey || i == Keys.RShiftKey) { rtnKey = rtnKey | Keys.Shift; }

            }

            return rtnKey | key;

        }



        private Boolean IsCtrlAltShiftKeys(Keys key)

        {

            if (key == Keys.LControlKey || key == Keys.RControlKey || key == Keys.LMenu || key == Keys.RMenu || key == Keys.LShiftKey || key == Keys.RShiftKey) { return true; }

            return false;

        }

    }


}
