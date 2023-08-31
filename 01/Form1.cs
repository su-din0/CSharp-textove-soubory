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

namespace _01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        Vytvořte textový soubor, který bude obsahovat N řádků. V každém řádku bude tolik
        hvězdiček, kolikátý je to řádek. Název a umístění vytvořeného souboru vyberte pomocí
        saveFileDialogu
        */

        private void button1_Click(object sender, EventArgs e)
        {

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int n = int.Parse(textBox1.Text);
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < i + 1; j++)
                    {
                        sw.Write("*");
                    }
                    sw.WriteLine();
                }
                sw.Close();
            }
        }
    }
}
