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

namespace _02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        V textovém souboru Text.txt vyhledejte znaky ‘?‘ a vypište kolikátý je to znak.
        Uveďte, zda jste ve svém algoritmu počítali i se znaky konce řádků.
        */
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string text = File.ReadAllText(openFileDialog1.FileName);
                int poziceZnaku = -1;
                bool znakNalezen = false;
                for (int i = 0; i < text.Length && !znakNalezen; i++)
                {
                    if (text[i] == '?')
                    {
                        znakNalezen = true;
                        poziceZnaku = i + 1;
                    }
                }

                if (znakNalezen) MessageBox.Show("Znak ? se v souboru nachází na pozici " + poziceZnaku);
                else MessageBox.Show("Znak ? se v souboru nenachází");
            }
        }
    }
}
