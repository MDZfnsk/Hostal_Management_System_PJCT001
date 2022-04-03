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
    public partial class newStudent : Form
    {
        public newStudent()
        {
            InitializeComponent();

           
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            StdEncap stden = new StdEncap();
            stden.setValues(int.Parse(guna2TextBox1.Text),guna2TextBox2.Text,guna2TextBox3.Text,int.Parse(guna2TextBox4.Text),guna2TextBox5.Text);

            //int id = int.Parse(guna2TextBox1.Text);
            //string name = guna2TextBox2.Text;
            //string address = guna2TextBox3.Text;
            //int mobileno = int.Parse(guna2TextBox4.Text);
            //string email = guna2TextBox5.Text;
            string gname = guna2TextBox6.Text;
            int gno = int.Parse(guna2TextBox7.Text);
            string roomno =  guna2TextBox8.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "INSERT INTO Prototype VALUES("+stden.getstudentID()+",'"+stden.getStudentName()+"','"+stden.getstdaddress()+"',"+stden.getStdmobile()+",'"+stden.getstdemail()+"','"+gname+"',"+gno+",'"+roomno+"'); ";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                customMessegeBox cm = new customMessegeBox();
                cm.Show();
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

        private void newStudent_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void guna2TextBox8_Leave(object sender, EventArgs e)
        {
            guna2TextBox8.BorderColor = Color.DimGray;
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            string rm = guna2TextBox8.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "SELECT COUNT(*) FROM Prototype WHERE (Room_Number = '" + rm + "'); ";
            SqlCommand cmd = new SqlCommand(query, con);

            try
            {
                con.Open();
                int Room = (int)cmd.ExecuteScalar();

                if (Room > 0)
                {
                    guna2TextBox8.BorderColor = Color.Red;
                    MessageBox.Show("This Room already booked");
                    guna2TextBox8.Text = "";


                }
                else
                {
                    guna2TextBox8.Enabled = true;
                }
            }
            catch (SqlException SE)
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
