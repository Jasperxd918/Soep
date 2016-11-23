using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Soep
{
    class Soep_classes
    {
        MySqlConnection _mssCon = new MySqlConnection("Server=localhost;Database=soep;Uid=root;");

        public DataTable Inloggen(string sNaam, string sPassword)
        {
            DataTable dtResult = new DataTable();

            try
            {
                _mssCon.Open();
                if (_mssCon.State == ConnectionState.Open)
                {
                    MySqlCommand mssCommand = new MySqlCommand("SELECT * FROM SoepDB WHERE Name='@naam' AND Password='@Password';", _mssCon);
                    dtResult.Load(mssCommand.ExecuteReader());
                    mssCommand.Parameters.AddWithValue("@Naam",sNaam);
                    mssCommand.Parameters.AddWithValue("@Password", sPassword);
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


            return dtResult;
        }
    }
}

