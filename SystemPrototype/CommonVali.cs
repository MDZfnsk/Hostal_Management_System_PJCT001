using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SystemPrototype
{
    class CommonVali
    {
        public bool ID_Validation(int ID)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT * FROM Employee WHERE Emp_ID = " + ID + "";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();


                if (sdr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (SqlException excp)
            {
                string error = excp.ToString();
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool DigitsOnly(string s)
        {
            int len = s.Length;
            for (int i = 0; i < len; ++i)
            {
                char c = s[i];
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
    }
}
