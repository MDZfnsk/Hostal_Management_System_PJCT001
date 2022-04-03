using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SystemPrototype
{
    public partial class LOGINDETAILS : Form
    {
        public LOGINDETAILS()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string uname = textBox1.Text;
            string pwd = textBox2.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "INSERT INTO Login VALUES('"+uname+"','"+Utilis.Security.HashSHA1(pwd)+"');";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("INSERTED");
            }
            catch(SqlException SE)
            {
                MessageBox.Show(SE + ToString());
            }
            finally
            {
                con.Close();
            }
        }
    }
}
