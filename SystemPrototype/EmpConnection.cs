using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SystemPrototype
{
    class EmpConnection
    {
        public int ExecuteQRY(string QRY)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand(QRY, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch (SqlException ex)
            {
                string val = ex.ToString();
                return 0;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
