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

        public DataRow Inloggen(string sGebruikersnaam, string sPassword)
        {
            DataTable dtResult = new DataTable();

            try
            {
                _mssCon.Open();
                if (_mssCon.State == ConnectionState.Open)
                {
                    MySqlCommand mssCommand = new MySqlCommand("SELECT gebruikersnaam, wachtwoord FROM gebruikers WHERE gebruikersnaam = @Gebruikersnaam", _mssCon);
                    mssCommand.Parameters.AddWithValue("@Gebruikersnaam", sGebruikersnaam);
                    mssCommand.Parameters.AddWithValue("@Wachtwoord", sPassword);
                    dtResult.Load(mssCommand.ExecuteReader());
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

            var x = dtResult.Rows[0];
            var username = x["gebruikersnaam"].ToString();
            var password = x["wachtwoord"].ToString();

            if (password == sPassword && username == sGebruikersnaam)
            {
                
            }

            return dtResult.Rows[0];

        }
    }
}
