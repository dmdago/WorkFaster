using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
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
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;

        // Variables for keyboard state
        private static bool ctrlPressed = false;
        private static bool altPressed = false;
        private static bool shiftPressed = false;

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
                else if (vkCode == 164 || vkCode == 165) // 164 is Left Alt, 165 is Right Alt
                {
                    altPressed = true;
                }
                else if (vkCode == 160 || vkCode == 161) // 160 is Left Shift, 161 is Right Shift
                {
                    shiftPressed = true;
                }
                else if (ctrlPressed && altPressed && shiftPressed && vkCode == 83) // CTRL + ALT + SHIFT + S
                {
                    ctrlPressed = false;
                    altPressed = false;
                    shiftPressed = false;
                    ShowBingoMessage();
                }
                else
                {
                    ctrlPressed = false;
                    altPressed = false;
                    shiftPressed = false;
                }
            }

            return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }

        private static async void ShowBingoMessage()
        {
            MessageBox.Show("Bingo!");

            // Esperar 1 segundo
            await Task.Delay(1000);

            // Cerrar el MessageBox
            foreach (Form form in Application.OpenForms)
            {
                if (form is MessageBox)
                {
                    form.Close();
                    break;
                }
            }
        }

        // Delegate for the hook callback function
        public delegate IntPtr HookCallbackDelegate(int nCode, IntPtr wParam, IntPtr lParam);
    }
}
