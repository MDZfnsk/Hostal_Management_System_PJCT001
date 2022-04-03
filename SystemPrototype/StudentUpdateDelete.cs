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
    public partial class StudentUpdateDelete : Form
    {
        

        public StudentUpdateDelete()
        {
            InitializeComponent();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            clearAll();

        }

        private void clearAll()
        {
            guna2TextBox1.Text = "";
            guna2TextBox2.Text = "";
            guna2TextBox3.Text = "";
            guna2TextBox4.Text = "";
            guna2TextBox5.Text = "";
            guna2TextBox6.Text = "";
            guna2TextBox7.Text = "";
            guna2TextBox8.Text = "";
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            int std = int.Parse(guna2TextBox1.Text);

            string con1 = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\NSBM\1st_Year\3rd_Semester\C# Programming\Assignments\Final Group Project\VIVA\Project\SystemPrototypeDb.mdf;Integrated Security=True;Connect Timeout=30";
            string query = "SELECT *FROM Prototype WHERE Student_Id = "+std+"";

            try
            {
                SqlDataAdapter da = new SqlDataAdapter(query, con1);
                DataSet ds = new DataSet();
                da.Fill(ds, "Prototype");

                if(ds.Tables["Prototype"].Rows.Count!=0)
                {
                    guna2TextBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                    guna2TextBox3.Text = ds.Tables[0].Rows[0][2].ToString();
                    guna2TextBox4.Text = ds.Tables[0].Rows[0][3].ToString();
                    guna2TextBox5.Text = ds.Tables[0].Rows[0][4].ToString();
                    guna2TextBox6.Text = ds.Tables[0].Rows[0][5].ToString();
                    guna2TextBox7.Text = ds.Tables[0].Rows[0][6].ToString();
                    guna2TextBox8.Text = ds.Tables[0].Rows[0][7].ToString();
                
                }
 
                else
                {
                    clearAll();
                    MessageBox.Show("No Record With This Student Id Exists", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }

            catch(SqlException SE)
            {
                MessageBox.Show(SE + ToString());
            }

            

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(guna2TextBox1.Text);
            string name = guna2TextBox2.Text;
            string address = guna2TextBox3.Text;
            int mobileno = int.Parse(guna2TextBox4.Text);
            string email = guna2TextBox5.Text;
            string gname = guna2TextBox6.Text;
            int gno = int.Parse(guna2TextBox7.Text);
            string roomno = guna2TextBox8.Text;

            string query = "UPDATE Prototype SET Student_Name = '" + name + "',Address = '" + address + "',Mobile_Number = " + mobileno + ",Email = '" + email + "',Guardian_Name = '" + gname + "',Guardian_Tele = " + gno + ",Room_Number = '" + roomno + "' WHERE Student_Id = "+id+"; ";

            StudentConnection st = new StudentConnection();
            string feedback = st.DataConnection(query);

            MessageBox.Show(feedback);

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            int std = int.Parse(guna2TextBox1.Text);

            string deletequery = "DELETE FROM Prototype WHERE Student_Id = "+std+" ";

            StudentConnection st = new StudentConnection();
            string feedback = st.DataConnection(deletequery);

            MessageBox.Show(feedback);
        }
    }
}
