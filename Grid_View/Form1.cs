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
            // Odczytaj zawartoœæ pliku CSV
            string[] lines = File.ReadAllLines(filePath);
            // Tworzenie tabeli danych
            DataTable dataTable = new DataTable();
            // Dodanie kolumn na podstawie nag³ówka
            string[] headers = lines[0].Split(',');
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }
            // Dodawanie wierszy do tabeli danych
            for (int i = 1; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                dataTable.Rows.Add(values);
            }
            // Przypisanie tabeli danych do DataGridView
            dataGridView1.DataSource = dataTable;
        }
        private void ExportToCSV(DataGridView dataGridView, string filePath)
        {
            // Tworzenie nag³ówka pliku CSV
            string csvContent = "Column1,Column2,Column3" + Environment.NewLine;
            // Dodawanie danych z DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Pomijaj wiersze niemieszcz¹ce siê w DataGridView (np. wiersz zaznaczania)
                if (!row.IsNewRow)
                {
                    // Dodaj kolejne wartoœci w wierszu, oddzielone przecinkami
                    csvContent += string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>()
                    .ToArray(), c => c.Value)) + Environment.NewLine;
                }
            }
            // Zapisanie zawartoœci do pliku CSV
            File.WriteAllText(filePath, csvContent);
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
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Pomijaj wiersze niemieszcz¹ce siê w DataGridView (np. wiersz zaznaczania)
                if (!row.IsNewRow)
                {
                    // Dodaj kolejne wartoœci w wierszu, oddzielone przecinkami
                    csvContent += string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>()
                    .ToArray(), c => c.Value)) + Environment.NewLine;
                }
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (TextWriter writer = new StreamWriter(fileName))
            {
                serializer.Serialize(writer, this);
            }
            Console.WriteLine("Obiekt zosta³ zserializowany do pliku XML.");
        }
        // Metoda do deserializacji z XML
        public static Person DeserializeFromXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Person>));
            using (TextReader reader = new StreamReader(fileName))
            {
                Person person = (Person)serializer.Deserialize(reader);
                Console.WriteLine("Obiekt zosta³ odczytany z pliku XML.");
                return person;
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
        public Person() { } // Domyœlny konstruktor wymagany do serializacji
        // Konstruktor
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
      
        
    }

    
}



