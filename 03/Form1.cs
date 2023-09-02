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

namespace _03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        Na disku je textový soubor, který vyberte pomocí komponenty OpenFileDialog a
        načtěte ho do komponenty ListBox. Vytvořte další textový soubor, který vyberete
        pomocí komponenty SaveFileDialog, soubor bude mít obsah stejný s prvním textovým
        souborem, ale budou vypuštěny všechny nadbytečné mezery.
        */
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] radky = File.ReadAllLines(openFileDialog1.FileName);
                listBox1.Items.Clear();
                foreach (string radek in radky)
                {
                    listBox1.Items.Add(radek);
                }
                
                if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                    foreach (string radek in radky)
                    {
                        int i = 0;
                        string upraveny = radek.Trim();
                        while (upraveny.Contains("  "))
                        {
                            upraveny = upraveny.Replace("  ", " ");
                        }
                        
                        sw.WriteLine(upraveny);
                    }
                    sw.Close();
                }

            }
        }
    }
}
