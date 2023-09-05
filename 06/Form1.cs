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

namespace _06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        Je dán textový soubor knihy.txt, kde na každém řádku je
        Název;Autor;Umístění;Žánr;Datum. Každý údaj je oddělen středníkem. Soubor zobrazte
        do ListBoxu. Vytvořte dva nové textové soubory, v 1. souboru budou knihy mladší než
        rok 1950 a ve 2. souboru knihy starší. Do TextBoxu zadejte jméno autora a zobrazte
        informace o první jeho knížce zapsané v původním souboru.
        */

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("knihy.txt", Encoding.Default);
            StreamWriter mladsi = new StreamWriter("mladsi.txt");
            StreamWriter starsi = new StreamWriter("starsi.txt");

            string autor = textBox1.Text;
            bool nalezen = false;

            listBox1.Items.Clear();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                listBox1.Items.Add(line);

                char[] oddelovace = { ';' };
                string[] udaje = line.Split(oddelovace, StringSplitOptions.RemoveEmptyEntries);
                DateTime vydani = DateTime.Parse(udaje[udaje.Length-1]);
                if (vydani.Year < 1950) mladsi.WriteLine(line);
                else starsi.WriteLine(line);


                if (!nalezen && udaje[1] == autor)
                {
                    nalezen = true;
                    MessageBox.Show(line);
                }

            }
            sr.Close();
            mladsi.Close();
            starsi.Close();
        }
    }
}
