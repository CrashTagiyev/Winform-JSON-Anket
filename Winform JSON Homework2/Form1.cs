using System.IO.Pipes;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace Winform_JSON_Homework2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Save_Button_Click(object sender, EventArgs e)
        {
            if (Surname_Textbox.Text == "" || Name_Textbox.Text == "" || Fathername_Texbox.Text == "" || Country_Textbox.Text == "" || City_Textbox.Text == "" || Phonenumber_Textbox.Text == "")
            {
                MessageBox.Show("Fill all slots");
            }
            else
            {

                using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Select a folder to save the JSON file";

                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        string folderPath = folderBrowserDialog.SelectedPath;
                        // Create a sample object to serialize as JSON
                        Person anket = new Person
                            (
                                Surname_Textbox.Text,
                                Name_Textbox.Text,
                                Fathername_Texbox.Text,
                                Country_Textbox.Text,
                                City_Textbox.Text,
                                PhoneNumber_Label_Text.Text,
                                Birthday_Picker.Value

                            );
                        if (Female_Radio_Button.Checked == true)
                        {
                            anket.Gender = "Female";
                        }
                        else anket.Gender = "Male";
                        // Serialize the object to JSON string
                        //var option = new JsonSerializerOptions { WriteIndented = true };
                        string jsonString = JsonConvert.SerializeObject(anket, Formatting.Indented);

                        // Specify the file path
                        string filePath = Path.Combine(folderPath, $"{anket.Name + " " + anket.Surname}.json");

                        // Save the JSON string to the file
                        File.WriteAllText(filePath, jsonString);
                    }
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Birthday_Picker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Load_Button_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "JSON Files|*.json|All Files|*.*"; // Set the file filter
                openFileDialog.Title = "Open a JSON File"; // Set the dialog title

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file name
                    string fileName = openFileDialog.FileName;

                    // Read the JSON data from the file
                    string jsonString = File.ReadAllText(fileName);
                    Person data = JsonConvert.DeserializeObject<Person>(jsonString);
                    // Deserialize the JSON string to an object

                    Surname_Textbox.Text = data.Surname;
                    Name_Textbox.Text = data.Name;
                    Fathername_Texbox.Text = data.Fathername;
                    Country_Textbox.Text = data.Country;
                    City_Textbox.Text = data.City;
                    Phonenumber_Textbox.Text = data.Phonenumber;
                    Birthday_Picker.Value = Convert.ToDateTime(data.BirthDay);
                }
            }
        }

        private void Male_Radio_Button_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}