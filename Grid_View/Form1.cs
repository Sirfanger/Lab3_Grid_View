using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Grid_View
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var pracownik = new Pracownik();
            if (pracownik.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.Rows.Add(pracownik.imie, pracownik.nazwisko, pracownik.wiek, pracownik.praca);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void usun_Click(object sender, EventArgs e)
        {
            int rowind = dataGridView1.CurrentCell.RowIndex;
            dataGridView1.Rows.RemoveAt(rowind);
        }
        private void LoadCSVToDataGridView(string filePath)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Plik CSV nie istnieje.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length == 0)
                {
                    MessageBox.Show("Plik CSV jest pusty.");
                    return;
                }

                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();

                // Nagłówki
                string[] headers = lines[0].Split(',');
                foreach (string header in headers)
                {
                    dataGridView1.Columns.Add(header.Trim(), header.Trim());
                }

                // Wiersze
                for (int i = 1; i < lines.Length; i++)
                {
                    if (string.IsNullOrWhiteSpace(lines[i])) continue;

                    string[] values = lines[i].Split(',');
                    if (values.Length != headers.Length)
                    {
                        MessageBox.Show($"Niezgodność liczby kolumn w linii {i + 1}. Pominięto.");
                        continue;
                    }

                    dataGridView1.Rows.Add(values);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas wczytywania CSV: " + ex.Message);
            }
        }
        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Nagłówki
                var headers = dataGridView.Columns.Cast<DataGridViewColumn>();
                writer.WriteLine(string.Join(",", headers.Select(col => col.HeaderText)));

                // Dane
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        var values = row.Cells.Cast<DataGridViewCell>()
                                              .Select(cell => cell.Value?.ToString()?.Replace(",", " ") ?? "");
                        writer.WriteLine(string.Join(",", values));
                    }
                }
            }
        }
        public void SerializeToJSON(string fileName)
        {
            List<Person> people = new List<Person>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    try
                    {
                        string firstName = row.Cells[0].Value?.ToString();
                        string lastName = row.Cells[1].Value?.ToString();
                        int age = int.Parse(row.Cells[2].Value?.ToString() ?? "0");
                        string stanowisko = row.Cells[3].Value?.ToString();

                        people.Add(new Person(firstName, lastName, age, stanowisko));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Błąd podczas serializacji: " + ex.Message);
                    }
                }
            }

            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(people, options);
            File.WriteAllText(fileName, jsonString);

            MessageBox.Show("Dane zapisane do pliku JSON.");
        }
        public void DeserializeFromJSON(string fileName)
        {
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Plik JSON nie istnieje.");
                return;
            }

            try
            {
                string jsonString = File.ReadAllText(fileName);
                List<Person> people = JsonSerializer.Deserialize<List<Person>>(jsonString);

                dataGridView1.Rows.Clear();

                foreach (Person p in people)
                {
                    dataGridView1.Rows.Add(p.FirstName, p.LastName, p.Wiek, p.Stanowisko);
                }

                MessageBox.Show("Dane wczytane z pliku JSON.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd podczas deserializacji JSON: " + ex.Message);
            }
        }

        private void odczyt_Click(object sender, EventArgs e)
        {
            string dane = textBox1.Text;
            LoadCSVToDataGridView(dane);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void zapis_Click(object sender, EventArgs e)
        {
            ExportToCSV(dataGridView1, textBox1.Text);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SerializeToJSON("test.JSON");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeserializeFromJSON("test.JSON");
        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Wiek { get; set; }
        public string Stanowisko { get; set; }
        public Person() { } // Domyœlny konstruktor wymagany do serializacji
        // Konstruktor
        public Person(string firstName, string lastName, int age, string stanowisko)
        {
            FirstName = firstName;
            LastName = lastName;
            Wiek = age;
            Stanowisko = stanowisko;
        }
    }
}