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

namespace _04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /*
        Je dán soubor matematika.txt, který na každém řádku obsahuje matematický příklad,
        Data v souboru matematika.txt jsou např. ve tvaru:
        1 + 2 =
        2 * 3 =
        10 / 5 =
        14 – 5 =
        5 + 12 =
        Operandy a operátory jsou odděleny jednou mezerou. Soubor zobrazte. Program zapíše
        výsledky matematických operací na konec každého řádku souboru. Opravený soubor
        zobrazte.
        Data v opraveném souboru budou ve tvaru:
        1 + 2 = 3
        2 * 3 = 6
        10 / 5 = 2
        14 – 5 = 9
        5 + 12 = 17
        */

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("matematika.txt");
            StreamWriter sw = new StreamWriter("temp.txt");

            while (!sr.EndOfStream)
            {
                string radek = sr.ReadLine();
                string[] pole = radek.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                int a = int.Parse(pole[0]);
                int b = int.Parse(pole[2]);
                char op = char.Parse(pole[1]);

                double vysledek = 0;
                switch (op)
                {
                    case '+':
                        vysledek = a + b;
                        break;
                    case '-':
                        vysledek = a - b;
                        break;
                    case '*':
                        vysledek = a * b;
                        break;
                    case '/':
                        vysledek = a / b;
                        break;
                    default:
                        break;
                }
                sw.WriteLine(radek + " " + vysledek);
            }
            sr.Close();
            sw.Close();
            File.Delete("matematika.txt");
            File.Move("temp.txt", "matematika.txt");
        }
    }
}
