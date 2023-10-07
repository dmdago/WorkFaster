using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WorkFaster
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookCallbackDelegate lpfn, IntPtr wParam, uint lParam);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        private static int WH_KEYBOARD_LL = 13;
        private static int WM_KEYDOWN = 0x100;
        private static int WM_SYSKEYDOWN = 0x0104;
        static bool ctrlPressed = false;
        static bool ctrlAPressed = false;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            HookCallbackDelegate hcDelegate = HookCallback;

            string mainModuleName = Process.GetCurrentProcess().MainModule.ModuleName;
            IntPtr hook = SetWindowsHookEx(WH_KEYBOARD_LL, hcDelegate, GetModuleHandle(mainModuleName), 0);


            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }
        public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            //Console.WriteLine($"{wParam} - {(IntPtr)wParam}");
            /* if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
             {
                 int vkCode = Marshal.ReadInt32(lParam);
                 //Console.WriteLine($"[{(Keys)vkCode}]");
                 MessageBox.Show($"[{(Keys)vkCode}]");
             }*/

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (vkCode == 162 || vkCode == 163) //162 is Left Ctrl, 163 is Right Ctrl
                {
                    ctrlPressed = true;
                }
                else if (vkCode == 65 && ctrlPressed == true) // "A"
                {
                    ctrlPressed = false;
                    ctrlAPressed = true;
                }
                else if (vkCode == 83 && ctrlAPressed == true) // "S"
                {
                    ctrlPressed = false;
                    ctrlAPressed = false;
                    MessageBox.Show("Bingo!");
                }
                else
                {
                    ctrlPressed = false;
                    ctrlAPressed = false;
                }

                // return (IntPtr)1; // note: this will interfere with keyboard processing for other apps
            }
            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        public delegate IntPtr HookCallbackDelegate(int nCode, IntPtr wParam, IntPtr lParam);

    }
}