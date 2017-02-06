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
        int iFoutTijd = 5;
        int iTijd = 60;
        string[] saSommen = File.ReadAllLines("Sommen.txt");
        public Schermpie(string sNaam, string sNiveau)
        {
            InitializeComponent();
            lbGebruiker.Content = sNaam;
            lbNiveau.Content = sNiveau;


        }


        private void Schermpie_Load(object sender, EventArgs e)
        {
            if (lbNiveau.Content == "Niveau 1")
            {
                MaakSommen(new string[] { "+" }, 1, 10);
            }
            else if (lbGroep.Text == "Groep 4")
            {
                MaakSommen(new string[] { "+", "-" }, 1, 10);
            }
            else if (lbGroep.Text == "Groep 5")
            {
                MaakSommen(new string[] { "+", "-" }, 1, 15);
            }
            else if (lbGroep.Text == "Groep 6")
            {
                MaakSommen(new string[] { "+", "-", "*", "/" }, 1, 10);
            }
            else if (lbGroep.Text == "Groep 7")
            {
                MaakSommen(new string[] { "+", "-", "*", "/" }, 1, 15);

            }
            else if (lbGroep.Text == "Groep 8")
            {
                MaakSommen(new string[] { "+", "-", "*", "/" }, 5, 25);
            }
        }

        private void MaakSommen(string[] saOperator, int iMin, int iMax)
        {
            tbUitkomst.Clear();
            iIndex = rand.Next(0, saOperator.Length);
            lbOperator.Text = saOperator[iIndex];
            int iGetal1 = rand.Next(iMin, iMax);
            lbGetal1.Text = iGetal1.ToString();
            int iGetal2 = rand.Next(iMin, iMax);
            lbGetal2.Text = iGetal2.ToString();
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
                lbGetal1.Text = iGetal1.ToString();
                lbGetal2.Text = iGetal2.ToString();
                iUitkomst = iGetal1 / iGetal2;
                sUitkomst = iUitkomst.ToString();
            }
        }

        private void btCheck_Click(object sender, EventArgs e)
        {
            //Groep 3
            if (tbUitkomst.Text == sUitkomst && lbGroep.Text == "Groep 3")
            {
                tbUitkomst.Clear();
                int iScore = Int32.Parse(lbScorePunt.Text);
                iScore++;
                string sScore = iScore.ToString();
                lbScorePunt.Text = sScore;
                MaakSommen(new string[] { "+" }, 1, 10);
            }
            else if (tbUitkomst.Text != sUitkomst && lbGroep.Text == "Groep 3")
            {
                tbUitkomst.Clear();
                iTijd -= 2;
                tmFout.Start();
                MaakSommen(new string[] { "+" }, 1, 10);
            }
            //Groep 4
            else if (tbUitkomst.Text == sUitkomst && lbGroep.Text == "Groep 4")
            {
                tbUitkomst.Clear();
                int iScore = Int32.Parse(lbScorePunt.Text);
                iScore++;
                string sScore = iScore.ToString();
                lbScorePunt.Text = sScore;
                MaakSommen(new string[] { "+", "-" }, 1, 10);
            }
            else if (tbUitkomst.Text != sUitkomst && lbGroep.Text == "Groep 4")
            {

                tbUitkomst.Clear();
                iTijd -= 2;
                tmFout.Start();
                MaakSommen(new string[] { "+", "-" }, 1, 10);
            }
            //Groep 5
            else if (tbUitkomst.Text == sUitkomst && lbGroep.Text == "Groep 5")
            {
                tbUitkomst.Clear();
                int iScore = Int32.Parse(lbScorePunt.Text);
                iScore++;
                string sScore = iScore.ToString();
                lbScorePunt.Text = sScore;
                MaakSommen(new string[] { "+", "-" }, 1, 15);
            }
            else if (tbUitkomst.Text != sUitkomst && lbGroep.Text == "Groep 5")
            {

                tbUitkomst.Clear();
                iTijd -= 2;
                tmFout.Start();
                MaakSommen(new string[] { "+", "-" }, 1, 15);
            }
            //Groep 6
            else if (tbUitkomst.Text == sUitkomst && lbGroep.Text == "Groep 6")
            {
                tbUitkomst.Clear();
                int iScore = Int32.Parse(lbScorePunt.Text);
                iScore++;
                string sScore = iScore.ToString();
                lbScorePunt.Text = sScore;
                MaakSommen(new string[] { "+", "-", "*", "/" }, 1, 10);
            }
            else if (tbUitkomst.Text != sUitkomst && lbGroep.Text == "Groep 6")
            {
                tbUitkomst.Clear();
                iTijd -= 2;
                tmFout.Start();
                MaakSommen(new string[] { "+", "-", "*", "/" }, 1, 10);
            }
            //Groep 7
            else if (tbUitkomst.Text == sUitkomst && lbGroep.Text == "Groep 7")
            {
                tbUitkomst.Clear();
                int iScore = Int32.Parse(lbScorePunt.Text);
                iScore++;
                string sScore = iScore.ToString();
                lbScorePunt.Text = sScore;
                MaakSommen(new string[] { "+", "-", "*", "/" }, 1, 15);
            }
            else if (tbUitkomst.Text != sUitkomst && lbGroep.Text == "Groep 7")
            {
                tbUitkomst.Clear();
                iTijd -= 2;
                tmFout.Start();
                MaakSommen(new string[] { "+", "-", "*", "/" }, 1, 15);
            }
            //Groep 8
            else if (tbUitkomst.Text == sUitkomst && lbGroep.Text == "Groep 8")
            {
                tbUitkomst.Clear();
                int iScore = Int32.Parse(lbScorePunt.Text);
                iScore++;
                string sScore = iScore.ToString();
                lbScorePunt.Text = sScore;
                MaakSommen(new string[] { "+", "-", "*", "/" }, 5, 25);
            }
            else if (tbUitkomst.Text != sUitkomst && lbGroep.Text == "Groep 8")
            {
                tbUitkomst.Clear();
                iTijd -= 2;
                tmFout.Start();
                MaakSommen(new string[] { "+", "-", "*", "/" }, 5, 25);
            }
        }

        private void tbUitkomst_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btCheck_Click(this, new EventArgs());
            }
        }

        private void tmFout_Tick(object sender, EventArgs e)
        {
            iFoutTijd--;
            if (iFoutTijd > 0)
            {
                pbFout.Visible = true;
                lbFout.Visible = true;
            }
            else if (iFoutTijd == 0)
            {
                pbFout.Visible = false;
                lbFout.Visible = false;
                tmFout.Stop();
                iFoutTijd = 20;
            }
        }


    }
}
