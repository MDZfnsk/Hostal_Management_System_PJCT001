using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SystemPrototype
{
    class StudentConnection
    {
        public string DataConnection(string x)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand(x, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return "Operation Successfully Perform";
            }

            catch (SqlException SE)
            {
                return "Operation is Not Successfull" + SE;
            }
            finally
            {
                con.Close();
            }

        }
    }
}
