using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Soep
{
    class Functies
    {
        public DataRow Inloggen(int iID)
        {
            DataTable dtResult = new DataTable();

            try
            {
                _mssCon.Open();
                if (_mssCon.State == ConnectionState.Open)
                {
                    MySqlCommand mssCommand = new MySqlCommand("SELECT * FROM jasper WHERE ID=@ID;", _mssCon);
                    mssCommand.Parameters.AddWithValue("@ID", iID);
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


            return dtResult.Rows[0];
        }
    }
}
