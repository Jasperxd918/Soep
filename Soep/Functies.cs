using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows;

namespace Soep
{
    class Functies
    {
        MySqlConnection _mssCon = new MySqlConnection("Server=localhost;Database=Soep;Uid=root;Pwd=;");

        public bool Inloggen(string sGebruikersnaam, string sWachtwoord)
        {
            bool bResult = false;

            try
            {
                _mssCon.Open();
                if (_mssCon.State == ConnectionState.Open)
                {

                    MySqlCommand mssCommand = new MySqlCommand("SELECT count(*) FROM `gebruikers` WHERE Gebruikersnaam=@Gebruiker AND Wachtwoord=@ww;", _mssCon);
                    mssCommand.Parameters.AddWithValue("@Gebruiker", sGebruikersnaam);
                    mssCommand.Parameters.AddWithValue("@ww", sWachtwoord);

                    if (mssCommand.ExecuteScalar().ToString() == "1")
                    {
                        bResult = true;
                    }
                    else
                    {
                        MessageBox.Show("wachtwoord is incorrect");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Er ging iets fout");
            }
            finally
            {
                _mssCon.Close();
            }


            return bResult;
        }
    }
}
