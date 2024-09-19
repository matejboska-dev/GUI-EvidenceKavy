using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace http_winform_revised
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient httpClient = new();
        private const string endpointUrl = "http://ajax1.lmsoft.cz/procedure.php";
        private readonly List<RadioButton> userRadioButtons = new();
        private readonly List<TrackBar> drinkTrackBars = new();

        public Form1()
        {
            InitializeComponent();
            monthComboBox.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", EncodeToBase64($"{username}:{password}"));

            var peopleData = FetchDataFromApi<GetPeopleData>("getPeopleList");
            PopulatePeopleList(peopleData);

            var drinkTypes = FetchDataFromApi<GetTypeData>("getTypesList");
            CreateDrinkControls(drinkTypes);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            int selectedPersonIndex = GetSelectedUserIndex();
            if (selectedPersonIndex == 0)
            {
                MessageBox.Show("No user selected. Please select a user and try again.");
                return;
            }

            var formData = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("user", selectedPersonIndex.ToString())
            };

            for (int index = 0; index < drinkTrackBars.Count; index++)
            {
                formData.Add(new KeyValuePair<string, string>("type[]", drinkTrackBars[index].Value.ToString()));
            }

            SubmitDrinkData(formData);
        }

        private static string EncodeToBase64(string input)
        {
            var inputBytes = Encoding.GetEncoding(28591).GetBytes(input);
            return Convert.ToBase64String(inputBytes);
        }

        private async void SubmitDrinkData(IEnumerable<KeyValuePair<string, string>> formData)
        {
            var encodedContent = new FormUrlEncodedContent(formData);
            var response = await httpClient.PostAsync(CombineEndpoint("saveDrinks"), encodedContent);
            var responseBody = await response.Content.ReadAsStringAsync();
            MessageBox.Show(responseBody, "Server Response");
        }

        private static string CombineEndpoint(string command) => $"{endpointUrl}?cmd={command}";

        private void printSummaryButton_Click(object sender, EventArgs e)
        {
            monthDataFlowLayout.Controls.Clear();
            var monthData = FetchDataFromApi($"getSummaryOfDrinks&month={monthComboBox.SelectedIndex + 1}");

            foreach (var entry in monthData)
            {
                var summaryLabel = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Point, 238),
                    Text = $"{entry[2]} drank {entry[1]} times {entry[0]}",
                    Location = new Point(5, 0),
                    Size = new Size(120, 50),
                    TabIndex = 5
                };

                monthDataFlowLayout.Controls.Add(summaryLabel);
            }
        }

        private static List<T>? FetchDataFromApi<T>(string endpoint, bool arrayOnly = false)
        {
            var jsonResponse = httpClient.GetStringAsync(CombineEndpoint(endpoint)).Result;
            var parsedData = JsonConvert.DeserializeObject<Dictionary<string, T>>(jsonResponse)?.Values;

            return parsedData?.ToList();
        }

        private static object[][]? FetchDataFromApi(string endpoint)
        {
            var jsonResponse = httpClient.GetStringAsync(CombineEndpoint(endpoint)).Result;
            return JsonConvert.DeserializeObject<object[][]>(jsonResponse);
        }

        private int GetSelectedUserIndex()
        {
            for (int i = 0; i < userRadioButtons.Count; i++)
            {
                if (userRadioButtons[i].Checked)
                {
                    return i + 1;
                }
            }
            return 0;
        }

        private void PopulatePeopleList(List<GetPeopleData> data)
        {
            foreach (var person in data)
            {
                var radioButton = new RadioButton
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 238),
                    Location = new Point(25, 18),
                    Margin = new Padding(20, 10, 0, 0),
                    Name = "personRadioButton",
                    Size = new Size(150, 30),
                    Text = person.Name,
                    TabIndex = 1
                };

                userRadioButtons.Add(radioButton);
                peopleFlowLayout.Controls.Add(radioButton);
            }
        }

        private void CreateDrinkControls(List<GetTypeData> data)
        {
            foreach (var drink in data)
            {
                var drinkLabel = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 238),
                    Size = new Size(115, 45),
                    Location = new Point(5, 0),
                    Text = drink.Typ
                };

                var valueLabel = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point, 238),
                    Size = new Size(50, 45),
                    Location = new Point(470, 40),
                    Text = "0"
                };

                var drinkTrackbar = new TrackBar
                {
                    Location = new Point(3, 60),
                    Size = new Size(450, 50),
                    Name = $"drinkType{drink.ID}",
                    TabIndex = 2
                };

                drinkTrackbar.Scroll += (s, e) => valueLabel.Text = drinkTrackbar.Value.ToString();

                var panel = new Panel
                {
                    Size = new Size(520, 120),
                    Name = "drinkPanel"
                };

                panel.Controls.Add(drinkLabel);
                panel.Controls.Add(valueLabel);
                panel.Controls.Add(drinkTrackbar);

                drinkTrackBars.Add(drinkTrackbar);
                drinksFlowLayout.Controls.Add(panel);
            }
        }
    }
}
