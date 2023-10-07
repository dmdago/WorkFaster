using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WorkFaster
{
    public partial class Main : Form
    {
        private const string TrelloApiUrl = "https://api.trello.com/1/cards";

        public Main()
        {
            InitializeComponent();

            // Initializing api data 
            this.apiKeytxt.Text = WorkFaster.Properties.Settings.Default.apiKeySet;
            this.apiTokentxt.Text = WorkFaster.Properties.Settings.Default.apiTokenSet;
            this.idListtxt.Text = WorkFaster.Properties.Settings.Default.apiIdListSet;

            // Set the initial state of the form to Minimized
            this.WindowState = FormWindowState.Minimized;

            // Optionally, you can hide the window if you don't want it to appear in the taskbar
            this.ShowInTaskbar = false;

            // Create ContextMenuStrip
            contextMenuStrip = new ContextMenuStrip();

            // Add "Exit" option
            ToolStripMenuItem exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Click += exitMenuItem_Click;
            contextMenuStrip.Items.Add(exitMenuItem);

            // Assign ContextMenuStrip
            notifyIcon.ContextMenuStrip = contextMenuStrip;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Get the selected text
            string selectedText = "asd"; // Replace with actual text selection logic

            // Check if there is selected text
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                // Get API key and access token from TextBoxes
                string apiKey = this.apiKeytxt.Text;
                string accessToken = this.apiTokentxt.Text;
                string idList = this.idListtxt.Text;

                if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(accessToken))
                {
                    MessageBox.Show("Please enter your Trello API key, access token and Id List.");
                    return;
                }

                // Send the text to Trello using a POST request
                bool success = await SendTextToTrello(selectedText, apiKey, accessToken, idList);

                if (success)
                {
                    MessageBox.Show("Sent to Trello successfully.");
                }
                else
                {
                    MessageBox.Show("Error sending to Trello.");
                }
            }
        }

        private async Task<bool> SendTextToTrello(string selectedText, string apiKey, string accessToken, string idList)
        {
            try
            {
                // Create an HttpClient object for making the POST request
                using (HttpClient client = new HttpClient())
                {
                    // Create the data to be sent to Trello
                    var data = new
                    {
                        name = selectedText,
                        desc = selectedText,
                        key = apiKey,
                        token = accessToken,
                        idList = idList
                    };

                    // Serialize the data to JSON format
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                    // Configure the HTTP request content
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Send the POST request to the Trello API
                    HttpResponseMessage response = await client.PostAsync(TrelloApiUrl, content);

                    // Check if the request was successful
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception)
            {
                return false; // Error handling
            }
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            //if the form is minimized
            //hide it from the task bar
            //and show the system tray icon (represented by the NotifyIcon control)
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon.Visible = true;

                    WorkFaster.Properties.Settings.Default.apiKeySet = this.apiKeytxt.Text;
                    WorkFaster.Properties.Settings.Default.apiTokenSet = this.apiTokentxt.Text;
                    WorkFaster.Properties.Settings.Default.apiIdListSet = this.idListtxt.Text;
                    WorkFaster.Properties.Settings.Default.Save();
            
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            // Clean everything
            // Pending code


            // Close app
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}