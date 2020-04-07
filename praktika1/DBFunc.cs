using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace praktika1
{
    class DBFunc
    {
        internal static DataTable sendRequest(string query)
        {
            string connectionString = "server=localhost;database=prakt;uid=root;pwd=;";
            MySqlConnection cnn;
            cnn = new MySqlConnection(connectionString);
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                cnn.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                da.Dispose();
                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection!");
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
