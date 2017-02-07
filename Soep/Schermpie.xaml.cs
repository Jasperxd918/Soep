using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Soep
{
    public partial class Schermpie : Window
    {
        Functies _Functies = new Functies();
        Random rand = new Random();
        string sUitkomst = "Nul";
        int iIndex = 0;
        int iUitkomst = 0;
        string[] saSommen = File.ReadAllLines("Sommen.txt");
        public Schermpie(string sNaam, string sNiveau)
        {
            InitializeComponent();
            lbGebruikersnaam.Content = sNaam;
            lbNiveau.Content = sNiveau;


        }


        private void Schermpie_Load(object sender, EventArgs e)
        {
           
        }

        private void MaakSommen(string[] saOperator, int iMin, int iMax)
        {
            tbUitkomst.Clear();
            iIndex = rand.Next(0, saOperator.Length);
            lbOperator.Content = saOperator[iIndex];
            int iGetal1 = rand.Next(iMin, iMax);
            lbGetalA.Content = iGetal1.ToString();
            int iGetal2 = rand.Next(iMin, iMax);
            lbGetalB.Content = iGetal2.ToString();
            if (iIndex == 0)
            {
                iUitkomst = iGetal1 + iGetal2;
                sUitkomst = iUitkomst.ToString();
            }
            else if (iIndex == 1)
            {
                iUitkomst = iGetal1 - iGetal2;
                sUitkomst = iUitkomst.ToString();
            }
            else if (iIndex == 2)
            {
                iUitkomst = iGetal1 * iGetal2;
                sUitkomst = iUitkomst.ToString();
            }
            else if (iIndex == 3)
            {
                string sSom = saSommen[rand.Next(0, saSommen.Length)];
                string[] substrings = sSom.Split(' ');
                iGetal1 = Int32.Parse(substrings[0]);
                iGetal2 = Int32.Parse(substrings[2]);
                lbGetalA.Content = iGetal1.ToString();
                lbGetalB.Content = iGetal2.ToString();
                iUitkomst = iGetal1 / iGetal2;
                sUitkomst = iUitkomst.ToString();
            }
        }
        private void btsend_Click(object sender, RoutedEventArgs e)
        {
            //Niveau 1
            if (tbUitkomst.Text == sUitkomst && lbNiveau.Content.ToString() == "Niveau 1")
                {
                
                    tbUitkomst.Clear();
                    int iScore = int.Parse(lbScorePunt.Content.ToString());
                    iScore++;
                    string sScore = iScore.ToString();
                    lbScorePunt.Content = sScore;
                    MaakSommen(new string[] { "+" }, 1, 10);
                }

                else if (tbUitkomst.Text != sUitkomst && lbNiveau.Content.ToString() == "Niveau 1")
                {
                    tbUitkomst.Clear();
                MessageBox.Show("Het juiste antwoord was " + iUitkomst.ToString());
                    MaakSommen(new string[] { "+" }, 1, 10);
                }

                
                //Niveau 2
                else if (tbUitkomst.Text == sUitkomst && lbNiveau.Content.ToString() == "Niveau 2")
                {
                    tbUitkomst.Clear();
                    int iScore = Int32.Parse(lbScorePunt.Content.ToString());
                    iScore++;
                    string sScore = iScore.ToString();
                    lbScorePunt.Content = sScore;
                    MaakSommen(new string[] { "+", "-" }, 1, 10);
                }
                else if (tbUitkomst.Text != sUitkomst && lbNiveau.Content.ToString() == "Niveau 2")
                {

                    tbUitkomst.Clear();
                    MaakSommen(new string[] { "+", "-" }, 1, 10);
                }
                //Niveau 3
                else if (tbUitkomst.Text == sUitkomst && lbNiveau.Content.ToString() == "Niveau 3")
                {
                    tbUitkomst.Clear();
                    int iScore = Int32.Parse(lbScorePunt.Content.ToString());
                    iScore++;
                    string sScore = iScore.ToString();
                    lbScorePunt.Content = sScore;
                    MaakSommen(new string[] { "+", "-" }, 1, 15);
                }
                else if (tbUitkomst.Text != sUitkomst && lbNiveau.Content.ToString() == "Niveau 3")
                {

                    tbUitkomst.Clear();
                    MaakSommen(new string[] { "+", "-" }, 1, 15);
                }
        }

        private void schermpie_Loaded(object sender, RoutedEventArgs e)
        {
            if (lbNiveau.Content.ToString() == "Niveau 1")
            {
                MaakSommen(new string[] { "+" }, 1, 10);
            }

            else if (lbNiveau.Content.ToString() == "Niveau 2")
            {
                MaakSommen(new string[] { "+", "-" }, 1, 10);
            }
            else if (lbNiveau.Content.ToString() == "Niveau 3")
            {
                MaakSommen(new string[] { "+", "-" }, 1, 15);
            }  
        }
    } 
}
