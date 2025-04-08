using System.Data;

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
    }
}