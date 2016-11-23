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
        MySqlConnection _mssCon = new MySqlConnection("Server = localhost; Database=SoepDB;Uid=root;Pwd=;");

        public DataTable Inloggen()
        {
            DataTable dtResult = new DataTable();

            try
            {
                _mssCon.Open();
                if (_mssCon.State == ConnectionState.Open)
                {
                    MySqlCommand mssCommand = new MySqlCommand("SELECT * FROM jasper;", _mssCon);
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


            return dtResult;
        }
    }
}

