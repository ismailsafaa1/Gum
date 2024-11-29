using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GymUnversity
{
    internal class DB
    {
        internal class function
        {
            protected static SqlConnection getconnection()
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=DESKTOP-GE3H3SI; database=GumManagment; User Id=sa; Password=sa123456; integrated security = True";
                return con;
            }

            public SqlDataReader getForCombo(string query)
            {
                SqlConnection con = getconnection();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd = new SqlCommand(query, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                return sdr;

            }

        }
    }
}
