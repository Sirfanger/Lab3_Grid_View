using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grid_View
{
    public partial class Pracownik : Form
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string wiek { get; set; }
        public string praca { get; set; }
        public Pracownik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            imie = textBox3.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            nazwisko = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            wiek = textBox1.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            praca = comboBox1.SelectedItem.ToString();
        }
    }
}
