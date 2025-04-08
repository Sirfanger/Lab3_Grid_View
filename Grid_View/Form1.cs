using System.Data;
using System;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;


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
                MessageBox.Show("Plik CSV nie istnieje.", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                // Nag³ówki
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
                        MessageBox.Show($"Niezgodnoœæ liczby kolumn w linii {i + 1}. Pominiêto.");
                        continue;
                    }

                    dataGridView1.Rows.Add(values);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("B³¹d podczas wczytywania CSV: " + ex.Message);
            }
        }
        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Nag³ówki
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
            SerializeToXML("person.xml");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        // Metoda do serializacji do XML
        public void SerializeToXML(string fileName)
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
                        MessageBox.Show("B³¹d podczas serializacji: " + ex.Message);
                    }
                }
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, people);
            }

            MessageBox.Show("Dane zapisane do XML.");
        }
        public void DeserializeFromXML(string fileName)
        {
            if (!File.Exists(fileName))
            {
                MessageBox.Show("Plik XML nie istnieje.");
                return;
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (TextReader reader = new StreamReader(fileName))
            {
                try
                {
                    List<Person> people = (List<Person>)serializer.Deserialize(reader);
                    dataGridView1.Rows.Clear();

                    foreach (Person p in people)
                    {
                        dataGridView1.Rows.Add(p.FirstName, p.LastName, p.Age, p.Stanowisko);
                    }

                    MessageBox.Show("Dane wczytane z XML.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("B³¹d deserializacji: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeserializeFromXML("person.xml");
        }
    }
    [Serializable]
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string Stanowisko { get; set; }  
        public Person() { } // Domyœlny konstruktor wymagany do serializacji
        // Konstruktor
        public Person(string firstName, string lastName, int age, string stanowisko)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Stanowisko = stanowisko;
        }


    }


}



