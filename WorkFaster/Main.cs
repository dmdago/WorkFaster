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

        private async void button1_Click(object sender, EventArgs e) // Marca como async y cambia a async void
        {
            // Obtiene el texto seleccionado
            string selectedText = "asd";

            // Verifica que haya texto seleccionado
            if (!string.IsNullOrWhiteSpace(selectedText))
            {
                // Obtiene la clave de API y el token de acceso de los TextBox
                string apiKey = "f7c1a0293aa0dc1b191179b639ae6384";
                string accessToken = "ATTA55f2f9a7150ff195237459151773c6861162b23307c048223829600d23a816a49DD1746B";
                string idList = "64f9e4715aedf3b3f22800d9";

                if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(accessToken))
                {
                    MessageBox.Show("Por favor, ingresa la clave de API y el token de acceso de Trello.");
                    return;
                }

                // Realiza la solicitud POST a la API de Trello
                bool success = await EnviarTextoATrello(selectedText, apiKey, accessToken, idList);

                if (success)
                {
                    MessageBox.Show("Texto enviado a Trello correctamente.");
                }
                else
                {
                    MessageBox.Show(success.ToString());
                }
            }
        }

        private async Task<bool> EnviarTextoATrello(string selectedText, string apiKey, string accessToken, string idList)
        {
            try
            {
                // Crea un objeto HttpClient para hacer la solicitud POST
                using (HttpClient client = new HttpClient())
                {
                    // Crea los datos que se enviarán a Trello
                    var data = new
                    {
                        name = selectedText,
                        desc = selectedText,
                        key = apiKey,
                        token = accessToken,
                        idList = idList
                    };

                    // Convierte los datos a formato JSON
                    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                    // Configura el contenido de la solicitud HTTP
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Realiza la solicitud POST a la API de Trello
                    HttpResponseMessage response = await client.PostAsync(TrelloApiUrl, content);

                    // Verifica si la solicitud fue exitosa
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception)
            {
                return false; // Manejo de errores
            }
        }
    }
}
