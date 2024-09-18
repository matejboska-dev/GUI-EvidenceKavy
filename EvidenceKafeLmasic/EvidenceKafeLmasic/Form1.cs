using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace EvidenceKafeLmasic
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        private const string baseUrl = "http://ajax1.lmsoft.cz/procedure.php";
        private const string username = "coffe";
        private const string password = "kafe";

        public Form1()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            this.Text = "Evidování kávy";
            this.Size = new System.Drawing.Size(500, 600);

            var lblTitle = new Label { Text = "Evidování kávy", Font = new System.Drawing.Font("Arial", 16), Dock = DockStyle.Top, TextAlign = System.Drawing.ContentAlignment.MiddleCenter };
            var panel = new Panel { Dock = DockStyle.Fill };

            var peopleListBox = new Panel { Dock = DockStyle.Top, Height = 100 }; // Changed to Panel
            var drinkListPanel = new Panel { Dock = DockStyle.Top, Height = 200 };
            var monthSelector = new NumericUpDown { Minimum = 1, Maximum = 12, Dock = DockStyle.Top };
            var submitButton = new Button { Text = "Odeslat", Dock = DockStyle.Top };
            var toggleResultsButton = new Button { Text = "Zobrazit výsledky", Dock = DockStyle.Top };
            var resultsPanel = new Panel { Dock = DockStyle.Fill, Visible = false };

            panel.Controls.Add(resultsPanel);
            panel.Controls.Add(toggleResultsButton);
            panel.Controls.Add(submitButton);
            panel.Controls.Add(monthSelector);
            panel.Controls.Add(drinkListPanel);
            panel.Controls.Add(peopleListBox);
            panel.Controls.Add(lblTitle);

            this.Controls.Add(panel);

            submitButton.Click += async (sender, e) => await SubmitForm();
            toggleResultsButton.Click += async (sender, e) => await ToggleResults(resultsPanel);

            LoadPeopleList(peopleListBox);
            LoadDrinkTypes(drinkListPanel);
        }

        private async Task LoadPeopleList(Panel panel)
        {
            var people = await GetFromJsonAsync<Person>("getPeopleList");
            panel.Controls.Clear();
            foreach (var person in people)
            {
                var radioButton = new RadioButton { Text = person.Name, Tag = person.ID, Dock = DockStyle.Top };
                panel.Controls.Add(radioButton);
            }
        }

        private async Task LoadDrinkTypes(Panel panel)
        {
            var drinks = await GetFromJsonAsync<Drink>("getTypesList");
            panel.Controls.Clear();
            foreach (var drink in drinks)
            {
                var label = new Label { Text = drink.Type, AutoSize = true };
                var trackBar = new TrackBar { Minimum = 0, Maximum = 10, Dock = DockStyle.Top };
                var valueLabel = new Label { Text = "0", Dock = DockStyle.Top };
                trackBar.ValueChanged += (sender, e) => valueLabel.Text = trackBar.Value.ToString();

                var drinkPanel = new Panel { Dock = DockStyle.Top };
                drinkPanel.Controls.Add(valueLabel);
                drinkPanel.Controls.Add(trackBar);
                drinkPanel.Controls.Add(label);

                panel.Controls.Add(drinkPanel);
            }
        }

        private async Task SubmitForm()
        {
            // Implement form submission logic here
        }

        private async Task ToggleResults(Panel resultsPanel)
        {
            // Implement results toggling logic here
        }

        private async Task<List<T>> GetFromJsonAsync<T>(string endpoint)
        {
            var response = await client.GetStringAsync(baseUrl + "?cmd=" + endpoint);
            return JsonConvert.DeserializeObject<List<T>>(response);
        }

        private async Task SendRequest(string endpoint, HttpContent content, HttpMethod method)
        {
            var request = new HttpRequestMessage(method, baseUrl + "?cmd=" + endpoint)
            {
                Content = content
            };

            var byteArray = System.Text.Encoding.ASCII.GetBytes($"{username}:{password}");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            var response = await client.SendAsync(request);
            var responseString = await response.Content.ReadAsStringAsync();

            MessageBox.Show(responseString);
        }

        public class Person
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        public class Drink
        {
            public int ID { get; set; }
            public string Type { get; set; }
        }

        public class Summary
        {
            public string Drink { get; set; }
            public int Count { get; set; }
            public string Type { get; set; }
        }
    }
}
