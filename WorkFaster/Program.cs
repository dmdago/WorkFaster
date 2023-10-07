using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WorkFaster
{
    internal static class Program
    {
        // Import WinAPI functions
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookCallbackDelegate lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        // Constants
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x0104;

        // Variables for keyboard state
        private static bool ctrlPressed = false;
        private static bool ctrlAPressed = false;

        [STAThread]
        static void Main()
        {
            // Create the delegate for the keyboard hook
            HookCallbackDelegate hookCallbackDelegate = HookCallback;

            // Get the name of the main module
            string mainModuleName = Process.GetCurrentProcess().MainModule.ModuleName;

            // Set up the keyboard hook
            IntPtr hook = SetWindowsHookEx(WH_KEYBOARD_LL, hookCallbackDelegate, GetModuleHandle(mainModuleName), 0);

            // Initialize application configuration
            ApplicationConfiguration.Initialize();

            // Run the main application
            Application.Run(new Main());
        }

        public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam);

                if (vkCode == 162 || vkCode == 163) // 162 is Left Ctrl, 163 is Right Ctrl
                {
                    ctrlPressed = true;
                }
                else if (vkCode == 65 && ctrlPressed) // "A"
                {
                    ctrlPressed = false;
                    ctrlAPressed = true;
                }
                else if (vkCode == 83 && ctrlAPressed) // "S"
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
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        // Delegate for the hook callback function
        public delegate IntPtr HookCallbackDelegate(int nCode, IntPtr wParam, IntPtr lParam);
    }
}
