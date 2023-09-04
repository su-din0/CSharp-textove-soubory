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

namespace _08
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        Na disku je textový soubor knihy.txt, pomocí OpenDialogu ho načtěte do ListBoxu.
        Opravte tento soubor tak, že všechna velká písmena budou nahrazena malými nebo malá
        písmena nahrazena velkými. Podle volby v ComboBoxu
        */
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                listBox1.Items.Clear();
                while (!sr.EndOfStream)
                {
                    string radek = sr.ReadLine();
                    listBox1.Items.Add(radek);
                }
                sr = new StreamReader(openFileDialog1.FileName);
                StreamWriter sw = new StreamWriter("temp.txt");

                if (comboBox1.SelectedIndex == 0)
                {
                    //Velka na mala
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        line = line.ToLower();
                        sw.WriteLine(line);
                    }

                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    //Mala na velka
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        line = line.ToUpper();
                        sw.WriteLine(line);
                    }
                }

                sw.Close();
                sr.Close();

                File.Delete(openFileDialog1.FileName);
                File.Move("temp.txt", openFileDialog1.FileName);

            }
        }
    }
}
