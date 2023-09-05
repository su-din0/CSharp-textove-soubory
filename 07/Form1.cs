using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        V textovém souboru vybraném pomocí openFileDialogu spočtěte, kolik řádků začíná
        velkým písmenem a končí právě jednou tečkou.
        */
        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int pocet = 0;
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (char.IsUpper(line[0]) && line[line.Length - 1] == '.' && line[line.Length - 2] != '.') pocet++;
                }
                sr.Close();
                if (pocet > 0) MessageBox.Show($"Pocet radku zacinajicich velkym pismenem a koncicich prave jednou teckou je {pocet}");
                else MessageBox.Show("Nic");
            }    
        }
    }
}
