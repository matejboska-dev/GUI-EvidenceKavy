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

namespace http_winform
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new();
        private const string url = "http://ajax1.lmsoft.cz/procedure.php";

        private readonly List<RadioButton> radioButtons = [];
        private readonly List<TrackBar> trackBars = [];

        public Form1()
        {
            InitializeComponent();
            monthComboBox.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        const string username = "coffeee";
        const string password = "password";

        static List<T>? GetFromJson<T>(string endpoint, bool onlyArray = false)
        {
            var json = client.GetStringAsync(GetPath(endpoint)).Result;

            var result = JsonConvert.DeserializeObject<Dictionary<string, T>>(json)?.Values;

            return result?.ToList();
        }

        static object[][]? GetFromJson(string endpoint)
        {
            var json = client.GetStringAsync(GetPath(endpoint)).Result;
            return JsonConvert.DeserializeObject<object[][]>(json);
        }

        public static string BtoA(string toEncode)
        {
            byte[] bytes = Encoding.GetEncoding(28591).GetBytes(toEncode);
            string toReturn = Convert.ToBase64String(bytes);
            return toReturn;
        }

        private void print_Click(object sender, EventArgs e)
        {
            monthDataFlowLayout.Controls.Clear();
            var data = GetFromJson($"getSummaryOfDrinks&month={monthComboBox.SelectedIndex + 1}");

            foreach (var item in data)
            {
                var label = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 14f, FontStyle.Regular, GraphicsUnit.Point, 238),
                    Size = new Size(105, 45),
                    Location = new Point(3, 0),
                    TabIndex = 4,
                    Text = item[2].ToString() + " vypil " + item[1].ToString() + "x " + item[0]
                };

                monthDataFlowLayout.Controls.Add(label);
            }

        }

        private void GeneratePeople(List<RecievePeopleData> data)
        {
            foreach (var item in data)
            {
                var radioButton = new RadioButton
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238),
                    Location = new Point(30, 20),
                    Margin = new Padding(30, 20, 0, 0),
                    Name = "radioButton1",
                    Size = new Size(171, 36),
                    TabIndex = 0,
                    TabStop = true,
                    Text = item.Name,
                    UseVisualStyleBackColor = true
                };
                radioButtons.Add(radioButton);
                peopleFlowLayout.Controls.Add(radioButton);
            }
        }
        private void GenerateDrinks(List<RecieveType> data)
        {
            foreach (var item in data)
            {
                var typeLabel = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238),
                    Size = new Size(105, 45),
                    Location = new Point(3, 0),
                    TabIndex = 4,
                    Text = item.Typ
                };

                var valueLabel = new Label
                {
                    AutoSize = true,
                    Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 238),
                    Size = new Size(37, 45),
                    Location = new Point(450, 43),
                    TabIndex = 4,
                    Text = "0"
                };

                var trackbar = new TrackBar
                {
                    Location = new Point(3, 59),
                    Name = $"type{item.ID}",
                    Size = new Size(429, 45),
                    TabIndex = 3
                };
                trackbar.Scroll += (o, e) =>
                {
                    valueLabel.Text = trackbar.Value.ToString();
                };

                var panel = new Panel();
                panel.Controls.Add(typeLabel);
                panel.Controls.Add(valueLabel);
                panel.Controls.Add(trackbar);
                panel.Name = "panel1";
                panel.Size = new Size(500, 107);

                trackBars.Add(trackbar);
                drinksFlowLayout.Controls.Add(panel);
                drinksFlowLayout.PerformLayout();
                panel.PerformLayout();

            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Authorization", $"Basic {BtoA($"{username}:{password}")}");

            var people = GetFromJson<RecievePeopleData>("getPeopleList");
            GeneratePeople(people);

            var types = GetFromJson<RecieveType>("getTypesList");
            GenerateDrinks(types);
        }

        private static string GetPath(string endpoint) => url + "?cmd=" + endpoint;

        private async void send_Click(object sender, EventArgs e)
        {

            int selectedUser = 0;
            for (int i = 0; i < radioButtons.Count; i++)
            {
                if (radioButtons[i].Checked)
                {
                    selectedUser = i + 1;
                    break;
                }
            }

            if (selectedUser == 0)
            {
                MessageBox.Show("No user selected", "");
                return;
            }


         
            var kvpairs = new KeyValuePair<string, string>[trackBars.Count+1];
            kvpairs[0] = new("user", selectedUser.ToString());
         
            for (int i = 0; i< trackBars.Count; i++)
            {
                kvpairs[i+1]= new ("type[]", trackBars[i].Value.ToString());//   += ",type[]:" + "\"" + item.Value + "\"";
            }
            //content += "}";

          //  var data = new StringContent(content, Encoding.UTF8, "application/json");

          
            
            var encodedContent = new FormUrlEncodedContent(kvpairs);

        
            var response = await client.PostAsync(GetPath("saveDrinks"), encodedContent);
            var responseString = await response.Content.ReadAsStringAsync();
            MessageBox.Show(responseString.ToString(), "");
        }
    }
}
