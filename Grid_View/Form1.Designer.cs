﻿namespace Grid_View
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
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
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
            odczyt.Click += odczyt_Click;
            // 
            // zapis
            // 
            zapis.Location = new Point(111, 285);
            zapis.Name = "zapis";
            zapis.Size = new Size(112, 52);
            zapis.TabIndex = 3;
            zapis.Text = "Zapis do .csv";
            zapis.UseVisualStyleBackColor = true;
            zapis.Click += zapis_Click;
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
            // textBox1
            // 
            textBox1.Location = new Point(462, 301);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(128, 23);
            textBox1.TabIndex = 5;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.Location = new Point(111, 343);
            button1.Name = "button1";
            button1.Size = new Size(112, 55);
            button1.TabIndex = 6;
            button1.Text = "Zapis do XML";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Location = new Point(289, 343);
            button2.Name = "button2";
            button2.Size = new Size(111, 55);
            button2.TabIndex = 7;
            button2.Text = "odczyt XML";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(588, 230);
            button3.Name = "button3";
            button3.Size = new Size(107, 65);
            button3.TabIndex = 8;
            button3.Text = "Test";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);
            Controls.Add(zapis);
            Controls.Add(odczyt);
            Controls.Add(usun);
            Controls.Add(dodaj);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}