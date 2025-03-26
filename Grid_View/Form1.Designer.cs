namespace Grid_View
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dodaj = new Button();
            usun = new Button();
            odczyt = new Button();
            zapis = new Button();
            dataGridView1 = new DataGridView();
            Imie = new DataGridViewTextBoxColumn();
            Nazwisko = new DataGridViewTextBoxColumn();
            Wiek = new DataGridViewTextBoxColumn();
            Stanowisko = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dodaj
            // 
            dodaj.Location = new Point(588, 67);
            dodaj.Name = "dodaj";
            dodaj.Size = new Size(75, 45);
            dodaj.TabIndex = 0;
            dodaj.Text = "Dodaj";
            dodaj.UseVisualStyleBackColor = true;
            dodaj.Click += button1_Click;
            // 
            // usun
            // 
            usun.Location = new Point(588, 130);
            usun.Name = "usun";
            usun.Size = new Size(75, 47);
            usun.TabIndex = 1;
            usun.Text = "Usun";
            usun.UseVisualStyleBackColor = true;
            usun.Click += usun_Click;
            // 
            // odczyt
            // 
            odczyt.Location = new Point(289, 285);
            odczyt.Name = "odczyt";
            odczyt.Size = new Size(115, 52);
            odczyt.TabIndex = 2;
            odczyt.Text = "odczyt z .csv";
            odczyt.UseVisualStyleBackColor = true;
            // 
            // zapis
            // 
            zapis.Location = new Point(111, 285);
            zapis.Name = "zapis";
            zapis.Size = new Size(112, 52);
            zapis.TabIndex = 3;
            zapis.Text = "Zapis do .csv";
            zapis.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Imie, Nazwisko, Wiek, Stanowisko });
            dataGridView1.Location = new Point(34, 39);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(446, 176);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Imie
            // 
            Imie.HeaderText = "Imie";
            Imie.Name = "Imie";
            // 
            // Nazwisko
            // 
            Nazwisko.HeaderText = "Nazwisko";
            Nazwisko.Name = "Nazwisko";
            // 
            // Wiek
            // 
            Wiek.HeaderText = "Wiek";
            Wiek.Name = "Wiek";
            // 
            // Stanowisko
            // 
            Stanowisko.HeaderText = "Stanowisko";
            Stanowisko.Name = "Stanowisko";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(zapis);
            Controls.Add(odczyt);
            Controls.Add(usun);
            Controls.Add(dodaj);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button dodaj;
        private Button usun;
        private Button odczyt;
        private Button zapis;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Imie;
        private DataGridViewTextBoxColumn Nazwisko;
        private DataGridViewTextBoxColumn Wiek;
        private DataGridViewTextBoxColumn Stanowisko;
    }
}