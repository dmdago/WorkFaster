using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Threading.Tasks;

namespace WorkFaster
{
    public partial class Main : Form
    {
        private const string TrelloApiUrl = "https://api.trello.com/1/cards";

        public Main()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Get the selected text
            string selectedText = "asd"; // Replace with actual text selection logic

            // Check if there is selected text
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                // Get API key and access token from TextBoxes
                string apiKey = "f7c1a0293aa0dc1b191179b639ae6384";
                string accessToken = "ATTA55f2f9a7150ff195237459151773c6861162b23307c048223829600d23a816a49DD1746B";
                string idList = "64f9e4715aedf3b3f22800d9";

                if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(accessToken))
                {
                    MessageBox.Show("Please enter your Trello API key and access token.");
                    return;
                }

                // Send the text to Trello using a POST request
                bool success = await SendTextToTrello(selectedText, apiKey, accessToken, idList);

                if (success)
                {
                    MessageBox.Show("Text sent to Trello successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to send text to Trello.");
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
    }
}