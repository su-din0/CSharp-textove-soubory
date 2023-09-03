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

namespace _10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        V textovém souboru vybraném pomocí openFileDialogu spočtěte, kolik obsahuje slov.
        Slova jsou oddělena libovolným počtem mezer. Výsledek zapište na konec souboru a
        opravený soubor zobrazte.
        */

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                StreamWriter sw = new StreamWriter("temp.txt");

                int pocetSlov = 0;
                while (!sr.EndOfStream)
                {
                    char[] oddelovace = { ' ' };
                    string radek = sr.ReadLine();
                    string[] slova = radek.Split(oddelovace, StringSplitOptions.RemoveEmptyEntries);
                    pocetSlov += slova.Length;
                    sw.WriteLine(radek);
                }
                sw.WriteLine($"Počet slov: {pocetSlov}");


                sr.Close();
                sw.Close();

                File.Delete(openFileDialog1.FileName);
                File.Move("temp.txt", openFileDialog1.FileName);

            }

        }
    }
}
