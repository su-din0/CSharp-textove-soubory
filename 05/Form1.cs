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

namespace _05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        Na disku je textový soubor cislo.txt, v každém řádku je řetězec cifer představující celé číslo.
        Sečtěte čísla v jednotlivých řádcích, spočtěte počet sudých čísel a počet lichých čísel.
        Tyto tři výsledky zapište na konec souboru, každé číslo na samostatný řádek (žádné
        doplňující texty). Původní i opravený textový soubor zobrazte v komponentách ListBox
        */

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("cislo.txt");
            StreamWriter sw = new StreamWriter("temp.txt");

            listBox1.Items.Clear();
            int pocetSud = 0, pocetLich = 0, soucet = 0;
            while (!sr.EndOfStream)
            {
                string radek = sr.ReadLine();
                int cislo = int.Parse(radek);

                soucet += cislo;
                if (cislo % 2 == 0) pocetSud++;
                else pocetLich++;

                sw.WriteLine(radek);
                listBox1.Items.Add(radek);
            }
            sw.WriteLine(soucet);
            sw.WriteLine(pocetSud);
            sw.WriteLine(pocetLich);


            sr.Close();
            sw.Close();

            File.Delete("cislo.txt");
            File.Move("temp.txt", "cislo.txt");

            sr = new StreamReader("cislo.txt");

            listBox2.Items.Clear();
            while (!sr.EndOfStream)
            {
                string radek = sr.ReadLine();
                listBox2.Items.Add(radek);
            }


        }
    }
}
