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

namespace _09
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        Pomocí OpenFileDialogu vyberte textový soubor, který má v každém řádku celá čísla
        oddělená mezerou nebo tabulátorem. Vybraný soubor zobrazte. Do komponenty
        ListBox vypište součet čísel z každého řádku souboru. Celkový součet všech čísel
        zapište na konec souboru. Opravený soubor zobrazte. 
        */
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter("temp.txt");
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                int soucet = 0;

                listBox1.Items.Clear();
                listBox2.Items.Clear();
                while (!sr.EndOfStream)
                {
                    string radek = sr.ReadLine();
                    char[] oddelovace = { ' ' };
                    string[] cisla = radek.Split(oddelovace, StringSplitOptions.RemoveEmptyEntries);
                    int soucetRadku = 0;
                    foreach (string item in cisla)
                    {
                        int cislo = int.Parse(item);
                        soucetRadku += cislo;
                        soucet += soucetRadku;
                    }

                    listBox1.Items.Add(radek);
                    listBox2.Items.Add($"{radek} {soucetRadku}");
                    sw.WriteLine(radek);
                }
                sw.WriteLine(soucet);

                sw.Close();
                sr.Close();

                File.Delete(openFileDialog1.FileName);
                File.Move("temp.txt", openFileDialog1.FileName);

                sr = new StreamReader(openFileDialog1.FileName);

                listBox3.Items.Clear();
                while (!sr.EndOfStream)
                {
                    string radek = sr.ReadLine();
                    listBox3.Items.Add(radek);
                }

                sr.Close();



            }
        }
    }
}
