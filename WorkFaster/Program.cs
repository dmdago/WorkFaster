using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkFaster
{
    internal class Program
    {
        // Import WinAPI functions
        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookCallbackDelegate lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);

        // Constants
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const uint WM_GETTEXT = 0x000D;

        // Variables for keyboard state
        private static bool ctrlPressed = false;
        private static bool altPressed = false;
        private static bool shiftPressed = false;

        // Trello API settings
        private static string trelloApiUrl = "https://api.trello.com/1/cards";

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
                else if (ctrlPressed && altPressed && shiftPressed && vkCode == 65) // CTRL + ALT + SHIFT + A
                {
                    ctrlPressed = false;
                    altPressed = false;
                    shiftPressed = false;

                    // Call an async method to perform the asynchronous tasks
                    PerformAsyncTasks();
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

        private static async void PerformAsyncTasks()
        {
            // Copy selected text into clipboard
            await Task.Factory.StartNew(fetchSelectionToClipboard);

            // Access clipboard which now contains selected text in foreground window
            await Task.Factory.StartNew(useClipBoardValue);

            // Get the text from the clipboard
            string clipboardText = Clipboard.GetText();

            if (!string.IsNullOrWhiteSpace(clipboardText))
            {
                await Fnname(clipboardText);
            }
        }

        private static async Task Fnname(string clipboardText)
        {
            // Check if there is clipboard text
            if (!string.IsNullOrWhiteSpace(clipboardText))
            {
                // Get API key and access token from application settings
                string apiKey = WorkFaster.Properties.Settings.Default.apiKeySet;
                string accessToken = WorkFaster.Properties.Settings.Default.apiTokenSet;
                string idList = WorkFaster.Properties.Settings.Default.apiIdListSet;

                if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(accessToken))
                {
                    MessageBox.Show("Please enter your Trello API key, access token, and Id List.");
                    return;
                }

                // Send the clipboard text to Trello using a POST request
                await SendTextToTrello(clipboardText, apiKey, accessToken, idList);
            }
        }

        private static async Task SendTextToTrello(string clipboardText, string apiKey, string accessToken, string idList)
        {
            try
            {
                // Create an HttpClient object for making the POST request
                using (HttpClient client = new HttpClient())
                {
                    // Create the data to be sent to Trello
                    var data = new
                    {
                        name = clipboardText,
                        desc = clipboardText,
                        key = apiKey,
                        token = accessToken,
                        idList = idList
                    };

                    // Serialize the data to JSON format
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                    // Configure the HTTP request content
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Send the POST request to the Trello API
                    HttpResponseMessage response = await client.PostAsync(trelloApiUrl, content);

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        ShowMessage("Sent to Trello successfully.");
                    }
                    else
                    {
                        ShowMessage("Error sending to Trello.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error: " + ex.Message);
            }
        }

        private static async void ShowMessage(string message)
        {
            // Create a new instance of MessageForm with the provided message
            var messageForm = new MessageForm(message);

            // Show the message form
            messageForm.Show();

            // Wait for 5 seconds (5000 ms)
            await Task.Delay(5000);

            // Close the message form
            messageForm.Close();
        }

        static void fetchSelectionToClipboard()
        {
            Thread.Sleep(400);
            SendKeys.SendWait("^c");   // magic line which copies selected text to clipboard
            Thread.Sleep(400);
        }

        // depends on the type of your app, you sometimes need to access clipboard from a Single Thread Appartment model..therefore I'm creating a new thread here
        static void useClipBoardValue()
        {
            Exception threadEx = null;
            // Single Thread Apartment model
            Thread staThread = new Thread(
               delegate ()
               {
                   try
                   {
                       Console.WriteLine(Clipboard.GetText());
                   }
                   catch (Exception ex)
                   {
                       threadEx = ex;
                   }
               });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
            staThread.Join();
        }

        // Delegate for the hook callback function
        public delegate IntPtr HookCallbackDelegate(int nCode, IntPtr wParam, IntPtr lParam);
    }
}
